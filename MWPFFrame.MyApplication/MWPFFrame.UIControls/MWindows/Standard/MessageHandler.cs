using System;

namespace MWPFFrame.UIControls.Standard
{
    internal delegate IntPtr MessageHandler(WM uMsg, IntPtr wParam, IntPtr lParam, out bool handled);
}
