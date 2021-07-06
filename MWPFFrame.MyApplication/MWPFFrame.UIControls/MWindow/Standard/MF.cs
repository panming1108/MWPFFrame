using System;

namespace MWPFFrame.UIControls.Standard
{
    [Flags]
    internal enum MF : uint
    {
        DOES_NOT_EXIST = uint.MaxValue,
        ENABLED = 0x0,
        BYCOMMAND = 0x0,
        GRAYED = 0x1,
        DISABLED = 0x2
    }
}
