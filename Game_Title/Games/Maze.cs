using System.Drawing;
using System.Numerics;
using System.Runtime.InteropServices;

namespace Maze
{
    public class Mazing
    {
        static int size = 40;
        public static void MazingMain()
        {
            Console.WriteLine($"How large do you want the maze? (between '10' and '{Math.Min(Console.LargestWindowHeight - 2, Console.LargestWindowWidth - 2)}')");
            String input = Console.ReadLine();
            int parsedInt;
            while (!int.TryParse(input, out parsedInt) || (parsedInt > Math.Min(Console.LargestWindowHeight - 2, Console.LargestWindowWidth - 2) || parsedInt < 10))
            {
                Console.WriteLine($"please input a valid integer between '10' and '{Math.Min(Console.LargestWindowHeight - 2, Console.LargestWindowWidth - 2)}'");
                input = Console.ReadLine();
            }
            size = parsedInt;

            // Make sure it fits (with some padding)
            //int consoleWidth = Math.Min(size * 2 + 2, Console.LargestWindowWidth);
            //int consoleHeight = Math.Min(size + 2, Console.LargestWindowHeight);

            //Console.SetWindowSize(consoleWidth, consoleHeight);
            //Console.SetBufferSize(consoleWidth, consoleHeight);
            Console.CursorVisible = false;
           // Console.WindowWidth = consoleWidth;
            //Console.WindowHeight = consoleHeight;

            //Console.SetWindowSize(size, size);
            MazeGame game = new MazeGame(size);
            game.SetupMaze();
            // later you can call game.Navigate();
            Console.WindowHeight = Console.LargestWindowHeight;
            Console.WindowWidth = Console.LargestWindowWidth;
        }
    }

    public class MazeGame(int size)
    {
        
        private static readonly Random rand = new Random();
        private int size = size;
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
        (int x, int y)? endPoint = (size-1,size);
        private static Dictionary<int[], String> eventLocations = new Dictionary<int[], string>();
        private Player user;

