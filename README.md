TEXT MAZE RUNNER

Text Maze Runner is a console-based puzzle game built in pure C# (.NET Console App) that challenges players to navigate through maze-like levels using keyboard controls. Designed with clean architecture and object-oriented principles, the game emphasizes modular design, reusability, and clarity.

Players control a character (@) within a grid-based map filled with walls (#), open paths (.), and a goal (X). The objective is simple: reach the goal by navigating the maze, avoiding walls, and using logic to find the shortest path. ────────────────────────────────────────────────────────────────────────

Running the App

*You can launch Text Maze Runner either via the .NET CLI or from an IDE.

1. Using the .NET CLI

Open your terminal or command prompt.

Change into the project directory:

Ex: cd /path/TextMazeRunner


Visual Studio

Double-click TextMazeRunner.sln to open the solution.

In Solution Explorer, right-click the TextMazeRunner project and choose Set as Startup Project.

Press F5 (or click the green Run button) to build and start the game.


Visual Studio Code

Install the C# extension (ms-dotnettools.csharp)

Open the project folder

Press Ctrl+Shift+B to build

Press F5 to launch

────────────────────────────────────────────────────────────────────────

OVERVIEW OF THE GAME

• You control @ in a grid-based maze
• Walls are #, open floor is . and the exit is X
• Reach X to complete the level and advance
• Levels are plain-text files in the Maps/ folder and load in filename order

────────────────────────────────────────────────────────────────────────

CONTROLS

Move Up:     W or Up Arrow  
Move Down:   S or Down Arrow  
Move Left:   A or Left Arrow  
Move Right:  D or Right Arrow  
Restart:     R  
Quit:        Q or Esc

────────────────────────────────────────────────────────────────────────

LEVEL / MAP FORMAT

• Each level is a .txt file in the TextMazeRunner\bin\Debug\net9.0\Maps directory
• All lines must be the same length (rectangular grid)

• Symbols:

   (#) - Wall (impassable)
   (.) - Floor (passable)
   (@) - Player start (one per file)
   (X) - Exit (one per file)

Example (Maps/level1.txt):
```txt
##########
#@...#...#
#.#.#.#X.#
#.#.....##
##########
```

────────────────────────────────────────────────────────────────────────

ADDING OR EDITING LEVELS

1- Create or open a .txt file in Maps/ (e.g. level4.txt)

2- Ensure every row has the same number of characters

3- Place exactly one @ (start) and one X (exit)

4- Use # for walls and . for open spaces

5- Save, the game auto-load levels by filename order

────────────────────────────────────────────────────────────────────────

KNOWN LIMITATIONS & BONUS FEATURES

Limitations
- No diagonal movement
- Static level order: Levels always load in filename order no random or playlist mode.
- No in-game save/load; quitting resets progress
- Maps must be perfectly rectangular
- No audio effects: Pure text output, no sound 

Bonus Features
- Custom intro screen with game title and color formatting.
- Player can press R to restart the level or Q/Esc to quit the game anytime.
- Gracefully handles invalid keys with feedback and re-displays controls.

