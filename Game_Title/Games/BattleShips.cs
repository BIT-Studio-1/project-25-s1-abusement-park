using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.Arm;
using System.Threading;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Game_Title
{
    public class BattleShip
    {
        public static void BattleShipMain()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            //Game Intro                                                                                                                                                                                            
            Console.WriteLine(@"                                                     _  _              ");
            Console.WriteLine(@"                                                    ' \/ '             ");
            Console.WriteLine(@"    _  _                        <|                                     ");
            Console.WriteLine(@"     \/              __'__     __'__      __'__                                 __________         __    __  .__                .__    .__                       ");
            Console.WriteLine(@"                    /    /    /    /     /    /                                 \______   \_____ _/  |__/  |_|  |   ____   _____|  |__ |__|_____                 ");
            Console.WriteLine(@"                   /\____\    \____\     \____\               _  _               |    |  _/\__  \\   __\   __\  | _/ __ \ /  ___/  |  \|  \____ \                ");
            Console.WriteLine(@"                  / ___!___   ___!___    ___!___               \/                |    |   \ / __ \|  |  |  | |  |_\  ___/ \___ \|   Y  \  |  |_> >               ");
            Console.WriteLine(@"                // (      (  (      (   (      (                                 |______  /(____  /__|  |__| |____/\___  >____  >___|  /__|   __/                ");
            Console.WriteLine(@"              / /   \______\  \______\   \______\                                       \/      \/                     \/     \/     \/   |__|                   ");
            Console.WriteLine(@"            /  /   ____!_____ ___!______ ____!_____                                                                       Pirate style!");
            Console.WriteLine(@"          /   /   /         //         //         /                      ");
            Console.WriteLine(@"       /    /   |         ||         ||         |                        ");
            Console.WriteLine(@"      /_____/     \         \\         \\         \                                               Press ENTER to continue... ");
            Console.WriteLine(@"            \      \_________\\_________\\_________\                     ");
            Console.WriteLine(@"             \         |          |         |                            ");
            Console.WriteLine(@"              \________!__________!_________!________/                   ");
            Console.WriteLine(@"               \|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_/|                   ");
            Console.WriteLine(@"                \    _______________                /                    ");
            Console.WriteLine(@" ^^^%%%^%^^^%^%%^\_'/_)/_)_/_)__)/_)/)/)_)_'_'_'_/)/)/)/)%%%^^^%^^%%%%^  ");
            Console.WriteLine(@" ^!!^^'!%%!^^^!^^^!!^^^%%%%%!!!!^^^%%^^^!!%%%%^^^!!!!!!%%%^^^^%^^%%%^^^! ");
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Instructions:  ");
            Console.WriteLine();
            Console.WriteLine("   This a Battleship style game.Enter the 4 XY coordinates to place your ship on the grid.                   ");
            Console.WriteLine("   Your opponent, the Kraken, is also 4 coordinates long, Type the coordinates, then press ENTER to fire.          ");
            Console.WriteLine("   Your job is to defeat the Kraken before it defeats you! You can type EXIT at any time to end the game            ");
            Console.WriteLine("               (Enter coordinates one at a time e.g. X:3,  Y:4)                                                   ");
            Console.WriteLine();
            Console.WriteLine("              Are you ready for battle? Press ENTER to continue");
            Console.WriteLine();
            Console.WriteLine(@"                                ⠀⠀ ⣀⣤⣴⣶⣤⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀  ");
            Console.WriteLine(@"                          ⠀⠀⠀⠀⣠⡤⣤⣄⣾⣿⣿⣿⣿⣿⣿⣷⣠⣀⣄⡀⠀⠀⠀⠀  ");
            Console.WriteLine(@"                          ⠀⠀⠀⠀⠙⠀⠈⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⣬⡿⠀⠀⠀⠀  ");
            Console.WriteLine(@"                          ⠀⠀⠀⠀⠀⢀⣼⠟⢿⣿⣿⣿⣿⣿⣿⡿⠘⣷⣄⠀⠀⠀⠀⠀  ");
            Console.WriteLine(@"                          ⣰⠛⠛⣿⢠⣿⠋⠀⠀⢹⠻⣿⣿⡿⢻⠁⠀⠈⢿⣦⠀⠀⠀⠀  ");
            Console.WriteLine(@"                          ⢈⣵⡾⠋⣿⣯⠀⠀⢀⣼⣷⣿⣿⣶⣷⡀⠀⠀⢸⣿⣀⣀⠀⠀  ");
            Console.WriteLine(@"                          ⢾⣿⣀⠀⠘⠻⠿⢿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣶⠿⣿⡁⠀⠀⠀  ");
            Console.WriteLine(@"                          ⠈⠙⠛⠿⠿⠿⢿⣿⡿⣿⣿⡿⢿⣿⣿⣿⣷⣄⠀⠘⢷⣆⠀⠀  ");
            Console.WriteLine(@"                          ⠀⠀⠀⠀⠀⢠⣿⠏⠀⣿⡏⠀⣼⣿⠛⢿⣿⣿⣆⠀⠀⣿⡇⡀  ");
            Console.WriteLine(@"                          ⠀⠀⠀⠀⢀⣾⡟⠀⠀⣿⣇⠀⢿⣿⡀⠈⣿⡌⠻⠷⠾⠿⣻⠁  ");
            Console.WriteLine(@"                          ⠀⠀⣠⣶⠟⠫⣤⠀⠀⢸⣿⠀⣸⣿⢇⡤⢼⣧⠀⠀⠀⢀⣿⠀  ");
            Console.WriteLine(@"                          ⠀⣾⡏⠀⡀⣠⡟⠀⠀⢀⣿⣾⠟⠁⣿⡄⠀⠻⣷⣤⣤⡾⠋⠀  ");
            Console.WriteLine(@"                          ⠀⠙⠷⠾⠁⠻⣧⣀⣤⣾⣿⠋⠀⠀⢸⣧⠀⠀⠀⠉⠁⠀⠀⠀  ");
            Console.WriteLine(@"                          ⠀⠀⠀⠀⠀⠀⠈⠉⠉⠹⣿⣄⠀⠀⣸⡿⠀⠀⠀⠀⠀⠀⠀⠀  ");
            Console.WriteLine(@"                          ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⠛⠿⠟⠛⠁⠀⠀⠀⠀⠀⠀    ");
            Console.ReadLine();
            Console.Clear();

            //Grid Layout
            Console.WriteLine(@"                                                  1   2   3   4   5   6   7        ");
            Console.WriteLine(@"                                                +---+---+---+---+---+---+---+      ");
            Console.WriteLine(@"                                              A | * | * | * | * | * | * | * |      ");
            Console.WriteLine(@"                        _==|                    +---+---+---+---+---+---+---+      ");
            Console.WriteLine(@"              _==|   )__)  |                  B | * | * | * | * | * | * | * |      ");
            Console.WriteLine(@"                )_)  )___) ))                   +---+---+---+---+---+---+---+      ");
            Console.WriteLine(@"               )___) )____))_)                C | * | * | * | * | * | * | * |      ");
            Console.WriteLine(@"          _    )____)_____))__)\                +---+---+---+---+---+---+---+      ");
            Console.WriteLine(@"           \---__|____/|___|___-\\---         D | * | * | * | * | * | * | * |      ");
            Console.WriteLine(@"   ^^^^^^^^^\   oo oo oo oo     /~~^^^^^^^      +---+---+---+---+---+---+---+      ");
            Console.WriteLine(@"     ~^^^^ ~~~~^^~~~~^^~~^^~~~~~              E | * | * | * | * | * | * | * |      ");
            Console.WriteLine(@"       ~~^^      ~^^~     ~^~ ~^ ~^             +---+---+---+---+---+---+---+      ");
            Console.WriteLine(@"            ~^~~        ~~~^^~                F | * | * | * | * | * | * | * |      ");
            Console.WriteLine(@"                                                +---+---+---+---+---+---+---+      ");
            Console.WriteLine(@"                                              G | * | * | * | * | * | * | * |      ");
            Console.WriteLine(@"                                                +---+---+---+---+---+---+---+      ");

            //Place Ships                   
            Console.WriteLine("Enter the XY coordinates of your Battleship:");
            Console.WriteLine("(Battleship is 4-Squares Long e.g. C3 - F3)");


            string[] battleshipPos = new string[4];
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($"Enter coordinate {i + 1}:");
                Console.Write("XY:   ");

                battleshipPos[i] = Console.ReadLine().ToUpper();
            }
            Console.WriteLine();
            Console.WriteLine("Your Battleship positions are:");
            for (int i = 0; i < 4; i++)
            {
                Console.Write(battleshipPos[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("The Kraken is preparing for battle...");
            Thread.Sleep(500);
            Console.WriteLine();
            Console.WriteLine("Press ENTER to ready the cannons!");
            Console.ReadLine();
            Console.Clear();




            //Game loop and grid set up
            int BSgridSize = 7;
            char[,] BSplayerGrid = new char[BSgridSize, BSgridSize];
            char[,] BSkrakenGrid = new char[BSgridSize, BSgridSize];
            List<string> BSkrakenAim = new List<string>();

            Console.WriteLine(@"                                                  1   2   3   4   5   6   7                                         ");
            Console.WriteLine(@"                                                +---+---+---+---+---+---+---+               ⠀⠀ ⣀⣤⣴⣶⣤⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀      ");
            Console.WriteLine(@"                                              A | * | * | * | * | * | * | * |         ⠀⠀⠀⠀⣠⡤⣤⣄⣾⣿⣿⣿⣿⣿⣿⣷⣠⣀⣄⡀⠀⠀⠀⠀      ");
            Console.WriteLine(@"                        _==|                    +---+---+---+---+---+---+---+         ⠀⠀⠀⠀⠙⠀⠈⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⣬⡿⠀⠀⠀⠀      ");
            Console.WriteLine(@"              _==|   )__)  |                  B | * | * | * | * | * | * | * |         ⠀⠀⠀⠀⠀⢀⣼⠟⢿⣿⣿⣿⣿⣿⣿⡿⠘⣷⣄⠀⠀⠀⠀⠀      ");
            Console.WriteLine(@"                )_)  )___) ))                   +---+---+---+---+---+---+---+         ⣰⠛⠛⣿⢠⣿⠋⠀⠀⢹⠻⣿⣿⡿⢻⠁⠀⠈⢿⣦⠀⠀⠀⠀      ");
            Console.WriteLine(@"               )___) )____))_)                C | * | * | * | * | * | * | * |         ⢈⣵⡾⠋⣿⣯⠀⠀⢀⣼⣷⣿⣿⣶⣷⡀⠀⠀⢸⣿⣀⣀⠀⠀      ");
            Console.WriteLine(@"          _    )____)_____))__)\                +---+---+---+---+---+---+---+         ⢾⣿⣀⠀⠘⠻⠿⢿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣶⠿⣿⡁⠀⠀⠀      ");
            Console.WriteLine(@"           \---__|____/|___|___-\\---         D | * | * | * | * | * | * | * |         ⠈⠙⠛⠿⠿⠿⢿⣿⡿⣿⣿⡿⢿⣿⣿⣿⣷⣄⠀⠘⢷⣆⠀⠀      ");
            Console.WriteLine(@"   ^^^^^^^^^\   oo oo oo oo     /~~^^^^^^^      +---+---+---+---+---+---+---+         ⠀⠀⠀⠀⠀⢠⣿⠏⠀⣿⡏⠀⣼⣿⠛⢿⣿⣿⣆⠀⠀⣿⡇⡀      ");
            Console.WriteLine(@"     ~^^^^ ~~~~^^~~~~^^~~^^~~~~~              E | * | * | * | * | * | * | * |         ⠀⠀⠀⠀⢀⣾⡟⠀⠀⣿⣇⠀⢿⣿⡀⠈⣿⡌⠻⠷⠾⠿⣻⠁      ");
            Console.WriteLine(@"       ~~^^      ~^^~     ~^~ ~^ ~^             +---+---+---+---+---+---+---+         ⠀⠀⣠⣶⠟⠫⣤⠀⠀⢸⣿⠀⣸⣿⢇⡤⢼⣧⠀⠀⠀⢀⣿⠀      ");
            Console.WriteLine(@"            ~^~~        ~~~^^~                F | * | * | * | * | * | * | * |         ⠀⣾⡏⠀⡀⣠⡟⠀⠀⢀⣿⣾⠟⠁⣿⡄⠀⠻⣷⣤⣤⡾⠋⠀      ");
            Console.WriteLine(@"                                                +---+---+---+---+---+---+---+         ⠀⠙⠷⠾⠁⠻⣧⣀⣤⣾⣿⠋⠀⠀⢸⣧⠀⠀⠀⠉⠁⠀⠀⠀      ");
            Console.WriteLine(@"                                              G | * | * | * | * | * | * | * |         ⠀⠀⠀⠀⠀⠀⠈⠉⠉⠹⣿⣄⠀⠀⣸⡿⠀⠀⠀⠀⠀⠀⠀⠀      ");
            Console.WriteLine(@"                                                +---+---+---+---+---+---+---+         ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⠛⠿⠟⠛⠁⠀⠀⠀⠀⠀⠀        ");

            Console.WriteLine("Your Battleship positions are:");

            for (int i = 0; i < 4; i++)
            {
                Console.Write(battleshipPos[i] + " ");
            }

            //grid icon 
            for (int y = 0; y < BSgridSize; y++)
            {
                for (int x = 0; x < BSgridSize; x++)
                {
                    BSplayerGrid[y, x] = '*';
                    BSkrakenGrid[y, x] = '*';
                }
            }
            //Computer ship position
            BSkrakenGrid[5, 3] = '#';
            BSkrakenGrid[5, 4] = '#';
            BSkrakenGrid[5, 5] = '#';
            BSkrakenGrid[5, 6] = '#';

            int krakenHits = 0;
            int BSshipHits = 0;
            while (krakenHits <= 4 && BSshipHits <= 4)
            {
                //Grid Layout
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
                        if (BSplayerGrid[x, y] == 'X')
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        else if (BSplayerGrid[x, y] == '0')
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                        }
                        Console.Write(BSplayerGrid[x, y] + "  ");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.WriteLine();
                }

                Console.WriteLine();
                Console.WriteLine($"Your Battleship has {BSshipHits} hits left until it sinks!");

                //userInput
                Console.WriteLine();
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

                Console.WriteLine("Firing cannons");
                Thread.Sleep(300);
                Console.Write(".");
                Thread.Sleep(300);
                Console.Write(".");
                Thread.Sleep(300);
                Console.Write(".");
                Thread.Sleep(300);
                Console.WriteLine();
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

                //Kraken Guess
                Console.WriteLine("It's the Kraken's turn!");
                Console.WriteLine();
                string krakenMove;
                Random rand = new Random();
                int BSkrakenHits = 0;
                do
                {
                    int BSgridNum1 = rand.Next(0);
                    int BSgridNum2 = rand.Next(1, 7);
                    krakenMove = ($"{BSgridNum1}{BSgridNum2}");
                } while (BSkrakenAim.Contains(krakenMove));

                BSkrakenAim.Add(krakenMove);
                Console.WriteLine("Kraken moving");
                Thread.Sleep(300);
                Console.Write(".");
                Thread.Sleep(300);
                Console.Write(".");
                Thread.Sleep(300);
                Console.Write(".");
                Thread.Sleep(300);
                Console.WriteLine();
                Console.WriteLine($"The Kraken hits: {krakenMove}");

                if (battleshipPos.Contains(krakenMove))
                {
                    Console.WriteLine("The Kraken has hit your ship!");
                    BSkrakenHits++;
                    BSshipHits = BSshipHits - BSkrakenHits;
                    Console.WriteLine($"Your Battleship has {BSshipHits} left!");
                }
                else
                {
                    Console.WriteLine("The kraken missed!");
                }

                Console.WriteLine("Press ENTER to fire again!");
                Console.ReadLine();
                Console.Clear();
            }

            if (krakenHits == 0)
            {
                Console.WriteLine("Game over. You've defeated the Kraken!");
                Console.WriteLine("Press ENTER to proceed");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Game over. You have been defeated by the Kraken!");
                Console.WriteLine("Press ENTER to try again!");
            }

        }
    }
}
