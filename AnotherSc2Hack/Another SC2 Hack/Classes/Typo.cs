namespace Another_SC2_Hack.Classes
{
    static class Typo
    {
        public enum UnitId
        {
            PuColossus = 38,            //Valid
            TbTechlab = 39,             //Valid
            TbReactor = 40,             //Valid
            ZuInfestedTerran = 42,      //Valid
            ZuBanelingCocoon = 43,      //Valid
            ZuBaneling = 44,            //Valid
            PuMothership = 45,          //Valid
            TuPdd = 46,                 //
            ZuChangeling = 47,          //Valid
            ZuChangelingZealot = 48,    //Valid
            ZuChangelingMarineShield = 49,  //Valid
            ZuChangelingMarine = 50,    //Valid
            ZuChangelingSpeedling = 51, //Valid
            ZuChangelingZergling = 52,  //Valid
            TbCcGround = 54,            //Valid
            TbSupplyGround = 55,        //Valid
            TbRefinery = 56,            //Valid
            TbBarracksGround = 57,      //Valid
            TbEbay = 58,                //Valid
            TbTurret = 59,              //Valid
            TbBunker = 60,              //Valid
            TbSensortower = 61,         //Valid
            TbGhostacademy = 62,        //Valid
            TbFactoryGround = 63,       //Valid
            TbStarportGround = 64,      //Valid
            TbArmory = 66,              //Valid
            TbFusioncore = 67,          //Valid
            TbAutoTurret = 68,          //Valid
            TuSiegetankSieged = 69,     //Valid
            TuSiegetank = 70,           //Valid
            TuVikingGround = 71,        //Valid
            TuVikingAir = 72,           //Valid
            TbCcAir = 73,               //Valid
            TbTechlabRax = 74,          //Not Sure
            TbReactorRax = 75,          //Not sure
            TbTechlabFactory = 76,      //Not sure
            TbReactorFactory = 77,      //Not sure
            TbTechlabStarport = 78,     //Not sure
            TbReactorStarport = 79,     //Not sure
            TbFactoryAir = 80,          //Valid
            TbStarportAir = 81,         //Valid
            TuScv = 82,                 //Valid
            TbRaxAir = 83,              //Valid
            TbSupplyHidden = 84,        //Valid
            TuMarine = 85,              //Valid
            TuReaper = 86,              //Valid
            TuGhost = 87,               //Valid
            TuMarauder = 88,            //Valid
            TuThor = 89,                //Valid
            TuHellion = 90,             //Valid
            TuMedivac = 91,             //Valid
            TuBanshee = 92,             //Valid
            TuRaven = 93,               //Valid
            TuBattlecruiser = 94,       //Valid
            PbNexus = 96,               //Valid
            PbPylon = 97,               //Valid
            PbAssimilator = 98,         //Valid
            PbGateway = 99,             //Valid
            PbForge = 100,               //Valid
            PbFleetbeacon = 101,         //Valid
            PbTwilightcouncil = 102,     //Valid
            PbCannon = 103,              //Valid
            PbStargate = 104,            //Valid
            PbTemplararchives = 105,     //Valid
            PbDarkshrine = 106,         //Valid
            PbRoboticssupportbay = 107, //Valid
            PbRoboticsbay = 108,        //Valid
            PbCybercore = 109,          //Valid
            PuZealot = 110,             //Valid 
            PuStalker = 111,            //Valid
            PuHightemplar = 112,        //Valid
            PuDarktemplar = 113,        //Valid
            PuSentry = 114,             //Valid
            PuPhoenix = 115,            //Valid
            PuCarrier = 116,            //Valid
            PuVoidray = 117,            //Valid
            PuWarpprismTransport = 118, //Valid
            PuObserver = 119,           //Valid
            PuImmortal = 120,           //Valid
            PuProbe = 121,              //Valid
            PuInterceptor = 122,        //Valid
            ZbHatchery = 123,           //Valid
            ZbExtractor = 125,          //Valid
            ZbSpawningPool = 126,       //Valid
            ZbEvolutionChamber = 127,   //Valid
            ZbHydraDen = 128,           //Valid
            ZbSpire = 129,              //Valid
            ZbUltraCavern = 130,        //Valid
            ZbInfestationPit = 131,     //Valid
            ZbNydusNetwork = 132,       //Valid
            ZbBanelingNest = 133,       //Valid
            ZbRoachWarren = 134,        //Valid
            ZbSpineCrawler = 135,       //Valid
            ZbSporeCrawler = 136,       //Valid
            ZbLiar = 137,               //Valid
            ZbHive = 138,               //Valid
            ZbGreaterspire = 139,       //Valid
            ZuEgg = 140,                //Valid
            ZuDone = 141,               //Valid
            ZuZergling = 142,           //Valid
            ZuOverlord = 143,           //Valid
            ZuHydralisk = 144,          //Valid
			ZuMutalisk = 145,           //Valid
            ZuUltra = 146,              //Valid
            ZuRoach = 147,              //Valid
            ZuInfestor = 148,           //Valid
            ZuCorruptor = 149,          //Valid
            ZuBroodlordCocoon = 150,    //Valid
            ZuBroodlord = 151,          //Valid
            ZuBanelingBurrow = 152,     //Valid
            ZuDroneBurrow = 153,        //Valid
            ZuHydraBurrow = 154,        //Valid
            ZuRoachBurrow = 155,        //Valid
            ZuZerglingBurrow = 156,     //Valid
            ZuInfestedTerran2 = 157,    //Valid
            ZuQueenBurrow = 162,        //Valid
            ZuQueen = 163,              //Valid
            ZuInfestorBurrow = 164,     //Valid
            ZuOverseerCocoon = 165,     //Valid
            ZuOverseer = 166,           //Valid
            TbPlanetary = 167,          //Valid
            ZuUltraBurrow = 168,        //Valid
            TbOrbitalGround = 169,      //Valid
            PbWarpgate = 170,           //Valid
            TbOrbitalAir = 171,         //Valid
            PuWarpprismPhase = 173,     //Valid
            ZbCreeptumor = 174,         //Valid
            ZbSpineCrawlerUnrooted = 176,   //Valid
            ZbSporeCrawlerUnrooted = 177,   //Valid
            PuArchon = 178,             //Valid
            ZbNydusWorm = 179,          //Valid
            ZuBroodlordEscort = 180,    //Valid
            NbMineralRichPatch = 181,   //Valid
            NbXelNagaTower = 183,       //Valid
            ZuInfestedSwarmEgg = 187,   //Valid
            ZuLarva = 188,              //Valid
            TuMule = 196,               //Valid
            ZuBroodling = 219,          //Valid
            NbMineralPatch = 260,       //Valid
            NbGas = 261,                //Valid
            NbGasSpace = 262,           //Valid
            NbGasRich = 263             //Valid
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
