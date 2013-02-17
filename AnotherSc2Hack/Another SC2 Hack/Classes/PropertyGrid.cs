using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Another_SC2_Hack.Classes
{
    class PropertyGrid1
    {
        /// <summary>
        // Customer class to be displayed in the property grid
        /// </summary>
        /// 
        [DefaultPropertyAttribute("Name")]
        public class Unit
        {
            string[] strUnit = new string[70];
            bool[]bUnit = new bool[70];

            [CategoryAttribute("Protoss"), DescriptionAttribute("Enable warning for this unit")]
            public bool Probe
            {
                get
                {
                    return bUnit[0];
                }
                set
                {
                    bUnit[0] = value;
                }
            }

            [CategoryAttribute("Protoss"), DescriptionAttribute("Enable warning for this unit")]
            public bool Zealot
            {
                get
                {
                    return bUnit[1];
                }
                set
                {
                    bUnit[1] = value;
                }
            }

            [CategoryAttribute("Protoss"), DescriptionAttribute("Enable warning for this unit")]
            public bool Stalker
            {
                get
                {
                    return bUnit[2];
                }
                set
                {
                    bUnit[2] = value;
                }
            }

           
        } 
    }
}
