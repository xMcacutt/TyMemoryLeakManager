using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Reflection.Emit;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace TyMemoryLeakManager
{
    public partial class TyMLM: Form
    {
        public static bool AllowSound = true;
        public TyMLM()
        {
            InitializeComponent();
            Font = new Font(mFontCollection.Families[0], 12.5F);
            MemUsage.Font = new Font(mFontCollection.Families[0], 25.5F);

            SettingsHandler.Setup();
            ProcessHandler.Initialize();
            BackgroundWorker loop = new BackgroundWorker();
            loop.DoWork += (s, e) => Loop();
            loop.RunWorkerAsync();
        }

        public void Loop()
        {
            while (true)
            {
                while (!ProcessHandler.HasTyProcess)
                {
                    ProcessHandler.FindTyProcess();
                }
                SetData();
            }
        }

        public void DebugWrite(string msg)
        {
            MemUsage.Text = msg;
        }

        public void SetData()
        {
            if (!ProcessHandler.HasTyProcess) return;
            int memValue = 0;
            Category.Invoke((MethodInvoker)delegate {
                switch (Category.Text)
                {
                    case "Any%":
                        memValue = SettingsHandler.Categories.Any;
                        break;
                    case "51TEGS":
                        memValue = SettingsHandler.Categories._51TEGS;
                        break;
                    case "100%":
                        memValue = SettingsHandler.Categories._100;
                        break;
                    case "All Rainbow Scales":
                        memValue = SettingsHandler.Categories.ARS;
                        break;
                    case "All Golden Cogs":
                        memValue = SettingsHandler.Categories.AGC;
                        break;
                    case "Save The Bilbies":
                        memValue = SettingsHandler.Categories.STB;
                        break;
                    case "Cheat% All Levels":
                        memValue = SettingsHandler.Categories.CheatAL;
                        break;
                    case "Max%":
                        memValue = SettingsHandler.Categories.Max;
                        break;
                    default:
                        memValue = 0;
                        break;
                }
            });
            int currentUsage = ProcessHandler.GetProcessMemory();
            // Use Invoke method to update UI controls
            MemUsage.Invoke((MethodInvoker)delegate {
                MemUsage.Text = currentUsage.ToString() + "MB";
                MemUsage.Refresh();
            });
            int predictedUsage = currentUsage + memValue;
            int remainingSpace = 1550 - currentUsage;
            float remainingRuns = (float)((float)remainingSpace / (float)memValue);
            string msg;
            Color color;
            if(remainingRuns > 1.5)
            {
                msg = "Low - Safe To Continue Runs! ";
                color = Color.DarkGreen;
            }
            else if(remainingRuns > 1)
            {
                msg = "Mid - Safe To Continue Runs! ";
                color = Colors.DeepGold;
            }
            else
            {
                msg = "High - Do NOT Start Another Run! ";
                if (AllowSound)
                {
                    SoundPlayer player = new SoundPlayer("./Alert.wav");
                    player.Play();
                    AllowSound = false;
                }
                color = Color.DarkRed;
            }
            msg += '\n';
            msg += remainingRuns.ToString();
            msg += " Runs Remaining!";
            Severity.Invoke((MethodInvoker)delegate {
                Severity.Text = msg;
                Severity.ForeColor = color;
            });
            MemUseBar.BeginInvoke(new Action(() => {
                MemUseBar.MemValue = currentUsage;
                MemUseBar.PredictedValue = memValue;
                MemUseBar.PredictedColor = color;
                MemUseBar.Refresh();
            }));
            
        }

        private void CategoryChanged(object sender, EventArgs e)
        {
            AllowSound = true;
            if (!ProcessHandler.HasTyProcess) return;
            int memValue;
            switch (Category.Text)
            {
                case "Any%":
                    memValue = SettingsHandler.Categories.Any;
                    break;
                case "51TEGS":
                    memValue = SettingsHandler.Categories._51TEGS;
                    break;
                case "100%":
                    memValue = SettingsHandler.Categories._100;
                    break;
                case "All Rainbow Scales":
                    memValue = SettingsHandler.Categories.ARS;
                    break;
                case "All Golden Cogs":
                    memValue = SettingsHandler.Categories.AGC;
                    break;
                case "Save The Bilbies":
                    memValue = SettingsHandler.Categories.STB;
                    break;
                case "Cheat% All Levels":
                    memValue = SettingsHandler.Categories.CheatAL;
                    break;
                case "Max%":
                    memValue = SettingsHandler.Categories.Max;
                    break;
                default:
                    memValue = 0;
                    break;
            }
            MemUsage.Text = memValue.ToString() + "MB";
            MemUseBar.PredictedValue = memValue;
            MemUseBar.Refresh();
        }
    }
}
