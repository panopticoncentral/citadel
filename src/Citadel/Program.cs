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
            {
                s_sdl2.OnWindowEvent += Sdl2_OnWindowEvent;

                while (true)
                {
                    s_sdl2.WaitForEvent();
                }
            }
        }

        private static void Sdl2_OnWindowEvent(object sender, WindowEventArgs e)
        {
            switch (e.Type)
            {
                case WindowEventType.Exposed:
                    var surface = s_window.GetSurface();
                    surface.FillRectangle(new Rectangle(0, 0, 100, 100), Color.FromRgb(surface.PixelFormat, 0x34, 0x00, 0x00));
                    s_window.UpdateSurface();
                    s_sdl2.Delay(10000);
                    break;
            }
        }
    }
}
