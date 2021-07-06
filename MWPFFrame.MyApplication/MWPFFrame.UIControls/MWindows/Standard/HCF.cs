using System;

namespace MWPFFrame.UIControls.Standard
{
    [Flags]
    internal enum HCF
    {
        HIGHCONTRASTON = 0x1,
        AVAILABLE = 0x2,
        HOTKEYACTIVE = 0x4,
        CONFIRMHOTKEY = 0x8,
        HOTKEYSOUND = 0x10,
        INDICATOR = 0x20,
        HOTKEYAVAILABLE = 0x40
    }
}
