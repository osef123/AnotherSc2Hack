namespace Another_SC2_Hack.Classes
{
    static class Typo
    {
        public enum UnitId
        {
            PuColossus = 30,            //Valid
            TbTechlab = 33,             //Valid
            TbReactor = 34,             //Valid
            ZuInfestedTerran = 36,      //Valid
            ZuBanelingCocoon = 37,      //Valid
            ZuBaneling = 38,            //Valid
            PuMothership = 39,          //Valid
            TuPdd = 40,                 //Valid
            ZuChangeling = 41,          //Valid
            ZuChangelingZealot = 42,    //Valid
            ZuChangelingMarineShield = 43,  //Valid
            ZuChangelingMarine = 44,    //Valid
            ZuChangelingSpeedling = 45, //Valid
            ZuChangelingZergling = 46,  //Valid
            TbCcGround = 48,            //Valid
            TbSupplyGround = 49,        //Valid
            TbRefinery = 50,            //Valid
            TbBarracksGround = 51,      //Valid
            TbEbay = 52,                //Valid
            TbTurret = 53,              //Valid
            TbBunker = 54,              //Valid
            TbSensortower = 55,         //Valid
            TbGhostacademy = 56,        //Valid
            TbFactoryGround = 57,       //Valid
            TbStarportGround = 58,      //Valid
            TbArmory = 60,              //Valid
            TbFusioncore = 61,          //Valid
            TbAutoTurret = 62,          //Valid
            TuSiegetankSieged = 63,     //Valid
            TuSiegetank = 64,           //Valid
            TuVikingGround = 65,        //Valid
            TuVikingAir = 66,           //Valid
            TbCcAir = 67,               //Valid
            TbTechlabRax = 68,          //Not Sure
            TbReactorRax = 69,          //Not sure
            TbTechlabFactory = 70,      //Not sure
            TbReactorFactory = 71,      //Not sure
            TbTechlabStarport = 72,     //Not sure
            TbReactorStarport = 73,     //Not sure
            TbFactoryAir = 74,          //Valid
            TbStarportAir = 75,         //Valid
            TuScv = 76,                 //Valid
            TbRaxAir = 77,              //Valid
            TbSupplyHidden = 78,        //Valid
            TuMarine = 79,              //Valid
            TuReaper = 80,              //Valid
            TuGhost = 81,               //Valid
            TuMarauder = 82,            //Valid
            TuThor = 83,                //Valid
            TuHellion = 84,             //Valid
            TuMedivac = 85,             //Valid
            TuBanshee = 86,             //Valid
            TuRaven = 87,               //Valid
            TuBattlecruiser = 88,       //Valid
            PbNexus = 90,               //Valid
            PbPylon = 91,               //Valid
            PbAssimilator = 92,         //Valid
            PbGateway = 93,             //Valid
            PbForge = 94,               //Valid
            PbFleetbeacon = 95,         //Valid
            PbTwilightcouncil = 96,     //Valid
            PbCannon = 97,              //Valid
            PbStargate = 98,            //Valid
            PbTemplararchives = 99,     //Valid
            PbDarkshrine = 100,         //Valid
            PbRoboticssupportbay = 101, //Valid
            PbRoboticsbay = 102,        //Valid
            PbCybercore = 103,          //Valid
            PuZealot = 104,             //Valid 
            PuStalker = 105,            //Valid
            PuHightemplar = 106,        //Valid
            PuDarktemplar = 107,        //Valid
            PuSentry = 108,             //Valid
            PuPhoenix = 109,            //Valid
            PuCarrier = 110,            //Valid
            PuVoidray = 111,            //Valid
            PuWarpprismTransport = 112, //Valid
            PuObserver = 113,           //Valid
            PuImmortal = 114,           //Valid
            PuProbe = 115,              //Valid
            PuInterceptor = 116,        //Valid
            ZbHatchery = 117,           //Valid
            ZbExtractor = 119,          //Valid
            ZbSpawningPool = 120,       //Valid
            ZbEvolutionChamber = 121,   //Valid
            ZbHydraDen = 122,           //Valid
            ZbSpire = 123,              //Valid
            ZbUltraCavern = 124,        //Valid
            ZbInfestationPit = 125,     //Valid
            ZbNydusNetwork = 126,       //Valid
            ZbBanelingNest = 127,       //Valid
            ZbRoachWarren = 128,        //Valid
            ZbSpineCrawler = 129,       //Valid
            ZbSporeCrawler = 130,       //Valid
            ZbLiar = 131,               //Valid
            ZbHive = 132,               //Valid
            ZbGreaterspire = 133,       //Valid
            ZuEgg = 134,                //Valid
            ZuDone = 135,               //Valid
            ZuZergling = 136,           //Valid
            ZuOverlord = 137,           //Valid
            ZuHydralisk = 138,          //Valid
			ZuMutalisk = 139,           //Valid
            ZuUltra = 140,              //Valid
            ZuRoach = 141,              //Valid
            ZuInfestor = 142,           //Valid
            ZuCorruptor = 143,          //Valid
            ZuBroodlordCocoon = 144,    //Valid
            ZuBroodlord = 145,          //Valid
            ZuBanelingBurrow = 146,     //Valid
            ZuDroneBurrow = 147,        //Valid
            ZuHydraBurrow = 148,        //Valid
            ZuRoachBurrow = 149,        //Valid
            ZuZerglingBurrow = 150,     //Valid
            ZuInfestedTerran2 = 151,    //Valid
            ZuQueenBurrow = 156,        //Valid
            ZuQueen = 157,              //Valid
            ZuInfestorBurrow = 158,     //Valid
            ZuOverseerCocoon = 159,     //Valid
            ZuOverseer = 160,           //Valid
            TbPlanetary = 161,          //Valid
            ZuUltraBurrow = 162,        //Valid
            TbOrbitalGround = 163,      //Valid
            PbWarpgate = 164,           //Valid
            TbOrbitalAir = 165,         //Valid
            PuWarpprismPhase = 167,     //Valid
            ZbCreeptumor = 168,         //Valid
            ZbSpineCrawlerUnrooted = 169,   //Valid
            ZbSporeCrawlerUnrooted = 170,   //Valid
            PuArchon = 171,             //Valid
            ZbNydusWorm = 172,          //Valid
            ZuBroodlordEscort = 173,    //Valid
            NbMineralRichPatch = 174,   //Valid
            NbXelNagaTower = 176,       //Valid
            ZuInfestedSwarmEgg = 180,   //Valid
            ZuLarva = 181,              //Valid
            TuMule = 189,               //Valid
            ZuBroodling = 212,          //Valid
            NbMineralPatch = 253,       //Valid
            NbGas = 254,                //Valid
            NbGasSpace = 255,           //Valid
            NbGasRich = 256             //Valid
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
