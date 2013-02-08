using System.Diagnostics;

namespace Another_SC2_Hack.Classes
{
    public class Offsets
    {
        public Offsets(Process starcraft)
        {
            
            switch (starcraft.MainModule.FileVersionInfo.FileVersion)
            {
                #region WoL - 1.5.3.23260

                case "1.5.3.23260":
                    //Playerinfo
                    Struct = 0x270C7F0;
                    CameraX = Struct + 0x008;
                    CameraDistance = Struct + 0x010;
                    CameraY = Struct + 0x00C;
                    CameraRotation = 0x018;
                    Playertype = Struct + 0x01D;
                    Status = Struct + 0x01E;
                    NameLenght = Struct + 0x044;
                    Name = Struct + 0x04C;
                    Color = Struct + 0x0A4;
                    Apm = Struct + 0x3A8;
                    Epm = Struct + 0x3E0;
                    Workers = Struct + 0x528;
                    SupplyMin = Struct + 0x5F0;
                    SupplyMax = Struct + 0x5D8;
                    MineralsCurrent = Struct + 0x628;
                    GasCurrent = Struct + 0x630;
                    MineralsIncome = Struct + 0x6A8;
                    GasIncome = Struct + 0x6B0;
                    MineralsArmy = Struct + 0x910;
                    GasArmy = Struct + 0x930;
                    Size = 0xA68;

                    //Team
                    Team = 0x2E77180;
                    TeamSize = 0x4;

                    //Race
                    Race = 0x3EB44E0;
                    RaceSize = 0x10;

                    //ChatInput
                    ChatBase = 0x017AB3C8;
                    ChatOff0 = 0x398;
                    ChatOff1 = 0x21C;
                    ChatOff2 = 0x004;
                    ChatOff3 = 0x004;
                    ChatOff4 = 0x014;

                    //Localplayer
                    Localplayer1 = 0x0176ECF7;
                    Localplayer2 = 0x0179DF9F;
                    Localplayer3 = 0x017A48E7;
                    Localplayer4 = 0x1683E30;

                    //Unitinfo
                    StructUnit = 0x2766B40;
                    UnitPosX = StructUnit + 0x44;
                    UnitPosY = StructUnit + 0x48;
                    UnitTargetFilter = StructUnit + 0x14;
                    UnitTotal = 0x1681D34;
                    UnitDeathType = StructUnit + 0x69;
                    UnitDestinationX = StructUnit + 0x78;
                    UnitDestinationY = StructUnit + 0x7C;
                    UnitEnergy = StructUnit + 0x114;
                    UnitOwner = StructUnit + 0x2A;
                    UnitState = StructUnit + 0x23;
                    UnitBeeingPuked = StructUnit + 0xD4;
                    UnitMoveState = StructUnit + 0x22;
                    UnitModel = StructUnit + 8;
                    UnitModelId = 0x18;
                    UnitModelSize = 0x3D4;
                    UnitSize = 0x1C0;

                    //Mapinfo
                    StructMap = 0x2659E64;
                    MapIngame = StructMap + 0x3C;
                    MapTop = StructMap + 0xE8;
                    MapRight = StructMap + 0xE4;
                    MapBottom = StructMap + 0xE0;
                    MapLeft = StructMap + 0xDC;

                    //TeamColor
                    TeamColor1 = 0x17ABAA4;
                    TeamColor2 = 0x262F0E0;

                    //Ingame Timer
                    TimerData = 0x02659ECC;

                    //Pause
                    PauseEnabled = 0x01773830;

                    //Gamespeed
                    Gamespeed = 0x01773818;


                    break;

                #endregion

                #region WoL - 1.5.4.24540

                case "1.5.4.24540":
                    //Playerinfo
                    Struct = 0x270C7A0;
                    CameraX = Struct + 0x008;
                    CameraDistance = Struct + 0x010;
                    CameraY = Struct + 0x00C;
                    CameraRotation = 0x018;
                    Team = Struct + 0x01C;                
                    Playertype = Struct + 0x01D;
                    Status = Struct + 0x01E;
                    NameLenght = Struct + 0x044;
                    Name = Struct + 0x04C;
                    Color = Struct + 0x0A4;
                    Apm = Struct + 0x3A8;
                    Epm = Struct + 0x3E0;
                    Workers = Struct + 0x528;
                    SupplyMin = Struct + 0x5F0;
                    SupplyMax = Struct + 0x5D8;
                    MineralsCurrent = Struct + 0x628;
                    GasCurrent = Struct + 0x630;
                    MineralsIncome = Struct + 0x6A8;
                    GasIncome = Struct + 0x6B0;
                    MineralsArmy = Struct + 0x910;
                    GasArmy = Struct + 0x930;
                    Size = 0xA68;

                    //Team
                    //Team = 0x2E77140;
                    //TeamSize = 0x4;

                    //Race
                    Race = 0x3EB44A0;
                    RaceSize = 0x10;

                    //ChatInput
                    ChatBase = 0x017AB3C8;
                    ChatOff0 = 0x398;
                    ChatOff1 = 0x21C;
                    ChatOff2 = 0x004;
                    ChatOff3 = 0x004;
                    ChatOff4 = 0x014;

                    //Localplayer
                    Localplayer1 = 0x0176ECF7;
                    Localplayer2 = 0x0179DF9F;
                    Localplayer3 = 0x017A48E7;
                    Localplayer4 = 0x1683E30;

                    //Unitinfo
                    StructUnit = 0x2772B80;
                    UnitPosX = StructUnit + 0x44;
                    UnitPosY = StructUnit + 0x48;
                    UnitTargetFilter = StructUnit + 0x14;
                    UnitTotal = 0x1681D34;
                    UnitDeathType = StructUnit + 0x69;
                    UnitDestinationX = StructUnit + 0x78;
                    UnitDestinationY = StructUnit + 0x7C;
                    UnitEnergy = StructUnit + 0x114;
                    UnitOwner = StructUnit + 0x2A;
                    UnitState = StructUnit + 0x23;
                    UnitBeeingPuked = StructUnit + 0xD4;
                    UnitMoveState = StructUnit + 0x22;
                    UnitModel = StructUnit + 8;
                    UnitModelId = 0x18;
                    UnitModelSize = 0x3D4;
                    UnitSize = 0x1C0;

                    //Mapinfo
                    StructMap = 0x2659E14;
                    MapIngame = StructMap + 0x3C;
                    MapTop = StructMap + 0xE8;
                    MapRight = StructMap + 0xE4;
                    MapBottom = StructMap + 0xE0;
                    MapLeft = StructMap + 0xDC;

                    //TeamColor
                    TeamColor1 = 0x17ABAA4;
                    TeamColor2 = 0x262F0E0;

                    //Ingame Timer
                    TimerData = 0x02659E7C;

                    //Pause
                    PauseEnabled = 0x01773830;

                    //Gamespeed
                    Gamespeed = 0x01773818;

                    //Fps
                    FramesPerSecond = 0x0262F9C4;

                    //Gametype
                    Gametype = 0x0176DCC8;


                    break;

                #endregion

                #region HotS - 2.0.0.24247

                case "2.0.0.24247":
                    //Playerinfo
                    Struct = (int)starcraft.MainModule.BaseAddress + 0x02543260; 
                    CameraX = Struct + 0x008;             //Valid
                    CameraDistance = Struct + 0x00A;      //Valid
                    CameraY = Struct + 0x00C;             //Valid
                    Playertype = Struct + 0x01D;          //Not Validated
                    Status = Struct + 0x01E;              //Not Validated
                    NameLenght = Struct + 0x044;          //Not Validated
                    Name = Struct + 0x0B0;                //Valid
                    Color = Struct + 0x108;               //Valid
                    Apm = Struct + 0x530;                 //Valid
                    Epm = Struct + 0x570;                 //Valid
                    Workers = Struct + 0x528;             //Not Validated
                    SupplyMin = Struct + 0x7F8;           //Valid
                    SupplyMax = Struct + 0x7E0;           //Valid
                    MineralsCurrent = Struct + 0x830;     //Valid
                    GasCurrent = Struct + 0x838;          //Valid
                    MineralsIncome = Struct + 0x8B0;      //Valid
                    GasIncome = Struct + 0x8B8;           //Valid
                    MineralsArmy = Struct + 0xB18;        //Valid
                    GasArmy = Struct + 0xB38;             //Valid
                    Size = 0xC90;                           //Valid

                    //Team
                    Team = 0x2E77180;
                    TeamSize = 0x4;

                    //Race
                    Race = 0x3EB44E0;
                    RaceSize = 0x10;

                    //ChatInput
                    ChatBase = (int)starcraft.MainModule.BaseAddress + 0x02063318;
                    ChatOff0 = 0x3D4;
                    ChatOff1 = 0x078;
                    ChatOff2 = 0x224;
                    ChatOff3 = 0x000;
                    ChatOff4 = 0x014;

                    //Localplayer
                    Localplayer1 = 0x0176ECF7;
                    Localplayer2 = 0x0179DF9F;
                    Localplayer3 = 0x017A48E7;
                    Localplayer4 = 0x1683E30;

                    //Unitinfo
                    StructUnit = 0x2766B40;
                    UnitPosX = StructUnit + 0x44;
                    UnitPosY = StructUnit + 0x48;
                    UnitTargetFilter = StructUnit + 0x14;
                    UnitTotal = 0x1681D34;
                    UnitDeathType = StructUnit + 0x69;
                    UnitDestinationX = StructUnit + 0x78;
                    UnitDestinationY = StructUnit + 0x7C;
                    UnitEnergy = StructUnit + 0x114;
                    UnitOwner = StructUnit + 0x2A;
                    UnitState = StructUnit + 0x23;
                    UnitBeeingPuked = StructUnit + 0xD4;
                    UnitMoveState = StructUnit + 0x22;
                    UnitModel = StructUnit + 8;
                    UnitModelId = 0x18;
                    UnitModelSize = 0x3D4;
                    UnitSize = 0x1C0;

                    //Mapinfo
                    StructMap = 0x03B90BF4;
                    MapIngame = StructMap + 0x3C;
                    MapTop = StructMap + 0xE8;            //Valid
                    MapRight = StructMap + 0xE4;
                    MapBottom = StructMap + 0xE0;
                    MapLeft = StructMap + 0xDC;

                    //TeamColor
                    TeamColor1 = 0x037643FC;                //Valid
                    TeamColor2 = 0x053ED168;                //Valid

                    //Ingame Timer
                    TimerData = 0x02659ECC;

                    //Pause
                    PauseEnabled = 0x01773830;

                    //Gamespeed
                    Gamespeed = 0x053AEB18;                 //Valid


                    break;

                #endregion

                #region HotS - 2.0.3.24764

                case "2.0.3.24764":
                    //Playerinfo
                    Struct = (int)starcraft.MainModule.BaseAddress + 0x2561CE8;
                    CameraX = Struct + 0x008;             //Valid
                    CameraDistance = Struct + 0x00A;      //Valid
                    CameraY = Struct + 0x00C;             //Valid
                    Team = Struct + 0x01C;                //Valid
                    Playertype = Struct + 0x01D;          //Seems to work
                    Status = Struct + 0x01E;              //Seems to work
                    NameLenght = Struct + 0x050;          //Valid
                    Name = Struct + 0x0B0;                //Valid
                    Color = Struct + 0x138;               //Valid
                    Apm = Struct + 0x560;                 //Valid
                    Epm = Struct + 0x5A0;                 //Valid
                    Workers = Struct + 0x750;             //Valid
                    SupplyMin = Struct + 0x828;           //Valid
                    SupplyMax = Struct + 0x810;           //Valid
                    MineralsCurrent = Struct + 0x860;     //Valid
                    GasCurrent = Struct + 0x868;          //Valid
                    MineralsIncome = Struct + 0x8E0;      //Valid
                    GasIncome = Struct + 0x8E8;           //Valid
                    MineralsArmy = Struct + 0xB48;        //Valid
                    GasArmy = Struct + 0xB68;             //Valid
                    Size = 0xCC0;                         //Valid

                    //Team
                    //Team = 0x2E77140;   //Unused
                    //TeamSize = 0x4;     //Unused

                    //Race
                    Race = (int) starcraft.MainModule.BaseAddress + 0x1EB1C30;  //Valid
                    RaceSize = 0x10;                                            //Valid

                    //ChatInput
                    ChatBase = 0x017AB3C8;
                    ChatOff0 = 0x398;
                    ChatOff1 = 0x21C;
                    ChatOff2 = 0x004;
                    ChatOff3 = 0x004;
                    ChatOff4 = 0x014;

                    //Localplayer
                    Localplayer1 = 0x0176ECF7;                                          //Outdated/ Unused
                    Localplayer2 = 0x0179DF9F;                                          //Outdated/ Unused
                    Localplayer3 = (int)starcraft.MainModule.BaseAddress + 0x3CEDDAC;   //Valid
                    Localplayer4 = (int)starcraft.MainModule.BaseAddress + 0x209BE5B;   //Valid

                    //Unitinfo
                    StructUnit = (int) starcraft.MainModule.BaseAddress + 0x25DE380;    //Valid
                    UnitPosX = StructUnit + 0x44 + 4;                                   //Valid
                    UnitPosY = StructUnit + 0x48 + 4;                                   //Valid
                    UnitTargetFilter = StructUnit + 0x14 + 4;                           //Valid
                    UnitTotal = 0x1681D34;                                              //Outdated/ Unused
                    UnitDeathType = StructUnit + 0x69 + 4;                              //Unused
                    UnitDestinationX = StructUnit + 0x78 + 4;                           //Valid
                    UnitDestinationY = StructUnit + 0x7C + 4;                           //Valid
                    UnitEnergy = StructUnit + 0x114 + 4;                                //Valid
                    UnitOwner = StructUnit + 0x2A + 4;                                  //Not sure
                    UnitState = StructUnit + 0x23 + 4;                                  //Not sure
                    UnitBeeingPuked = StructUnit + 0xD4 + 4;                            //Not sure
                    UnitMoveState = StructUnit + 0x22 + 4;                              //Unused
                    UnitModel = StructUnit + 8 + 4;                                         //Valid
                    UnitModelId = 0x18;                                                 //Valid
                    UnitModelSize = 0x3D4;                                              //Outdated
                    UnitSize = 0x1C0;                                                   //Valid

                    //Mapinfo 
                    StructMap = (int) starcraft.MainModule.BaseAddress + 0x24AF0FC;     //Valid
                    MapTop = StructMap + 0xE8;                                          //Valid
                    MapRight = StructMap + 0xE4;                                        //Valid
                    MapBottom = StructMap + 0xE0;                                       //Valid
                    MapLeft = StructMap + 0xDC;                                         //Valid

                    //TeamColor 
                    TeamColor1 = (int) starcraft.MainModule.BaseAddress + 0x208275C;    //Valid
                    TeamColor2 = (int) starcraft.MainModule.BaseAddress + 0x3D82928;    //Valid

                    //Ingame Timer 
                    TimerData = (int) starcraft.MainModule.BaseAddress + 0x2081BEC;     //Valid

                    //Pause VALID
                    PauseEnabled = (int)starcraft.MainModule.BaseAddress + 0x216B7B8;/* 0x022ab7b8
                                               * 0x25ef0b8 
                                               * 0x3de06e4 
                                               * 0x3e0fc20 */

                    //Gamespeed VALID
                    Gamespeed = (int) starcraft.MainModule.BaseAddress + 0x3CCFC08; //or 0x3e0fc08

                    //Fps VALID
                    FramesPerSecond = (int)     
                    starcraft.MainModule.BaseAddress + 0x3D8320C;   //or 0x3ec320c

                    //Gametype NOT VALID
                    Gametype = 0x0176DCC8;      


                    break;

                #endregion

                #region HNew, unknown versions

                default:
                    System.Windows.Forms.MessageBox.Show("Version seems to be new..\nGive me a few days updating it!",
                                                         "Ouch, new Version?!");
                    break;

                #endregion
            }
        }

