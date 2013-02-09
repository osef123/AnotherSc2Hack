using System;
using System.Drawing;
using System.Text;

namespace Another_SC2_Hack.Classes
{
    class PlayerInfo
    {
        private readonly BufferForm _myForm;

        public PlayerInfo(BufferForm frm)
        {
            _myForm = frm;
        }

        //Size is 4 bytes
        public Int32 CameraX(Int32 playerNum)
        {
            return (BitConverter.ToInt32(Pinvokes.ReadProcess(_myForm.HStarCraft, _myForm.OOffset.CameraX + _myForm.OOffset.Size * playerNum, 4), 0) / 4096);
        }

        //Size is 4 bytes
        public Int32 CameraY(Int32 playerNum)
        {
            return (BitConverter.ToInt32(Pinvokes.ReadProcess(_myForm.HStarCraft, _myForm.OOffset.CameraY + _myForm.OOffset.Size * playerNum, 4), 0) / 4096);
        }

        //Size is 4 bytes
        public Int32 CameraDistance(Int32 playerNum)
        {
            return (BitConverter.ToInt32(Pinvokes.ReadProcess(_myForm.HStarCraft, _myForm.OOffset.CameraDistance + _myForm.OOffset.Size * playerNum, 4), 0) / 4096);
        }

        //Size is 1 byte
        public Int32 Status(Int32 playerNum)
        {
            return
                Pinvokes.ReadProcess(_myForm.HStarCraft, _myForm.OOffset.Status + _myForm.OOffset.Size * playerNum, 1)[0];
        }

        //Size is 4 bytes
        public Int32 NameLength(Int32 playerNum)
        {
            return (BitConverter.ToInt32(Pinvokes.ReadProcess(_myForm.HStarCraft, _myForm.OOffset.NameLenght + _myForm.OOffset.Size * playerNum, 4), 0));
        }

        //Size is 1 byte + NameLength
        public string Name(Int32 playerNum)
        {
            return (Encoding.UTF8.GetString(Pinvokes.ReadProcess(_myForm.HStarCraft, _myForm.OOffset.Name + _myForm.OOffset.Size * playerNum, NameLength(playerNum))));
        }

        //Size is 4 bytes
        public Color Color(Int32 playerNum)
        {
            var iColor =
                BitConverter.ToInt32(
                    Pinvokes.ReadProcess(_myForm.HStarCraft, _myForm.OOffset.Color + _myForm.OOffset.Size*playerNum, 4),
                    0);

            var strresult = "";


            switch (iColor)
            {
                case 0:
                    strresult = "255,255,255,255";
                    break;
                case 1:
                    strresult = "255,180,20,30";
                    break;
                case 2:
                    strresult = "255,0,66,255";
                    break;
                case 3:
                    strresult = "255,28,166,233";
                    break;
                case 4:
                    strresult = "255,84,0,129";
                    break;
                case 5:
                    strresult = "255,234,224,41";
                    break;
                case 6:
                    strresult = "255,253,138,14";
                    break;
                case 7:
                    strresult = "255,22,128,0";
                    break;
                case 8:
                    strresult = "255,228,91,175";
                    break;
                case 9:
                    strresult = "255,31,1,200";
                    break;
                case 10:
                    strresult = "255,82,84,148";
                    break;
                case 11:
                    strresult = "255,15,97,69";
                    break;
                case 12:
                    strresult = "255,78,41,3";
                    break;
                case 13:
                    strresult = "255,149,255,144";
                    break;
                case 14:
                    strresult = "255,35,35,35";
                    break;
                case 15:
                    strresult = "255,228,91,175";
                    break;
            }

            string[] strendresult = strresult.Split(',');


            var iresult = new Int32[4];

            iresult[0] = Int32.Parse(strendresult[0]);
            iresult[1] = Int32.Parse(strendresult[1]);
            iresult[2] = Int32.Parse(strendresult[2]);
            iresult[3] = Int32.Parse(strendresult[3]);


            return System.Drawing.Color.FromArgb(iresult[0], iresult[1], iresult[2], iresult[3]);
        }

        //Size is 1 byte
        public Int32 Type(Int32 playerNum)
        {
            return
              Pinvokes.ReadProcess(_myForm.HStarCraft, _myForm.OOffset.Playertype + _myForm.OOffset.Size * playerNum,
                                   4)[0];  
        }

