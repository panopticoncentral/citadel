using System;

namespace Citadel.Sdl
{
    internal sealed class Sdl2 : IDisposable
    {
        public Sdl2(InitializationFlags flags)
        {
            if (Interop.SDL_Init(flags) < 0)
            {
                throw new SdlException(Interop.SDL_GetError());
            }
        }

        public void Dispose()
        {
            Interop.SDL_Quit();
        }
    }
}
