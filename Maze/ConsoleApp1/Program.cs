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
        private int size = 20;
        private int[,] mazeGrid = {
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

        private int[]? startPoint;
        private int[]? endPoint;
        private Player? user;

        public void SetupMaze()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    int activePoint = mazeGrid[j, i];

                    if (startPoint == null && activePoint == 0 && (i == 0 || j == 0))
                    {
                        startPoint = [i, j];
                    }
                    else if (endPoint == null && activePoint == 0 && (i == size - 1 || j == size - 1))
                    {
                        endPoint = [i, j];
                    }

                }
            }

            if (startPoint != null)
            {
                user = new Player(startPoint);
            }

            DrawMaze();

            do
            {
                Console.WriteLine("you can use 'W A S D' to move");

                char input = GetInput(['w', 'a', 's', 'd']);
                Navigate(input);
                
                DrawMaze();
            }
            while (!(user.x == endPoint[0] && user.y == endPoint[1]));

            Console.WriteLine("you win!");
        }

        public void Navigate(char input)
        {
            switch (input)
            {
                case 'w':
                    //up
                    if (mazeGrid[user.y-1,user.x] == 0)
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
                case 's':
                    //down
                    if (mazeGrid[user.y+1, user.x] == 0)
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
                case 'a':
                    //left
                    if (mazeGrid[user.y, user.x-1] == 0)  
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
                    if (mazeGrid[user.y, user.x+1] == 0)
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
                default:
                    
                    break;
            }
            Console.WriteLine();
        }

        public static char GetInput(char[] usableChars)
        {


            Char input = Console.ReadKey().KeyChar;
            if (!usableChars.Contains(input))
            {
                Console.WriteLine($"Please input a direction using '{string.Join(" ", usableChars)}'");
                input = GetInput(usableChars);
            }

            return input;
        }

        public void DrawMaze(){
            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    if (user.x == x && user.y == y)
                    {
                        Console.Write("X");
                    }
                    else
                    {
                        Console.Write(mazeGrid[y, x]);
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