        //Size is 4 bytes
        public Int32 Apm(Int32 playerNum)
        {
            return
                (BitConverter.ToInt32(
                    Pinvokes.ReadProcess(_myForm.HStarCraft, _myForm.OOffset.Apm + _myForm.OOffset.Size*playerNum, 4), 0));
        }

        //Size is 4 bytes
        public Int32 Epm(Int32 playerNum)
        {
            return
                (BitConverter.ToInt32(
                    Pinvokes.ReadProcess(_myForm.HStarCraft, _myForm.OOffset.Epm + _myForm.OOffset.Size * playerNum, 4), 0));
        }

        //Size is 4 bytes
        public Int32 Minerals(Int32 playerNum)
        {
            return
                (BitConverter.ToInt32(
                    Pinvokes.ReadProcess(_myForm.HStarCraft, _myForm.OOffset.MineralsCurrent + _myForm.OOffset.Size * playerNum, 4), 0));
        }

        //Size is 4 bytes
        public Int32 Gas(Int32 playerNum)
        {
            return
                (BitConverter.ToInt32(
                    Pinvokes.ReadProcess(_myForm.HStarCraft, _myForm.OOffset.GasCurrent + _myForm.OOffset.Size * playerNum, 4), 0));
        }

        //Size is 4 bytes
        public Int32 MineralsIncome(Int32 playerNum)
        {
            return
                (BitConverter.ToInt32(
                    Pinvokes.ReadProcess(_myForm.HStarCraft, _myForm.OOffset.MineralsIncome + _myForm.OOffset.Size * playerNum, 4), 0));
        }

        //Size is 4 bytes
        public Int32 GasIncome(Int32 playerNum)
        {
            return
                (BitConverter.ToInt32(
                    Pinvokes.ReadProcess(_myForm.HStarCraft, _myForm.OOffset.GasIncome + _myForm.OOffset.Size * playerNum, 4), 0));
        }

        //Size is 4 bytes
        public Int32 MineralsArmy(Int32 playerNum)
        {
            return
                (BitConverter.ToInt32(
                    Pinvokes.ReadProcess(_myForm.HStarCraft, _myForm.OOffset.MineralsArmy + _myForm.OOffset.Size * playerNum, 4), 0));
        }

        //Size is 4 bytes
        public Int32 GasArmy(Int32 playerNum)
        {
            return
                (BitConverter.ToInt32(
                    Pinvokes.ReadProcess(_myForm.HStarCraft, _myForm.OOffset.GasArmy + _myForm.OOffset.Size * playerNum, 4), 0));
        }

        //Size is 4 bytes
        public Int32 SupplyMin(Int32 playerNum)
        {
            return
                (BitConverter.ToInt32(
                    Pinvokes.ReadProcess(_myForm.HStarCraft, _myForm.OOffset.SupplyMin + _myForm.OOffset.Size * playerNum, 4), 0) / 4096);
        }

        //Size is 4 bytes
        public Int32 SupplyMax(Int32 playerNum)
        {
            return
                (BitConverter.ToInt32(
                    Pinvokes.ReadProcess(_myForm.HStarCraft, _myForm.OOffset.SupplyMax + _myForm.OOffset.Size * playerNum, 4), 0) / 4096);
        }

        //Size is 4 bytes
        public Int32 Workers(Int32 playerNum)
        {
            return
                (BitConverter.ToInt32(
                    Pinvokes.ReadProcess(_myForm.HStarCraft, _myForm.OOffset.Workers + _myForm.OOffset.Size * playerNum, 4), 0));
        }

        //Size is 1 byte
        public Int32 Team(Int32 playerNum)
        {
            return
                (
                    Pinvokes.ReadProcess(_myForm.HStarCraft, _myForm.OOffset.Team + _myForm.OOffset.Size*playerNum, 4)
                        [0]) + 1;
        }

        //Size is 4 bytes
        public string Race(Int32 playerNum)
        {
            return
                (Encoding.UTF8.GetString(
                    Pinvokes.ReadProcess(_myForm.HStarCraft, _myForm.OOffset.Race + _myForm.OOffset.RaceSize*playerNum,
                                         4)));
        }

