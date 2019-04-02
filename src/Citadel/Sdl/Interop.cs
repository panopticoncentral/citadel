using System.Runtime.InteropServices;

namespace Citadel.Sdl
{
    internal static class Interop
    {
        private const string Sdl2 = "SDL2";

        [DllImport(Sdl2, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern string SDL_GetError();

        [DllImport(Sdl2, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_Init(InitializationFlags flags);

        [DllImport(Sdl2, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_Quit();
    }
}
