using System.Windows;
using System.Windows.Media;

namespace MWPFFrame.UIControls.Standard
{
    internal static class DpiHelper
    {
        private static Matrix _transformToDevice;

        private static Matrix _transformToDip;

        static DpiHelper()
        {
            using (SafeDC hdc = SafeDC.GetDesktop())
            {
                int deviceCaps = NativeMethods.GetDeviceCaps(hdc, DeviceCap.LOGPIXELSX);
                int deviceCaps2 = NativeMethods.GetDeviceCaps(hdc, DeviceCap.LOGPIXELSY);
                _transformToDip = Matrix.Identity;
                _transformToDip.Scale(96.0 / (double)deviceCaps, 96.0 / (double)deviceCaps2);
                _transformToDevice = Matrix.Identity;
                _transformToDevice.Scale((double)deviceCaps / 96.0, (double)deviceCaps2 / 96.0);
            }
        }

        public static Point LogicalPixelsToDevice(Point logicalPoint)
        {
            return _transformToDevice.Transform(logicalPoint);
        }

        public static Point DevicePixelsToLogical(Point devicePoint)
        {
            return _transformToDip.Transform(devicePoint);
        }

        public static Rect LogicalRectToDevice(Rect logicalRectangle)
        {
            Point point = LogicalPixelsToDevice(new Point(logicalRectangle.Left, logicalRectangle.Top));
            Point point2 = LogicalPixelsToDevice(new Point(logicalRectangle.Right, logicalRectangle.Bottom));
            return new Rect(point, point2);
        }

        public static Rect DeviceRectToLogical(Rect deviceRectangle)
        {
            Point point = DevicePixelsToLogical(new Point(deviceRectangle.Left, deviceRectangle.Top));
            Point point2 = DevicePixelsToLogical(new Point(deviceRectangle.Right, deviceRectangle.Bottom));
            return new Rect(point, point2);
        }

        public static Size LogicalSizeToDevice(Size logicalSize)
        {
            Point point = LogicalPixelsToDevice(new Point(logicalSize.Width, logicalSize.Height));
            Size result = default(Size);
            result.Width = point.X;
            result.Height = point.Y;
            return result;
        }

        public static Size DeviceSizeToLogical(Size deviceSize)
        {
            Point point = DevicePixelsToLogical(new Point(deviceSize.Width, deviceSize.Height));
            return new Size(point.X, point.Y);
        }

        public static Thickness LogicalThicknessToDevice(Thickness logicalThickness)
        {
            Point point = LogicalPixelsToDevice(new Point(logicalThickness.Left, logicalThickness.Top));
            Point point2 = LogicalPixelsToDevice(new Point(logicalThickness.Right, logicalThickness.Bottom));
            return new Thickness(point.X, point.Y, point2.X, point2.Y);
        }
    }
}