        //Size is 1 byte
        public Int32 LocalPlayer()
        {
            return Pinvokes.ReadProcess(_myForm.HStarCraft, _myForm.OOffset.Localplayer4, 1)[0] - 1;
        }

        //Size is 4 bytes
        public Int32 Playercount()
        {
            var iCount = 0;

            for (var i = 0; i < 64; i++)
            {
                if (NameLength(i) > 0)
                    iCount++;

                else
                    break;
            }

            return iCount;
        }

        //Size is 4 bytes
        public Int32 UnitPosX(Int32 unitNum)
        {
            return
                (BitConverter.ToInt32(
                    Pinvokes.ReadProcess(_myForm.HStarCraft, _myForm.OOffset.UnitPosX + _myForm.OOffset.UnitSize*unitNum,
                                         4), 0)/4096);
        }

        //Size is 4 bytes
        public Int32 UnitPosY(Int32 unitNum)
        {
            return
                (BitConverter.ToInt32(
                    Pinvokes.ReadProcess(_myForm.HStarCraft, _myForm.OOffset.UnitPosY + _myForm.OOffset.UnitSize*unitNum,
                                         4), 0)/4096);
        }

        //Size is 4 bytes
        public Int32 UnitDestPosX(Int32 unitNum)
        {
            return
                (BitConverter.ToInt32(
                    Pinvokes.ReadProcess(_myForm.HStarCraft,
                                         _myForm.OOffset.UnitDestinationX + _myForm.OOffset.UnitSize*unitNum, 4), 0)/
                 4096);
        }

        //Size is 4 bytes
        public Int32 UnitDestPosY(Int32 unitNum)
        {
            return
                (BitConverter.ToInt32(
                    Pinvokes.ReadProcess(_myForm.HStarCraft,
                                         _myForm.OOffset.UnitDestinationY + _myForm.OOffset.UnitSize*unitNum, 4), 0)/
                 4096);
        }

        //Size is 4 bytes
        public Int32 UnitTotal()
        {
            var ver = new Version(_myForm.PStarcraft.MainModule.FileVersionInfo.FileVersion);
            var verDummy = new Version(2, 0, 0, 0);

            if (ver > verDummy)
            {
                /* If the value of the struct address is 0, there is no unit*/
                var iCount = 0;
                while (
                    BitConverter.ToInt32(
                        Pinvokes.ReadProcess(_myForm.HStarCraft,
                                             _myForm.OOffset.StructUnit + _myForm.OOffset.UnitSize*iCount, 4), 0) > 0)
                    iCount++;

                return iCount;
            }


            /* WoL */
            return (BitConverter.ToInt32(Pinvokes.ReadProcess(_myForm.HStarCraft, _myForm.OOffset.UnitTotal, 4), 0));
        }

        //Size is byte
        public Int32 UnitOwner(Int32 unitNum)
        {
            return
                Pinvokes.ReadProcess(_myForm.HStarCraft, _myForm.OOffset.UnitOwner + _myForm.OOffset.UnitSize*unitNum,
                                     4)[0];
        }

        //Size is 4 bytes
        public Int32 UnitState(Int32 unitNum)
        {
            return
                BitConverter.ToInt32(Pinvokes.ReadProcess(_myForm.HStarCraft, _myForm.OOffset.UnitState + _myForm.OOffset.UnitSize * unitNum,
                                     4), 0);
        }

        //Size is 4 bytes
        public Int32 UnitEnergy(Int32 unitNum)
        {
            return
                (BitConverter.ToInt32(
                    Pinvokes.ReadProcess(_myForm.HStarCraft,
                                         _myForm.OOffset.UnitEnergy + _myForm.OOffset.UnitSize * unitNum, 4), 0) /
                 4096);
        }

        //Size is 8 bytes, unsigned
        public UInt64 UnitTargetFilter(Int32 unitNum)
        {
            return
                BitConverter.ToUInt64(Pinvokes.ReadProcess(_myForm.HStarCraft, _myForm.OOffset.UnitTargetFilter + _myForm.OOffset.UnitSize * unitNum,
                                     8), 0);
        }

