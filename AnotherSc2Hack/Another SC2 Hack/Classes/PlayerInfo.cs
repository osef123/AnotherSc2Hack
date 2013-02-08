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
    }
}
