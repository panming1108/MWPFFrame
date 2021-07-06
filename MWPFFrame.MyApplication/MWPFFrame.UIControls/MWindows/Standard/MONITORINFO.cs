using System.Runtime.InteropServices;

namespace MWPFFrame.UIControls.Standard
{
    [StructLayout(LayoutKind.Sequential)]
    internal class MONITORINFO
    {
        public int cbSize = Marshal.SizeOf(typeof(MONITORINFO));

        public RECT rcMonitor;

        public RECT rcWork;

        public int dwFlags;
    }
}
