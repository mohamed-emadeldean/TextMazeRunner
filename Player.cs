namespace TextMazeRunner
{
    public class Player
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public readonly char Symbol = '@';
        public readonly ConsoleColor Color = ConsoleColor.Green;

        //set the player at the given starting position.
        public Player(int startX, int startY)
        {
            X = startX;
            Y = startY;
        }

        //move the player to a new position.
        public void UpdatePosition(int newX, int newY)
        {
            X = newX;
            Y = newY;
        }
    }
}