namespace TextMazeRunner
{
    public class Map
    {
        public char[,] Grid { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public int StartXPos { get; private set; }
        public int StartYPos { get; private set; }

        // loads the maze from a file, finds the '@' start marker.
        public Map(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            Height = lines.Length;
            Width = lines[0].Length;

            Grid = new char[Height, Width];
           
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Grid[i,j] = lines[i][j];

                    //finds and sets the starting position.
                    if (lines[i][j] == '@')
                    {
                        StartXPos = i;
                        StartYPos = j;
                        Grid[i, j] = '.';
                    }
                }
            }
        }

        //checks if the player next move is inside the grid and not a wall (‘#’)
        public bool CanMoveTo(int x, int y)
        {
            return x >= 0
                   && y >= 0
                   && x < Height
                   && y < Width
                   && Grid[x, y] != '#';
        }

        //checks if the player next move is the target (‘X’).
        public bool IsTarget(int x, int y)
        {
            return Grid[x,y] == 'X';
        }

    }
}