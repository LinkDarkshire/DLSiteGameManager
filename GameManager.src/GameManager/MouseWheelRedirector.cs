using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace GameManager {
    /// <summary>
    /// A message filter that redirects mouse wheel events to the control under the cursor.
    /// </summary>
    public class MouseWheelRedirector : IMessageFilter {
        public bool PreFilterMessage(ref Message m) {
            const int WM_MOUSEWHEEL = 0x020A;
            const int WM_MOUSEHWHEEL = 0x020E;

            switch (m.Msg) {
                case WM_MOUSEWHEEL:
                case WM_MOUSEHWHEEL:
                    IntPtr hControlUnderMouse = WindowFromPoint(new Point((int)m.LParam));

                    if (hControlUnderMouse == m.HWnd) {
                        //The message is already going to the correct control
                        return false;
                    }
                    else {
                        //Redirect message to the control under the cursor
                        SendMessage(hControlUnderMouse, m.Msg, m.WParam, m.LParam);
                        return true;
                    }
                default:
                    return false;
            }
        }

        [DllImport("user32.dll")]
        private static extern IntPtr WindowFromPoint(Point p);

        [DllImport("user32.dll", SetLastError = false)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
    }
}
