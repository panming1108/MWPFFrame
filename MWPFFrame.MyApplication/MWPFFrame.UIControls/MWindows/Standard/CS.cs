﻿using System;

namespace MWPFFrame.UIControls.Standard
{
    [Flags]
    internal enum CS : uint
    {
        VREDRAW = 0x1,
        HREDRAW = 0x2,
        DBLCLKS = 0x8,
        OWNDC = 0x20,
        CLASSDC = 0x40,
        PARENTDC = 0x80,
        NOCLOSE = 0x200,
        SAVEBITS = 0x800,
        BYTEALIGNCLIENT = 0x1000,
        BYTEALIGNWINDOW = 0x2000,
        GLOBALCLASS = 0x4000,
        IME = 0x10000,
        DROPSHADOW = 0x20000
    }
}
