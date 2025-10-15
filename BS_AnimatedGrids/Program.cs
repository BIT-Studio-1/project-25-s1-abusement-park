using System;
using System.Reflection.Metadata.Ecma335;

namespace BS_AnimatedGrids
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int BSgridSize = 7;
            char [,] BSplayerGrid = new char [BSgridSize, BSgridSize];
            char[,] BSkrakenGrid = new char [BSgridSize, BSgridSize];

            //Computer Ship         
            BSkrakenGrid[5, 3] = '#';
            BSkrakenGrid[5, 4] = '#';
            BSkrakenGrid[5, 5] = '#';
            BSkrakenGrid[5, 6] = '#';

            int KrakenHits = 0;

            //launch game
            while (KrakenHits <= 4)
            {
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
                        Console.Write(BSplayerGrid[x, y] + "  ");
                    }
                    Console.WriteLine();
                }

                //userInput
                Console.WriteLine("Enter coordinates to strike:");
                Console.Write("X: ");
                string tempX = Console.ReadLine();
                Console.Write("Y: ");
                string tempY = Console.ReadLine();
                int BSuserInputX = Convert.ToInt32(tempX);
                int BSuserInputY = Convert.ToInt32(tempY);

                if (BSuserInputX < 0 || BSuserInputX >= BSgridSize || BSuserInputY < 0 || BSuserInputY >= BSgridSize)
                {
                    Console.WriteLine("Invalid Coordinates. Please try again.");
                    continue;
                }



                Console.ReadLine();

            }
        }
    }
}
