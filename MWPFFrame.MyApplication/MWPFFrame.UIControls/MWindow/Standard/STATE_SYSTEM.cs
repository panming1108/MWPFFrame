﻿using System;

namespace MWPFFrame.UIControls.Standard
{
    [Flags]
    internal enum STATE_SYSTEM
    {
        UNAVAILABLE = 0x1,
        SELECTED = 0x2,
        FOCUSED = 0x4,
        PRESSED = 0x8,
        CHECKED = 0x10,
        MIXED = 0x20,
        INDETERMINATE = 0x20,
        READONLY = 0x40,
        HOTTRACKED = 0x80,
        DEFAULT = 0x100,
        EXPANDED = 0x200,
        COLLAPSED = 0x400,
        BUSY = 0x800,
        FLOATING = 0x1000,
        MARQUEED = 0x2000,
        ANIMATED = 0x4000,
        INVISIBLE = 0x8000,
        OFFSCREEN = 0x10000,
        SIZEABLE = 0x20000,
        MOVEABLE = 0x40000,
        SELFVOICING = 0x80000,
        FOCUSABLE = 0x100000,
        SELECTABLE = 0x200000,
        LINKED = 0x400000,
        TRAVERSED = 0x800000,
        MULTISELECTABLE = 0x1000000,
        EXTSELECTABLE = 0x2000000,
        ALERT_LOW = 0x4000000,
        ALERT_MEDIUM = 0x8000000,
        ALERT_HIGH = 0x10000000,
        PROTECTED = 0x20000000,
        VALID = 0x3FFFFFFF
    }
}
