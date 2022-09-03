using System;
using System.Windows.Forms;

namespace GameManager {
    /// <summary>
    /// A standard tab control with its tabs hidden.
    /// </summary>
    class TablessControl : TabControl {
        protected override void WndProc(ref Message m) {
            //Hide tabs by trapping the TCM_ADJUSTRECT message
            if (m.Msg == 0x1328 && !DesignMode) {
                m.Result = (IntPtr)1;
            }
            else {
                base.WndProc(ref m);
            }
        }
    }
}
