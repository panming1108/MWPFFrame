using Microsoft.Win32.SafeHandles;
using System.Runtime.ConstrainedExecution;

namespace MWPFFrame.UIControls.Standard
{
    internal sealed class SafeHBITMAP : SafeHandleZeroOrMinusOneIsInvalid
    {
        private SafeHBITMAP()
            : base(ownsHandle: true)
        {
        }

        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        protected override bool ReleaseHandle()
        {
            return NativeMethods.DeleteObject(handle);
        }
    }
}
