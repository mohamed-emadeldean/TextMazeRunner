namespace TextMazeRunner
{
    class Program
    {
        static void Main()
        {
            var game = new Game();

            // when a level is completed, show a message
            game.LevelCompleted += levelIndex =>
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\n Level {levelIndex + 1} completed! \n");
                Console.ResetColor();
            };

            // start the game
            game.Start();
        }
    }
}
