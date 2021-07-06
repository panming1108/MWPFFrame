using MWPFFrame.UIControls.Standard;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;

namespace MWPFFrame.UIControls
{
    public static class SystemCommands
    {
        public static RoutedCommand CloseWindowCommand
        {
            get;
            private set;
        }

        public static RoutedCommand MaximizeWindowCommand
        {
            get;
            private set;
        }

        public static RoutedCommand MinimizeWindowCommand
        {
            get;
            private set;
        }

        public static RoutedCommand RestoreWindowCommand
        {
            get;
            private set;
        }

        public static RoutedCommand ShowSystemMenuCommand
        {
            get;
            private set;
        }

        static SystemCommands()
        {
            CloseWindowCommand = new RoutedCommand("CloseWindow", typeof(SystemCommands));
            MaximizeWindowCommand = new RoutedCommand("MaximizeWindow", typeof(SystemCommands));
            MinimizeWindowCommand = new RoutedCommand("MinimizeWindow", typeof(SystemCommands));
            RestoreWindowCommand = new RoutedCommand("RestoreWindow", typeof(SystemCommands));
            ShowSystemMenuCommand = new RoutedCommand("ShowSystemMenu", typeof(SystemCommands));
        }

        private static void _PostSystemCommand(Window window, SC command)
        {
            IntPtr handle = new WindowInteropHelper(window).Handle;
            if (!(handle == IntPtr.Zero) && NativeMethods.IsWindow(handle))
            {
                NativeMethods.PostMessage(handle, WM.SYSCOMMAND, new IntPtr((int)command), IntPtr.Zero);
            }
        }

        public static void CloseWindow(Window window)
        {
            Verify.IsNotNull(window, "window");
            _PostSystemCommand(window, SC.CLOSE);
        }

        public static void MaximizeWindow(Window window)
        {
            Verify.IsNotNull(window, "window");
            _PostSystemCommand(window, SC.MAXIMIZE);
        }

        public static void MinimizeWindow(Window window)
        {
            Verify.IsNotNull(window, "window");
            _PostSystemCommand(window, SC.MINIMIZE);
        }

        public static void RestoreWindow(Window window)
        {
            Verify.IsNotNull(window, "window");
            _PostSystemCommand(window, SC.RESTORE);
        }

        public static void ShowSystemMenu(Window window, Point screenLocation)
        {
            Verify.IsNotNull(window, "window");
            ShowSystemMenuPhysicalCoordinates(window, DpiHelper.LogicalPixelsToDevice(screenLocation));
        }

        internal static void ShowSystemMenuPhysicalCoordinates(Window window, Point physicalScreenLocation)
        {
            Verify.IsNotNull(window, "window");
            IntPtr handle = new WindowInteropHelper(window).Handle;
            if (!(handle == IntPtr.Zero) && NativeMethods.IsWindow(handle))
            {
                IntPtr systemMenu = NativeMethods.GetSystemMenu(handle, bRevert: false);
                uint num = NativeMethods.TrackPopupMenuEx(systemMenu, 256u, (int)physicalScreenLocation.X, (int)physicalScreenLocation.Y, handle, IntPtr.Zero);
                if (0 != num)
                {
                    NativeMethods.PostMessage(handle, WM.SYSCOMMAND, new IntPtr(num), IntPtr.Zero);
                }
            }
        }
    }
}
