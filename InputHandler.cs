namespace TextMazeRunner
{
    //all the commands the player can issue
    public enum InputCommandType
    {
        Move,
        Restart,
        Quit,
        Invalid
    }

    public readonly struct InputCommand
    {
        public InputCommandType Type { get; init; }
        public int DeltaX { get; init; }
        public int DeltaY { get; init; }
        public string Message { get; init; }
    }

    public class InputHandler
    {
        // turns a ConsoleKey into an InputCommand
        public static InputCommand GetCommand(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    // move up
                    return new InputCommand
                    {
                        Type   = InputCommandType.Move,
                        DeltaX = -1,
                        DeltaY = 0
                    };

                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    // move down
                    return new InputCommand
                    {
                        Type   = InputCommandType.Move,
                        DeltaX = +1,
                        DeltaY = 0
                    };

                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    // move left
                    return new InputCommand
                    {
                        Type   = InputCommandType.Move,
                        DeltaX = 0,
                        DeltaY = -1
                    };

                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    // move right 
                    return new InputCommand
                    {
                        Type   = InputCommandType.Move,
                        DeltaX = 0,
                        DeltaY = +1
                    };

                case ConsoleKey.R:
                    // restart
                    return new InputCommand
                    {
                        Type = InputCommandType.Restart
                    };

                case ConsoleKey.Q:
                case ConsoleKey.Escape:
                    // quit 
                    return new InputCommand
                    {
                        Type = InputCommandType.Quit
                    };

                default:
                    //if the player presses any other key, show invalid key pressed and show instructions
                    return new InputCommand
                    {
                        Type    = InputCommandType.Invalid,
                        Message = "Invalid input!\nUse W/A/S/D or Arrow Keys to move.\nR to restart.\nQ to quit.\nPress any key to continue..."
                    };
            }
        }
    }
}
