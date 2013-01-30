using System;
using System.Collections.Generic;
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
    }
}
