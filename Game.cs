namespace TextMazeRunner
{
    public class Game
    {

        public event Action<int> LevelCompleted = delegate{};

        private Map map = default!;
        private Player player = default!;
        private Renderer renderer = default!;
        private InputHandler inputHandler = default!;

        private enum PlayResult { Completed, Restart, Quit }

        // main entry point for the game loop
        public void Start()
        {
            while (true)
            {
                // show title screen and instructions
                IntroMenu();

                // load all .txt maps from the Maps folder in the app directory
                string mapsFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Maps");
                var mapFiles = Directory
                    .EnumerateFiles(mapsFolder, "*.txt")
                    .OrderBy(Path.GetFileName)
                    .ToArray();

                // if there are no maps, tell the player and exit
                if (mapFiles.Length == 0)
                {
                    Console.WriteLine("No maps found. Quitting...");
                    break;
                }

                int levelIndex = 0;
                bool quit = false;

                // play through each level in order
                while (levelIndex < mapFiles.Length)
                {
                    Console.Clear();
                    Console.WriteLine($"Loading Level {levelIndex + 1}: {Path.GetFileName(mapFiles[levelIndex])}");

                    // play the current level and get the result
                    PlayResult result = PlayLevel(mapFiles[levelIndex]);

                    if (result == PlayResult.Completed)
                    {
                        LevelCompleted(levelIndex);
                        levelIndex++;
                        // if more levels remain, wait for the player to proceed
                        if (levelIndex < mapFiles.Length)
                        {
                            Console.WriteLine("Press any key to continue to next level...");
                            Console.ReadKey(true);
                        }
                    }
                    else if (result == PlayResult.Restart)
                    {
                        // restart level
                        break;
                    }
                    else
                    {
                        // quit game
                        quit = true;
                        break;
                    }
                }

                if (quit)
                {
                    Console.WriteLine("Quitting...");
                    break;
                }
                // if there is no more levels, congratulate the player and exit
                if (levelIndex >= mapFiles.Length)
                {
                    Console.WriteLine("\nAll levels completed! Well done!");
                    break;
                }
            }
        }

        // plays a level and returns the Result
        private PlayResult PlayLevel(string mapPath)
        {
            if (!File.Exists(mapPath))
                return PlayResult.Quit;

            // set up map, player, and renderer for this level
            map = new Map(mapPath);
            player = new Player(map.StartXPos, map.StartYPos);
            renderer = new Renderer(map, player);
            inputHandler = new InputHandler();

            // loop until the level ends
            while (true)
            {
                Console.Clear();
                renderer.DrawMap();

                // read a key and convert to a command
                var cmd = InputHandler.GetCommand(Console.ReadKey(true).Key);

                if (cmd.Type == InputCommandType.Move)
                {

                    // calculate where the player wants to go
                    int newX = player.X + cmd.DeltaX;
                    int newY = player.Y + cmd.DeltaY;

                    // only move if the spot is open
                    if (map.CanMoveTo(newX, newY))
                        player.UpdatePosition(newX, newY);

                    // if that spot is the target position, end the level
                    if (map.IsTarget(newX, newY))
                    {
                        return PlayResult.Completed;
                    }
                }
                else if (cmd.Type == InputCommandType.Restart)
                {
                    // restart this level
                    return PlayResult.Restart;
                }
                else if (cmd.Type == InputCommandType.Quit)
                {
                    // quit the game
                    return PlayResult.Quit;
                }
                else
                {
                    // invalid key, show the message and wait for any key
                    Console.WriteLine(cmd.Message);
                    Console.ReadKey(true);
                }
            }
        }
        
        // shows the intro screen with title and controls
        private static void IntroMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("================================");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("       TEXT MAZE RUNNER");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("================================");
            Console.ResetColor();
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Instructions:");
            Console.ResetColor();
            Console.WriteLine();

            Console.WriteLine("- Use W/A/S/D or Arrow Keys to move");
            Console.WriteLine();
            Console.WriteLine("- Reach 'X' to complete the level");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Press any key to begin...");
            Console.ResetColor();
            Console.ReadKey(true);
        }
    }
}