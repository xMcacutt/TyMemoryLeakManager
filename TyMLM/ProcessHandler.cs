using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace TyMemoryLeakManager
{
    internal class ProcessHandler
    {
        public static IntPtr HProcess;
        public static Process TyProcess;
        public static bool HasTyProcess = false;
        private static int TyProcessBaseAddress;

        private static bool HasFolderPath = false;

        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll")]
        internal static unsafe extern bool ReadProcessMemory(
            int hProcess,
            void* lpBaseAddress,
            void* lpBuffer,
            uint nSize,
            uint* lpNumberOfBytesRead);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool WriteProcessMemory(IntPtr hProcess, int lpBaseAddress, byte[] lpBuffer, int dwSize, out IntPtr lpNumberOfBytesWritten);

        public static void Initialize()
        {
            HasFolderPath = SettingsHandler.Settings.TyFolderPath != "";
        }

        public static int GetProcessMemory()
        {
            if (!HasTyProcess) { return 0; }

            try
            {
                TyProcess.Refresh();
                return (int)(TyProcess.WorkingSet64 / 1048576);
            }
            catch (Exception)
            {
                HasTyProcess = false;
                RestartTy();
                return 0;
            }
        }

        public static bool RestartTy()
        {
            TyMLM.AllowSound = true;
            string[] argsFile = System.IO.File.ReadAllLines("./Arguments.txt");
            string arguments = "";
            foreach(string line in argsFile)
            {
                if (line.StartsWith("-"))
                {
                    arguments += Regex.Replace(line, @"\s+", "");
                    arguments += " ";
                }
            }
            TyProcess = new Process
            {
                StartInfo = new ProcessStartInfo(SettingsHandler.Settings.TyFolderPath)
                {
                    UseShellExecute = false,
                    RedirectStandardError = true,
                    RedirectStandardOutput = true,
                    Arguments = arguments,
                    WorkingDirectory = System.IO.Path.GetDirectoryName(SettingsHandler.Settings.TyFolderPath)
                }
            };
            TyProcess.Start();
            return SetupProcess();
        }

        private static bool SetupProcess()
        {
            TyProcess.EnableRaisingEvents = true;
            TyProcess.Exited += (o, e) =>
            {
                var exitedProcess = o as Process;
                TyProcess.Close();
                TyProcess.Dispose();
                HasTyProcess = false;
            };

            HProcess = OpenProcess(0x1F0FFF, false, TyProcess.Id);
            while (TyProcess.MainModule == null)
            {
            }
            TyProcessBaseAddress = (int)TyProcess.MainModule.BaseAddress;
            if (!HasFolderPath)
            {
                SettingsHandler.Settings.TyFolderPath = TyProcess.MainModule.FileName;
                SettingsHandler.Save();
                HasFolderPath = true;
            }
            HasTyProcess = true;

            return true;
        }

        //Returns true if currently has a handle to the Ty process
        //Attempts to find the Ty process if not, returns true if successfully found
        //Returns false if Ty is closed
        public static bool FindTyProcess()
        {
            if (HasTyProcess)
                return true;

            Process[] processes = Process.GetProcessesByName("TY");

            if (processes.Length == 0)
            {
                if (HasFolderPath)
                    return RestartTy();
                return false;
            }
            else if (processes.Length > 1)
            {
                
            }
            TyProcess = processes.First();
            SetupProcess();
            return true;
        }

        public static unsafe bool TryRead<T>(int address, out T result, bool addBase)
        where T : unmanaged
        {
            try
            {
                fixed (T* pResult = &result)
                {
                    //string s = GetCallStackAsString();
                    if (addBase) address = TyProcessBaseAddress + address;
                    uint nSize = (uint)sizeof(T), nRead;
                    //BasicIoC.LoggerInstance.Write(address.ToString() + " " + s);
                    return ReadProcessMemory((int)HProcess, (void*)address, pResult, nSize, &nRead)
                        && nRead == nSize;
                }
            }
            catch (Exception ex)
            {
                result = default;
                throw ex;
            }
        }


    }
}