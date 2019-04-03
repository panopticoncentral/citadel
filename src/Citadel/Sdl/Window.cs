using System;

namespace Citadel.Sdl
{
    internal sealed class Window : ObjectBase
    {
        public const int UndefinedWindowPosition = 0x1FFF0000;

        public Window(IntPtr data) : base(data)
        {
        }

        protected override void FreeData()
        {
            Interop.SDL_DestroyWindow(Data);
        }

        public Surface GetSurface()
        {
            ThrowIfDisposed();
            return new Surface(Interop.SDL_GetWindowSurface(Data));
        }

        public void UpdateSurface()
        {
            ThrowIfDisposed();
            Interop.CheckError(Interop.SDL_UpdateWindowSurface(Data));
        }
    }
}
