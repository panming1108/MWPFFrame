﻿using System.Runtime.InteropServices;

namespace MWPFFrame.UIControls.Standard
{
    internal struct NONCLIENTMETRICS
    {
        public int cbSize;

        public int iBorderWidth;

        public int iScrollWidth;

        public int iScrollHeight;

        public int iCaptionWidth;

        public int iCaptionHeight;

        public LOGFONT lfCaptionFont;

        public int iSmCaptionWidth;

        public int iSmCaptionHeight;

        public LOGFONT lfSmCaptionFont;

        public int iMenuWidth;

        public int iMenuHeight;

        public LOGFONT lfMenuFont;

        public LOGFONT lfStatusFont;

        public LOGFONT lfMessageFont;

        public int iPaddedBorderWidth;

        public static NONCLIENTMETRICS VistaMetricsStruct
        {
            get
            {
                NONCLIENTMETRICS result = default(NONCLIENTMETRICS);
                result.cbSize = Marshal.SizeOf(typeof(NONCLIENTMETRICS));
                return result;
            }
        }

        public static NONCLIENTMETRICS XPMetricsStruct
        {
            get
            {
                NONCLIENTMETRICS result = default(NONCLIENTMETRICS);
                result.cbSize = Marshal.SizeOf(typeof(NONCLIENTMETRICS)) - 4;
                return result;
            }
        }
    }
}
