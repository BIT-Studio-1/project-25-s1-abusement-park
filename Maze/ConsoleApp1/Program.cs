using System.Runtime.InteropServices;

namespace Maze
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            MazeGame game = new MazeGame();
            game.SetupMaze();
            // later you can call game.Navigate();
        }
    }

    public class MazeGame
    {
        private static readonly Random rand = new Random();
        private int size = 20;
        private int[,] mazeGrid;

        /*{
            {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,1,1,1,1},
            {1,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,0,1,1},
            {1,0,1,1,1,1,1,0,1,1,0,1,1,0,1,0,1,0,1,1},
            {1,0,1,0,0,0,0,0,1,1,0,0,1,0,0,0,0,0,1,1},
            {1,0,1,1,1,1,1,0,1,1,0,0,1,1,1,1,1,0,1,1},
            {1,0,0,0,0,1,0,0,1,0,0,0,0,0,0,0,1,0,1,1},
            {1,0,1,1,0,0,0,0,0,0,1,0,1,1,1,1,1,0,1,1},
            {1,0,1,1,1,1,1,0,1,0,1,0,0,0,0,0,0,0,1,1},
            {1,0,1,0,0,0,0,0,0,0,1,0,1,1,1,1,1,1,1,1},
            {1,0,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,1,1},
            {1,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,0,1,1},
            {1,0,1,1,0,0,1,1,1,0,1,0,0,0,0,0,0,0,1,1},
            {1,0,1,1,0,0,0,0,1,0,1,1,0,1,0,0,1,0,1,1},
            {1,0,1,0,0,1,1,0,1,1,1,1,0,1,0,0,0,0,1,1},
            {1,1,1,1,1,1,1,0,0,0,0,0,0,1,0,1,1,0,1,1},
            {1,0,1,0,0,0,0,0,1,0,1,0,0,1,0,0,1,0,1,1},
            {1,0,1,1,1,0,1,0,1,0,0,1,0,0,0,1,0,0,1,1},
            {1,0,0,0,1,0,1,0,1,1,0,1,0,1,0,1,0,1,1,1},
            {1,0,1,0,0,0,0,0,0,1,0,1,0,0,0,1,0,0,1,1},
            {1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}
        };
        */

        (int x, int y)? startPoint = (1,0);
        (int x, int y)? endPoint = (19,20);
        private Player user;

        public void SetupMaze()
        {
            mazeGrid = GenerateMaze(size,size);
            //MakeMaze();
            /**
            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    int activePoint = mazeGrid[y, x];

                    // Check if it's a path and on an edge
                    if (activePoint == 0 && (x == 0 || y == 0 || x == size-1 || y == size-1))
                    {
                        if (startPoint == null)
                        {
                            startPoint = (x, y);
                        }
                        else if (endPoint == null)
                        {
                            endPoint = (x, y);
                        }
                    }
                }
            }
            */

            if (startPoint != null)
            {
                user = new Player(startPoint.Value.x, startPoint.Value.y);
            }

            DrawMaze();

            // Find a starting point (any open space)
            int playerX = 1, playerY = 1;
            Console.SetCursorPosition(playerX*2, (playerY));
            Console.Write("@@");

            do
            {
                ConsoleKey key = Console.ReadKey(true).Key;
                int newX = playerX, newY = playerY;

                switch (key)
                {
                    case ConsoleKey.W: newY--; break;
                    case ConsoleKey.S: newY++; break;
                    case ConsoleKey.A: newX--; break;
                    case ConsoleKey.D: newX++; break;
                    case ConsoleKey.Escape: return; // quit
                }

                // Only move if next spot is a path (0)
                if (mazeGrid[newY, newX] == 0)
                {
                    // Erase old position
                    Console.SetCursorPosition((playerX * 2), playerY);
                    Console.Write("  ");

                    // Draw new position
                    playerX = newX;
                    playerY = newY;
                    Console.SetCursorPosition((playerX*2), playerY);
                    Console.Write("@@");
                }
            }
            while (!(user.y == endPoint.Value.y));

                Console.WriteLine("you win!");
        }

        public void MakeMaze(){
            mazeGrid = new int[size,size];
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    mazeGrid[y,x] = 1;
                }
            }
            
        }

        public void Navigate(char input)
        {
            switch (input)
            {
                case 'w':    //Up

                    int upSquare;
                    try{
                        upSquare = mazeGrid[user.y - 1, user.x];
                    }
                    catch(Exception e){
                        upSquare = 1;
                    }

                    if (upSquare == 0)
                    {
                        user.y--;
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("that way is blocked");
                        Console.WriteLine();
                    }
                    break;
                case 's':   //Down
                    int downSquare;
                    try
                    {
                        downSquare = mazeGrid[user.y + 1, user.x];
                    }
                    catch (Exception e)
                    {
                        downSquare = 1;
                    }

                    if (downSquare == 0)
                    {
                        user.y++;
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("that way is blocked");
                        Console.WriteLine();
                    }
                    break;
                case 'a':   //Left
                    int leftSquare;
                    try
                    {
                        leftSquare = mazeGrid[user.y, user.x - 1];
                    }
                    catch (Exception e)
                    {
                        leftSquare = 1;
                    }

                    if (leftSquare == 0)
                    {
                        user.x--;
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("that way is blocked");
                        Console.WriteLine();
                    }
                    break;
                case 'd':
                    //right
                    int rightSquare;
                    try
                    {
                        rightSquare = mazeGrid[user.y, user.x + 1];
                    }
                    catch (Exception e)
                    {
                        rightSquare = 1;
                    }

                    if (rightSquare == 0)
                    {
                        user.x++;
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("that way is blocked");
                        Console.WriteLine();
                    }
                    break;
            }
            Console.WriteLine();
        }

        public static char MazeGetInput(char[] usableChars)
        {


            Char input = Console.ReadKey().KeyChar;
            if (!usableChars.Contains(input))
            {
                Console.WriteLine($"Please input a direction using '{string.Join(" ", usableChars)}'");
                input = MazeGetInput(usableChars);
            }

            return input;
        }

        public void DrawMaze(){
            for (int y = 0; y < mazeGrid.GetLength(0); y++)
            {
                for (int x = 0; x < mazeGrid.GetLength(1); x++)
                {
                    if (x == user.x && y == user.y)
                    {
                        Console.Write("##");
                    }
                    else
                    {
                        Console.Write(mazeGrid[y, x] == 1 ? "██" : "  ");
                    }
                }
                Console.WriteLine();
            }
        }

        public static int[,] GenerateMaze(int width, int height)
        {
            // Ensure odd dimensions
            if (width % 2 == 0) width++;
            if (height % 2 == 0) height++;

            int[,] maze = new int[height, width];

            // Fill with walls (1)
            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                    maze[y, x] = 1;

            // Starting point
            int startX = 1;
            int startY = 1;
            maze[startY, startX] = 0;

            CarvePath(startX, startY, maze);

            // Create entry and exit
            maze[0, 1] = 0;                 // entry at top
            maze[height - 1, width - 2] = 0; // exit at bottom

            return maze;
        }

        private static void CarvePath(int x, int y, int[,] maze)
        {
            // Directions: up, right, down, left
            int[][] dirs = {
            new[] { 0, -2 },
            new[] { 2, 0 },
            new[] { 0, 2 },
            new[] { -2, 0 }
        };

            // Shuffle directions
            Shuffle(dirs);

            foreach (var d in dirs)
            {
                int nx = x + d[0];
                int ny = y + d[1];

                if (ny > 0 && ny < maze.GetLength(0) - 1 &&
                    nx > 0 && nx < maze.GetLength(1) - 1 &&
                    maze[ny, nx] == 1)
                {
                    // Knock down wall between (x,y) and (nx,ny)
                    maze[y + d[1] / 2, x + d[0] / 2] = 0;
                    maze[ny, nx] = 0;
                    CarvePath(nx, ny, maze);
                }
            }
        }

        private static void Shuffle<T>(T[] array)
        {
            for (int i = array.Length - 1; i > 0; i--)
            {
                int j = rand.Next(i + 1);
                (array[i], array[j]) = (array[j], array[i]);
            }
        }
    }
}
