﻿namespace MWPFFrame.UIControls.Standard
{
    internal enum SPI
    {
        GETBEEP = 1,
        SETBEEP = 2,
        GETMOUSE = 3,
        SETMOUSE = 4,
        GETBORDER = 5,
        SETBORDER = 6,
        GETKEYBOARDSPEED = 10,
        SETKEYBOARDSPEED = 11,
        LANGDRIVER = 12,
        ICONHORIZONTALSPACING = 13,
        GETSCREENSAVETIMEOUT = 14,
        SETSCREENSAVETIMEOUT = 0xF,
        GETSCREENSAVEACTIVE = 0x10,
        SETSCREENSAVEACTIVE = 17,
        GETGRIDGRANULARITY = 18,
        SETGRIDGRANULARITY = 19,
        SETDESKWALLPAPER = 20,
        SETDESKPATTERN = 21,
        GETKEYBOARDDELAY = 22,
        SETKEYBOARDDELAY = 23,
        ICONVERTICALSPACING = 24,
        GETICONTITLEWRAP = 25,
        SETICONTITLEWRAP = 26,
        GETMENUDROPALIGNMENT = 27,
        SETMENUDROPALIGNMENT = 28,
        SETDOUBLECLKWIDTH = 29,
        SETDOUBLECLKHEIGHT = 30,
        GETICONTITLELOGFONT = 0x1F,
        SETDOUBLECLICKTIME = 0x20,
        SETMOUSEBUTTONSWAP = 33,
        SETICONTITLELOGFONT = 34,
        GETFASTTASKSWITCH = 35,
        SETFASTTASKSWITCH = 36,
        SETDRAGFULLWINDOWS = 37,
        GETDRAGFULLWINDOWS = 38,
        GETNONCLIENTMETRICS = 41,
        SETNONCLIENTMETRICS = 42,
        GETMINIMIZEDMETRICS = 43,
        SETMINIMIZEDMETRICS = 44,
        GETICONMETRICS = 45,
        SETICONMETRICS = 46,
        SETWORKAREA = 47,
        GETWORKAREA = 48,
        SETPENWINDOWS = 49,
        GETHIGHCONTRAST = 66,
        SETHIGHCONTRAST = 67,
        GETKEYBOARDPREF = 68,
        SETKEYBOARDPREF = 69,
        GETSCREENREADER = 70,
        SETSCREENREADER = 71,
        GETANIMATION = 72,
        SETANIMATION = 73,
        GETFONTSMOOTHING = 74,
        SETFONTSMOOTHING = 75,
        SETDRAGWIDTH = 76,
        SETDRAGHEIGHT = 77,
        SETHANDHELD = 78,
        GETLOWPOWERTIMEOUT = 79,
        GETPOWEROFFTIMEOUT = 80,
        SETLOWPOWERTIMEOUT = 81,
        SETPOWEROFFTIMEOUT = 82,
        GETLOWPOWERACTIVE = 83,
        GETPOWEROFFACTIVE = 84,
        SETLOWPOWERACTIVE = 85,
        SETPOWEROFFACTIVE = 86,
        SETCURSORS = 87,
        SETICONS = 88,
        GETDEFAULTINPUTLANG = 89,
        SETDEFAULTINPUTLANG = 90,
        SETLANGTOGGLE = 91,
        GETWINDOWSEXTENSION = 92,
        SETMOUSETRAILS = 93,
        GETMOUSETRAILS = 94,
        SETSCREENSAVERRUNNING = 97,
        SCREENSAVERRUNNING = 97,
        GETFILTERKEYS = 50,
        SETFILTERKEYS = 51,
        GETTOGGLEKEYS = 52,
        SETTOGGLEKEYS = 53,
        GETMOUSEKEYS = 54,
        SETMOUSEKEYS = 55,
        GETSHOWSOUNDS = 56,
        SETSHOWSOUNDS = 57,
        GETSTICKYKEYS = 58,
        SETSTICKYKEYS = 59,
        GETACCESSTIMEOUT = 60,
        SETACCESSTIMEOUT = 61,
        GETSERIALKEYS = 62,
        SETSERIALKEYS = 0x3F,
        GETSOUNDSENTRY = 0x40,
        SETSOUNDSENTRY = 65,
        GETSNAPTODEFBUTTON = 95,
        SETSNAPTODEFBUTTON = 96,
        GETMOUSEHOVERWIDTH = 98,
        SETMOUSEHOVERWIDTH = 99,
        GETMOUSEHOVERHEIGHT = 100,
        SETMOUSEHOVERHEIGHT = 101,
        GETMOUSEHOVERTIME = 102,
        SETMOUSEHOVERTIME = 103,
        GETWHEELSCROLLLINES = 104,
        SETWHEELSCROLLLINES = 105,
        GETMENUSHOWDELAY = 106,
        SETMENUSHOWDELAY = 107,
        GETWHEELSCROLLCHARS = 108,
        SETWHEELSCROLLCHARS = 109,
        GETSHOWIMEUI = 110,
        SETSHOWIMEUI = 111,
        GETMOUSESPEED = 112,
        SETMOUSESPEED = 113,
        GETSCREENSAVERRUNNING = 114,
        GETDESKWALLPAPER = 115,
        GETAUDIODESCRIPTION = 116,
        SETAUDIODESCRIPTION = 117,
        GETSCREENSAVESECURE = 118,
        SETSCREENSAVESECURE = 119,
        GETHUNGAPPTIMEOUT = 120,
        SETHUNGAPPTIMEOUT = 121,
        GETWAITTOKILLTIMEOUT = 122,
        SETWAITTOKILLTIMEOUT = 123,
        GETWAITTOKILLSERVICETIMEOUT = 124,
        SETWAITTOKILLSERVICETIMEOUT = 125,
        GETMOUSEDOCKTHRESHOLD = 126,
        SETMOUSEDOCKTHRESHOLD = 0x7F,
        GETPENDOCKTHRESHOLD = 0x80,
        SETPENDOCKTHRESHOLD = 129,
        GETWINARRANGING = 130,
        SETWINARRANGING = 131,
        GETMOUSEDRAGOUTTHRESHOLD = 132,
        SETMOUSEDRAGOUTTHRESHOLD = 133,
        GETPENDRAGOUTTHRESHOLD = 134,
        SETPENDRAGOUTTHRESHOLD = 135,
        GETMOUSESIDEMOVETHRESHOLD = 136,
        SETMOUSESIDEMOVETHRESHOLD = 137,
        GETPENSIDEMOVETHRESHOLD = 138,
        SETPENSIDEMOVETHRESHOLD = 139,
        GETDRAGFROMMAXIMIZE = 140,
        SETDRAGFROMMAXIMIZE = 141,
        GETSNAPSIZING = 142,
        SETSNAPSIZING = 143,
        GETDOCKMOVING = 144,
        SETDOCKMOVING = 145,
        GETACTIVEWINDOWTRACKING = 0x1000,
        SETACTIVEWINDOWTRACKING = 4097,
        GETMENUANIMATION = 4098,
        SETMENUANIMATION = 4099,
        GETCOMBOBOXANIMATION = 4100,
        SETCOMBOBOXANIMATION = 4101,
        GETLISTBOXSMOOTHSCROLLING = 4102,
        SETLISTBOXSMOOTHSCROLLING = 4103,
        GETGRADIENTCAPTIONS = 4104,
        SETGRADIENTCAPTIONS = 4105,
        GETKEYBOARDCUES = 4106,
        SETKEYBOARDCUES = 4107,
        GETMENUUNDERLINES = 4106,
        SETMENUUNDERLINES = 4107,
        GETACTIVEWNDTRKZORDER = 4108,
        SETACTIVEWNDTRKZORDER = 4109,
        GETHOTTRACKING = 4110,
        SETHOTTRACKING = 4111,
        GETMENUFADE = 4114,
        SETMENUFADE = 4115,
        GETSELECTIONFADE = 4116,
        SETSELECTIONFADE = 4117,
        GETTOOLTIPANIMATION = 4118,
        SETTOOLTIPANIMATION = 4119,
        GETTOOLTIPFADE = 4120,
        SETTOOLTIPFADE = 4121,
        GETCURSORSHADOW = 4122,
        SETCURSORSHADOW = 4123,
        GETMOUSESONAR = 4124,
        SETMOUSESONAR = 4125,
        GETMOUSECLICKLOCK = 4126,
        SETMOUSECLICKLOCK = 4127,
        GETMOUSEVANISH = 4128,
        SETMOUSEVANISH = 4129,
        GETFLATMENU = 4130,
        SETFLATMENU = 4131,
        GETDROPSHADOW = 4132,
        SETDROPSHADOW = 4133,
        GETBLOCKSENDINPUTRESETS = 4134,
        SETBLOCKSENDINPUTRESETS = 4135,
        GETUIEFFECTS = 4158,
        SETUIEFFECTS = 4159,
        GETDISABLEOVERLAPPEDCONTENT = 4160,
        SETDISABLEOVERLAPPEDCONTENT = 4161,
        GETCLIENTAREAANIMATION = 4162,
        SETCLIENTAREAANIMATION = 4163,
        GETCLEARTYPE = 4168,
        SETCLEARTYPE = 4169,
        GETSPEECHRECOGNITION = 4170,
        SETSPEECHRECOGNITION = 4171,
        GETFOREGROUNDLOCKTIMEOUT = 0x2000,
        SETFOREGROUNDLOCKTIMEOUT = 8193,
        GETACTIVEWNDTRKTIMEOUT = 8194,
        SETACTIVEWNDTRKTIMEOUT = 8195,
        GETFOREGROUNDFLASHCOUNT = 8196,
        SETFOREGROUNDFLASHCOUNT = 8197,
        GETCARETWIDTH = 8198,
        SETCARETWIDTH = 8199,
        GETMOUSECLICKLOCKTIME = 8200,
        SETMOUSECLICKLOCKTIME = 8201,
        GETFONTSMOOTHINGTYPE = 8202,
        SETFONTSMOOTHINGTYPE = 8203,
        GETFONTSMOOTHINGCONTRAST = 8204,
        SETFONTSMOOTHINGCONTRAST = 8205,
        GETFOCUSBORDERWIDTH = 8206,
        SETFOCUSBORDERWIDTH = 8207,
        GETFOCUSBORDERHEIGHT = 8208,
        SETFOCUSBORDERHEIGHT = 8209,
        GETFONTSMOOTHINGORIENTATION = 8210,
        SETFONTSMOOTHINGORIENTATION = 8211,
        GETMINIMUMHITRADIUS = 8212,
        SETMINIMUMHITRADIUS = 8213,
        GETMESSAGEDURATION = 8214,
        SETMESSAGEDURATION = 8215
    }
}
