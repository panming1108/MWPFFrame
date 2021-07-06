using Microsoft.Win32.SafeHandles;
using System.Security.Permissions;

namespace MWPFFrame.UIControls.Standard
{
    internal sealed class SafeFindHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        [SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode = true)]
        private SafeFindHandle()
            : base(ownsHandle: true)
        {
        }

        protected override bool ReleaseHandle()
        {
            return NativeMethods.FindClose(handle);
        }
    }
}
