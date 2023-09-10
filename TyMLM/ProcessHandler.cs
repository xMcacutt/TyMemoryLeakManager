using Microsoft.Win32.SafeHandles;
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

        [StructLayout(LayoutKind.Sequential)]
        struct PProcessMemoryCounters
        {
            public uint cb;
            public uint PageFaultCount;
            public uint PeakWorkingSetSize;
            public uint WorkingSetSize;
            public uint QuotaPeakPagedPoolUsage;
            public uint QuotaPagedPoolUsage;
            public uint QuotaPeakNonPagedPoolUsage;
            public uint QuotaNonPagedPoolUsage;
            public uint PagefileUsage;
            public uint PeakPagefileUsage;
        }
        private static PProcessMemoryCounters ppsmemCounters;

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
        
        [DllImport("psapi.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool GetProcessMemoryInfo(IntPtr hProcess, out PProcessMemoryCounters ppsmemCounters, int size);
        const int PPMC_SIZE = 40;

        public static void Initialize()
        {
            HasFolderPath = SettingsHandler.Settings.TyFolderPath != "";
            ppsmemCounters = new PProcessMemoryCounters() { cb = PPMC_SIZE };
        }

        const long BYTES_TO_MEGABYTES = 1024 * 1024;
        public static int GetProcessMemory()
        {

            if (!HasTyProcess) { return 0; }

            try
            {
                TyProcess.Refresh();
                ulong mem = 0;
                if (GetProcessMemoryInfo(HProcess, out ppsmemCounters, PPMC_SIZE))
                {
                    mem = ppsmemCounters.WorkingSetSize;
                }
                return (int)(mem / BYTES_TO_MEGABYTES);
                        
            }
            catch (Exception)
            {
                if (!FindTyProcess() & HasFolderPath)
                    RestartTy();
                else
                {
                    //god help us all
                }
                return 0;
            }
        }

        public static void RestartTy()
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
        }

        private static void SetupProcess()
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
                {
                    RestartTy();
                    SetupProcess();
                    return true;
                }
                else
                {
                    //No process found, no path to restart ty, :(
                    HasTyProcess = false;
                    return false;
                }
            }
            else if (processes.Length > 1)
            {
                //show some warning about having multiple ty instances running. if u want.
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