using System;
using System.Runtime.InteropServices;

namespace Citadel.Sdl
{
    internal sealed class Surface : ObjectBase
    {
        public PixelFormat PixelFormat
        {
            get
            {
                var surface = Marshal.PtrToStructure<SDL_Surface>(Data);
                return new PixelFormat(surface._format);
            }
        }

        public Surface(IntPtr data, bool shouldFree = true) : base(data, shouldFree)
        {
        }

        public void FillRectangle(Rectangle rectangle, Color color)
        {
            ThrowIfDisposed();
            Interop.CheckError(Interop.SDL_FillRect(Data, ref rectangle, color));
        }

        protected override void FreeData()
        {
            Interop.SDL_FreeSurface(Data);
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct SDL_Surface
        {
            public uint _flags;
            public IntPtr _format; // SDL_PixelFormat*
            public int _w;
            public int _h;
            public int _pitch;
            public IntPtr _pixels; // void*
            public IntPtr _userdata; // void*
            public int _locked;
            public IntPtr _lock_data; // void*
            public Rectangle _clip_rect;
            public IntPtr _map; // SDL_BlitMap*
            public int _refcount;
        }
    }
}
