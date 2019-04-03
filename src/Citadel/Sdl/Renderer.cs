using System;

namespace Citadel.Sdl
{
    internal sealed class Renderer : ObjectBase
    {
        public Renderer(IntPtr data) : base(data)
        {
        }

        protected override void FreeData()
        {
            Interop.SDL_DestroyRenderer(Data);
        }

        public Texture CreateTextureFromSurface(Surface surface)
        {
            ThrowIfDisposed();
            return new Texture(Interop.CheckPointer(Interop.SDL_CreateTextureFromSurface(Data, surface.Data)));
        }

        public void Clear()
        {
            ThrowIfDisposed();
            Interop.CheckError(Interop.SDL_RenderClear(Data));
        }

        public void Copy(Texture texture, Rectangle source, Rectangle destination)
        {
            ThrowIfDisposed();
            Interop.CheckError(Interop.SDL_RenderCopy(Data, texture.Data, ref source, ref destination));
        }

        public void Present()
        {
            ThrowIfDisposed();
            Interop.SDL_RenderPresent(Data);
        }
    }
}
