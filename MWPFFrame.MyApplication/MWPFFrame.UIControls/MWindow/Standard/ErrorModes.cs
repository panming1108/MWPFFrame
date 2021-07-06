using System;

namespace MWPFFrame.UIControls.Standard
{
    [Flags]
    internal enum ErrorModes
    {
        Default = 0x0,
        FailCriticalErrors = 0x1,
        NoGpFaultErrorBox = 0x2,
        NoAlignmentFaultExcept = 0x4,
        NoOpenFileErrorBox = 0x8000
    }
}
