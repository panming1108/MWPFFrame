using System;

namespace MWPFFrame.UIControls.Standard
{
    [Flags]
    internal enum WTNCA : uint
    {
        NODRAWCAPTION = 0x1,
        NODRAWICON = 0x2,
        NOSYSMENU = 0x4,
        NOMIRRORHELP = 0x8,
        VALIDBITS = 0xF
    }
}
