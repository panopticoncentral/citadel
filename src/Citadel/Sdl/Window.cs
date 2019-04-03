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
            return new Surface(Interop.SDL_GetWindowSurface(Data), false);
        }

        public void UpdateSurface()
        {
            ThrowIfDisposed();
            Interop.CheckError(Interop.SDL_UpdateWindowSurface(Data));
        }

        public Renderer CreateRenderer(int index, RendererFlags flags)
        {
            ThrowIfDisposed();
            return new Renderer(Interop.CheckPointer(Interop.SDL_CreateRenderer(Data, index, flags)));
        }
    }
}
