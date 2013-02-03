using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using Another_SC2_Hack.Forms;

namespace Another_SC2_Hack.Classes
{
    class Various
    {
        public static void InitResolution(MainForm frm)
        {
            Int32 iWidth = Screen.PrimaryScreen.Bounds.Width,
                  iHeidth = Screen.PrimaryScreen.Bounds.Height;

            #region 1920x1080

            if (iWidth >= 1920 - 10 && iWidth < 1920 + 10 &&
                iHeidth >= 1080 - 10 && iHeidth < 1080 + 10)
            {
                frm._iResWidth = 550;
                frm._iIncWidth = 550;
                frm._iArmWidth = 550;
                frm._iApmWidth = 550;
                frm._iWorWidth = 150;
                frm._iMapWidth = 262;


                frm._iResHeigth = 40;
                frm._iIncHeigth = 40;
                frm._iArmHeigth = 40;
                frm._iApmHeigth = 40;
                frm._iWorHeigth = 40;
                frm._iMapHeigth = 258;


                frm._iResX = 1312;
                frm._iIncX = 1316;
                frm._iArmX = 1317;
                frm._iApmX = 5;
                frm._iWorX = 1319;
                frm._iMapX = 28;


                frm._iResY = 44;
                frm._iIncY = 328;
                frm._iArmY = 629;
                frm._iApmY = 64;
                frm._iWorY = 826;
                frm._iMapY = 808;
                
            }

            #endregion

            #region 1680x1050

            else if (iWidth >= 1680 - 10 && iWidth < 1680 + 10 &&
                     iHeidth >= 1050 - 10 && iHeidth < 1050 + 10)
            {
                frm._iResX = 1144;
                frm._iResY = 72;
                frm._iResWidth = 501;
                frm._iResHeigth = 36;

                frm._iIncX = 1144;
                frm._iIncY = 279;
                frm._iIncWidth = 501;
                frm._iIncHeigth = 36;

                frm._iWorX = 1031;
                frm._iWorY = 859;
                frm._iWorWidth = 103;
                frm._iWorHeigth = 30;

                frm._iMapX = 26;
                frm._iMapY = 787;
                frm._iMapWidth = 254;
                frm._iMapHeigth = 250;

                frm._iArmX = 1144;
                frm._iArmY = 288;
                frm._iArmWidth = 501;
                frm._iArmHeigth = 36;

                frm._iApmX = 7;
                frm._iApmY = 70;
                frm._iApmWidth = 515;
                frm._iApmHeigth = 36;
            }

            #endregion

            #region 1600x900

            else if (iWidth >= 1600 - 10 && iWidth < 1600 + 10 &&
                     iHeidth >= 900 - 10 && iHeidth < 900 + 10)
            {
                frm._iResX = 1146;
                frm._iResY = 61;
                frm._iResWidth = 419;
                frm._iResHeigth = 30;

                frm._iIncX = 1146;
                frm._iIncY = 171;
                frm._iIncWidth = 419;
                frm._iIncHeigth = 30;

                frm._iWorX = 1033;
                frm._iWorY = 732;
                frm._iWorWidth = 103;
                frm._iWorHeigth = 30;

                frm._iMapX = 24;
                frm._iMapY = 674;
                frm._iMapWidth = 218;
                frm._iMapHeigth = 214;

                frm._iArmX = 1146;
                frm._iArmY = 288;
                frm._iArmWidth = 419;
                frm._iArmHeigth = 30;

                frm._iApmX = 3;
                frm._iApmY = 67;
                frm._iApmWidth = 405;
                frm._iApmHeigth = 29;
            }

            #endregion

            #region 1440x900

            else if (iWidth >= 1440 - 10 && iWidth < 1440 + 10 &&
                     iHeidth >= 900 - 10 && iHeidth < 900 + 10)
            {
                frm._iResX = 985;
                frm._iResY = 62;
                frm._iResWidth = 419;
                frm._iResHeigth = 30;

                frm._iIncX = 985;
                frm._iIncY = 128;
                frm._iIncWidth = 419;
                frm._iIncHeigth = 30;

                frm._iWorX = 874;
                frm._iWorY = 732;
                frm._iWorWidth = 103;
                frm._iWorHeigth = 30;

                frm._iMapX = 24;
                frm._iMapY = 674;
                frm._iMapWidth = 218;
                frm._iMapHeigth = 214;

                frm._iArmX = 985;
                frm._iArmY = 198;
                frm._iArmWidth = 419;
                frm._iArmHeigth = 30;

                frm._iApmX = 3;
                frm._iApmY = 80;
                frm._iApmWidth = 405;
                frm._iApmHeigth = 30;
            }

            #endregion

            #region 1400x1050

            else if (iWidth >= 1400 - 10 && iWidth < 1400 + 10 &&
                     iHeidth >= 1050 - 10 && iHeidth < 1050 + 10)
            {
                frm._iResX = 878;
                frm._iResY = 73;
                frm._iResWidth = 474;
                frm._iResHeigth = 34;

                frm._iIncX = 878;
                frm._iIncY = 162;
                frm._iIncWidth = 474;
                frm._iIncHeigth = 34;

                frm._iWorX = 722;
                frm._iWorY = 858;
                frm._iWorWidth = 137;
                frm._iWorHeigth = 40;

                frm._iMapX = 27;
                frm._iMapY = 787;
                frm._iMapWidth = 252;
                frm._iMapHeigth = 248;

                frm._iArmX = 878;
                frm._iArmY = 261;
                frm._iArmWidth = 474;
                frm._iArmHeigth = 34;

                frm._iApmX = 12;
                frm._iApmY = 77;
                frm._iApmWidth = 460;
                frm._iApmHeigth = 33;
            }

            #endregion

            #region 1366x768

            else if (iWidth >= 1366 - 10 && iWidth < 1366 + 10 &&
                     iHeidth >= 768 - 10 && iHeidth < 768 + 10)
            {
                frm._iResX = 970;
                frm._iResY = 52;
                frm._iResWidth = 378;
                frm._iResHeigth = 27;

                frm._iIncX = 970;
                frm._iIncY = 111;
                frm._iIncWidth = 378;
                frm._iIncHeigth = 27;

                frm._iWorX = 868;
                frm._iWorY = 627;
                frm._iWorWidth = 103;
                frm._iWorHeigth = 30;

                frm._iMapX = 26;
                frm._iMapY = 574;
                frm._iMapWidth = 187;
                frm._iMapHeigth = 183;

                frm._iArmX = 970;
                frm._iArmY = 163;
                frm._iArmWidth = 378;
                frm._iArmHeigth = 27;

                frm._iApmX = 2;
                frm._iApmY = 73;
                frm._iApmWidth = 378;
                frm._iApmHeigth = 27;
            }        

            #endregion

            #region 1360x1024

            else if (iWidth >= 1360 - 10 && iWidth < 1360 + 10 &&
                     iHeidth >= 1024 - 10 && iHeidth < 1024 + 10)
            {
                frm._iResX = 848;
                frm._iResY = 70;
                frm._iResWidth = 474;
                frm._iResHeigth = 35;

                frm._iIncX = 848;
                frm._iIncY = 160;
                frm._iIncWidth = 474;
                frm._iIncHeigth = 35;

                frm._iWorX = 701;
                frm._iWorY = 835;
                frm._iWorWidth = 137;
                frm._iWorHeigth = 40;

                frm._iMapX = 25;
                frm._iMapY = 766;
                frm._iMapWidth = 249;
                frm._iMapHeigth = 244;

                frm._iArmX = 848;
                frm._iArmY = 247;
                frm._iArmWidth = 474;
                frm._iArmHeigth = 35;

                frm._iApmX = 1;
                frm._iApmY = 85;
                frm._iApmWidth = 488;
                frm._iApmHeigth = 35;
            }

            #endregion

            #region 1280x720

            else if (iWidth >= 1280 - 10 && iWidth < 1280 + 10 &&
                     iHeidth >= 720 - 10 && iHeidth < 720 + 10)
            {
                frm._iResX = 906;
                frm._iResY = 49;
                frm._iResWidth = 364;
                frm._iResHeigth = 26;

                frm._iIncX = 906;
                frm._iIncY = 107;
                frm._iIncWidth = 364;
                frm._iIncHeigth = 26;

                frm._iWorX = 806;
                frm._iWorY = 586;
                frm._iWorWidth = 103;
                frm._iWorHeigth = 30;

                frm._iMapX = 17;
                frm._iMapY = 540;
                frm._iMapWidth = 178;
                frm._iMapHeigth = 171;

                frm._iArmX = 906;
                frm._iArmY = 170;
                frm._iArmWidth = 364;
                frm._iArmHeigth = 26;

                frm._iApmX = 9;
                frm._iApmY = 127;
                frm._iApmWidth = 378;
                frm._iApmHeigth = 27;
            }

            #endregion

            #region Any other resolution

            else
            {
                frm._iResX = 0;
                frm._iResY = 0;

                frm._iIncX = 0;
                frm._iIncY = 0;

                frm._iWorX = 0;
                frm._iWorY = 0;

                frm._iApmX = 0;
                frm._iApmY = 0;

                frm._iMapX = 0;
                frm._iMapY = 0;

                frm._iArmX = 0;
                frm._iArmY = 0;

                MessageBox.Show("Your reoslution is not supported!\nBut I changed the position anyway!", "RESOLUTION");
            }

            #endregion

            MessageBox.Show("Panel's size and position\n" +
                            "were adjusted successful!", "Success!");
        }

