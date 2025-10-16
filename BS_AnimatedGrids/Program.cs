using System;
using System.Reflection.Metadata.Ecma335;
using System.Transactions;

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
          

            int krakenHits = 0;

            for (int y = 0; y < BSgridSize; y++)
            {
                for (int x = 0; x < BSgridSize; x++)
                {
                    BSplayerGrid[y, x] = '*';
                    BSkrakenGrid[y, x] = '*';
                }
            }
            BSkrakenGrid[5, 3] = '#';
            BSkrakenGrid[5, 4] = '#';
            BSkrakenGrid[5, 5] = '#';
            BSkrakenGrid[5, 6] = '#';
            
            //launch game
            while (krakenHits <= 4)
            {
                Console.Clear();
                
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
                string tempY = Console.ReadLine();
                Console.Write("Y: ");
                string tempX = Console.ReadLine();
                int BSuserX = Convert.ToInt32(tempX);
                int BSuserY = Convert.ToInt32(tempY);

                if (BSuserX < 0 || BSuserX > BSgridSize || BSuserY < 0 || BSuserY > BSgridSize)
                {
                    Console.WriteLine("Invalid Coordinates. Please try again.");
                    Console.ReadLine();
                    continue;
                } 

                if (BSplayerGrid[BSuserY, BSuserX] == '0')
                {
                    Console.WriteLine("Coordinates already hit. Try a different area!");
                    continue;
                }
              
                if (BSkrakenGrid[BSuserY, BSuserX] == '#')
                {
                    Console.WriteLine("You've hit the kraken!");              
                    BSplayerGrid[BSuserY, BSuserX] = 'X';
                    BSkrakenGrid[BSuserY, BSuserX] = 'X';
                    krakenHits = krakenHits + 1;
                }
                else
                {
                    Console.WriteLine("You missed!");
                    BSplayerGrid[BSuserY, BSuserX] = '0';
                }
                    Console.ReadLine();

            }
        }
    }
}
