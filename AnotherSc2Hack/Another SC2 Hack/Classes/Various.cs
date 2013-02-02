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

            if (iWidth >= 1920 - 10 && iWidth < 1920 + 10 &&
                iHeidth >= 1080 - 10 && iHeidth < 1080 + 10)
            {
                //Do nothing
            }

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
            }
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
    }
}
