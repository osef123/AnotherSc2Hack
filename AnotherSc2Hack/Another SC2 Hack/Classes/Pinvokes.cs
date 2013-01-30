using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Another_SC2_Hack.Classes
{
    class Pinvokes
    {
        public static byte[] ReadProcess(IntPtr hProcess, int address, int size)
        {
            var buffer = new byte[size];

            IntPtr bytesRead;

            ReadProcessMemory(hProcess, (IntPtr)address, buffer, (uint) size, out bytesRead);


            return buffer;
        }

        /// <summary>
        /// Sends a Keypress to a specific handle
        /// </summary>
        /// <param name="handle">The target handle</param>
        /// <param name="vkey">The Actual key you want to simulate</param>
        /// <param name="times">How many times you want to simulate that keypress</param>
        public static void SimulateCompleteKeypress(IntPtr handle, Keys vkey, int times)
        {
            for (var i = 0; i < times; i++)
            {

                /* KeyDown */
                SendMessage(handle, WM_KEYDOWN, (IntPtr)vkey, IntPtr.Zero);

                /* KeyUp */
                SendMessage(handle, WM_KEYUP, (IntPtr)vkey, IntPtr.Zero);


                System.Threading.Thread.Sleep(10);
            }
        }

        [DllImport("kernel32.dll")]
        public static extern Int32 ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [In, Out] byte[] buffer, UInt32 size, out IntPtr lpNumberOfBytesRead);

        [DllImport("kernel32.dll")]
        public static extern Int32 CloseHandle(IntPtr hObject);

        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(UInt32 dwDesiredAccess, Int32 bInheritHandle, UInt32 dwProcessId);

        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(Keys vkey);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, UInt32 msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", SetLastError = true)]
        public static extern UInt32 GetWindowLong(IntPtr hWnd, int nIndex);
        
        [DllImport("user32.dll")]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr SetActiveWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll", EntryPoint = "GetWindowLong")]
        public static extern IntPtr GetWindowLongPtr(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll", EntryPoint = "SetWindowLong")]
        public static extern int SetWindowLong32(HandleRef hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll", EntryPoint = "SetWindowLongPtr")]
        public static extern IntPtr SetWindowLongPtr64(HandleRef hWnd, int nIndex, IntPtr dwNewLong);

        [DllImport("user32.dll")]
        public static extern bool DrawMenuBar(IntPtr hWnd);

        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int y, int cx, int cy, int wFlags);

        [DllImport("user32.dll")]
        public static extern IntPtr GetActiveWindow();

        public const uint PROCESS_VM_READ = (0x0010);
        public const uint WM_KEYDOWN = (0x0100);
        public const uint WM_KEYUP = (0x101);
        public const uint VM_ENTER = (0x000D);
        public const uint VM_ESCAPE = (0x001B);
        public const int GWL_EXSTYLE = -20;
        public const int WS_EX_LAYERED = 0x80000;
        public const int WS_EX_TRANSPARENT = 0x20;
        public const int LWA_ALPHA = 0x2;
        public const int LWA_COLORKEY = 0x1;
        public const int GWL_STYLE = -16;              //hex constant for style changing
        public const int WS_BORDER = 0x00800000;       //window with border
        public const int WS_CAPTION = 0x00C00000;      //window with a title bar
        public const int WS_SYSMENU = 0x00080000;      //window with no borders etc.
        public const int WS_MINIMIZEBOX = 0x00020000;  //window with minimizebox
    }
}
