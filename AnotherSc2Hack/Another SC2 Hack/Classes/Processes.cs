using System;
using System.Diagnostics;

namespace Another_SC2_Hack.Classes
{
    class Processes
    {
        public IntPtr Starcraft = IntPtr.Zero;

        public IntPtr HandleStacraft(Process proc)
        {
            Starcraft = Pinvokes.OpenProcess(Pinvokes.PROCESS_VM_READ, 1, (uint) proc.Id);
            return Starcraft;
        }

        public IntPtr GetHandle
        {
            get { return Starcraft; }
        }


    }
}