        public void SetupMaze()
        {
            
            mazeGrid = GenerateMaze(size,size);

            if (startPoint != null)
            {
                user = new Player(startPoint.Value.x, startPoint.Value.y);
            }

            

            DrawMaze();
            /*
            foreach (var item in eventLocations)
            {
                String coordsVal;
                Console.WriteLine($"{item.Key[0]} , {item.Key[1]}, {item.Value}");
            }

            // Find a starting point (any open space)
            Console.SetCursorPosition(user.x*2, (user.y + 2));
            Console.Write("@@");
            */
            

            do
            {
                ConsoleKey key = Console.ReadKey(true).Key;
                int newX = user.x, newY = user.y;
                bool exit = false;

                switch (key)
                {
                    case ConsoleKey.W: newY--; break;
                    case ConsoleKey.S: newY++; break;
                    case ConsoleKey.A: newX--; break;
                    case ConsoleKey.D: newX++; break;
                    case ConsoleKey.Escape: exit = true; break;
                }

                if (exit) {
                break;
                }

                // Only move if next spot is a path (0)
                if ((newY > 0 && newY <= size) && (newX > 0 && newX <= size)) { 
                    if (mazeGrid[newY, newX] == 0)
                    {
                        // Erase old position
                        Console.SetCursorPosition((user.x * 2), user.y);
                        Console.Write("  ");

                        // Draw new position
                        user.x = newX;
                        user.y = newY;
                        Console.SetCursorPosition((user.x * 2), user.y);
                        Console.Write("@@");
                    }
                }
                String locationName;
                if (eventLocations.TryGetValue(new int[] { user.x, user.y }, out locationName))
                { 
                    if (locationName.Equals("clown"))
                    {
                        Console.Clear();
                        Console.WriteLine("                      ..:::::::::::::..\r\n                .:::::''              ``:::.\r\n              .:;'                        `::.\r\n           ..::'                            `::.\r\n          ::'                                  ::.:'\r\n      `::.::                                    ::.\r\n    .::::::::'                                `:.:::.    .:':'\r\n:::::::::::::.          .:.                .:. ` :::::::::':::\r\n:::.::::::::::::'       :::                :::    :::::::::':::'\r\n..::::::::::::'          ' `                ' `   .::::::' :::'\r\n::::::::::::'  `:.   .:::::::.          .:::::::.:: .:' :'.::'\r\n::::::::::::    `::.::'     `::.      .::'     `::.::':'.:::'\r\n::::::::::::      .::'        `:;  . .::'        `:;:'.::''\r\n:::::::::::'.     ::'    .    .:: :  ::'    .    .:::::''\r\n:`::::::::::::.:  `::.  :O: .::;' :  `::.  :O: .::;'::'\r\n   `::::::`::`:.    `:::::::::'   :.   `:::::::::':'''\r\n       `````:`::.     , .         `:.        , . `::.\r\n            :: `::.   :::      ..::::::::..  :::  `::\r\n      .::::'::. `::.  `:'     :::::::::::::; `:'   :;\r\n            ::'    ::.   .::'  ``:::::::;'' :.   .:'\r\n            `::    `::  ::'        ::       .::  :'\r\n             ::.    :'.::::::.    :  :   .::::. .:::.\r\n:.           `::.     :::'  ``::::. .::::'' `::::' `::.\r\n`::.          `::.    `:::. ::.  `::::' .:: ::::;    `::\r\n:.`:.          `::.     `::. `:::.    .::'  ::;'     .:;.\r\n ::`::.          `::.     `::.  `::. .::' .:;':'     :;':.\r\n::':``:::::.       `::.     `::. `::::'  .:;':'     .;':':\r\n: .:`:::':`:::::.   `::.      `:::.   .::;'.:'  .::;'' ';:\r\n..::': :. ::::. `::::::`::..      `:::::'  .:':::'::.:: :':\r\n:' :'.:::. `:: :: ::. .::`::.   .     . .:;':' ::'`:: :::'\r\n: ::.:. `:  `::'  `:: ::'::`::::::::::::;' :: .:' .::: ;:'\r\n::.::.:::: .:: :.  `:':'  ::.:'`::. .::':.::' :: .::''::'\r\n`:::`::.`:.::' ::  .: ::  `::'  `:: :' .::' ::.:.::' :;\r\n   `::::::.`:. .:. :: `::.:: ::  `::. .:: ::.`:::':.:;'\r\n         `::::::::::...:::'  `::.:'`:.::'.:.:;' .:;'\r\n                    `::::::::::::::::::::'.::;:;'");
                        Console.WriteLine("88888888ba                           \r\n88      \"8b                          \r\n88      ,8P                          \r\n88aaaaaa8P'  ,adPPYba,   ,adPPYba,   \r\n88\"\"\"\"\"\"8b, a8\"     \"8a a8\"     \"8a  \r\n88      `8b 8b       d8 8b       d8  \r\n88      a8P \"8a,   ,a8\" \"8a,   ,a8\"  \r\n88888888P\"   `\"YbbdP\"'   `\"YbbdP\"' ");
                        Console.ReadKey();
                        DrawMaze();
                    }
                }
            }
            while (!(user.y == endPoint.Value.y));
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

            Dictionary<int[,], int> specials = new Dictionary<int[,], int>();

            specials.Add(new int[5, 10], 2);

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
                    nx > 0 && nx < maze.GetLength(1) - 1)
                {
                    if (maze[ny, nx] == 1)
                    {
                        // Knock down wall between (x,y) and (nx,ny)
                        maze[y + d[1] / 2, x + d[0] / 2] = 0;
                        maze[ny, nx] = 0;
                        CarvePath(nx, ny, maze);
                    }
                    else
                    {
                        int j = rand.Next(0, 200);
                        if (j >= 0 && j <= 6)
                        {
                            // Knock down wall between (x,y) and (nx,ny)
                            maze[y + d[1] / 2, x + d[0] / 2] = 0;
                            maze[ny, nx] = 0;
                            CarvePath(nx, ny, maze);
                        }
                        if (j > 6 && j < 20)
                        {
                            int[] coords = { x, y };
                            eventLocations.Add(coords, "clown");
                        }
                    }
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
