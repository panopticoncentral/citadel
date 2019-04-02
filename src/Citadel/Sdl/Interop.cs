using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Citadel.Sdl
{
    internal static class Interop
    {
        private const string Sdl2 = "SDL2";

        public static byte[] ToUtf8(this string s) => s == null ? null : Encoding.UTF8.GetBytes(s + '\0');

        [DllImport(Sdl2, EntryPoint = "SDL_CreateWindow", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_CreateWindow(byte[] title, int x, int y, int w, int h, WindowFlags flags);

        [DllImport(Sdl2, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_DestroyWindow(IntPtr window);

        [DllImport(Sdl2, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern string SDL_GetError();

        [DllImport(Sdl2, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_Init(InitializationFlags flags);

        [DllImport(Sdl2, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_Quit();
    }
}
