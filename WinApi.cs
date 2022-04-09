using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWinApi
{
    public static class WinApi
    {
        #region DELEGATES
        public delegate LRESULT WndProcDelegate(HWND hWnd, uint uMsg, WPARAM wParam, LPARAM lParam);
        public delegate void MsgBoxCallbackDelegate(IntPtr lpHelpInfo);
        public delegate void SendAsyncProcDelegate(HWND hWnd, uint uMsg, ulong data, LRESULT res);
        public delegate LRESULT HookProcDelegate(int code, WPARAM wParam, LPARAM lParam);

        #endregion

        #region CONST
        public const byte NULL = 0x0;

        #region Window class styles
        public const uint CS_BYTEALIGNCLIENT = 0x1000;
        public const uint CS_BYTEALIGNWINDOW = 0x2000;
        public const uint CS_CLASSDC         = 0x0040;
        public const uint CS_DBLCLKS         = 0x0008;
        public const uint CS_DROPSHADOW      = 0x00020000;
        public const uint CS_GLOBALCLASS     = 0x4000;
        public const uint CS_HREDRAW         = 0x0002;
        public const uint CS_NOCLOSE         = 0x0200;
        public const uint CS_OWNDC           = 0x0020;
        public const uint CS_PARENTDC        = 0x0080;
        public const uint CS_SAVEBITS        = 0x0800;
        public const uint CS_VREDRAW         = 0x0001;
        #endregion

        #region Default icons
        public const ulong IDI_APPLICATION = 32512;
        public const ulong IDI_ASTERISK    = 32516;
        public const ulong IDI_ERROR       = 32513;
        public const ulong IDI_EXCLAMATION = 32515;
        public const ulong IDI_HAND        = IDI_ERROR;
        public const ulong IDI_INFORMATION = IDI_ASTERISK;
        public const ulong IDI_QUESTION    = 32514;
        public const ulong IDI_SHIELD      = 32518;
        public const ulong IDI_WARNING     = IDI_EXCLAMATION;
        public const ulong IDI_WINLOGO     = 32517;
        #endregion

        #region Default cursors
        public const ulong IDC_APPSTARTING = 32650;
        public const ulong IDC_ARROW       = 32512;
        public const ulong IDC_HAND        = 32649;
        public const ulong IDC_HELP        = 32651;
        public const ulong IDC_IBEAM       = 32513;
        public const ulong IDC_ICON        = 32641;
        public const ulong IDC_NO          = 32648;
        public const ulong IDC_SIZE        = 32640;
        public const ulong IDC_SIZEALL     = 32646;
        public const ulong IDC_SIZENESW    = 32643;
        public const ulong IDC_SIZENS      = 32645;
        public const ulong IDC_SIZENWSE    = 32642;
        public const ulong IDC_SIZEWE      = 32644;
        public const ulong IDC_UPARROW     = 32516;
        public const ulong IDC_WAIT        = 32514;
        public const ulong IDC_CROSS       = 32515;
        #endregion

        #region Window styles
        public const ulong WS_BORDER           = 0x00800000L;
        public const ulong WS_CHILD            = 0x40000000L;
        public const ulong WS_CHILDWINDOW      = WS_CHILD;
        public const ulong WS_CLIPCHILDREN     = 0x02000000L;
        public const ulong WS_CLIPSIBLINGS     = 0x04000000L;
        public const ulong WS_DISABLED         = 0x08000000L;
        public const ulong WS_DLGFRAME         = 0x00400000L;
        public const ulong WS_GROUP            = 0x00020000L;
        public const ulong WS_HSCROLL          = 0x00100000L;
        public const ulong WS_ICONIC           = 0x20000000L;
        public const ulong WS_MAXIMIZE         = 0x01000000L;
        public const ulong WS_MINIMIZE         = 0x20000000L;
        public const ulong WS_POPUP            = 0x80000000L;
        public const ulong WS_POPUPWINDOW      = WS_POPUP | WS_BORDER | WS_SYSMENU;
        public const ulong WS_SIZEBOX          = 0x00040000L;
        public const ulong WS_TABSTOP          = 0x00010000L;
        public const ulong WS_TILED            = WS_OVERLAPPED;
        public const ulong WS_TILEDWINDOW      = WS_OVERLAPPED | WS_CAPTION | WS_SYSMENU | WS_THICKFRAME | WS_MINIMIZEBOX | WS_MAXIMIZEBOX;
        public const ulong WS_VISIBLE          = 0x10000000L;
        public const ulong WS_VSCROLL          = 0x00200000L;
        public const ulong WS_OVERLAPPED       = 0x00000000L;
        public const ulong WS_CAPTION          = 0x00C00000L;
        public const ulong WS_SYSMENU          = 0x00080000L;
        public const ulong WS_THICKFRAME       = WS_SIZEBOX;
        public const ulong WS_MINIMIZEBOX      = 0x00020000L;
        public const ulong WS_MAXIMIZEBOX      = 0x00010000L;
        public const ulong WS_OVERLAPPEDWINDOW = WS_OVERLAPPED | WS_CAPTION | WS_SYSMENU | WS_THICKFRAME | WS_MINIMIZEBOX | WS_MAXIMIZEBOX;
        #endregion

        #region Show states
        public const int SW_SHOWNORMAL      = 1;
        public const int SW_HIDE            = 0;
        public const int SW_NORMAL          = SW_SHOWNORMAL;
        public const int SW_SHOWMINIMIZED   = 2;
        public const int SW_SHOWMAXIMIZED   = 3;
        public const int SW_MAXIMIZE        = SW_SHOWMAXIMIZED;
        public const int SW_SHOWNOACTIVATE  = 4;
        public const int SW_SHOW            = 5;
        public const int SW_MINIMIZE        = 6;
        public const int SW_SHOWMINNOACTIVE = 7;
        public const int SW_SHOWNA          = 8;
        public const int SW_RESTORE         = 9;
        public const int SW_SHOWDEFAULT     = 10;
        public const int SW_FORCEMINIMIZE   = 11;
        #endregion

        #region Button styles
        public const ulong BS_3STATE          = 0x00000005;
        public const ulong BS_AUTO3STATE      = 0x00000006;
        public const ulong BS_AUTOCHECKBOX    = 0x00000003;
        public const ulong BS_AUTORADIOBUTTON = 0x00000009;
        public const ulong BS_BITMAP          = 0x00000080;
        public const ulong BS_BOTTOM          = 0x00000800;
        public const ulong BS_CENTER          = 0x00000300;
        public const ulong BS_CHECKBOX        = 0x00000002;
        public const ulong BS_DEFPUSHBUTTON   = 0x00000001;
        public const ulong BS_GROUPBOX        = 0x00000007;
        public const ulong BS_ICON            = 0x00000040;
        public const ulong BS_FLAT            = 0x00008000;
        public const ulong BS_LEFT            = 0x00000100;
        public const ulong BS_LEFTTEXT        = 0x00000020;
        public const ulong BS_MULTILINE       = 0x00002000;
        public const ulong BS_NOTIFY          = 0x00004000;
        public const ulong BS_OWNERDRAW       = 0x0000000B;
        public const ulong BS_PUSHBUTTON      = 0x00000000;
        public const ulong BS_PUSHLIKE        = 0x00001000;
        public const ulong BS_RADIOBUTTON     = 0x00000004;
        public const ulong BS_RIGHT           = 0x00000200;
        public const ulong BS_RIGHTBUTTON     = BS_LEFTTEXT;
        public const ulong BS_TEXT            = 0x00000000;
        public const ulong BS_TOP             = 0x00000400;
        public const ulong BS_TYPEMASK        = 0x0000000F;
        public const ulong BS_USERBUTTON      = 0x00000008;
        public const ulong BS_VCENTER         = 0x00000C00;
        #endregion

        #region WNDPROC messages
        public const uint WM_DESTROY               = 0x0002;
        public const uint WM_CREATE                = 0x0001;
        public const uint WM_LBUTTONDOWN           = 0x0201;
        public const uint WM_RBUTTONDOWN           = 0x0204;
        public const uint WM_COMMAND               = 0x0111;
        public const uint WM_NULL                  = 0x0000;
        public const uint WM_MOVE                  = 0x0003;
        public const uint WM_SIZE                  = 0x0005;
        public const uint WM_ACTIVATE              = 0x0006;
        public const uint WM_SETFOCUS              = 0x0007;
        public const uint WM_KILLFOCUS             = 0x0008;
        public const uint WM_ENABLE                = 0x000a;
        public const uint WM_SETREDRAW             = 0x000b;
        public const uint WM_SETTEXT               = 0x000c;
        public const uint WM_GETTEXT               = 0x000d;
        public const uint WM_GETTEXTLENGTH         = 0x000e;
        public const uint WM_PAINT                 = 0x000f;
        public const uint WM_CLOSE                 = 0x0010;
        public const uint WM_QUERYENDSESSION       = 0x0011;
        public const uint WM_QUIT                  = 0x0012;
        public const uint WM_QUERYOPEN             = 0x0013;
        public const uint WM_ERASEBKGND            = 0x0014;
        public const uint WM_SYSCOLORCHANGE        = 0x0015;
        public const uint WM_ENDSESSION            = 0x0016;
        public const uint WM_SHOWWINDOW            = 0x0018;
        public const uint WM_CTLCOLOR              = 0x0019;
        public const uint WM_WININICHANGE          = 0x001a;
        public const uint WM_DEVMODECHANGE         = 0x001b;
        public const uint WM_ACTIVATEAPP           = 0x001c;
        public const uint WM_FONTCHANGE            = 0x001d;
        public const uint WM_TIMECHANGE            = 0x001e;
        public const uint WM_CANCELMODE            = 0x001f;
        public const uint WM_SETCURSOR             = 0x0020;
        public const uint WM_MOUSEACTIVATE         = 0x0021;
        public const uint WM_CHILDACTIVATE         = 0x0022;
        public const uint WM_QUEUESYNC             = 0x0023;
        public const uint WM_GETMINMAXINFO         = 0x0024;
        public const uint WM_PAINTICON             = 0x0026;
        public const uint WM_ICONERASEBKGND        = 0x0027;
        public const uint WM_NEXTDLGCTL            = 0x0028;
        public const uint WM_SPOOLERSTATUS         = 0x002a;
        public const uint WM_DRAWITEM              = 0x002b;
        public const uint WM_MEASUREITEM           = 0x002c;
        public const uint WM_DELETEITEM            = 0x002d;
        public const uint WM_VKEYTOITEM            = 0x002e;
        public const uint WM_CHARTOITEM            = 0x002f;
        public const uint WM_SETFONT               = 0x0030;
        public const uint WM_GETFONT               = 0x0031;
        public const uint WM_SETHOTKEY             = 0x0032;
        public const uint WM_GETHOTKEY             = 0x0033;
        public const uint WM_QUERYDRAGICON         = 0x0037;
        public const uint WM_COMPAREITEM           = 0x0039;
        public const uint WM_GETOBJECT             = 0x003d;
        public const uint WM_COMPACTING            = 0x0041;
        public const uint WM_COMMNOTIFY            = 0x0044;
        public const uint WM_WINDOWPOSCHANGING     = 0x0046;
        public const uint WM_WINDOWPOSCHANGED      = 0x0047;
        public const uint WM_POWER                 = 0x0048;
        public const uint WM_COPYGLOBALDATA        = 0x0049;
        public const uint WM_COPYDATA              = 0x004a;
        public const uint WM_CANCELJOURNAL         = 0x004b;
        public const uint WM_NOTIFY                = 0x004e;
        public const uint WM_INPUTLANCHANGEREQUEST = 0x0050;
        public const uint WM_INPUTLANCHANGE        = 0x0051;
        public const uint WM_TCARD                 = 0x0052;
        public const uint WM_HELP                  = 0x0053;
        public const uint WM_USERCHANGED           = 0x0054;
        public const uint WM_NOTIFYFORMAT          = 0x0055;
        public const uint WM_CONTEXTMENU           = 0x007b;
        public const uint WM_STYLECHANGING         = 0x007c;
        public const uint WM_STYLECHANGED          = 0x007d;
        public const uint WM_DISPLAYCHANGE         = 0x007e;
        public const uint WM_GETICON               = 0x007f;
        public const uint WM_SETICON               = 0x0080;
        public const uint WM_NCCREATE              = 0x0081;
        public const uint WM_NCDESTROY             = 0x0081;
        public const uint WM_KEYDOWN               = 0x0100;
        public const uint WM_KEYUP                 = 0x0101;
        #endregion

        #region Accessibility parameters
        public const uint SPI_GETACCESSTIMEOUT            = 0x003c;
        public const uint SPI_SETACCESSTIMEOUT            = 0x003d;
        public const uint SPI_GETAUDIODESCRIPTION         = 0x0074;
        public const uint SPI_SETAUDIODESCRIPTION         = 0x0075;
        public const uint SPI_GETCLIENTAREAANIMATION      = 0x1042;
        public const uint SPI_SETCLIENTAREAANIMATION      = 0x1043;
        public const uint SPI_GETDISABLEOVERLAPPEDCONTENT = 0x1040;
        public const uint SPI_SETDISABLEOVERLAPPEDCONTENT = 0x1041;
        public const uint SPI_GETFILTERKEYS               = 0x0032;
        public const uint SPI_SETFILTERKEYS               = 0x0033;
        public const uint SPI_GETFOCUSBORDERHEIGHT        = 0x2010;
        public const uint SPI_SETDOCUSBORDERHEIGHT        = 0x2011;
        public const uint SPI_GETFOCUSBORDERWIDTH         = 0x200e;
        public const uint SPI_SETFOCUSBORDERWIDTH         = 0x200f;
        public const uint SPI_GETHIGHCONTRAST             = 0x0042;
        public const uint SPI_SETHIGHCONTRAST             = 0x0043;
        public const uint SPI_GETLOGICALDPIOVERRIDE       = 0x009e;
        public const uint SPI_SETLOGICALDPIOVERRIDE       = 0x009f;
        public const uint SPI_GETMESSAGEDURATION          = 0x2016;
        public const uint SPI_SETMESSAGEDURATION          = 0x2017;
        public const uint SPI_GETMOUSECLICKLOCK           = 0x101e;
        public const uint SPI_SETMOUSECLICKLOCK           = 0x101f;
        public const uint SPI_GETMOUSECLICKLOCKTIME       = 0x2008;
        public const uint SPI_SETMOUSECLICKLOCKTIME       = 0x2009;
        public const uint SPI_GETMOUSEKEYS                = 0x0036;
        public const uint SPI_SETMOUSEKEYS                = 0x0037;
        public const uint SPI_GETMOUSESONAR               = 0x101c;
        public const uint SPI_SETMOUSESONAR               = 0x101d;
        public const uint SPI_GETMOUSEVANISH              = 0x1020;
        public const uint SPI_SETMOUSEVANISH              = 0x1021;
        public const uint SPI_GETSCREENREADER             = 0x0046;
        public const uint SPI_SETSCREENREADER             = 0x0047;
        public const uint SPI_GETSERIALKEYS               = 0x003e;
        public const uint SPI_SETSERIALKEYS               = 0x003f;
        public const uint SPI_GETSHOWSOUNDS               = 0x0038;
        public const uint SPI_SETSHOWSOUNDS               = 0x0039;
        public const uint SPI_GETSOUNDSENTRY              = 0x0040;
        public const uint SPI_SETSOUNDSENTRY              = 0x0041;
        public const uint SPI_GETSTICKYKEYS               = 0x003a;
        public const uint SPI_SETSTICKYKEYS               = 0x003b;
        public const uint SPI_GETTOGGLEKEYS               = 0x0034;
        public const uint SPI_SETTOGGLEKEYS               = 0x0035;
        #endregion

        #region Desktop parameters
        public const uint SPI_GETCLEARTYPE                = 0x1048;
        public const uint SPI_SETCLEARTYPE                = 0x1049;
        public const uint SPI_GETDESKWALLPAPER            = 0x0073;
        public const uint SPI_SETDESKWALLPAPER            = 0x0014;
        public const uint SPI_GETDROPSHADOW               = 0x1024;
        public const uint SPI_SETDROPSHADOW               = 0x1025;
        public const uint SPI_GETFLATMENU                 = 0x1022;
        public const uint SPI_SETFLATMENU                 = 0x1023;
        public const uint SPI_GETFONTSMOOTHING            = 0x004a;
        public const uint SPI_SETFONTSMOOTHING            = 0x004b;
        public const uint SPI_GETFONTSMOOTHINGCONTRAST    = 0x200c;
        public const uint SPI_SETFONTSMOOTHINGCONTRAST    = 0x200d;
        public const uint SPI_GETFONTSMOOTHINGORIENTATION = 0x2012;
        public const uint SPI_SETFONTSMOOTHINGORIENTATION = 0x2013;
        public const uint SPI_GETFONTSMOOTHINGTYPE        = 0x200a;
        public const uint SPI_SETFONTSMOOTHINGTYPE        = 0x200b;
        public const uint SPI_GETWORKAREA                 = 0x0030;
        public const uint SPI_SETWORKAREA                 = 0x002f;
        public const uint SPI_SETCURSORS                  = 0x0057;
        public const uint SPI_SETDESKPATTERN              = 0x0015;
        #endregion

        #region Icon parameters
        public const uint SPI_GETICONMETRICS        = 0x002d;
        public const uint SPI_SETICONMETRICS        = 0x002e;
        public const uint SPI_GETICONTITLELOGFONT   = 0x001f;
        public const uint SPI_SETICONTITLELOGFONT   = 0x0022;
        public const uint SPI_SETICONS              = 0x0058;
        public const uint SPI_GETICONTITLEWRAP      = 0x0019;
        public const uint SPI_SETICONTITLEWRAP      = 0x001a;
        public const uint SPI_ICONHORIZONTALSPACING = 0x000d;
        public const uint SPI_ICONVERTICALSPACING   = 0x0018;
        #endregion

        #region Input parameters
        public const uint SPI_GETBEEP                     = 0x0001;
        public const uint SPI_SETBEEP                     = 0x0002;
        public const uint SPI_GETBLOCKSENDINPUTRESETS     = 0x1026;
        public const uint SPI_SETBLOCKSENDINPUTRESETS     = 0x1027;
        public const uint SPI_GETCONTACTVISUALIZATION     = 0x2018;
        public const uint SPI_SETCONTACTVISUALIZATION     = 0x2019;
        public const uint SPI_GETDEFAULTINPUTLANG         = 0x0059;
        public const uint SPI_SETDEFAULTINPUTLANG         = 0x005a;
        public const uint SPI_GETGESTUREVISUALIZATION     = 0x201a;
        public const uint SPI_SETGESTUREVISUALIZATION     = 0x201b;
        public const uint SPI_SETDOUBLECLICKTIME          = 0x0020;
        public const uint SPI_SETDOUBLECLICKHEIGHT        = 0x001e;
        public const uint SPI_SETDOUBLECLICKWIDTH         = 0x001d;
        public const uint SPI_GETKEYBOARDCUES             = 0x100a;
        public const uint SPI_SETKEYBOARDCUES             = 0x100b;
        public const uint SPI_GETKEYBOARDDELAY            = 0x0016;
        public const uint SPI_SETKEYBOARDDELAY            = 0x0017;
        public const uint SPI_GETKEYBOARDPREF             = 0x0044;
        public const uint SPI_SETKEYBOARDPREF             = 0x0045;
        public const uint SPI_GETKEYBOARDSPEED            = 0x000a;
        public const uint SPI_SETKEYBOARDSPEED            = 0x000b;
        public const uint SPI_SETLANGTOGGLE               = 0x005b;
        public const uint SPI_GETMOUSE                    = 0x0003;
        public const uint SPI_SETMOUSE                    = 0x0004;
        public const uint SPI_SETMOUSEBUTTONSWAP          = 0x0021;
        public const uint SPI_GETMOUSEHOVERHEIGHT         = 0x0064;
        public const uint SPI_SETMOUSEHOVERHEIGHT         = 0x0065;
        public const uint SPI_GETMOUSEHOVERTIME           = 0x0066;
        public const uint SPI_SETMOUSEHOVERTIME           = 0x0067;
        public const uint SPI_GETMOUSEHOVERWIDTH          = 0x0062;
        public const uint SPI_SETMOUSEHOVERWIDTH          = 0x0063;
        public const uint SPI_GETMOUSESPEED               = 0x0070;
        public const uint SPI_SETMOUSESPEED               = 0x0071;
        public const uint SPI_GETMOUSETRAILS              = 0x005e;
        public const uint SPI_SETMOUSETRAILS              = 0x005d;
        public const uint SPI_GETMOUSEWHEELROUTING        = 0x201c;
        public const uint SPI_SETMOUSEWHEELROUTING        = 0x201d;
        public const uint SPI_GETPENVISUALIZATION         = 0x201e;
        public const uint SPI_SETPENVISUALIZATION         = 0x201f;
        public const uint SPI_GETSNAPTODEFBUTTON          = 0x005f;
        public const uint SPI_SETSNAPTODEFBUTTON          = 0x0060;
        public const uint SPI_GETSYSTEMLANGUAGEBAR        = 0x1050;
        public const uint SPI_SETSYSTEMLANGUAGEBAR        = 0x1051;
        public const uint SPI_GETTHREADLOCALINPUTSETTINGS = 0x104e;
        public const uint SPI_SETTHREADLOCALINPUTSETTINGS = 0x104f;
        public const uint SPI_GETWHEELSCROLLCHARS         = 0x006c;
        public const uint SPI_SETWHEELSCROLLCHARS         = 0x006d;
        public const uint SPI_GETWHEELSCROLLLINES         = 0x0068;
        public const uint SPI_SETWHEELSCROLLLINES         = 0x0069;
        #endregion

        #region Menu parameters
        public const uint SPI_GETMENUDROPALIGNMENT = 0x001b;
        public const uint SPI_SETMENUDROPALIGNMENT = 0x001c;
        public const uint SPI_GETMENUFADE          = 0x1012;
        public const uint SPI_SETMENUFADE          = 0x1013;
        public const uint SPI_GETMENUSHOWDELAY     = 0x006a;
        public const uint SPI_SETMENUSHOWDELAY     = 0x006b;
        #endregion

        #region Screen saver parameters
        public const uint SPI_GETSCREENSAVEACTIVE   = 0x0010;
        public const uint SPI_SETSCREENSAVEACTIVE   = 0x0011;
        public const uint SPI_GETSCREENSAVERRUNNING = 0x0072;
        public const uint SPI_GETSCREENSAVESECURE   = 0x0076;
        public const uint SPI_SETSCREENSAVESECURE   = 0x0077;
        public const uint SPI_GETSCREENSAVETIMEOUT  = 0x000e;
        public const uint SPI_SETSCREENSAVETIMEOUT  = 0x000f;
        #endregion

        #region Time-out parameters
        public const uint SPI_GETHUNGAPPTIMEOUT           = 0x0078;
        public const uint SPI_SETHUNGAPPTIMEOUT           = 0x0079;
        public const uint SPI_GETWAITTOKILLTIMEOUT        = 0x007a;
        public const uint SPI_SETWAITTOKILLTIMEOUT        = 0x007b;
        public const uint SPI_GETWAITTOKILLSERVICETIMEOUT = 0x007c;
        public const uint SPI_SETWAITTOKILLSERVICETIMEOUT = 0x007d;
        #endregion

        #region UI effects
        public const uint SPI_GETCOMBOBOXANIMATION      = 0x1004;
        public const uint SPI_SETCOMBOBOXANIMATION      = 0x1005;
        public const uint SPI_GETCURSORSHADOW           = 0x101a;
        public const uint SPI_SETCURSORSHADOW           = 0x101b;
        public const uint SPI_GETGRADIENTCAPTIONS       = 0x1008;
        public const uint SPI_SETGRADIENTCAPTIONS       = 0x1009;
        public const uint SPI_GETHOTTRACKING            = 0x100e;
        public const uint SPI_SETHOTTRACKING            = 0x100f;
        public const uint SPI_GETLISTBOXSMOOTHSCROLLING = 0x1006;
        public const uint SPI_SETLISTBOXSMOOTHSCROLLING = 0x1007;
        public const uint SPI_GETMENUANIMATION          = 0x1002;
        public const uint SPI_SETMENUANIMATION          = 0x1003;
        public const uint SPI_GETMENUUNDERLINES         = 0x100a;
        public const uint SPI_SETMENUUNDERLINES         = 0x100b;
        public const uint SPI_GETSELECTIONFADE          = 0x1014;
        public const uint SPI_SETSELECTIONFADE          = 0x1015;
        public const uint SPI_GETTOOLTIPANIMATION       = 0x1016;
        public const uint SPI_SETTOOLTIPANIMATION       = 0x1017;
        public const uint SPI_GETTOOLTIPFADE            = 0x1018;
        public const uint SPI_SETTOOLTIPFADE            = 0x1019;
        public const uint SPI_GETUIEFFECTS              = 0x103e;
        public const uint SPI_SETUIEFFECTS              = 0x103f;
        #endregion

        #region Window parameters
        public const uint SPI_GETACTIVEWINDOWTRACKING   = 0x1000;
        public const uint SPI_SETACTIVEWINDOWTRACKING   = 0x1001;
        public const uint SPI_GETACTIVEWNDTRKZORDER     = 0x100c;
        public const uint SPI_SETACTIVEWNDTRKZORDER     = 0x100d;
        public const uint SPI_GETACTIVEWNDTRKTIMEOUT    = 0x2002;
        public const uint SPI_SETACTIVEWNDTRKTIMEOUT    = 0x2003;
        public const uint SPI_GETANIMATION              = 0x0048;
        public const uint SPI_SETANIMATION              = 0x0049;
        public const uint SPI_GETBORDER                 = 0x0005;
        public const uint SPI_SETBORDER                 = 0x0006;
        public const uint SPI_GETCARETWIDTH             = 0x2006;
        public const uint SPI_SETCARETWIDTH             = 0x2007;
        public const uint SPI_GETDOCKMOVING             = 0x0090;
        public const uint SPI_SETDOCKMOVING             = 0x0091;
        public const uint SPI_GETDRAGFROMMAXIMIZE       = 0x008c;
        public const uint SPI_SETDRAGFROMMAXIMIZE       = 0x008d;
        public const uint SPI_GETDRAGFULLWINDOWS        = 0x0026;
        public const uint SPI_SETDRAGFULLWINDOWS        = 0x0025;
        public const uint SPI_GETFOREGROUNDFLASHCOUNT   = 0x2004;
        public const uint SPI_SETFOREGROUNDFLASHCOUNT   = 0x2005;
        public const uint SPI_GETFOREGROUNDLOCKTIMEOUT  = 0x2000;
        public const uint SPI_SETFOREGROUNDLOCKTIMEOUT  = 0x2001;
        public const uint SPI_GETMINIMIZEDMETRICS       = 0x002b;
        public const uint SPI_SETMINIMIZEDMETRICS       = 0x002c;
        public const uint SPI_GETMOUSEDOCKTRESHOLD      = 0x007e;
        public const uint SPI_SETMOUSEDOCKTRESHOLD      = 0x007f;
        public const uint SPI_GETMOUSEDRAGOUTTRESHOLD   = 0x0084;
        public const uint SPI_SETMOUSEDRAGOUTTRESHOLD   = 0x0085;
        public const uint SPI_GETMOUSESIDEMOVETHRESHOLD = 0x0088;
        public const uint SPI_SETMOUSESIDEMOVETHRESHOLD = 0x0089;
        public const uint SPI_GETNONCLIENTMETRICS       = 0x0029;
        public const uint SPI_SETNONCLIENTMETRICS       = 0x002a;
        public const uint SPI_GETPENDOCKTRESHOLD        = 0x0080;
        public const uint SPI_SETPENDOCKTRESHOLD        = 0x0081;
        public const uint SPI_GETPENDRAGOUTTRESHOLD     = 0x0086;
        public const uint SPI_SETPENDRAGOUTTRESHOLD     = 0x0087;
        public const uint SPI_GETPENSIDEMOVETRESHOLD    = 0x008a;
        public const uint SPI_SETPENSIDEMOVETRESHOLD    = 0x008b;
        public const uint SPI_GETSHOWIMEUI              = 0x006e;
        public const uint SPI_SETSHOWIMEUI              = 0x006f;
        public const uint SPI_GETSNAPSIZING             = 0x008e;
        public const uint SPI_SETSNAPSIZING             = 0x008f;
        public const uint SPI_GETWINARRANGING           = 0x0082;
        public const uint SPI_SETWINARRANGING           = 0x0083;
        public const uint SPI_SETDRAGHEIGHT             = 0x004d;
        public const uint SPI_SETDRAGWIDTH              = 0x004c;
        #endregion

        #region MessageBox values
        public const uint MB_ABORTRETRYIGNORE     = 0x00000002;
        public const uint MB_CANCELTRYCONTINUE    = 0x00000006;
        public const uint MB_HELP                 = 0x00004000;
        public const uint MB_OK                   = 0x00000000;
        public const uint MB_OKCANCEL             = 0x00000001;
        public const uint MB_RETRYCANCEL          = 0x00000005;
        public const uint MB_YESNO                = 0x00000004;
        public const uint MB_YESNOCANCEL          = 0x00000003;
        public const uint MB_ICONEXCLAMATION      = 0x00000030;
        public const uint MB_ICONWARNING          = 0x00000030;
        public const uint MB_ICONINFORMATION      = 0x00000040;
        public const uint MB_ICONASTERISK         = 0x00000040;
        public const uint MB_ICONQUESTION         = 0x00000020;
        public const uint MB_ICONSTOP             = 0x00000010;
        public const uint MB_ICONERROR            = 0x00000010;
        public const uint MB_ICONHAND             = 0x00000010;
        public const uint MB_DEFBUTTON1           = 0x00000000;
        public const uint MB_DEFBUTTON2           = 0x00000100;
        public const uint MB_DEFBUTTON3           = 0x00000200;
        public const uint MB_DEFBUTTON4           = 0x00000300;
        public const uint MB_APPMODAL             = 0x00000000;
        public const uint MB_SYSTEMMODAL          = 0x00001000;
        public const uint MB_TASKMODAL            = 0x00002000;
        public const uint MB_DEFAULT_DESKTOP_ONLY = 0x00020000;
        public const uint MB_RIGHT                = 0x00080000;
        public const uint MB_RTLREADING           = 0x00100000;
        public const uint MB_SETFOREGROUND        = 0x00010000;
        public const uint MB_TOPMOST              = 0x00040000;
        public const uint MB_SERVICE_NOTIFICATION = 0x00200000;
        public const uint MB_USERICON             = 0x00000080;

        public const int IDABORT    = 3;
        public const int IDCANCEL   = 2;
        public const int IDCONTINUE = 11;
        public const int IDIGNORE   = 5;
        public const int IDNO       = 7;
        public const int IDOK       = 1;
        public const int IDRETRY    = 4;
        public const int IDTRYAGAIN = 10;
        public const int IDYES      = 6;

        #endregion

        #region Hook types

        public const int WH_CALLWNDPROC     = 4;
        public const int WH_CALLWNDPROCRET  = 12;
        public const int WH_CBT             = 5;
        public const int WH_DEBUG           = 9;
        public const int WH_FOREGROUNDIDLE  = 11;
        public const int WH_GETMESSAGE      = 3;
        public const int WH_JOURNALPLAYBACK = 1;
        public const int WH_JOURNALRECORD   = 0;
        public const int WH_KEYBOARD        = 2;
        public const int WH_KEYBOARD_LL     = 13;
        public const int WH_MOUSE           = 7;
        public const int WH_MOUSE_LL        = 14;
        public const int WH_MSGFILTER       = -1;
        public const int WH_SHELL           = 10;
        public const int WH_SYSMSGFILTER    = 6;

        #endregion

        #endregion

        #region STRUCTS
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct WndClassA
        {
            public uint style;
            public WNDPROC lpfnWndProc;
            public int cbClsExtra;
            public int cbWndExtra;
            public HINSTANCE hInstance;
            public HICON hIcon;
            public HCURSOR hCursor;
            public HBRUSH hbrBackground;
            [MarshalAs(UnmanagedType.LPStr)]
            public string lpszMenuName;
            [MarshalAs(UnmanagedType.LPStr)]
            public string lpszClassName;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct WndClassW
        {
            public uint style;
            public WNDPROC lpfnWndProc;
            public int cbClsExtra;
            public int cbWndExtra;
            public HINSTANCE hInstance;
            public HICON hIcon;
            public HCURSOR hCursor;
            public HBRUSH hbrBackground;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string lpszMenuName;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string lpszClassName;
        }
        
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct WndClassExA
        {
            public uint cbSize;
            public uint style;
            public WNDPROC lpfnWndProc;
            public int cbClsExtra;
            public int cbWndExtra;
            public HINSTANCE hInstance;
            public HICON hIcon;
            public HCURSOR hCursor;
            public HBRUSH hbrBackground;
            [MarshalAs(UnmanagedType.LPStr)]
            public string lpszMenuName;
            [MarshalAs(UnmanagedType.LPStr)]
            public string lpszClassName;
            public HICON hIconSmall;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct WndClassExW
        {
            public uint cbSize;
            public uint style;
            public WNDPROC lpfnWndProc;
            public int cbClsExtra;
            public int cbWndExtra;
            public HINSTANCE hInstance;
            public HICON hIcon;
            public HCURSOR hCursor;
            public HBRUSH hbrBackground;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string lpszMenuName;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string lpszClassName;
            public HICON hIconSmall;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Msg
        {
            public HWND hWnd;
            public uint message;
            public WPARAM wParam;
            public LPARAM lParam;
            public DWORD time;
            public Point pt;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct NonClientMetricsA
        {
            public uint cbSize;
            public int iBorderWidth;
            public int iScrollWidth;
            public int iScrollHeight;
            public int iCaptionWidth;
            public int iCaptionHeight;
            public LogFontA lfCaptionFont;
            public int iSmCaptionWidth;
            public int iSmCaptionHeight;
            public LogFontA lfSmCaptionFont;
            public int iMenuWidth;
            public int iMenuHeight;
            public LogFontA lfMenuFont;
            public LogFontA lfStatusFont;
            public LogFontA lfMessageFont;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct NonClientMetricsW
        {
            public uint cbSize;
            public int iBorderWidth;
            public int iScrollWidth;
            public int iScrollHeight;
            public int iCaptionWidth;
            public int iCaptionHeight;
            public LogFontW lfCaptionFont;
            public int iSmCaptionWidth;
            public int iSmCaptionHeight;
            public LogFontW lfSmCaptionFont;
            public int iMenuWidth;
            public int iMenuHeight;
            public LogFontW lfMenuFont;
            public LogFontW lfStatusFont;
            public LogFontW lfMessageFont;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct LogFontA
        {
            public uint lfHeight;
            public uint lfWidth;
            public uint lfEscapement;
            public uint lfOrientation;
            public uint lfWeight;
            public byte lfItalic;
            public byte lfUnderline;
            public byte lfStrikeOut;
            public byte lfCharSet;
            public byte lfOutPrecision;
            public byte lfClipPrecision;
            public byte lfQuality;
            public byte lfPitchAndFamily;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string lfFaceName;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct LogFontW
        {
            public uint lfHeight;
            public uint lfWidth;
            public uint lfEscapement;
            public uint lfOrientation;
            public uint lfWeight;
            public byte lfItalic;
            public byte lfUnderline;
            public byte lfStrikeOut;
            public byte lfCharSet;
            public byte lfOutPrecision;
            public byte lfClipPrecision;
            public byte lfQuality;
            public byte lfPitchAndFamily;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string lfFaceName;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct MsgBoxParamsA
        {
            public uint cbSize;
            public HWND hwndOwner;
            public HINSTANCE hInstance;
            [MarshalAs(UnmanagedType.LPStr)]
            public string lpszText;
            [MarshalAs(UnmanagedType.LPStr)]
            public string lpszCaption;
            public DWORD dwStyle;
            [MarshalAs(UnmanagedType.LPStr)]
            public string lpszIcon;
            public DWORD dwContextHelpId;
            public IntPtr lpfnMsgBoxCallback;
            public DWORD dwLanguageId;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct MsgBoxParamsW
        {
            public uint cbSize;
            public HWND hwndOwner;
            public HINSTANCE hInstance;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string lpszText;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string lpszCaption;
            public DWORD dwStyle;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string lpszIcon;
            public DWORD dwContextHelpId;
            public IntPtr lpfnMsgBoxCallback;
            public DWORD dwLanguageId;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Point
        {
            public long x;
            public long y;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct HelpInfo
        {
            uint cbSize;
            int iContextType;
            int iCtrlId;
            HANDLE hItemHandle;
            DWORD dwContextId;
            Point MousePos;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Rect
        {
            public long left;
            public long top;
            public long right;
            public long bottom;
        }

        #endregion

        #region IMPORTS
        private static class API
        {
            [DllImport("user32.dll", CharSet = CharSet.Ansi)]
            public static extern int MessageBoxA(IntPtr hWnd, string text, string caption, uint type);
            [DllImport("user32.dll", CharSet = CharSet.Unicode)]
            public static extern int MessageBoxW(IntPtr hWnd, string text, string caption, uint type);
            [DllImport("user32.dll", CharSet = CharSet.Ansi)]
            public static extern int MessageBoxExA(IntPtr hWnd, string text, string caption, uint type, ushort wLanguageId);
            [DllImport("user32.dll", CharSet = CharSet.Unicode)]
            public static extern int MessageBoxExW(IntPtr hWnd, string text, string caption, uint type, ushort wLanguageId);
            [DllImport("user32.dll", CharSet = CharSet.Ansi)]
            public static extern int MessageBoxIndirectA(IntPtr lpmbp);
            [DllImport("user32.dll", CharSet = CharSet.Ansi)]
            public static extern int MessageBoxIndirectA(ref MsgBoxParamsA lpmbp);
            [DllImport("user32.dll", CharSet = CharSet.Unicode)]
            public static extern int MessageBoxIndirectW(IntPtr lpmbp);
            [DllImport("user32.dll", CharSet = CharSet.Unicode)]
            public static extern int MessageBoxIndirectW(ref MsgBoxParamsW lpmbp);

            [DllImport("user32.dll", CharSet = CharSet.Ansi)]
            public static extern IntPtr CreateWindowExA(ulong dwExStyle, string lpClassName, string lpWindowName, ulong dwStyle, int X, int Y, int nWidth,
                int nHeight, IntPtr hWndParent, IntPtr hMenu, IntPtr hInstance, IntPtr lpParam);
            [DllImport("user32.dll", CharSet = CharSet.Unicode)]
            public static extern IntPtr CreateWindowExW(ulong dwExStyle, string lpClassName, string lpWindowName, ulong dwStyle, int X, int Y, int nWidth,
                int nHeight, IntPtr hWndParent, IntPtr hMenu, IntPtr hInstance, IntPtr lpParam);

            [DllImport("user32.dll", CharSet = CharSet.Ansi)]
            public static extern ushort RegisterClassA(IntPtr lpWndClass);
            [DllImport("user32.dll", CharSet = CharSet.Unicode)]
            public static extern ushort RegisterClassW(IntPtr lpWndClass);
            [DllImport("user32.dll", CharSet = CharSet.Ansi)]
            public static extern ushort RegisterClassA(ref WndClassA lpWndClass);
            [DllImport("user32.dll", CharSet = CharSet.Unicode)]
            public static extern ushort RegisterClassW(ref WndClassW lpWndClass);
            [DllImport("user32.dll", CharSet = CharSet.Ansi)]
            public static extern ushort RegisterClassExA(IntPtr lpWndClass);
            [DllImport("user32.dll", CharSet = CharSet.Unicode)]
            public static extern ushort RegisterClassExW(IntPtr lpWndClass);
            [DllImport("user32.dll", CharSet = CharSet.Ansi)]
            public static extern ushort RegisterClassExA(ref WndClassExA lpWndClass);
            [DllImport("user32.dll", CharSet = CharSet.Unicode)]
            public static extern ushort RegisterClassExW(ref WndClassExW lpWndClass);

            [DllImport("user32.dll", CharSet = CharSet.Ansi)]
            public static extern long DefWindowProcA(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);
            [DllImport("user32.dll", CharSet = CharSet.Unicode)]
            public static extern long DefWindowProcW(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

            [DllImport("user32.dll", CharSet = CharSet.Ansi)]
            public static extern long DispatchMessageA(IntPtr lpMsg);
            [DllImport("user32.dll", CharSet = CharSet.Ansi)]
            public static extern long DispatchMessageA(ref Msg lpMsg);
            [DllImport("user32.dll", CharSet = CharSet.Unicode)]
            public static extern long DispatchMessageW(IntPtr lpMsg);
            [DllImport("user32.dll", CharSet = CharSet.Unicode)]
            public static extern long DispatchMessageW(ref Msg lpMsg);

            [DllImport("kernel32.dll")]
            public static extern void ExitProcess(uint uExitCode);

            [DllImport("user32.dll", CharSet = CharSet.Ansi)]
            public static extern bool GetMessageA(IntPtr lpMsg, IntPtr hWnd, uint wMsgFilterMin, uint wMsgFilterMax);
            [DllImport("user32.dll", CharSet = CharSet.Ansi)]
            public static extern bool GetMessageA(ref Msg lpMsg, IntPtr hWnd, uint wMsgFilterMin, uint wMsgFilterMax);
            [DllImport("user32.dll", CharSet = CharSet.Unicode)]
            public static extern bool GetMessageW(IntPtr lpMsg, IntPtr hWnd, uint wMsgFilterMin, uint wMsgFilterMax);
            [DllImport("user32.dll", CharSet = CharSet.Unicode)]
            public static extern bool GetMessageW(ref Msg lpMsg, IntPtr hWnd, uint wMsgFilterMin, uint wMsgFilterMax);

            [DllImport("kernel32.dll", CharSet = CharSet.Ansi)]
            public static extern IntPtr GetModuleHandleA(string lpModuleName);
            [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
            public static extern IntPtr GetModuleHandleW(string lpModuleName);
            [DllImport("kernel32.dll", CharSet = CharSet.Ansi)]
            public static extern bool GetModuleHandleExA(ulong dwFlags, string lpModuleName, IntPtr phModule);
            [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
            public static extern bool GetModuleHandleExW(ulong dwFlags, string lpModuleName, IntPtr phModule);
            [DllImport("kernel32.dll", CharSet = CharSet.Ansi)]
            public static extern bool GetModuleHandleExA(ulong dwFlags, string lpModuleName, ref IntPtr phModule);
            [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
            public static extern bool GetModuleHandleExW(ulong dwFlags, string lpModuleName, ref IntPtr phModule);

            [DllImport("user32.dll", CharSet = CharSet.Ansi)]
            public static extern IntPtr LoadCursorA(IntPtr hInstance, string lpCursorName);
            [DllImport("user32.dll", CharSet = CharSet.Unicode)]
            public static extern IntPtr LoadCursorW(IntPtr hInstance, string lpCursorName);
            [DllImport("user32.dll", CharSet = CharSet.Ansi)]
            public static extern IntPtr LoadCursorA(IntPtr hInstance, ulong lpCursorName);
            [DllImport("user32.dll", CharSet = CharSet.Unicode)]
            public static extern IntPtr LoadCursorW(IntPtr hInstance, ulong lpCursorName);
            [DllImport("user32.dll", CharSet = CharSet.Ansi)]
            public static extern IntPtr LoadCursorFromFileA(string lpFileName);
            [DllImport("user32.dll", CharSet = CharSet.Unicode)]
            public static extern IntPtr LoadCursorFromFileW(string lpFileName);

            [DllImport("user32.dll", CharSet = CharSet.Ansi)]
            public static extern IntPtr LoadIconA(IntPtr hInstance, string lpIconName);
            [DllImport("user32.dll", CharSet = CharSet.Unicode)]
            public static extern IntPtr LoadIconW(IntPtr hInstance, string lpIconName);
            [DllImport("user32.dll", CharSet = CharSet.Ansi)]
            public static extern IntPtr LoadIconA(IntPtr hInstance, ulong lpIconName);
            [DllImport("user32.dll", CharSet = CharSet.Unicode)]
            public static extern IntPtr LoadIconW(IntPtr hInstance, ulong lpIconName);

            [DllImport("user32.dll")]
            public static extern void PostQuitMessage(int nExitCode);

            [DllImport("user32.dll")]
            public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

            [DllImport("user32.dll")]
            public static extern bool TranslateMessage(IntPtr lpMsg);
            [DllImport("user32.dll")]
            public static extern bool TranslateMessage(ref Msg lpMsg);

            [DllImport("user32.dll")]
            public static extern bool UpdateWindow(IntPtr hWnd);

            [DllImport("gdi32.dll", CharSet = CharSet.Ansi)]
            public static extern IntPtr CreateFontIndirectA(ref LogFontA lplf);
            [DllImport("gdi32.dll", CharSet = CharSet.Unicode)]
            public static extern IntPtr CreateFontIndirectW(ref LogFontW lplf);
            [DllImport("gdi32.dll", CharSet = CharSet.Ansi)]
            public static extern IntPtr CreateFontIndirectA(IntPtr lplf);
            [DllImport("gdi32.dll", CharSet = CharSet.Unicode)]
            public static extern IntPtr CreateFontIndirectW(IntPtr lplf);
            [DllImport("gdi32.dll", CharSet = CharSet.Ansi)]
            public static extern IntPtr CreateFontA(int cHeight, int cWidth, int cEscapement, 
                int cOrientation, int cWeight, ulong bItalic, ulong bUnderline, ulong bStrikeOut, 
                ulong iCharSet, ulong iOutPrecision, ulong iClipPrecision, ulong iQuality, 
                ulong iPitchAndFamily, string pszFaceName);
            [DllImport("gdi32.dll", CharSet = CharSet.Unicode)]
            public static extern IntPtr CreateFontW(int cHeight, int cWidth, int cEscapement,
                int cOrientation, int cWeight, ulong bItalic, ulong bUnderline, ulong bStrikeOut,
                ulong iCharSet, ulong iOutPrecision, ulong iClipPrecision, ulong iQuality,
                ulong iPitchAndFamily, string pszFaceName);

            [DllImport("user32.dll", CharSet = CharSet.Ansi)]
            public static extern bool SystemParametersInfoA(uint uiAction, uint uiParam, IntPtr pvParam, uint fWinIni);
            [DllImport("user32.dll", CharSet = CharSet.Unicode)]
            public static extern bool SystemParametersInfoW(uint uiAction, uint uiParam, IntPtr pvParam, uint fWinIni);

            [DllImport("gdi32.dll")]
            public static extern bool DeleteObject(IntPtr ho);

            [DllImport("user32.dll", CharSet = CharSet.Ansi)]
            public static extern long SendMessageA(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);
            [DllImport("user32.dll", CharSet = CharSet.Unicode)]
            public static extern long SendMessageW(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);
            [DllImport("user32.dll", CharSet = CharSet.Ansi)]
            public static extern bool SendMessageCallbackA(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam, IntPtr lpResultCallBack, ulong dwData);
            [DllImport("user32.dll", CharSet = CharSet.Unicode)]
            public static extern bool SendMessageCallbackW(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam, IntPtr lpResultCallBack, ulong dwData);
            [DllImport("user32.dll", CharSet = CharSet.Ansi)]
            public static extern long SendMessageTimeoutA(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam, uint fuFlags, uint uTimeout, IntPtr lpdwResult);
            [DllImport("user32.dll", CharSet = CharSet.Unicode)]
            public static extern long SendMessageTimeoutW(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam, uint fuFlags, uint uTimeout, IntPtr lpdwResult);
            [DllImport("user32.dll", CharSet = CharSet.Ansi)]
            public static extern long SendMessageTimeoutA(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam, uint fuFlags, uint uTimeout, ref ulong lpdwResult);
            [DllImport("user32.dll", CharSet = CharSet.Unicode)]
            public static extern long SendMessageTimeoutW(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam, uint fuFlags, uint uTimeout, ref ulong lpdwResult);

            [DllImport("kernel32.dll")]
            public static extern ulong GetLastError();

            [DllImport("kernel32.dll", CharSet = CharSet.Ansi)]
            public static extern IntPtr LoadLibraryA(string lpLibFileName);
            [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
            public static extern IntPtr LoadLibraryW(string lpLibFileName);
            [DllImport("kernel32.dll", CharSet = CharSet.Ansi)]
            public static extern IntPtr LoadLibraryExA(string lpLibFileName, IntPtr hFile, ulong dwFlags);
            [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
            public static extern IntPtr LoadLibraryExW(string lpLibFileName, IntPtr hFile, ulong dwFlags);

            [DllImport("kernel32.dll")]
            public static extern bool FreeLibrary(IntPtr hLibModule);

            [DllImport("user32.dll")]
            public static extern bool GetClientRect(IntPtr hWnd, IntPtr lpRect);
            [DllImport("user32.dll")]
            public static extern bool GetClientRect(IntPtr hWnd, ref Rect lpRect);

            [DllImport("user32.dll")]
            public static extern bool GetWindowRect(IntPtr hWnd, IntPtr lpRect);
            [DllImport("user32.dll")]
            public static extern bool GetWindowRect(IntPtr hWnd, ref Rect lpRect);

            [DllImport("user32.dll", CharSet = CharSet.Ansi)]
            public static extern int GetWindowTextA(IntPtr hWnd, ref string lpString, int nMaxCount);
            [DllImport("user32.dll", CharSet = CharSet.Unicode)]
            public static extern int GetWindowTextW(IntPtr hWnd, ref string lpString, int nMaxCount);
            [DllImport("user32.dll", CharSet = CharSet.Ansi)]
            public static extern int GetWindowTextA(IntPtr hWnd, IntPtr lpString, int nMaxCount);
            [DllImport("user32.dll", CharSet = CharSet.Unicode)]
            public static extern int GetWindowTextW(IntPtr hWnd, IntPtr lpString, int nMaxCount);

            [DllImport("user32.dll", CharSet = CharSet.Ansi)]
            public static extern bool SetWindowTextA(IntPtr hWnd, string lpString);
            [DllImport("user32.dll", CharSet = CharSet.Unicode)]
            public static extern bool SetWindowTextW(IntPtr hWnd, string lpString);

            [DllImport("user32.dll", CharSet = CharSet.Ansi)]
            public static extern IntPtr SetWindowsHookExA(int idHook, IntPtr lpfn, IntPtr hmod, ulong dwThreadId);
            [DllImport("user32.dll", CharSet = CharSet.Unicode)]
            public static extern IntPtr SetWindowsHookExW(int idHook, IntPtr lpfn, IntPtr hmod, ulong dwThreadId);

            [DllImport("user32.dll")]
            public static extern long CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

            [DllImport("user32.dll")]
            public static extern bool UnhookWindowsHookEx(IntPtr hhk);
        }

        #endregion

        #region INTERFACE
        public static int MessageBoxA(HWND hWnd, LPCSTR text, LPCSTR caption, uint type) => API.MessageBoxA(hWnd, text, caption, type);
        public static int MessageBoxW(HWND hWnd, LPCWSTR text, LPCWSTR caption, uint type) => API.MessageBoxW(hWnd, text, caption, type);
        public static int MessageBoxExA(HWND hWnd, LPCSTR text, LPCSTR caption, uint type, WORD wLanguageId) => API.MessageBoxExA(hWnd, text, caption, type, wLanguageId);
        public static int MessageBoxExW(HWND hWnd, LPCWSTR text, LPCWSTR caption, uint type, WORD wLanguageId) => API.MessageBoxExW(hWnd, text, caption, type, wLanguageId);
        public static int MessageBoxIndirectA(IntPtr lpmbp) => API.MessageBoxIndirectA(lpmbp);
        public static int MessageBoxIndirectA(ref MsgBoxParamsA lpmbp) => API.MessageBoxIndirectA(ref lpmbp);
        public static int MessageBoxIndirectW(IntPtr lpmbp) => API.MessageBoxIndirectW(lpmbp);
        public static int MessageBoxIndirectW(ref MsgBoxParamsW lpmbp) => API.MessageBoxIndirectW(ref lpmbp);

        public static HWND CreateWindowExA(DWORD dwExStyle, LPCSTR lpClassName, LPCSTR lpWindowName, DWORD dwStyle,
            int X, int Y, int nWidth, int nHeight, HWND hWndParent, HMENU hMenu, HINSTANCE hInstance, LPVOID lpParam)
            => API.CreateWindowExA(dwExStyle, lpClassName, lpWindowName, dwStyle, X, Y, nWidth, nHeight, hWndParent, hMenu, hInstance, lpParam);
        public static HWND CreateWindowExW(DWORD dwExStyle, LPCWSTR lpClassName, LPCWSTR lpWindowName, DWORD dwStyle,
            int X, int Y, int nWidth, int nHeight, HWND hWndParent, HMENU hMenu, HINSTANCE hInstance, LPVOID lpParam)
            => API.CreateWindowExW(dwExStyle, lpClassName, lpWindowName, dwStyle, X, Y, nWidth, nHeight, hWndParent, hMenu, hInstance, lpParam);

        public static ATOM RegisterClassA(IntPtr lpWndClass) => API.RegisterClassA(lpWndClass);
        public static ATOM RegisterClassW(IntPtr lpWndClass) => API.RegisterClassW(lpWndClass);
        public static ATOM RegisterClassA(ref WndClassA lpWndClass) => API.RegisterClassA(ref lpWndClass);
        public static ATOM RegisterClassW(ref WndClassW lpWndClass) => API.RegisterClassW(ref lpWndClass);
        public static ATOM RegisterClassExA(IntPtr lpWndClass) => API.RegisterClassExA(lpWndClass);
        public static ATOM RegisterClassExW(IntPtr lpWndClass) => API.RegisterClassExW(lpWndClass);
        public static ATOM RegisterClassExA(ref WndClassExA lpWndClass) => API.RegisterClassExA(ref lpWndClass);
        public static ATOM RegisterClassExW(ref WndClassExW lpWndClass) => API.RegisterClassExW(ref lpWndClass);

        public static LRESULT DefWindowProcA(HWND hWnd, uint msg, WPARAM wParam, LPARAM lParam) => API.DefWindowProcA(hWnd, msg, wParam, lParam);
        public static LRESULT DefWindowProcW(HWND hWnd, uint msg, WPARAM wParam, LPARAM lParam) => API.DefWindowProcW(hWnd, msg, wParam, lParam);

        public static LRESULT DispatchMessageA(IntPtr lpMsg) => API.DispatchMessageA(lpMsg);
        public static LRESULT DispatchMessageA(ref Msg lpMsg) => API.DispatchMessageA(ref lpMsg);
        public static LRESULT DispatchMessageW(IntPtr lpMsg) => API.DispatchMessageW(lpMsg);
        public static LRESULT DispatchMessageW(ref Msg lpMsg) => API.DispatchMessageW(ref lpMsg);

        public static void ExitProcess(uint uExitCode) => API.ExitProcess(uExitCode);

        public static bool GetMessageA(IntPtr lpMsg, HWND hWnd, uint wMsgFilterMin, uint wMsgFilterMax) => API.GetMessageA(lpMsg, hWnd, wMsgFilterMin, wMsgFilterMax);
        public static bool GetMessageA(ref Msg lpMsg, HWND hWnd, uint wMsgFilterMin, uint wMsgFilterMax) => API.GetMessageA(ref lpMsg, hWnd, wMsgFilterMin, wMsgFilterMax);
        public static bool GetMessageW(IntPtr lpMsg, HWND hWnd, uint wMsgFilterMin, uint wMsgFilterMax) => API.GetMessageW(lpMsg, hWnd, wMsgFilterMin, wMsgFilterMax);
        public static bool GetMessageW(ref Msg lpMsg, HWND hWnd, uint wMsgFilterMin, uint wMsgFilterMax) => API.GetMessageW(ref lpMsg, hWnd, wMsgFilterMin, wMsgFilterMax);

        public static HMODULE GetModuleHandleA(LPCSTR lpModuleName) => API.GetModuleHandleA(lpModuleName);
        public static HMODULE GetModuleHandleW(LPCWSTR lpModuleName) => API.GetModuleHandleW(lpModuleName);
        public static void GetModuleHandleExA(DWORD dwFlags, LPCSTR lpModuleName, IntPtr phModule) => API.GetModuleHandleExA(dwFlags, lpModuleName, phModule);
        public static void GetModuleHandleExW(DWORD dwFlags, LPCWSTR lpModuleName, IntPtr phModule) => API.GetModuleHandleExW(dwFlags, lpModuleName, phModule);
        public static void GetModuleHandleExA(DWORD dwFlags, LPCSTR lpModuleName, ref HMODULE phModule) => API.GetModuleHandleExA(dwFlags, lpModuleName, ref phModule.value);
        public static void GetModuleHandleExW(DWORD dwFlags, LPCWSTR lpModuleName, ref HMODULE phModule) => API.GetModuleHandleExW(dwFlags, lpModuleName, ref phModule.value);

        public static HCURSOR LoadCursorA(HINSTANCE hInstance, LPCSTR lpCursorName) => API.LoadCursorA(hInstance, lpCursorName);
        public static HCURSOR LoadCursorW(HINSTANCE hInstance, LPCWSTR lpCursorName) => API.LoadCursorW(hInstance, lpCursorName);
        public static HCURSOR LoadCursorA(HINSTANCE hInstance, ulong lpCursorName) => API.LoadCursorA(hInstance, lpCursorName);
        public static HCURSOR LoadCursorW(HINSTANCE hInstance, ulong lpCursorName) => API.LoadCursorW(hInstance, lpCursorName);
        public static HCURSOR LoadCursorFromFileA(LPCSTR lpFileName) => API.LoadCursorFromFileA(lpFileName);
        public static HCURSOR LoadCursorFromFileW(LPCWSTR lpFileName) => API.LoadCursorFromFileA(lpFileName);

        public static HICON LoadIconA(HINSTANCE hInstance, LPCSTR lpIconName) => API.LoadIconA(hInstance, lpIconName);
        public static HICON LoadIconW(HINSTANCE hInstance, LPCWSTR lpIconName) => API.LoadIconA(hInstance, lpIconName);
        public static HICON LoadIconA(HINSTANCE hInstance, ulong lpIconName) => API.LoadIconA(hInstance, lpIconName);
        public static HICON LoadIconW(HINSTANCE hInstance, ulong lpIconName) => API.LoadIconA(hInstance, lpIconName);

        public static void PostQuitMessage(int nExitCode) => API.PostQuitMessage(nExitCode);

        public static bool ShowWindow(HWND hWnd, int nCmdShow) => API.ShowWindow(hWnd, nCmdShow);

        public static bool TranslateMessage(IntPtr lpMsg) => API.TranslateMessage(lpMsg);
        public static bool TranslateMessage(ref Msg lpMsg) => API.TranslateMessage(ref lpMsg);

        public static bool UpdateWindow(HWND hWnd) => API.UpdateWindow(hWnd);

        public static HFONT CreateFontIndirectA(ref LogFontA lplf) => API.CreateFontIndirectA(ref lplf);
        public static HFONT CreateFontIndirectW(ref LogFontW lplf) => API.CreateFontIndirectW(ref lplf);
        public static HFONT CreateFontIndirectA(IntPtr lplf) => API.CreateFontIndirectA(lplf);
        public static HFONT CreateFontIndirectW(IntPtr lplf) => API.CreateFontIndirectW(lplf);
        public static HFONT CreateFontA(int cHeight, int cWidth, int cEscapement,
            int cOrientation, int cWeight, ulong bItalic, ulong bUnderline, ulong bStrikeOut,
            ulong iCharSet, ulong iOutPrecision, ulong iClipPrecision, ulong iQuality,
            ulong iPitchAndFamily, LPCSTR pszFaceName) => API.CreateFontA(cHeight, cWidth,
                cEscapement, cOrientation, cWeight, bItalic, bUnderline, bStrikeOut,
                iCharSet, iOutPrecision, iClipPrecision, iQuality, iPitchAndFamily, pszFaceName);
        public static HFONT CreateFontW(int cHeight, int cWidth, int cEscapement,
            int cOrientation, int cWeight, ulong bItalic, ulong bUnderline, ulong bStrikeOut,
            ulong iCharSet, ulong iOutPrecision, ulong iClipPrecision, ulong iQuality,
            ulong iPitchAndFamily, LPCWSTR pszFaceName) => API.CreateFontW(cHeight, cWidth, 
                cEscapement, cOrientation, cWeight, bItalic, bUnderline, bStrikeOut, 
                iCharSet, iOutPrecision, iClipPrecision, iQuality, iPitchAndFamily, pszFaceName);

        public static bool SystemParametersInfoA(uint uiAction, uint uiParam, IntPtr pvParam, uint fWinIni) => API.SystemParametersInfoA(uiAction, uiParam, pvParam, fWinIni);
        public static bool SystemParametersInfoW(uint uiAction, uint uiParam, IntPtr pvParam, uint fWinIni) => API.SystemParametersInfoW(uiAction, uiParam, pvParam, fWinIni);

        public static bool DeleteObject(LPVOID ho) => API.DeleteObject(ho);

        public static LRESULT SendMessageA(HWND hWnd, uint msg, WPARAM wParam, LPARAM lParam) => API.SendMessageA(hWnd, msg, wParam, lParam);
        public static LRESULT SendMessageW(HWND hWnd, uint msg, WPARAM wParam, LPARAM lParam) => API.SendMessageW(hWnd, msg, wParam, lParam);
        public static bool SendMessageCallbackA(HWND hWnd, uint msg, WPARAM wParam, LPARAM lParam, IntPtr lpResultCallBack, ulong dwData) 
            => API.SendMessageCallbackA(hWnd, msg, lParam, wParam, lpResultCallBack, dwData);
        public static bool SendMessageCallbackW(HWND hWnd, uint msg, WPARAM wParam, LPARAM lParam, IntPtr lpResultCallBack, ulong dwData) 
            => API.SendMessageCallbackW(hWnd, msg, lParam, wParam, lpResultCallBack, dwData);
        public static LRESULT SendMessageTimeoutA(HWND hWnd, uint msg, WPARAM wParam, LPARAM lParam, uint fuFlags, uint uTimeout, IntPtr lpdwResult) 
            => API.SendMessageTimeoutA(hWnd, msg, lParam, wParam, fuFlags, uTimeout, lpdwResult);
        public static LRESULT SendMessageTimeoutW(HWND hWnd, uint msg, WPARAM wParam, LPARAM lParam, uint fuFlags, uint uTimeout, IntPtr lpdwResult) 
            => API.SendMessageTimeoutW(hWnd, msg, lParam, wParam, fuFlags, uTimeout, lpdwResult);
        public static LRESULT SendMessageTimeoutA(HWND hWnd, uint msg, WPARAM wParam, LPARAM lParam, uint fuFlags, uint uTimeout, ref ulong lpdwResult) 
            => API.SendMessageTimeoutA(hWnd, msg, lParam, wParam, fuFlags, uTimeout, ref lpdwResult);
        public static LRESULT SendMessageTimeoutW(HWND hWnd, uint msg, WPARAM wParam, LPARAM lParam, uint fuFlags, uint uTimeout, ref ulong lpdwResult) 
            => API.SendMessageTimeoutW(hWnd, msg, lParam, wParam, fuFlags, uTimeout, ref lpdwResult);

        public static DWORD GetLastError() => API.GetLastError();

        public static HMODULE LoadLibraryA(LPCSTR lpLibFileName) => API.LoadLibraryA(lpLibFileName);
        public static HMODULE LoadLibraryW(LPCWSTR lpLibFileName) => API.LoadLibraryW(lpLibFileName);
        public static HMODULE LoadLibraryExA(LPCSTR lpLibFileName, HANDLE hFile, DWORD dwFlags) => API.LoadLibraryExA(lpLibFileName, hFile, dwFlags);
        public static HMODULE LoadLibraryExW(LPCWSTR lpLibFileName, HANDLE hFile, DWORD dwFlags) => API.LoadLibraryExW(lpLibFileName, hFile, dwFlags);

        public static bool FreeLibrary(HMODULE hLibModule) => API.FreeLibrary(hLibModule);

        public static bool GetClientRect(HWND hWnd, IntPtr lpRect) => API.GetClientRect(hWnd, lpRect);
        public static bool GetClientRect(HWND hWnd, ref Rect lpRect) => API.GetClientRect(hWnd, ref lpRect);

        public static bool GetWindowRect(HWND hWnd, IntPtr lpRect) => API.GetWindowRect(hWnd, lpRect);
        public static bool GetWindowRect(HWND hWnd, ref Rect lpRect) => API.GetWindowRect(hWnd, ref lpRect);

        public static int GetWindowTextA(HWND hWnd, IntPtr lpString, int nMaxCount) => API.GetWindowTextA(hWnd, lpString, nMaxCount);
        public static int GetWindowTextW(HWND hWnd, IntPtr lpString, int nMaxCount) => API.GetWindowTextW(hWnd, lpString, nMaxCount);
        public static int GetWindowTextA(HWND hWnd, ref LPCSTR lpString, int nMaxCount) => API.GetWindowTextA(hWnd, ref lpString.value, nMaxCount);
        public static int GetWindowTextW(HWND hWnd, ref LPCWSTR lpString, int nMaxCount) => API.GetWindowTextW(hWnd, ref lpString.value, nMaxCount);

        public static bool SetWindowTextA(HWND hWnd, LPCSTR lpString) => API.SetWindowTextA(hWnd, lpString);
        public static bool SetWindowTextW(HWND hWnd, LPCWSTR lpString) => API.SetWindowTextW(hWnd, lpString);

        public static HHOOK SetWindowsHookExA(int idHook, IntPtr lpfn, HINSTANCE hmod, DWORD dwThreadId) => API.SetWindowsHookExA(idHook, lpfn, hmod, dwThreadId);
        public static HHOOK SetWindowsHookExW(int idHook, IntPtr lpfn, HINSTANCE hmod, DWORD dwThreadId) => API.SetWindowsHookExW(idHook, lpfn, hmod, dwThreadId);

        public static LRESULT CallNextHookEx(HHOOK hhk, int nCode, WPARAM wParam, LPARAM lParam) => API.CallNextHookEx(hhk, nCode, wParam, lParam);

        public static bool UnhookWindowsHookEx(HHOOK hhk) => API.UnhookWindowsHookEx(hhk);

        #endregion
    }
}