        /*** Prooves the resolution (based on the Primary Screen) ***/
        public static bool CheckResolution()
        {
            /* Supported Resolutions: 
             * 1920x1080 
             * 1680x1050
             * 1600x900
             * 1440x900
             * 1400x1050
             * 1366x768
             * 1360x1024
             * 1280x720  */

            Int32 iWidth = Screen.PrimaryScreen.Bounds.Width,
                  iHeigth = Screen.PrimaryScreen.Bounds.Height;

            
            if (iWidth > 1920 - 10 && iWidth < 1920 + 10 &&
                iHeigth > 1080 - 10 && iHeigth < 1080 + 10)
                return true;

            if (iWidth > 1680 - 10 && iWidth < 1680 + 10 &&
                iHeigth > 1050 - 10 && iHeigth < 1050 + 10)
                return true;

            if (iWidth > 1600 - 10 && iWidth < 1600 + 10 &&
                iHeigth > 900 - 10 && iHeigth < 900 + 10)
                return true;

            if (iWidth > 1440 - 10 && iWidth < 1440 + 10 &&
                iHeigth > 900 - 10 && iHeigth < 900 + 10)
                return true;

            if (iWidth > 1400 - 10 && iWidth < 1400 + 10 &&
                iHeigth > 1050 - 10 && iHeigth < 1050 + 10)
                return true;

            if (iWidth > 1366 - 10 && iWidth < 1366 + 10 &&
                iHeigth > 768 - 10 && iHeigth < 768 + 10)
                return true;

            if (iWidth > 1360 - 10 && iWidth < 1360 + 10 &&
                iHeigth > 1024 - 10 && iHeigth < 1024 + 10)
                return true;

            if (iWidth > 1280 - 10 && iWidth < 1280 + 10 &&
                iHeigth > 720 - 10 && iHeigth < 720 + 10)
                return true;

            return false;







        }

        /*** Check if SC2 is available ***/
        public static bool StarcraftAvailable()
        {
            var procs = Process.GetProcesses();

            foreach (var process in procs)
            {
                if (process.ProcessName.Equals("SC2"))
                    return true;
            }

            return false;
        }

        /*** Throws a little message ***/
        public static void ThrowCustomException(Exception ex, string strWhere)
        {
            /* Writing an error- report */
            MessageBox.Show("Error in the tool! Please post this!\n" +
                            "In which Method: " + strWhere + "\n" +
            "In which line: " + ex.Source + "\n" + 
            "Message: " + ex.Message + "\n" + 
            "Data: " + ex.Data + "\n" + 
            "Starcraft Loaded: " + StarcraftAvailable().ToString(), "ERROR EXCEPTION");
        }

        /*** Print out the supported resolutions using a messagebox ***/
        public static void PrintResolutionMessage()
        {
            MessageBox.Show("Supported Resolutions:\n\n" +
                            "1920x1080\n" +
                            "1680x1050\n" +
                            "1600x900\n" +
                            "1440x900\n" +
                            "1400x1050\n" +
                            "1366x768\n" +
                            "1360x1024\n" +
                            "1280x720", "Resolutions");
        }
    }
}
