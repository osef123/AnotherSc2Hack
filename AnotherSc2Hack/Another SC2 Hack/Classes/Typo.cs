namespace Another_SC2_Hack.Classes
{
    static class Typo
    {
        public enum UnitId
        {
            PuColossus = 30,            //Valid
            TbCcGround = 48,
            TbSupplyGround = 49,
            TbRefinery = 50,
            TbBarracksGround = 51,
            TbEbay = 52,
            TbTurret = 53,
            TbBunker = 54,
            TbSensortower = 55,
            TbGhostacademy = 56,
            TbFactoryGround = 57,
            TbStarportGround = 58,
            TbArmory = 60,
            TbFusioncore = 61,
            TuSiegetank = 64,
            TuVikingAir = 66,           //Valid
            TbCcAir = 67,
            TbTechlabRax = 68,
            TbReactorRax = 69,
            TbTechlabFactory = 70,
            TbReactorFactory = 71,
            TbTechlabStarport = 72,
            TbReactorStarport = 73,
            TbFactoryAir = 74,
            TbStarportAir = 75,
            TuScv = 76,                 //Valid
            TbRaxAir = 77,
            TbSupplyHidden = 78,
            TuMarine = 79,              //Valid
            TuReaper = 80,
            TuGhost = 81,
            TuMarauder = 82,            //Valid
            TuThor = 83,
            TuHellion = 84,
            TuMedivac = 85,             //Valid
            TuBanshee = 86,
            TuRaven = 87,
            TuBattlecruiser = 88,
            PbNexus = 90,
            PbPylon = 91,
            PbAssimilator = 92,
            PbGateway = 93,
            PbForge = 94,
            PbFleetbeacon = 95,
            PbTwilightcouncil = 96,
            PbCannon = 97,
            PbStargate = 98,
            PbTemplararchives = 99,
            PbDarkshrine = 100,
            PbRoboticssupportbay = 101,
            PbRoboticsbay = 102,
            PbCybercore = 103,
            PuZealot = 104,             //Valid
            PuStalker = 105,            //Valid
            PuHightemplar = 106,        //Valid
            PuDarktemplar = 107,
            PuSentry = 108,             //Valid
            PuPhoenix = 109,
            PuCarrier = 110,
            PuVoidray = 111,
            PuWarpprism = 112,  
            PuObserver = 113,           //Valid
            PuImmortal = 114,           //Valid
            PuProbe = 115,              //Valid
            ZbSpinecrawler = 128,
            ZbSporecrawler = 120,
            ZbExtractor = 119,          //Valid
            ZbNydusMain = 126,          //Valid
            ZbSpire = 123,              //Valid
            ZbEvolutionchamber = 125,   //INVALID
            ZbInfestationpit = 125,     //Valid
            ZbHydraden = 122,           //Valid
            ZbHatchery = 117,           //Valid
            ZbRoachwarren = 128,        //Valid
            ZbHive = 132,               //INVALID
            ZbLiar = 131,               //Valid
            ZbGreaterspire = 133,       //Valid
            ZbSpawningpool = 135,       //INVALID
            ZuDrone = 135,              //Valid
            ZuZergling = 136,           //Valid
            ZbBanelingnest = 137,       //INVALID
            ZuOverlord = 137,           //Valid
            ZuHydralisk = 138,          //Valid
            ZuMutalisk = 139,           //Valid
            ZuRoach = 141,              //Valid
            ZuInfestor = 142,           //Valid
            ZuCorruptor = 143,          //Valid
            ZuQueen = 157,              //Valid
            TbPlanetary = 161,
            TbOrbitalGround = 163,
            PbWarpgate = 164,
            TbOrbitalAir = 165,
            ZbCreeptumor = 168,         //Valid
            ZuBroodlord = 173,          //Valid
            ZuLarva = 181,              //Valid
            ZuInfestedterranEgg = 185,  //Valid
            TuMule = 189,               //Valid

           
        };

        public enum PlayerStatus
        {
            Playing = 0,
            Won = 1,
            Lost = 2,
            Tied = 3
        };

        public enum PlayerColor
        {
            White = 0,
            Red = 1,
            Blue = 2,
            Teal = 3,
            Purple = 4,
            Yellow = 5,
            Orange = 6,
            Green = 7,
            LightPink = 8,
            Violet = 9,
            LightGray = 10,
            DarkGreen = 11,
            Brown = 12,
            LightGreen = 13,
            DarkGray = 14,
            Pink = 15
        };

        public enum BufferformType 
        {
            Dummy = 0,
            Ressource = 1,
            Income = 2,
            Worker = 3,
            Apm = 4,
            Army = 5,
            Maphack = 6,
            Units = 7,
            Buildings = 8,
            Notification = 9,
            Upgrades = 10,
            Autogroup = 11
        };

        public enum Gamespeed
        {
            Slower = 0,
            Slow = 1,
            Normal = 2,
            Fast = 3,
            Faster = 4,
            Fasterx2 = 5,
            Fasterx4 = 6,
            Fasterx8 = 7
        };

        public enum WindowStyle
        {
            WindowedFullscreen = 262144,
            Windowed = 262400,
            Fullscreen = 262152
        };

        public enum Gametype
        {
            None = 0,
            Replay = 1,
            Challange = 2,
            VersusAi = 3,
            Ladder = 4
        };
    }
}
