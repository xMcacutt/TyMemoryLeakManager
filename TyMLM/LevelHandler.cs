using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TyMemoryLeakManager
{
    internal class LevelHandler
    {
        public LevelData GetCurrentLevel()
        {
            ProcessHandler.TryRead(0x280594, out int levelId, true);
            return Levels.GetLevelData(levelId);
        }
    }
}