        //Size is 4 bytes
        public Int32 UnitId(Int32 unitNum)
        {
            var iContentofUnitModel =
                BitConverter.ToInt32(
                    Pinvokes.ReadProcess(_myForm.HStarCraft,
                                         _myForm.OOffset.UnitModel + _myForm.OOffset.UnitSize*unitNum, 4), 0);

            var iContentofUnitModelShifted = (iContentofUnitModel << 5) & 0xFFFFFFFF;

            var id =
                BitConverter.ToInt32(
                    Pinvokes.ReadProcess(_myForm.HStarCraft, _myForm.OOffset.UnitModelId + (int)iContentofUnitModelShifted, 4),
                    0);

            return id;
        }

        //Size is 4 bytes (not safe tbh)
        public float UnitSize(Int32 unitNum)
        {
            var iContentofUnitModel =
                BitConverter.ToInt32(
                    Pinvokes.ReadProcess(_myForm.HStarCraft,
                                         _myForm.OOffset.UnitModel + _myForm.OOffset.UnitSize * unitNum, 4), 0);

            var iContentofUnitModelShifted = (iContentofUnitModel << 5) & 0xFFFFFFFF;


            var size =
                (float)BitConverter.ToInt32(
                    Pinvokes.ReadProcess(_myForm.HStarCraft, _myForm.OOffset.UnitModelSize + (int)iContentofUnitModelShifted, 4),
                    0);

            size /= 4096;

            return size;
        }

        //Size is 4 bytes
        public Int32 MapTop()
        {
            return (BitConverter.ToInt32(Pinvokes.ReadProcess(_myForm.HStarCraft, _myForm.OOffset.MapTop, 4), 0) / 4096);
        }

        //Size is 4 bytes
        public Int32 MapBottom()
        {
            return (BitConverter.ToInt32(Pinvokes.ReadProcess(_myForm.HStarCraft, _myForm.OOffset.MapBottom, 4), 0) / 4096);
        }

        //Size is 4 bytes
        public Int32 MapRight()
        {
            return (BitConverter.ToInt32(Pinvokes.ReadProcess(_myForm.HStarCraft, _myForm.OOffset.MapRight, 4), 0) / 4096);
        }

        //Size is 4 bytes
        public Int32 MapLeft()
        {
            return (BitConverter.ToInt32(Pinvokes.ReadProcess(_myForm.HStarCraft, _myForm.OOffset.MapLeft, 4), 0) / 4096);
        }

        //Size is 4 bytes
        public bool MapIngame()
        {
            return Timer() != 0;
        }

        //Max length is 255
        public string GetChatInput()
        {
            var i1 = BitConverter.ToInt32(Pinvokes.ReadProcess(_myForm.HStarCraft, _myForm.OOffset.ChatBase, 4), 0);
            var i2 = BitConverter.ToInt32(Pinvokes.ReadProcess(_myForm.HStarCraft, _myForm.OOffset.ChatOff0 + i1, 4), 0);
            var i3 = BitConverter.ToInt32(Pinvokes.ReadProcess(_myForm.HStarCraft, _myForm.OOffset.ChatOff1 + i2, 4), 0);
            var i4 = BitConverter.ToInt32(Pinvokes.ReadProcess(_myForm.HStarCraft, _myForm.OOffset.ChatOff2 + i3, 4), 0);
            var i5 = BitConverter.ToInt32(Pinvokes.ReadProcess(_myForm.HStarCraft, _myForm.OOffset.ChatOff3 + i4, 4), 0);
            
            var i6 = i5 + _myForm.OOffset.ChatOff4;    //<-- Result

            return Encoding.UTF8.GetString(Pinvokes.ReadProcess(_myForm.HStarCraft, i6, 255));
            
        }

        //Size is 1 byte
        public Int32 UnitMoveState(Int32 unitNum)
        {
            return
                Pinvokes.ReadProcess(_myForm.HStarCraft,
                                     _myForm.OOffset.UnitMoveState + _myForm.OOffset.UnitSize*unitNum, 1)[0];
        }

        //Size is 1 byte
        public Int32 TeamColor()
        {
            return Pinvokes.ReadProcess(_myForm.HStarCraft, _myForm.OOffset.TeamColor1, 1)[0];
        }

        //Size is 4 byte
        public Int32 Timer()
        {
            return (BitConverter.ToInt32(Pinvokes.ReadProcess(_myForm.HStarCraft, _myForm.OOffset.TimerData, 4), 0)/4096);
        }

