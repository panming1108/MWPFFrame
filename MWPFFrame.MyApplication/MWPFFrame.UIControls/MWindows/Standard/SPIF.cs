using System;

namespace MWPFFrame.UIControls.Standard
{
    [Flags]
    internal enum SPIF
    {
        None = 0x0,
        UPDATEINIFILE = 0x1,
        SENDCHANGE = 0x2,
        SENDWININICHANGE = 0x2
    }
}
