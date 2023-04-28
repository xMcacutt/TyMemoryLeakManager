using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TyMemoryLeakManager
{
    internal static class SettingsHandler
    {
        public static Settings Settings { get; private set; }
        public static Categories Categories { get; private set; }

        public static void Setup()
        {
            //MAIN SETTINGS
            string settings = File.ReadAllText("./Settings.json");
            string categories = File.ReadAllText("./Categories.json");
            Settings = JsonConvert.DeserializeObject<Settings>(settings);
            Categories = JsonConvert.DeserializeObject<Categories>(categories);
        }

        public static void Save()
        {
            string json = JsonConvert.SerializeObject(Settings);
            File.WriteAllText("./Settings.json", json);
        }
    }
}