        //Size is 4 bytes
        public bool Pause()
        {
            return (BitConverter.ToInt32(Pinvokes.ReadProcess(_myForm.HStarCraft, _myForm.OOffset.PauseEnabled, 4), 0) >
                    0);
        }

        //Size is 4 bytes
        public Typo.Gamespeed Gamespeed()
        {
            var ibuffer = BitConverter.ToInt32(
                Pinvokes.ReadProcess(_myForm.HStarCraft, _myForm.OOffset.Gamespeed, 4), 0);

            if (ibuffer.Equals(426))
                return Typo.Gamespeed.Slower;

            if (ibuffer.Equals(320))
                return Typo.Gamespeed.Slow;

            if (ibuffer.Equals(256))
                return Typo.Gamespeed.Normal;

            if (ibuffer.Equals(213))
                return Typo.Gamespeed.Fast;

            if (ibuffer.Equals(182))
                return Typo.Gamespeed.Faster;

            if (ibuffer.Equals(91))
                return Typo.Gamespeed.Fasterx2;

            if (ibuffer.Equals(45))
                return Typo.Gamespeed.Fasterx4;

            if (ibuffer.Equals(22))
                return Typo.Gamespeed.Fasterx8;

            return Typo.Gamespeed.Normal;
                
            
        }

        //Size if 4 bytes
        public Int32 FramesPerSecond()
        {
            return BitConverter.ToInt32(Pinvokes.ReadProcess(_myForm.HStarCraft, _myForm.OOffset.FramesPerSecond, 4), 0);
        }

        //Size is 1 byte
        public Typo.Gametype Gametype()
        {
            Int32 ibuffer = Pinvokes.ReadProcess(_myForm.HStarCraft, _myForm.OOffset.Gametype, 1)[0];

            if (ibuffer.Equals((int) Typo.Gametype.None))
                return Typo.Gametype.None;

            if (ibuffer.Equals((int)Typo.Gametype.Replay))
                return Typo.Gametype.Replay;

            if (ibuffer.Equals((int)Typo.Gametype.Challange))
                return Typo.Gametype.Challange;

            if (ibuffer.Equals((int)Typo.Gametype.VersusAi))
                return Typo.Gametype.VersusAi;

            if (ibuffer.Equals((int)Typo.Gametype.Ladder))
                return Typo.Gametype.Ladder;

            return Typo.Gametype.None;
        }

