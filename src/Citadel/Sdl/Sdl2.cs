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

        public Window CreateWindow(string title, int x, int y, int width, int height, WindowFlags flags)
        {
            var data = Interop.SDL_CreateWindow(title.ToUtf8(), x, y, width, height, flags);
            return data == IntPtr.Zero ? throw new SdlException() : new Window(data);
        }

        public void Dispose()
        {
            Interop.SDL_Quit();
        }
    }
}
