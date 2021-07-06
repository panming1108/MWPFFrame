using System;

namespace MWPFFrame.UIControls.Standard
{
    [Flags]
    internal enum SWP
    {
        ASYNCWINDOWPOS = 0x4000,
        DEFERERASE = 0x2000,
        DRAWFRAME = 0x20,
        FRAMECHANGED = 0x20,
        HIDEWINDOW = 0x80,
        NOACTIVATE = 0x10,
        NOCOPYBITS = 0x100,
        NOMOVE = 0x2,
        NOOWNERZORDER = 0x200,
        NOREDRAW = 0x8,
        NOREPOSITION = 0x200,
        NOSENDCHANGING = 0x400,
        NOSIZE = 0x1,
        NOZORDER = 0x4,
        SHOWWINDOW = 0x40
    }
}
