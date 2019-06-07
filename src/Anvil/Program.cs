using SdlSharp;

namespace Anvil
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Sdl.Initialize(Subsystems.Video);
            Sdl.Quit();
        }
    }
}
