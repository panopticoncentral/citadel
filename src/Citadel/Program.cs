using Citadel.Sdl;

namespace Citadel
{
    public static class Program
    {
        private static Sdl2 s_sdl2;
        private static Window s_window;

        public static void Main()
        {
            using (s_sdl2 = new Sdl2(InitializationFlags.Video))
            using (s_window = s_sdl2.CreateWindow("SDL Tutorial", Window.UndefinedWindowPosition, Window.UndefinedWindowPosition, 640, 480, WindowFlags.Shown))
            using (var renderer = s_window.CreateRenderer(-1, RendererFlags.Accelerated | RendererFlags.PresentVSync))
            using (var testBitmap = s_sdl2.LoadBitmap("test.bmp"))
            using (var texture = renderer.CreateTextureFromSurface(testBitmap))
            {
                for (var i = 0; i < 3; i++)
                {
                    renderer.Clear();
                    renderer.Copy(texture, null, null);
                    renderer.Present();
                    s_sdl2.Delay(2000);
                }
            }
        }
    }
}
