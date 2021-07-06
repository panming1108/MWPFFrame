﻿namespace MWPFFrame.UIControls.Standard
{
    internal enum FOF : ushort
    {
        MULTIDESTFILES = 1,
        CONFIRMMOUSE = 2,
        SILENT = 4,
        RENAMEONCOLLISION = 8,
        NOCONFIRMATION = 0x10,
        WANTMAPPINGHANDLE = 0x20,
        ALLOWUNDO = 0x40,
        FILESONLY = 0x80,
        SIMPLEPROGRESS = 0x100,
        NOCONFIRMMKDIR = 0x200,
        NOERRORUI = 0x400,
        NOCOPYSECURITYATTRIBS = 0x800,
        NORECURSION = 0x1000,
        NO_CONNECTED_ELEMENTS = 0x2000,
        WANTNUKEWARNING = 0x4000,
        NORECURSEREPARSE = 0x8000
    }
}
