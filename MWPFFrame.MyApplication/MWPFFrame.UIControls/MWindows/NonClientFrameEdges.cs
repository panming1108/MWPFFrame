using System;

namespace MWPFFrame.UIControls
{
    [Flags]
    public enum NonClientFrameEdges
    {
        None = 0x0,
        Left = 0x1,
        Top = 0x2,
        Right = 0x4,
        Bottom = 0x8
    }
}
