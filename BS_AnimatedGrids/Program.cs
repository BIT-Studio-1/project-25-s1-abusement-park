using System;

namespace BS_AnimatedGrids
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int BSgridSize = 7;
            char [,] BSplayerGrid = new char [BSgridSize, BSgridSize];
            char[,] BSkrakenGrid = new char [BSgridSize, BSgridSize];

            //launch grids
            for (int y = 0; y < BSgridSize; y++)
            {
                for (int x = 0; x < BSgridSize; x++)
                {
                    BSplayerGrid[y, x] = '*';
                    BSkrakenGrid[y, x] = '*';
                }
            }
            
            for (int y = 0; y < BSgridSize; y++)
            {
                Console.Write("  ");
                Console.Write(y);
            }
            Console.WriteLine();
            for (int x = 0; x < BSgridSize; x++)
            {
                Console.Write(x + " ");
                for (int y = 0; y < BSgridSize; y++)
                {
                    Console.Write(BSplayerGrid[x, y]+ "  ");
                }
                Console.WriteLine();
            }

            //userInput
            Console.WriteLine("Enter coordinates to strike:");
            Console.Write("X: ");
            string tempX = Console.ReadLine();
            int BSuserInputX = Convert.ToInt32(tempX);
            Console.Write("Y: ");
            string tempY =  Console.ReadLine();
            int BSuserInputY = Convert.ToInt32(tempY);

            Console.ReadLine();
        }
    }
}
