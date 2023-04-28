using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TyMemoryLeakManager
{
    public class SeverityWarnings
    {
        public Dictionary<string, string> Warnings = new Dictionary<string, string>()
        {
            {"Mid",  "No Risk Of Incoming Overflow!"},
            {"Mid",  "Low Risk Of Incoming Overflow!"},
            {"High", "DO NOT Start Another Run!"}
        };
    }
}
