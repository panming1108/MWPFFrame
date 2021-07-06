using System;

namespace MWPFFrame.UIControls.Standard
{
    [Flags]
    internal enum NIF : uint
    {
        MESSAGE = 0x1,
        ICON = 0x2,
        TIP = 0x4,
        STATE = 0x8,
        INFO = 0x10,
        GUID = 0x20,
        REALTIME = 0x40,
        SHOWTIP = 0x80,
        XP_MASK = 0x3B,
        VISTA_MASK = 0xFB
    }
}