        /* This is a more accurate way to get the unitsize
         * Previously, there were some mistakes about certain units
         * This is fixed now. However, unknow units still get fed by 
         * The found size */
        public float UnitSize2(Int32 unitNum)
        {
            var iId = UnitId(unitNum);
            float fSize = 0.0f;

            switch (iId)
            {
                case (int)Typo.UnitId.PuColossus:
                    fSize = 0.75f;
                    break;

                case (int)Typo.UnitId.TbTechlab:
                    fSize = 0.75f;
                    break;

                case (int)Typo.UnitId.TbReactor:
                    fSize = 0.75f;
                    break;

                case (int)Typo.UnitId.ZuInfestedTerran:
                    fSize = 0.5f;
                    break;

                case (int)Typo.UnitId.ZuBanelingCocoon:
                    fSize = 0.5f;
                    break;

                case (int)Typo.UnitId.ZuBaneling:
                    fSize = 0.5f;
                    break;

                case (int)Typo.UnitId.PuMothership:
                    fSize = 1.25f;
                    break;

                case (int)Typo.UnitId.TuPdd:
                    fSize = 0.5f;
                    break;

                case (int)Typo.UnitId.ZuChangeling:
                    fSize = 0.5f;
                    break;

                case (int)Typo.UnitId.ZuChangelingZealot:
                    fSize = 0.5f;
                    break;

                case (int)Typo.UnitId.ZuChangelingMarineShield:
                    fSize = 0.5f;
                    break;

                case (int)Typo.UnitId.ZuChangelingMarine:
                    fSize = 0.5f;
                    break;

                case (int)Typo.UnitId.ZuChangelingSpeedling:
                    fSize = 0.5f;
                    break;

                case (int)Typo.UnitId.ZuChangelingZergling:
                    fSize = 0.5f;
                    break;

                case (int)Typo.UnitId.TbCcGround:
                    fSize = 2.25f;
                    break;

                case (int)Typo.UnitId.TbSupplyGround:
                    fSize = 1.25f;
                    break;

                case (int)Typo.UnitId.TbRefinery:
                    fSize = 1.5f;
                    break;

                case (int)Typo.UnitId.TbBarracksGround:
                    fSize = 1.5f;
                    break;

                case (int)Typo.UnitId.TbEbay:
                    fSize = 1.25f;
                    break;

                case (int)Typo.UnitId.TbTurret:
                    fSize = 0.75f;
                    break;

                case (int)Typo.UnitId.TbBunker:
                    fSize = 1f;
                    break;

                case (int)Typo.UnitId.TbSensortower:
                    fSize = 0.75f;
                    break;

                case (int)Typo.UnitId.TbGhostacademy:
                    fSize = 1.5f;
                    break;

                case (int)Typo.UnitId.TbFactoryGround:
                    fSize = 1.5f;
                    break;

                case (int)Typo.UnitId.TbStarportGround:
                    fSize = 1.5f;
                    break;

                case (int)Typo.UnitId.TbArmory:
                    fSize = 1.25f;
                    break;

                case (int)Typo.UnitId.TbFusioncore:
                    fSize = 1.5f;
                    break;

                case (int)Typo.UnitId.TbAutoTurret:
                    fSize = 0.75f;
                    break;

                case (int)Typo.UnitId.TuSiegetankSieged:
                    fSize = 0.75f;
                    break;

                case (int)Typo.UnitId.TuSiegetank:
                    fSize = 0.75f;
                    break;

                case (int)Typo.UnitId.TuVikingGround:
                    fSize = 0.75f;
                    break;

                case (int)Typo.UnitId.TuVikingAir:
                    fSize = 0.75f;
                    break;

                case (int)Typo.UnitId.TbCcAir:
                    fSize = 2.25f;
                    break;

                case (int)Typo.UnitId.TbTechlabRax:
                    fSize = 0.75f;
                    break;

                case (int)Typo.UnitId.TbReactorRax:
                    fSize = 0.75f;
                    break;

                case (int)Typo.UnitId.TbTechlabFactory:
                    fSize = 0.75f;
                    break;

                case (int)Typo.UnitId.TbReactorFactory:
                    fSize = 0.75f;
                    break;

                case (int)Typo.UnitId.TbTechlabStarport:
                    fSize = 0.75f;
                    break;

                case (int)Typo.UnitId.TbReactorStarport:
                    fSize = 0.75f;
                    break;

                case (int)Typo.UnitId.TbFactoryAir:
                    fSize = 1.5f;
                    break;

                case (int)Typo.UnitId.TbStarportAir:
                    fSize = 1.5f;
                    break;

                case (int)Typo.UnitId.TuScv:
                    fSize = 0.5f;
                    break;

                case (int)Typo.UnitId.TbRaxAir:
                    fSize = 1.5f;
                    break;

                case (int)Typo.UnitId.TbSupplyHidden:
                    fSize = 1.25f;
                    break;

                case (int)Typo.UnitId.TuMarine:
                    fSize = 0.5f;
                    break;

                case (int)Typo.UnitId.TuReaper:
                    fSize = 0.5f;
                    break;

                case (int)Typo.UnitId.TuGhost:
                    fSize = 0.5f;
                    break;

                case (int)Typo.UnitId.TuMarauder:
                    fSize = 0.5f;
                    break;

                case (int)Typo.UnitId.TuThor:
                    fSize = 0.75f;
                    break;

                case (int)Typo.UnitId.TuHellion:
                    fSize = 0.5f;
                    break;

                case (int)Typo.UnitId.TuMedivac:
                    fSize = 0.75f;
                    break;

                case (int)Typo.UnitId.TuBanshee:
                    fSize = 0.75f;
                    break;

                case (int)Typo.UnitId.TuRaven:
                    fSize = 0.75f;
                    break;

                case (int)Typo.UnitId.TuBattlecruiser:
                    fSize = 1.25f;
                    break;

                case (int)Typo.UnitId.PbNexus:
                    fSize = 2.25f;
                    break;

                case (int)Typo.UnitId.PbPylon:
                    fSize = 0.75f;
                    break;

                case (int)Typo.UnitId.PbAssimilator:
                    fSize = 1.5f;
                    break;

                case (int)Typo.UnitId.PbGateway:
                    fSize = 1.5f;
                    break;

                case (int)Typo.UnitId.PbForge:
                    fSize = 1.5f;
                    break;

                case (int)Typo.UnitId.PbFleetbeacon:
                    fSize = 1.5f;
                    break;

                case (int)Typo.UnitId.PbTwilightcouncil:
                    fSize = 1.5f;
                    break;

                case (int)Typo.UnitId.PbCannon:
                    fSize = 0.75f;
                    break;

                case (int)Typo.UnitId.PbStargate:
                    fSize = 1.5f;
                    break;

                case (int)Typo.UnitId.PbTemplararchives:
                    fSize = 1.5f;
                    break;

                case (int)Typo.UnitId.PbDarkshrine:
                    fSize = 1.25f;
                    break;

                case (int)Typo.UnitId.PbRoboticssupportbay:
                    fSize = 1.5f;
                    break;

                case (int)Typo.UnitId.PbRoboticsbay:
                    fSize = 1.5f;
                    break;

                case (int)Typo.UnitId.PbCybercore:
                    fSize = 1.5f;
                    break;

                case (int)Typo.UnitId.PuZealot:
                    fSize = 0.5f;
                    break;

                case (int)Typo.UnitId.PuStalker:
                    fSize = 0.75f;
                    break;

                case (int)Typo.UnitId.PuHightemplar:
                    fSize = 0.5f;
                    break;

                case (int)Typo.UnitId.PuDarktemplar:
                    fSize = 0.5f;
                    break;

                case (int)Typo.UnitId.PuSentry:
                    fSize = 0.5f;
                    break;

                case (int)Typo.UnitId.PuPhoenix:
                    fSize = 0.75f;
                    break;

                case (int)Typo.UnitId.PuCarrier:
                    fSize = 1.25f;
                    break;

                case (int)Typo.UnitId.PuVoidray:
                    fSize = 0.75f;
                    break;

                case (int)Typo.UnitId.PuWarpprismTransport:
                    fSize = 0.75f;
                    break;

                case (int)Typo.UnitId.PuObserver:
                    fSize = 0.5f;
                    break;

                case (int)Typo.UnitId.PuImmortal:
                    fSize = 0.75f;
                    break;

                case (int)Typo.UnitId.PuProbe:
                    fSize = 0.5f;
                    break;

                case (int)Typo.UnitId.PuInterceptor:
                    fSize = 0.5f;
                    break;

                case (int)Typo.UnitId.ZbHatchery:
                    fSize = 2.25f;
                    break;

                case (int)Typo.UnitId.ZbExtractor:
                    fSize = 1.5f;
                    break;

                case (int)Typo.UnitId.ZbSpawningPool:
                    fSize = 1.5f;
                    break;

                case (int)Typo.UnitId.ZbEvolutionChamber:
                    fSize = 1.5f;
                    break;

                case (int)Typo.UnitId.ZbHydraDen:
                    fSize = 1.5f;
                    break;

                case (int)Typo.UnitId.ZbSpire:
                    fSize = 0.75f;
                    break;

                case (int)Typo.UnitId.ZbUltraCavern:
                    fSize = 1.5f;
                    break;

                case (int)Typo.UnitId.ZbInfestationPit:
                    fSize = 1.5f;
                    break;

                case (int)Typo.UnitId.ZbNydusNetwork:
                    fSize = 1.5f;
                    break;

                case (int)Typo.UnitId.ZbBanelingNest:
                    fSize = 1.5f;
                    break;

                case (int)Typo.UnitId.ZbRoachWarren:
                    fSize = 1.5f;
                    break;

                case (int)Typo.UnitId.ZbSpineCrawler:
                    fSize = 0.75f;
                    break;

                case (int)Typo.UnitId.ZbSporeCrawler:
                    fSize = 0.75f;
                    break;

                case (int)Typo.UnitId.ZbLiar:
                    fSize = 2.25f;
                    break;

                case (int)Typo.UnitId.ZbHive:
                    fSize = 2.25f;
                    break;

                case (int)Typo.UnitId.ZbGreaterspire:
                    fSize = 0.75f;
                    break;

                case (int)Typo.UnitId.ZuEgg:
                    fSize = 0.5f;
                    break;

                case (int)Typo.UnitId.ZuDone:
                    fSize = 0.5f;
                    break;

                case (int)Typo.UnitId.ZuZergling:
                    fSize = 0.5f;
                    break;

                case (int)Typo.UnitId.ZuOverlord:
                    fSize = 0.75f;
                    break;

                case (int)Typo.UnitId.ZuHydralisk:
                    fSize = 0.5f;
                    break;

                case (int)Typo.UnitId.ZuMutalisk:
                    fSize = 0.5f;
                    break;

                case (int)Typo.UnitId.ZuUltra:
                    fSize = 0.75f;
                    break;

                case (int)Typo.UnitId.ZuRoach:
                    fSize = 0.5f;
                    break;

                case (int)Typo.UnitId.ZuInfestor:
                    fSize = 0.75f;
                    break;

                case (int)Typo.UnitId.ZuCorruptor:
                    fSize = 0.75f;
                    break;

                case (int)Typo.UnitId.ZuBroodlordCocoon:
                    fSize = 0.75f;
                    break;

                case (int)Typo.UnitId.ZuBroodlord:
                    fSize = 0.75f;
                    break;

                case (int)Typo.UnitId.ZuBanelingBurrow:
                    fSize = 0.5f;
                    break;

                case (int)Typo.UnitId.ZuDroneBurrow:
                    fSize = 0.5f;
                    break;

                case (int)Typo.UnitId.ZuHydraBurrow:
                    fSize = 0.5f;
                    break;

                case (int)Typo.UnitId.ZuRoachBurrow:
                    fSize = 0.5f;
                    break;

                case (int)Typo.UnitId.ZuZerglingBurrow:
                    fSize = 0.5f;
                    break;

                case (int)Typo.UnitId.ZuInfestedTerran2:
                    fSize = 0.5f;
                    break;

                case (int)Typo.UnitId.ZuQueenBurrow:
                    fSize = 0.75f;
                    break;

                case (int)Typo.UnitId.ZuQueen:
                    fSize = 0.75f;
                    break;

                case (int)Typo.UnitId.ZuInfestorBurrow:
                    fSize = 0.75f;
                    break;

                case (int)Typo.UnitId.ZuOverseerCocoon:
                    fSize = 0.75f;
                    break;

                case (int)Typo.UnitId.ZuOverseer:
                    fSize = 0.75f;
                    break;

                case (int)Typo.UnitId.TbPlanetary:
                    fSize = 2.25f;
                    break;

                case (int)Typo.UnitId.ZuUltraBurrow:
                    fSize = 0.75f;
                    break;

                case (int)Typo.UnitId.TbOrbitalGround:
                    fSize = 2.25f;
                    break;

                case (int)Typo.UnitId.PbWarpgate:
                    fSize = 1.5f;
                    break;

                case (int)Typo.UnitId.TbOrbitalAir:
                    fSize = 2.25f;
                    break;

                case (int)Typo.UnitId.PuWarpprismPhase:
                    fSize = 0.75f;
                    break;

                case (int)Typo.UnitId.ZbCreeptumor:
                    fSize = 0.75f;
                    break;

                case (int)Typo.UnitId.ZbSpineCrawlerUnrooted:
                    fSize = 0.75f;
                    break;

                case (int)Typo.UnitId.ZbSporeCrawlerUnrooted:
                    fSize = 0.75f;
                    break;

                case (int)Typo.UnitId.PuArchon:
                    fSize = 0.75f;
                    break;

                case (int)Typo.UnitId.ZbNydusWorm:
                    fSize = 0.75f;
                    break;

                case (int)Typo.UnitId.ZuBroodlordEscort:
                    fSize = 0.5f;
                    break;

                case (int)Typo.UnitId.ZuInfestedSwarmEgg:
                    fSize = 0.5f;
                    break;

                case (int)Typo.UnitId.ZuLarva:
                    fSize = 0.5f;
                    break;

                case (int)Typo.UnitId.TuMule:
                    fSize = 0.5f;
                    break;

                case (int)Typo.UnitId.ZuBroodling:
                    fSize = 0.5f;
                    break;

                default:
                    fSize = UnitSize(unitNum);
                    break;
            }

            return fSize;
        }
    }
}
