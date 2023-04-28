using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TyMemoryLeakManager
{
    public struct LevelData
    {
        public int Id;
        public string Code;
        public int MemUsage;
        public int LeakedMemory;
    }
    public class Levels
    {
        public static LevelData GetLevelData(int levelID)
        {
            return levels[levelID];
        }

        #region leveldata
        public static readonly LevelData RainbowCliffs = new LevelData()
        {
            Id = 0,
            Code = "Z1",
            MemUsage = 295,
            LeakedMemory = 20
        };

        public static readonly LevelData RainbowCliffsDev = new LevelData()
        {
            Id = 1,
            Code = "Z2"
        };

        public static readonly LevelData TwoUp = new LevelData()
        {
            Id = 4,
            Code = "A1",
            MemUsage = 190,
            LeakedMemory = 35,
        };

        public static readonly LevelData WalkInThePark = new LevelData()
        {
            Id = 5,
            Code = "A2",
            MemUsage = 190,
            LeakedMemory = 20
        };

        public static readonly LevelData ShipRex = new LevelData()
        {
            Id = 6,
            Code = "A3",
            MemUsage = 230,
            LeakedMemory = 30
        };

        public static readonly LevelData BullsPen = new LevelData()
        {
            Id = 7,
            Code = "A4",
            MemUsage = 100,
            LeakedMemory = 3
        };

        public static readonly LevelData BridgeOnTheRiverTy = new LevelData()
        {
            Id = 8,
            Code = "B1",
            MemUsage = 160,
            LeakedMemory = 10
        };

        public static readonly LevelData SnowWorries = new LevelData()
        {
            Id = 9,
            Code = "B2",
            MemUsage = 110,
            LeakedMemory = 30
        };

        public static readonly LevelData OutbackSafari = new LevelData()
        {
            Id = 10,
            Code = "B3",
            MemUsage = 130,
            LeakedMemory = 20
        };

        public static readonly LevelData CrikeysCove = new LevelData()
        {
            Id = 19,
            Code = "D4",
            MemUsage = 90,
            LeakedMemory = 4
        };

        public static readonly LevelData LyreLyrePantsOnFire = new LevelData()
        {
            Id = 12,
            Code = "C1",
            MemUsage = 210,
            LeakedMemory = 55
        };

        public static readonly LevelData BeyondTheBlackStump = new LevelData()
        {
            Id = 13,
            Code = "C2",
            MemUsage = 120,
            LeakedMemory = 20
        };

        public static readonly LevelData RexMarksTheSpot = new LevelData()
        {
            Id = 14,
            Code = "C3",
            MemUsage = 150,
            LeakedMemory = 40
        };

        public static readonly LevelData FluffysFjord = new LevelData()
        {
            Id = 15,
            Code = "C4",
            MemUsage = 70,
            LeakedMemory = 4
        };

        public static readonly LevelData CassPass = new LevelData()
        {
            Id = 20,
            Code = "E1",
            MemUsage = 100,
            LeakedMemory = 40
        };

        public static readonly LevelData CassCrest = new LevelData()
        {
            Id = 17,
            Code = "D2",
            MemUsage = 220,
            LeakedMemory = 45
        };

        public static readonly LevelData FinalBattle = new LevelData()
        {
            Id = 23,
            Code = "E4",
            MemUsage = 85,
            LeakedMemory = 7
        };

        public static readonly LevelData EndGame = new LevelData()
        {
            Id = 16,
            Code = "END",
        };

        public static readonly LevelData BonusWorld1 = new LevelData()
        {
            Id = 21,
            Code = "E2",
            MemUsage = 140,
            LeakedMemory = 32
        };

        public static readonly LevelData BonusWorld2 = new LevelData()
        {
            Id = 22,
            Code = "E3",
            MemUsage = 140,
            LeakedMemory = 9
        };
        #endregion


        public static readonly Dictionary<int, LevelData> levels = new Dictionary<int, LevelData>
        {
            {0, RainbowCliffs },

            {4, TwoUp },
            {5, WalkInThePark },
            {6, ShipRex },
            {7, BullsPen },

            {8, BridgeOnTheRiverTy },
            {9, SnowWorries },
            {10, OutbackSafari },
            {19, CrikeysCove },

            {12, LyreLyrePantsOnFire },
            {13, BeyondTheBlackStump },
            {14, RexMarksTheSpot },
            {15, FluffysFjord },

            {20, CassPass },
            {17, CassCrest },
            {23, FinalBattle },
            {16, EndGame },

            {21, BonusWorld1 },
            {22, BonusWorld2 },
        };
    }
}
