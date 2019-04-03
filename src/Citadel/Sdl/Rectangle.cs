using System.Runtime.InteropServices;

namespace Citadel.Sdl
{
    [StructLayout(LayoutKind.Sequential)]
    public sealed class Rectangle
    {
        public int X { get; }
        public int Y { get; }
        public int Width { get; }
        public int Height { get; }

        public Rectangle(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }
    }
}
