using System;
using System.Runtime.InteropServices;

namespace RMS.UserControls
{
    public class Win32
    {
        public enum Bool
        {
            False = 0,
            True
        };


        [StructLayout(LayoutKind.Sequential)]
        public struct Point
        {
            public Int32 x;
            public Int32 y;

            public Point(Int32 x, Int32 y)
            {
                this.x = x;
                this.y = y;
            }
        }


        [StructLayout(LayoutKind.Sequential)]
        public struct Size
        {
            public Int32 cx;
            public Int32 cy;

            public Size(Int32 cx, Int32 cy)
            {
                this.cx = cx;
                this.cy = cy;
            }
        }


        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        struct ARGB
        {
            public byte Blue;
            public byte Green;
            public byte Red;
            public byte Alpha;
        }


        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct BLENDFUNCTION
        {
            public byte BlendOp;
            public byte BlendFlags;
            public byte SourceConstantAlpha;
            public byte AlphaFormat;
        }




        public const byte AC_SRC_OVER = 0x00;
        public const byte AC_SRC_ALPHA = 0x01;
        public const Int32 ULW_COLORKEY = 0x00000001;
        public const Int32 ULW_ALPHA = 0x00000002;
        public const Int32 ULW_OPAQUE = 0x00000004;
        public const Int32 AW_HOR_POSITIVE = 0x00000001;
        public const Int32 AW_HOR_NEGATIVE = 0x00000002;
        public const Int32 AW_VER_POSITIVE = 0x00000004;
        public const Int32 AW_VER_NEGATIVE = 0x00000008;
        public const Int32 AW_CENTER = 0x00000010;
        public const Int32 AW_HIDE = 0x00010000;
        public const Int32 AW_ACTIVATE = 0x00020000;
        public const Int32 AW_SLIDE = 0x00040000;
        public const Int32 AW_BLEND = 0x00080000;
        public const Int32 GWL_EXSTYLE = -20;
        public const Int32 LWA_COLORKEY = 0x01;
        public const Int32 LWA_ALPHA = 0x02;
        public const Int32 WS_EX_LAYERED = 0x00080000;
        public const Int32 WS_EX_TRANSPARENT = 0x20;

        // mouse events
        public const Int32 WM_MOUSEFIRST = 0x0200;
        public const Int32 WM_MOUSEMOVE = 0x0200;
        public const Int32 WM_LBUTTONDOWN = 0x0201;
        public const Int32 WM_LBUTTONUP = 0x0202;
        public const Int32 WM_LBUTTONDBLCLK = 0x0203;
        public const Int32 WM_RBUTTONDOWN = 0x0204;
        public const Int32 WM_RBUTTONUP = 0x0205;
        public const Int32 WM_RBUTTONDBLCLK = 0x0206;
        public const Int32 WM_MBUTTONDOWN = 0x0207;
        public const Int32 WM_MBUTTONUP = 0x0208;
        public const Int32 WM_MBUTTONDBLCLK = 0x0209;

        public const Int32 WM_NCMOUSEMOVE = 0x00A0;
        public const Int32 WM_NCLBUTTONDOWN = 0x00A1;
        public const Int32 WM_NCLBUTTONUP = 0x00A2;
        public const Int32 WM_NCLBUTTONDBLCLK = 0x00A3;
        public const Int32 WM_NCRBUTTONDOWN = 0x00A4;
        public const Int32 WM_NCRBUTTONUP = 0x00A5;
        public const Int32 WM_NCRBUTTONDBLCLK = 0x00A6;
        public const Int32 WM_NCMBUTTONDOWN = 0x00A7;
        public const Int32 WM_NCMBUTTONUP = 0x00A8;
        public const Int32 WM_NCMBUTTONDBLCLK = 0x00A9;

        // window possitions
        public const Int32 HWND_TOP = 0;
        public const Int32 HWND_BOTTOM = 1;
        public const Int32 HWND_TOPMOST = -1;
        public const Int32 HWND_NOTOPMOST = -2;

        public const Int32 SWP_NOACTIVATE = 0x0010;

        // ShowWindow()
        public const Int32 SW_SHOWNOACTIVATE = 4;

        [DllImport("user32.dll", ExactSpelling = true)]
        public static extern Boolean AnimateWindow(IntPtr hWnd, long dwTime, long dwFlags);

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern Bool UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst, ref Point pptDst, ref Size psize, IntPtr hdcSrc, ref Point pprSrc, Int32 crKey, ref BLENDFUNCTION pblend, Int32 dwFlags);

        [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport("user32.dll", ExactSpelling = true)]
        public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr CreateCompatibleDC(IntPtr hDC);

        [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern Bool DeleteDC(IntPtr hdc);

        [DllImport("gdi32.dll", ExactSpelling = true)]
        public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);

        [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern Bool DeleteObject(IntPtr hObject);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern int SetLayeredWindowAttributes(IntPtr hWnd, Int32 crKey, byte bAlpha, Int32 dwFlags);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool GetLayeredWindowAttributes(IntPtr hWnd, IntPtr crKey, IntPtr bAlpha, IntPtr dwFlags);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int width, int height, UInt32 uFlags);

        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, Int32 flags);

        public static long SetOpacity(IntPtr hWnd, byte opacity)
        {
            Int32 msg;
            try
            {

                msg = GetWindowLong(hWnd, GWL_EXSTYLE);
                msg |= WS_EX_LAYERED;
                SetWindowLong(hWnd, GWL_EXSTYLE, msg);
                SetLayeredWindowAttributes(hWnd, 0, opacity, LWA_ALPHA);
                return 0;
            }
            catch
            {
                return 2;
            }


        }

        public static byte GetOpacity(IntPtr hWnd)
        {
            IntPtr crKey = IntPtr.Zero;
            IntPtr bAlpha = IntPtr.Zero;
            IntPtr dwFlags = IntPtr.Zero;
            //SetWindowLong(hWnd, GWL_EXSTYLE, msg);
            bool t = GetLayeredWindowAttributes(hWnd, crKey, bAlpha, dwFlags);

            return Convert.ToByte(dwFlags.ToString());
        }
    }
}
