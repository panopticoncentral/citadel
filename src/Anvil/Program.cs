using Citadel;
using SdlSharp;
using SdlSharp.Graphics;

namespace Anvil
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Sdl.Initialize(Subsystems.Video);
            Image.Initialize(ImageFormats.Png);

            using var console = new Console((80, 60));
            console.Render();
            Timer.Delay(10000);

            Image.Quit();
            Sdl.Quit();
        }
    }
}
