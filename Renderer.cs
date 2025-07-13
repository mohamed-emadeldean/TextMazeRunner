namespace TextMazeRunner
{
    public class Renderer
    {
        private readonly Map map;
        private readonly Player player;

        // set up the renderer with the current map and player
        public Renderer(Map map, Player player)
        {
            this.map = map;
            this.player = player;
        }

        // draw the entire maze and the player to the console
        public void DrawMap()
        {
            for (int row = 0; row < map.Height; row++)
            {
                for (int col = 0; col < map.Width; col++)
                {
                    // if this is the player's spot, draw the player
                    if (row == player.X && col == player.Y)
                    {
                        Console.ForegroundColor = player.Color;
                        Console.Write(player.Symbol);
                    }
                    // if this is the exit (‘X’), draw it in red
                    else if (map.Grid[row, col] == 'X')
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write('X');
                    }
                    else
                    {
                        Console.ResetColor();
                        Console.Write(map.Grid[row, col]);
                    }
                }

                Console.WriteLine();
            }
        }
    }
}