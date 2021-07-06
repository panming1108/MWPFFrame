using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MWPFFrame.UIControls.Standard
{
    internal enum Status
    {
        Ok,
        GenericError,
        InvalidParameter,
        OutOfMemory,
        ObjectBusy,
        InsufficientBuffer,
        NotImplemented,
        Win32Error,
        WrongState,
        Aborted,
        FileNotFound,
        ValueOverflow,
        AccessDenied,
        UnknownImageFormat,
        FontFamilyNotFound,
        FontStyleNotFound,
        NotTrueTypeFont,
        UnsupportedGdiplusVersion,
        GdiplusNotInitialized,
        PropertyNotFound,
        PropertyNotSupported,
        ProfileNotFound
    }
}
