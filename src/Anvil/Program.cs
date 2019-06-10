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

            new Console();

            Image.Quit();
            Sdl.Quit();
        }
    }
}
