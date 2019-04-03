using System.Runtime.InteropServices;

namespace Citadel.Sdl
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct Color
    {
        private readonly uint _color;

        private Color(uint color)
        {
            _color = color;
        }

        public static Color FromRgb(PixelFormat format, byte red, byte green, byte blue) =>
            new Color(Interop.SDL_MapRGB(format.Data, red, green, blue));
    }
}