        #region create Addresses

        public int Struct = 0;
        public int StructUnit = 0;
        public int StructMap = 0;

        public int CameraX = 0,
                            CameraY = 0,
                            CameraDistance = 0,
                            CameraRotation = 0,
                            Playertype = 0,
                            Status = 0,
                            NameLenght = 0,
                            Name = 0,
                            Color = 0,
                            Apm = 0,
                            Epm = 0,
                            Workers = 0,
                            SupplyMin = 0,
                            SupplyMax = 0,
                            MineralsCurrent = 0,
                            GasCurrent = 0,
                            MineralsIncome = 0,
                            GasIncome = 0,
                            MineralsArmy = 0,
                            GasArmy = 0,
                            Size = 0;

        public int Race = 0,
                            RaceSize = 0,
                            Team = 0,
                            TeamSize = 0;

        public int ChatBase = 0x017AB3C8,
                            ChatOff0 = 0x398,
                            ChatOff1 = 0x21C,
                            ChatOff2 = 0x004,
                            ChatOff3 = 0x004,
                            ChatOff4 = 0x014;

        public int Localplayer1 = 0,
                            Localplayer2 = 0,
                            Localplayer3 = 0,
                            Localplayer4 = 0;

        public int UnitPosX = 0,
                   UnitPosY = 0,
                   UnitTargetFilter = 0,
                   UnitTotal = 0,
                   UnitDeathType = 0,
                   UnitDestinationX = 0,
                   UnitDestinationY = 0,
                   UnitEnergy = 0,
                   UnitOwner = 0,
                   UnitState = 0,
                   UnitModel = 0,
                   UnitBeeingPuked = 0,
                   UnitMoveState = 0,
                   UnitSize = 0,
                   UnitModelId = 0,
                   UnitModelSize = 0;

        public int MapIngame = 0,
                   MapTop = 0,
                   MapBottom = 0,
                   MapLeft = 0,
                   MapRight = 0;

        public int TeamColor1 = 0,
                   TeamColor2 = 0;

        public int TimerData = 0;

        public int PauseEnabled = 0;

        public int Gamespeed = 0;

        public int FramesPerSecond = 0;

        public int Gametype = 0;

        #endregion
    }
}
