using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWinApi
{
    public struct DWORD
    {
        internal ulong value;
        public static implicit operator ulong(DWORD v) => v.value;
        public static implicit operator DWORD(ulong v) => new DWORD(v);
        DWORD(ulong v) => value = v;
    }

    public struct WORD
    {
        internal ushort value;
        public static implicit operator ushort(WORD v) => v.value;
        public static implicit operator WORD(ushort v) => new WORD(v);
        WORD(ushort v) => value = v;
    }

    public struct HANDLE
    {
        internal IntPtr value;
        public static readonly IntPtr Null = IntPtr.Zero;
        public static implicit operator IntPtr(HANDLE v) => v.value;
        public static implicit operator HANDLE(IntPtr v) => new HANDLE(v);
        HANDLE(IntPtr v) => value = v;
    }

    public struct LPCSTR
    {

        internal string value;
        public static implicit operator string(LPCSTR v) => v.value;
        public static implicit operator LPCSTR(string v) => new LPCSTR(v);
        LPCSTR(string v) => value = v;
    }

    public struct LPCWSTR
    {
        internal string value;
        public static implicit operator string(LPCWSTR v) => v.value;
        public static implicit operator LPCWSTR(string v) => new LPCWSTR(v);
        LPCWSTR(string v) => value = v;
    }

    public struct HWND
    {
        internal IntPtr value;
        public static implicit operator IntPtr(HWND v) => v.value;
        public static implicit operator HWND(IntPtr v) => new HWND(v);
        HWND(IntPtr v) => value = v;
    }

    public struct HHOOK
    {
        internal IntPtr value;
        public static implicit operator IntPtr(HHOOK v) => v.value;
        public static implicit operator HHOOK(IntPtr v) => new HHOOK(v);
        HHOOK(IntPtr v) => value = v;
    }

    public struct HMENU
    {
        internal IntPtr value;
        public static implicit operator IntPtr(HMENU v) => v.value;
        public static implicit operator HMENU(IntPtr v) => new HMENU(v);
        HMENU(IntPtr v) => value = v;
    }

    public struct HFONT
    {
        internal IntPtr value;
        public static implicit operator IntPtr(HFONT v) => v.value;
        public static implicit operator HFONT(IntPtr v) => new HFONT(v);
        HFONT(IntPtr v) => value = v;
    }

    public struct HINSTANCE
    {
        internal IntPtr value;
        public static implicit operator IntPtr(HINSTANCE v) => v.value;
        public static implicit operator HINSTANCE(IntPtr v) => new HINSTANCE(v);
        public static implicit operator HMODULE(HINSTANCE v) => v.value;
        public static implicit operator HINSTANCE(HMODULE v) => new HINSTANCE(v.value);
        HINSTANCE(IntPtr v) => value = v;
    }

    public struct LPVOID
    {
        internal IntPtr value;
        public static implicit operator IntPtr(LPVOID v) => v.value;
        public static implicit operator LPVOID(IntPtr v) => new LPVOID(v);
        LPVOID(IntPtr v) => value = v;
    }

    public struct ATOM
    {
        internal ushort value;
        public static implicit operator ushort(ATOM v) => v.value;
        public static implicit operator ATOM(ushort v) => new ATOM(v);
        ATOM(ushort v) => value = v;
    }

    public struct WNDPROC
    {
        internal IntPtr value;
        public static implicit operator IntPtr(WNDPROC v) => v.value;
        public static implicit operator WNDPROC(IntPtr v) => new WNDPROC(v);
        WNDPROC(IntPtr v) => value = v;
    }

    public struct HBRUSH
    {
        internal IntPtr value;
        public static implicit operator IntPtr(HBRUSH v) => v.value;
        public static implicit operator HBRUSH(IntPtr v) => new HBRUSH(v);
        HBRUSH(IntPtr v) => value = v;
    }

    public struct HCURSOR
    {
        internal IntPtr value;
        public static implicit operator IntPtr(HCURSOR v) => v.value;
        public static implicit operator HCURSOR(IntPtr v) => new HCURSOR(v);
        HCURSOR(IntPtr v) => value = v;
    }

    public struct HICON
    {
        internal IntPtr value;
        public static implicit operator IntPtr(HICON v) => v.value;
        public static implicit operator HICON(IntPtr v) => new HICON(v);
        HICON(IntPtr v) => value = v;
    }

    public struct HMODULE
    {
        internal IntPtr value;
        public static implicit operator IntPtr(HMODULE v) => v.value;
        public static implicit operator HMODULE(IntPtr v) => new HMODULE(v);
        HMODULE(IntPtr v) => value = v;
    }

    public struct LRESULT
    {
        internal long value;
        public static implicit operator long(LRESULT v) => v.value;
        public static implicit operator LRESULT(long v) => new LRESULT(v);
        LRESULT(long v) => value = v;
    }

    public struct LPARAM
    {
        internal IntPtr value;
        public static implicit operator IntPtr(LPARAM v) => v.value;
        public static implicit operator LPARAM(IntPtr v) => new LPARAM(v);
        LPARAM(IntPtr v) => value = v;
    }

    public struct WPARAM
    {
        internal IntPtr value;
        public static implicit operator IntPtr(WPARAM v) => v.value;
        public static implicit operator WPARAM(IntPtr v) => new WPARAM(v);
        WPARAM(IntPtr v) => value = v;
    }
}
