using Citadel.Sdl;

namespace Citadel
{
    public static class Program
    {
        public static void Main()
        {
            using (var sdl2 = new Sdl2(InitializationFlags.Video))
            using (var window = sdl2.CreateWindow("SDL Tutorial", Window.UndefinedWindowPosition, Window.UndefinedWindowPosition, 640, 480, WindowFlags.Shown))
            {

            }
        }
    }
}
