using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MWPFFrame.UIControls.Standard
{
    internal static class Utility
    {
        private class _UrlDecoder
        {
            private readonly Encoding _encoding;

            private readonly char[] _charBuffer;

            private readonly byte[] _byteBuffer;

            private int _byteCount;

            private int _charCount;

            public _UrlDecoder(int size, Encoding encoding)
            {
                _encoding = encoding;
                _charBuffer = new char[size];
                _byteBuffer = new byte[size];
            }

            public void AddByte(byte b)
            {
                _byteBuffer[_byteCount++] = b;
            }

            public void AddChar(char ch)
            {
                _FlushBytes();
                _charBuffer[_charCount++] = ch;
            }

            private void _FlushBytes()
            {
                if (_byteCount > 0)
                {
                    _charCount += _encoding.GetChars(_byteBuffer, 0, _byteCount, _charBuffer, _charCount);
                    _byteCount = 0;
                }
            }

            public string GetString()
            {
                _FlushBytes();
                if (_charCount > 0)
                {
                    return new string(_charBuffer, 0, _charCount);
                }
                return "";
            }
        }

        private static readonly Version _osVersion = Environment.OSVersion.Version;

        private static readonly Version _presentationFrameworkVersion = Assembly.GetAssembly(typeof(Window)).GetName().Version;

        private static int s_bitDepth;

        public static bool IsOSVistaOrNewer => _osVersion >= new Version(6, 0);

        public static bool IsOSWindows7OrNewer => _osVersion >= new Version(6, 1);

        public static bool IsPresentationFrameworkVersionLessThan4 => _presentationFrameworkVersion < new Version(4, 0);

        private static bool _MemCmp(IntPtr left, IntPtr right, long cb)
        {
            int i;
            for (i = 0; i < cb - 8; i += 8)
            {
                long num = Marshal.ReadInt64(left, i);
                long num2 = Marshal.ReadInt64(right, i);
                if (num != num2)
                {
                    return false;
                }
            }
            for (; i < cb; i++)
            {
                byte b = Marshal.ReadByte(left, i);
                byte b2 = Marshal.ReadByte(right, i);
                if (b != b2)
                {
                    return false;
                }
            }
            return true;
        }

        public static int RGB(Color c)
        {
            return c.R | (c.G << 8) | (c.B << 16);
        }

        public static Color ColorFromArgbDword(uint color)
        {
            return Color.FromArgb((byte)((uint)((int)color & -16777216) >> 24), (byte)((color & 0xFF0000) >> 16), (byte)((color & 0xFF00) >> 8), (byte)(color & 0xFF));
        }

        public static int GET_X_LPARAM(IntPtr lParam)
        {
            return LOWORD(lParam.ToInt32());
        }

        public static int GET_Y_LPARAM(IntPtr lParam)
        {
            return HIWORD(lParam.ToInt32());
        }

        public static int HIWORD(int i)
        {
            return (short)(i >> 16);
        }

        public static int LOWORD(int i)
        {
            return (short)(i & 0xFFFF);
        }

        public static bool AreStreamsEqual(Stream left, Stream right)
        {
            if (null == left)
            {
                return right == null;
            }
            if (null == right)
            {
                return false;
            }
            if (!left.CanRead || !right.CanRead)
            {
                throw new NotSupportedException("The streams can't be read for comparison");
            }
            if (left.Length != right.Length)
            {
                return false;
            }
            int num = (int)left.Length;
            left.Position = 0L;
            right.Position = 0L;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            int num5 = 0;
            byte[] array = new byte[512];
            byte[] array2 = new byte[512];
            GCHandle gCHandle = GCHandle.Alloc(array, GCHandleType.Pinned);
            IntPtr left2 = gCHandle.AddrOfPinnedObject();
            GCHandle gCHandle2 = GCHandle.Alloc(array2, GCHandleType.Pinned);
            IntPtr right2 = gCHandle2.AddrOfPinnedObject();
            try
            {
                while (num2 < num)
                {
                    num4 = left.Read(array, 0, array.Length);
                    num5 = right.Read(array2, 0, array2.Length);
                    if (num4 != num5)
                    {
                        return false;
                    }
                    if (!_MemCmp(left2, right2, num4))
                    {
                        return false;
                    }
                    num2 += num4;
                    num3 += num5;
                }
                return true;
            }
            finally
            {
                gCHandle.Free();
                gCHandle2.Free();
            }
        }

        public static bool GuidTryParse(string guidString, out Guid guid)
        {
            Verify.IsNeitherNullNorEmpty(guidString, "guidString");
            try
            {
                guid = new Guid(guidString);
                return true;
            }
            catch (FormatException)
            {
            }
            catch (OverflowException)
            {
            }
            guid = default(Guid);
            return false;
        }

        public static bool IsFlagSet(int value, int mask)
        {
            return 0 != (value & mask);
        }

        public static bool IsFlagSet(uint value, uint mask)
        {
            return 0 != (value & mask);
        }

        public static bool IsFlagSet(long value, long mask)
        {
            return 0 != (value & mask);
        }

        public static bool IsFlagSet(ulong value, ulong mask)
        {
            return 0 != (value & mask);
        }

        public static IntPtr GenerateHICON(ImageSource image, Size dimensions)
        {
            if (image == null)
            {
                return IntPtr.Zero;
            }
            BitmapFrame bitmapFrame = image as BitmapFrame;
            if (bitmapFrame != null)
            {
                bitmapFrame = GetBestMatch(bitmapFrame.Decoder.Frames, (int)dimensions.Width, (int)dimensions.Height);
            }
            else
            {
                Rect rectangle = new Rect(0.0, 0.0, dimensions.Width, dimensions.Height);
                double num = dimensions.Width / dimensions.Height;
                double num2 = image.Width / image.Height;
                if (image.Width <= dimensions.Width && image.Height <= dimensions.Height)
                {
                    rectangle = new Rect((dimensions.Width - image.Width) / 2.0, (dimensions.Height - image.Height) / 2.0, image.Width, image.Height);
                }
                else if (num > num2)
                {
                    double num3 = image.Width / image.Height * dimensions.Width;
                    rectangle = new Rect((dimensions.Width - num3) / 2.0, 0.0, num3, dimensions.Height);
                }
                else if (num < num2)
                {
                    double num4 = image.Height / image.Width * dimensions.Height;
                    rectangle = new Rect(0.0, (dimensions.Height - num4) / 2.0, dimensions.Width, num4);
                }
                DrawingVisual drawingVisual = new DrawingVisual();
                DrawingContext drawingContext = drawingVisual.RenderOpen();
                drawingContext.DrawImage(image, rectangle);
                drawingContext.Close();
                RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap((int)dimensions.Width, (int)dimensions.Height, 96.0, 96.0, PixelFormats.Pbgra32);
                renderTargetBitmap.Render(drawingVisual);
                bitmapFrame = BitmapFrame.Create(renderTargetBitmap);
            }
            using (MemoryStream memoryStream = new MemoryStream())
            {
                BitmapEncoder bitmapEncoder = new PngBitmapEncoder();
                bitmapEncoder.Frames.Add(bitmapFrame);
                bitmapEncoder.Save(memoryStream);
                using (ManagedIStream stream = new ManagedIStream(memoryStream))
                {
                    IntPtr bitmap = IntPtr.Zero;
                    try
                    {
                        Status status = NativeMethods.GdipCreateBitmapFromStream(stream, out bitmap);
                        if (Status.Ok != status)
                        {
                            return IntPtr.Zero;
                        }
                        status = NativeMethods.GdipCreateHICONFromBitmap(bitmap, out IntPtr hbmReturn);
                        if (Status.Ok != status)
                        {
                            return IntPtr.Zero;
                        }
                        return hbmReturn;
                    }
                    finally
                    {
                        SafeDisposeImage(ref bitmap);
                    }
                }
            }
        }

        public static BitmapFrame GetBestMatch(IList<BitmapFrame> frames, int width, int height)
        {
            return _GetBestMatch(frames, _GetBitDepth(), width, height);
        }

        private static int _MatchImage(BitmapFrame frame, int bitDepth, int width, int height, int bpp)
        {
            return 2 * _WeightedAbs(bpp, bitDepth, fPunish: false) + _WeightedAbs(frame.PixelWidth, width, fPunish: true) + _WeightedAbs(frame.PixelHeight, height, fPunish: true);
        }

        private static int _WeightedAbs(int valueHave, int valueWant, bool fPunish)
        {
            int num = valueHave - valueWant;
            if (num < 0)
            {
                num = (fPunish ? (-2) : (-1)) * num;
            }
            return num;
        }

        private static BitmapFrame _GetBestMatch(IList<BitmapFrame> frames, int bitDepth, int width, int height)
        {
            int num = int.MaxValue;
            int num2 = 0;
            int index = 0;
            bool flag = frames[0].Decoder is IconBitmapDecoder;
            for (int i = 0; i < frames.Count; i++)
            {
                if (num == 0)
                {
                    break;
                }
                int num3 = flag ? frames[i].Thumbnail.Format.BitsPerPixel : frames[i].Format.BitsPerPixel;
                if (num3 == 0)
                {
                    num3 = 8;
                }
                int num4 = _MatchImage(frames[i], bitDepth, width, height, num3);
                if (num4 < num)
                {
                    index = i;
                    num2 = num3;
                    num = num4;
                }
                else if (num4 == num && num2 < num3)
                {
                    index = i;
                    num2 = num3;
                }
            }
            return frames[index];
        }

        private static int _GetBitDepth()
        {
            if (s_bitDepth == 0)
            {
                using (SafeDC hdc = SafeDC.GetDesktop())
                {
                    s_bitDepth = NativeMethods.GetDeviceCaps(hdc, DeviceCap.BITSPIXEL) * NativeMethods.GetDeviceCaps(hdc, DeviceCap.PLANES);
                }
            }
            return s_bitDepth;
        }

        public static void SafeDeleteFile(string path)
        {
            if (!string.IsNullOrEmpty(path))
            {
                File.Delete(path);
            }
        }

        public static void SafeDeleteObject(ref IntPtr gdiObject)
        {
            IntPtr intPtr = gdiObject;
            gdiObject = IntPtr.Zero;
            if (IntPtr.Zero != intPtr)
            {
                NativeMethods.DeleteObject(intPtr);
            }
        }

        public static void SafeDestroyIcon(ref IntPtr hicon)
        {
            IntPtr intPtr = hicon;
            hicon = IntPtr.Zero;
            if (IntPtr.Zero != intPtr)
            {
                NativeMethods.DestroyIcon(intPtr);
            }
        }

        public static void SafeDestroyWindow(ref IntPtr hwnd)
        {
            IntPtr hwnd2 = hwnd;
            hwnd = IntPtr.Zero;
            if (NativeMethods.IsWindow(hwnd2))
            {
                NativeMethods.DestroyWindow(hwnd2);
            }
        }

        public static void SafeDispose<T>(ref T disposable) where T : IDisposable
        {
            IDisposable disposable2 = disposable;
            disposable = default(T);
            if (null != disposable2)
            {
                disposable2.Dispose();
            }
        }

        public static void SafeDisposeImage(ref IntPtr gdipImage)
        {
            IntPtr intPtr = gdipImage;
            gdipImage = IntPtr.Zero;
            if (IntPtr.Zero != intPtr)
            {
                NativeMethods.GdipDisposeImage(intPtr);
            }
        }

        public static void SafeCoTaskMemFree(ref IntPtr ptr)
        {
            IntPtr intPtr = ptr;
            ptr = IntPtr.Zero;
            if (IntPtr.Zero != intPtr)
            {
                Marshal.FreeCoTaskMem(intPtr);
            }
        }

        public static void SafeFreeHGlobal(ref IntPtr hglobal)
        {
            IntPtr intPtr = hglobal;
            hglobal = IntPtr.Zero;
            if (IntPtr.Zero != intPtr)
            {
                Marshal.FreeHGlobal(intPtr);
            }
        }

        public static void SafeRelease<T>(ref T comObject) where T : class
        {
            T val = comObject;
            comObject = null;
            if (null != val)
            {
                Marshal.ReleaseComObject(val);
            }
        }

        public static void GeneratePropertyString(StringBuilder source, string propertyName, string value)
        {
            if (0 != source.Length)
            {
                source.Append(' ');
            }
            source.Append(propertyName);
            source.Append(": ");
            if (string.IsNullOrEmpty(value))
            {
                source.Append("<null>");
                return;
            }
            source.Append('"');
            source.Append(value);
            source.Append('"');
        }

        [Obsolete]
        public static string GenerateToString<T>(T @object) where T : struct
        {
            StringBuilder stringBuilder = new StringBuilder();
            PropertyInfo[] properties = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach (PropertyInfo propertyInfo in properties)
            {
                if (0 != stringBuilder.Length)
                {
                    stringBuilder.Append(", ");
                }
                object value = propertyInfo.GetValue(@object, null);
                string format = (value == null) ? "{0}: <null>" : "{0}: \"{1}\"";
                stringBuilder.AppendFormat(format, propertyInfo.Name, value);
            }
            return stringBuilder.ToString();
        }

        public static void CopyStream(Stream destination, Stream source)
        {
            destination.Position = 0L;
            if (source.CanSeek)
            {
                source.Position = 0L;
                destination.SetLength(source.Length);
            }
            byte[] array = new byte[4096];
            int num;
            do
            {
                num = source.Read(array, 0, array.Length);
                if (0 != num)
                {
                    destination.Write(array, 0, num);
                }
            }
            while (array.Length == num);
            destination.Position = 0L;
        }

        public static string HashStreamMD5(Stream stm)
        {
            stm.Position = 0L;
            StringBuilder stringBuilder = new StringBuilder();
            using (MD5 mD = MD5.Create())
            {
                byte[] array = mD.ComputeHash(stm);
                foreach (byte b in array)
                {
                    stringBuilder.Append(b.ToString("x2", CultureInfo.InvariantCulture));
                }
            }
            return stringBuilder.ToString();
        }

        public static void EnsureDirectory(string path)
        {
            if (!Directory.Exists(Path.GetDirectoryName(path)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(path));
            }
        }

        public static bool MemCmp(byte[] left, byte[] right, int cb)
        {
            GCHandle gCHandle = GCHandle.Alloc(left, GCHandleType.Pinned);
            IntPtr left2 = gCHandle.AddrOfPinnedObject();
            GCHandle gCHandle2 = GCHandle.Alloc(right, GCHandleType.Pinned);
            IntPtr right2 = gCHandle2.AddrOfPinnedObject();
            bool result = _MemCmp(left2, right2, cb);
            gCHandle.Free();
            gCHandle2.Free();
            return result;
        }

        public static string UrlDecode(string url)
        {
            if (url == null)
            {
                return null;
            }
            _UrlDecoder urlDecoder = new _UrlDecoder(url.Length, Encoding.UTF8);
            int length = url.Length;
            for (int i = 0; i < length; i++)
            {
                char c = url[i];
                int num;
                switch (c)
                {
                    case '+':
                        urlDecoder.AddByte(32);
                        continue;
                    case '%':
                        num = ((i >= length - 2) ? 1 : 0);
                        break;
                    default:
                        num = 1;
                        break;
                }
                if (num == 0)
                {
                    if (url[i + 1] == 'u' && i < length - 5)
                    {
                        int num2 = _HexToInt(url[i + 2]);
                        int num3 = _HexToInt(url[i + 3]);
                        int num4 = _HexToInt(url[i + 4]);
                        int num5 = _HexToInt(url[i + 5]);
                        if (num2 >= 0 && num3 >= 0 && num4 >= 0 && num5 >= 0)
                        {
                            urlDecoder.AddChar((char)((num2 << 12) | (num3 << 8) | (num4 << 4) | num5));
                            i += 5;
                            continue;
                        }
                    }
                    else
                    {
                        int num2 = _HexToInt(url[i + 1]);
                        int num3 = _HexToInt(url[i + 2]);
                        if (num2 >= 0 && num3 >= 0)
                        {
                            urlDecoder.AddByte((byte)((num2 << 4) | num3));
                            i += 2;
                            continue;
                        }
                    }
                }
                if ((c & 0xFF80) == 0)
                {
                    urlDecoder.AddByte((byte)c);
                }
                else
                {
                    urlDecoder.AddChar(c);
                }
            }
            return urlDecoder.GetString();
        }

        public static string UrlEncode(string url)
        {
            if (url == null)
            {
                return null;
            }
            byte[] array = Encoding.UTF8.GetBytes(url);
            bool flag = false;
            int num = 0;
            byte[] array2 = array;
            foreach (byte b in array2)
            {
                if (b == 32)
                {
                    flag = true;
                }
                else if (!_UrlEncodeIsSafe(b))
                {
                    num++;
                    flag = true;
                }
            }
            if (flag)
            {
                byte[] array3 = new byte[array.Length + num * 2];
                int num2 = 0;
                array2 = array;
                foreach (byte b in array2)
                {
                    if (_UrlEncodeIsSafe(b))
                    {
                        array3[num2++] = b;
                        continue;
                    }
                    if (b == 32)
                    {
                        array3[num2++] = 43;
                        continue;
                    }
                    array3[num2++] = 37;
                    array3[num2++] = _IntToHex((b >> 4) & 0xF);
                    array3[num2++] = _IntToHex(b & 0xF);
                }
                array = array3;
            }
            return Encoding.ASCII.GetString(array);
        }

        private static bool _UrlEncodeIsSafe(byte b)
        {
            if (_IsAsciiAlphaNumeric(b))
            {
                return true;
            }
            switch (b)
            {
                case 33:
                case 39:
                case 40:
                case 41:
                case 42:
                case 45:
                case 46:
                case 95:
                    return true;
                default:
                    return false;
            }
        }

        private static bool _IsAsciiAlphaNumeric(byte b)
        {
            return (b >= 97 && b <= 122) || (b >= 65 && b <= 90) || (b >= 48 && b <= 57);
        }

        private static byte _IntToHex(int n)
        {
            if (n <= 9)
            {
                return (byte)(n + 48);
            }
            return (byte)(n - 10 + 65);
        }

        private static int _HexToInt(char h)
        {
            if (h >= '0' && h <= '9')
            {
                return h - 48;
            }
            if (h >= 'a' && h <= 'f')
            {
                return h - 97 + 10;
            }
            if (h >= 'A' && h <= 'F')
            {
                return h - 65 + 10;
            }
            return -1;
        }

        public static void AddDependencyPropertyChangeListener(object component, DependencyProperty property, EventHandler listener)
        {
            if (component != null)
            {
                DependencyPropertyDescriptor dependencyPropertyDescriptor = DependencyPropertyDescriptor.FromProperty(property, component.GetType());
                dependencyPropertyDescriptor.AddValueChanged(component, listener);
            }
        }

        public static void RemoveDependencyPropertyChangeListener(object component, DependencyProperty property, EventHandler listener)
        {
            if (component != null)
            {
                DependencyPropertyDescriptor dependencyPropertyDescriptor = DependencyPropertyDescriptor.FromProperty(property, component.GetType());
                dependencyPropertyDescriptor.RemoveValueChanged(component, listener);
            }
        }

        public static bool IsThicknessNonNegative(Thickness thickness)
        {
            if (!IsDoubleFiniteAndNonNegative(thickness.Top))
            {
                return false;
            }
            if (!IsDoubleFiniteAndNonNegative(thickness.Left))
            {
                return false;
            }
            if (!IsDoubleFiniteAndNonNegative(thickness.Bottom))
            {
                return false;
            }
            if (!IsDoubleFiniteAndNonNegative(thickness.Right))
            {
                return false;
            }
            return true;
        }

        public static bool IsCornerRadiusValid(CornerRadius cornerRadius)
        {
            if (!IsDoubleFiniteAndNonNegative(cornerRadius.TopLeft))
            {
                return false;
            }
            if (!IsDoubleFiniteAndNonNegative(cornerRadius.TopRight))
            {
                return false;
            }
            if (!IsDoubleFiniteAndNonNegative(cornerRadius.BottomLeft))
            {
                return false;
            }
            if (!IsDoubleFiniteAndNonNegative(cornerRadius.BottomRight))
            {
                return false;
            }
            return true;
        }

        public static bool IsDoubleFiniteAndNonNegative(double d)
        {
            if (double.IsNaN(d) || double.IsInfinity(d) || d < 0.0)
            {
                return false;
            }
            return true;
        }
    }
}
