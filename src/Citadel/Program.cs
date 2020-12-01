using Citadel;

using SdlSharp;
using SdlSharp.Graphics;
using SdlSharp.Input;

namespace Tutorial
{
    internal static class Program
    {
        private static readonly Size s_tileSize = (16, 16);
        private static readonly Size s_screenSize = (1280, 720); // 80 tiles x 45 tiles
        private static readonly Size s_mapSize = (80, 45);

        private static readonly Point s_playerTile = (0, 11);
        private static readonly Point s_npcTile = (0, 9);

        private static readonly Point s_wallTile = (9, 2);
        private static readonly Point s_floorTile = (9, 7);

        public static void Main()
        {
            using var app = new Application(Subsystems.Video, ImageFormats.Png);
            var map = new Map(s_mapSize);

            using var gameWindow = new Screen("libcgs tutorial", s_screenSize, map, s_tileSize);

            var characterTileset = gameWindow.LoadTileset((1, 1), (54, 12), "png", Resources.Characters, Colors.Fuchsia);
            var dungeonTileset = gameWindow.LoadTileset((1, 1), (29, 18), "png", Resources.Dungeon, Colors.Fuchsia);

            var wallTerrain = new Terrain(new Tile(dungeonTileset, s_wallTile), true);
            var floorTerrain = new Terrain(new Tile(dungeonTileset, s_floorTile), false);

            for (var x = 0; x < map.Size.Width; x++)
            {
                for (var y = 0; y < map.Size.Height; y++)
                {
                    map[(x, y)] = y == 22 && x >= 30 && x <= 32 ? wallTerrain : floorTerrain;
                }
            }

            var player = new Character((s_mapSize.Width / 2, s_mapSize.Height / 2), new Tile(characterTileset, s_playerTile));
            map.AddCharacter(player);

            var npc = new Character(((s_mapSize.Width / 2) - 5, s_mapSize.Height / 2), new Tile(characterTileset, s_npcTile));
            map.AddCharacter(npc);

            var fullscreen = false;

            Keyboard.KeyDown += (s, e) =>
            {
                switch (e.Keycode)
                {
                    case Keycode.Escape:
                        app.Dispose();
                        break;

                    case Keycode.Up:
                        player.Move(map, Direction.Up);
                        break;

                    case Keycode.Down:
                        player.Move(map, Direction.Down);
                        break;

                    case Keycode.Left:
                        player.Move(map, Direction.Left);
                        break;

                    case Keycode.Right:
                        player.Move(map, Direction.Right);
                        break;

                    case Keycode.Return:
                        if ((e.Modifiers & KeyModifier.Alt) != 0)
                        {
                            fullscreen = !fullscreen;
                            gameWindow.Window.SetFullscreen(fullscreen, true);
                        }
                        break;
                }
            };

            while (app.DispatchEvent())
            {
                gameWindow.Render();
            }
        }
    }
}
