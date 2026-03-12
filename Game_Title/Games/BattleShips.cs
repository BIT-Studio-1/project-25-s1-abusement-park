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

                    
            //Place Ships                              
            List<string> battleshipPos = new List<string>();          
            string shipCords;

            for (int i = 0; i < 4; i++)
            {

                Console.Clear();
                Console.WriteLine(@"                                                  0   1   2   3   4   5   6        ");
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
                Console.WriteLine();
                Console.WriteLine("Enter the XY coordinates of your Battleship:");
                Console.WriteLine("(Battleship is 4-Squares Long e.g A0 - A3)");
                Console.WriteLine("(Remember to enter coordinates one digit at a time!)");
                Console.WriteLine($"Coordinate {i + 1}");
                if (battleshipPos.Count > 0)
                {
                    Console.WriteLine($"Current ship coordinates:");
                    for (int j = 0; j < battleshipPos.Count; j++)
                    {
                        Console.Write(battleshipPos[j] + " ");
                    }
                    Console.WriteLine();
                }
                Console.Write("Y: ");
                string shipTempY = Console.ReadLine().ToUpper();
                Console.Write("X: ");
                string shipTempX = Console.ReadLine();
                               
                if (shipTempY.Length != 1 || shipTempY[0] < 'A' || shipTempY[0] > 'G')
                {
                    Console.WriteLine("Invalid Coordinates. Press ENTER to try again.");
                    Console.ReadLine();
                    i = i - 1;
                    continue;
                }                                  
                int BSshipX = ' ';
                switch (shipTempX)
                {
                    case "0":
                        BSshipX = 0;
                        break;
                    case "1":
                        BSshipX = 1;
                        break;
                    case "2":
                        BSshipX = 2;
                        break;
                    case "3":
                        BSshipX = 3;
                        break;
                    case "4":
                        BSshipX = 4;
                        break;
                    case "5":
                        BSshipX = 5;
                        break;
                    case "6":
                        BSshipX = 6;
                        break;
                    default:
                        Console.WriteLine("Invalid Coordinates. Press ENTER to try again.");
                        Console.ReadLine();
                        i = i - 1;
                        continue;
                }
                shipCords = string.Join("", shipTempY, BSshipX);

                if (battleshipPos.Contains(shipCords))
                {
                    Console.WriteLine("Coordinates already used. Press ENTER to try again.");
                    Console.ReadLine();
                    i = i - 1;
                    continue;
                }
                battleshipPos.Add(shipCords);                                    
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

            //grid icon 
            for (int y = 0; y < BSgridSize; y++)
            {
                for (int x = 0; x < BSgridSize; x++)
                {
                    BSplayerGrid[x, y] = '*';
                    BSkrakenGrid[x, y] = '*';
                }
            }
            //Computer ship position

            Random rand = new Random();          
            int krakenNum, krakenNum2;          
            krakenNum = rand.Next(0, 8);   //randomly select a starting position for kraken ship
            krakenNum2 = rand.Next(0, 4);
            for (int i = 0; i < 4; i++)
            {
                BSkrakenGrid[krakenNum, krakenNum2] = '#';
                krakenNum2 = krakenNum2 + 1;
            }           


            int krakenHits = 0;
            int BSshipHits = 4;
            while (krakenHits < 4 && BSshipHits >= 0)
            {
                //Grid Layout
                Console.Clear();
                Console.WriteLine("Your moves:");
                Console.WriteLine("===========");
                for (int y = 0; y < BSgridSize; y++)
                {
                    Console.Write("  ");
                    Console.Write(y);
                }
                Console.WriteLine();
                for (int x = 0; x < BSgridSize; x++)
                {
                    Console.Write((char)('A' + x));
                    Console.Write(" ");
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
                Console.WriteLine("Your Battleship positions are:");
                for (int i = 0; i < 4; i++)
                {
                    Console.Write(battleshipPos[i] + " ");
                }

                //userInput
                Console.WriteLine();
                Console.WriteLine("Enter coordinates to strike:");
                Console.WriteLine("(Remember to enter coordinates one digit at a time!)");
                Console.Write("Y: ");  
                string tempY = Console.ReadLine().ToUpper();         //get user input for y axis, a-g
                Console.Write("X: ");
                string tempX = Console.ReadLine();               //get user input for x axis, 0-7
                int BSuserY = ' ';
                switch (tempY)
                {
                    case "A":
                        BSuserY = 0;
                        break;
                    case "B":
                        BSuserY = 1;
                        break;
                    case "C":
                        BSuserY = 2;
                        break;
                    case "D":
                        BSuserY = 3;
                        break;
                    case "E":
                        BSuserY = 4;
                        break;
                    case "F":
                        BSuserY = 5;
                        break;
                    case "G":
                        BSuserY = 6;
                        break;
                    default:
                        Console.WriteLine("Invalid Coordinates. Press ENTER to try again.");
                        Console.ReadLine();
                        continue;

                }               
                int BSuserX = ' ';
                switch (tempX)
                {
                    case "0":
                        BSuserX = 0;
                        break;
                    case "1":
                        BSuserX = 1;
                        break;
                    case "2":
                        BSuserX = 2;
                        break;
                    case "3":
                        BSuserX = 3;
                        break;
                    case "4":
                        BSuserX = 4;
                        break;
                    case "5":
                        BSuserX = 5;
                        break;
                    case "6":
                        BSuserX = 6;
                        break;
                    default:
                        Console.WriteLine("Invalid Coordinates. Press ENTER to try again.");
                        Console.ReadLine();
                        continue;
                }

                if (BSplayerGrid[BSuserY, BSuserX] == '0' || BSplayerGrid[BSuserY, BSuserX] == 'X')
                {
                    Console.WriteLine("Coordinates already hit. Press ENTER to try again.");
                    Console.ReadLine();
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
                Console.WriteLine("Press ENTER to continue");
                Console.ReadLine();
                Console.Clear();

                //Kraken Guess
                Console.WriteLine(@"        ⠀⠀ ⣀⣤⣴⣶⣤⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀  ");
                Console.WriteLine(@"  ⠀⠀⠀⠀⣠⡤⣤⣄⣾⣿⣿⣿⣿⣿⣿⣷⣠⣀⣄⡀⠀⠀⠀⠀  ");
                Console.WriteLine(@"  ⠀⠀⠀⠀⠙⠀⠈⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⣬⡿⠀⠀⠀⠀  ");
                Console.WriteLine(@"  ⠀⠀⠀⠀⠀⢀⣼⠟⢿⣿⣿⣿⣿⣿⣿⡿⠘⣷⣄⠀⠀⠀⠀⠀  ");
                Console.WriteLine(@"  ⣰⠛⠛⣿⢠⣿⠋⠀⠀⢹⠻⣿⣿⡿⢻⠁⠀⠈⢿⣦⠀⠀⠀⠀  ");
                Console.WriteLine(@"  ⢈⣵⡾⠋⣿⣯⠀⠀⢀⣼⣷⣿⣿⣶⣷⡀⠀⠀⢸⣿⣀⣀⠀⠀  ");
                Console.WriteLine(@"  ⢾⣿⣀⠀⠘⠻⠿⢿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣶⠿⣿⡁⠀⠀⠀  ");
                Console.WriteLine(@"  ⠈⠙⠛⠿⠿⠿⢿⣿⡿⣿⣿⡿⢿⣿⣿⣿⣷⣄⠀⠘⢷⣆⠀⠀  ");
                Console.WriteLine(@"  ⠀⠀⠀⠀⠀⢠⣿⠏⠀⣿⡏⠀⣼⣿⠛⢿⣿⣿⣆⠀⠀⣿⡇⡀  ");
                Console.WriteLine(@"  ⠀⠀⠀⠀⢀⣾⡟⠀⠀⣿⣇⠀⢿⣿⡀⠈⣿⡌⠻⠷⠾⠿⣻⠁  ");
                Console.WriteLine(@"  ⠀⠀⣠⣶⠟⠫⣤⠀⠀⢸⣿⠀⣸⣿⢇⡤⢼⣧⠀⠀⠀⢀⣿⠀  ");
                Console.WriteLine(@"  ⠀⣾⡏⠀⡀⣠⡟⠀⠀⢀⣿⣾⠟⠁⣿⡄⠀⠻⣷⣤⣤⡾⠋⠀  ");
                Console.WriteLine(@"  ⠀⠙⠷⠾⠁⠻⣧⣀⣤⣾⣿⠋⠀⠀⢸⣧⠀⠀⠀⠉⠁⠀⠀⠀  ");
                Console.WriteLine(@"  ⠀⠀⠀⠀⠀⠀⠈⠉⠉⠹⣿⣄⠀⠀⣸⡿⠀⠀⠀⠀⠀⠀⠀⠀  ");
                Console.WriteLine(@"  ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⠛⠿⠟⠛⠁⠀⠀⠀⠀⠀⠀    ");
                Console.WriteLine("   It's the Kraken's turn!");
                Console.WriteLine();
                string krakenMove;               
                
                do
                {
                    int BSgridNum = rand.Next(0,7);
                    char BSgridLetter = ((char)('A' +  BSgridNum));
                    int BSgridNum2 = rand.Next(0, 7);
                    krakenMove = ($"{BSgridLetter}{BSgridNum2}");
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
                    BSshipHits = BSshipHits - 1;
                    Console.WriteLine($"Your Battleship has {BSshipHits} hits left!");

                    Console.WriteLine(@"  ⠀⠀⠀⠀⠀⢀⣤⣶⣾⣿⣿⣿⣷⣶⣤⡀⠀⠀⠀⠀⠀  ");
                    Console.WriteLine(@"⠀ ⠀⠀⠀⠀⢰⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡆⠀⠀⠀⠀  ");
                    Console.WriteLine(@"⠀ ⠀⠀⠀⠀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⠀⠀⠀  ");
                    Console.WriteLine(@"⠀ ⠀⠀⠀⠀⢸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡏⠀⠀⠀⠀  ");
                    Console.WriteLine(@"⠀ ⠀⠀⠀⠀⢰⡟⠛⠉⠙⢻⣿⡟⠋⠉⠙⢻⡇⠀⠀⠀⠀  ");
                    Console.WriteLine(@"⠀ ⠀⠀⠀⠀⢸⣷⣀⣀⣠⣾⠛⣷⣄⣀⣀⣼⡏⠀⠀⠀⠀  ");
                    Console.WriteLine(@"⠀ ⠀⠀⣀⠀⠀⠛⠋⢻⣿⣧⣤⣸⣿⡟⠙⠛⠀⠀⣀⠀⠀  ");
                    Console.WriteLine(@"⠀ ⢀⣰⣿⣦⠀⠀⠀⠼⣿⣿⣿⣿⣿⡷⠀⠀⠀⣰⣿⣆⡀  ");
                    Console.WriteLine(@"⠀ ⢻⣿⣿⣿⣧⣄⠀⠀⠁⠉⠉⠋⠈⠀⠀⣀⣴⣿⣿⣿⡿  ");
                    Console.WriteLine(@"⠀ ⠀⠀⠀⠈⠙⠻⣿⣶⣄⡀⠀⢀⣠⣴⣿⠿⠛⠉⠁⠀⠀  ");
                    Console.WriteLine(@"⠀ ⠀⠀⠀⠀⠀⠀⠀⠉⣻⣿⣷⣿⣟⠉⠀⠀⠀⠀⠀⠀⠀  ");
                    Console.WriteLine(@"⠀ ⠀⠀⠀⠀⢀⣠⣴⣿⠿⠋⠉⠙⠿⣷⣦⣄⡀⠀⠀⠀⠀  ");
                    Console.WriteLine(@"⠀ ⣴⣶⣶⣾⡿⠟⠋⠀⠀⠀⠀⠀⠀⠀⠙⠻⣿⣷⣶⣶⣦  ");
                    Console.WriteLine(@"⠀ ⠙⢻⣿⡟⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢿⣿⡿⠋  ");
                    Console.WriteLine(@"⠀ ⠀⠀⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠀⠀  ");  
                }
                else
                {
                    Console.WriteLine("The kraken missed!");
                    Console.WriteLine();                   
                }

                Console.WriteLine("Press ENTER to fire again!");
                Console.ReadLine();
                Console.Clear();
            }

            if (krakenHits == 4)
            {
                Console.WriteLine("Congratulations. You've defeated the Kraken!");
                Console.WriteLine("Press ENTER to proceed");
                Console.WriteLine();
                Console.WriteLine(@"             ⢀⣀⣀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
                Console.WriteLine(@"⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣰⣿⣿⣿⣿⣿⣿⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
                Console.WriteLine(@"⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠿⠿⠿⠿⠿⠿⠿⠿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
                Console.WriteLine(@"⠀⠀⠀⠀⣠⣤⣄⡀⠀⠰⣶⣶⣶⣶⣶⣶⣶⣶⣶⣶⡖⠀⢀⣠⣤⣄⠀⠀⠀⠀");
                Console.WriteLine(@"⠀⠀⠀⠀⠙⣿⣿⡟⢀⣤⣤⣤⣤⣤⣤⣤⣤⣤⣤⣤⣤⡀⢻⣿⣿⠋⠀⠀⠀⠀");
                Console.WriteLine(@"⠀⠀⠀⠀⣠⣿⠏⢠⣾⣿⡟⠙⣿⣿⣿⣿⣿⣿⠋⢻⣿⣷⡄⠹⣿⣄⠀⠀⠀⠀");
                Console.WriteLine(@"⠀⢰⣾⣿⣿⡏⢠⣿⣿⠏⢠⣦⠈⢿⣿⣿⡿⠁⣴⡄⠹⣿⣿⡄⢹⣿⣿⣷⡆⠀");
                Console.WriteLine(@"⠀⠀⠙⢿⣿⠁⣼⣿⡟⢀⣿⣿⣇⠘⣿⣿⠃⣸⣿⣿⡀⢻⣿⣧⠈⣿⡿⠋⠀⠀");
                Console.WriteLine(@"⠀⠀⠀⠸⠿⠀⣿⣿⠁⣸⡇⠀⣿⡀⢹⡏⢀⣿⠀⢸⣇⠈⣿⣿⠀⠿⠇⠀⠀⠀");
                Console.WriteLine(@"⠀⠀⠀⠀⠀⠀⢿⣿⣤⡤⣤⣤⡄⢀⡤⠀⠀⢠⣤⣤⢤⣤⣿⡿⠀⠀⠀⠀⠀⠀");
                Console.WriteLine(@"⠀⠀⠀⠀⠀⠀⠘⢁⣤⣤⣤⣄⡀⠏⠀⠀⠀⢀⣠⣤⣤⣤⡈⠃⠀⠀⠀⠀⠀⠀");
                Console.WriteLine(@"⠀⠀⠀⠀⠀⠀⠀⢻⣿⡍⠹⣿⣷⣤⣀⣀⣤⣾⣿⠏⢩⣿⡟⠀⠀⠀⠀⠀⠀⠀");
                Console.WriteLine(@"⠀⠀⠀⠀⠀⠀⠀⠀⠹⣿⣦⣈⠙⠿⠿⠿⠿⠋⣁⣴⣿⠏⠀⠀⠀⠀⠀⠀⠀⠀");
                Console.WriteLine(@"⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠛⠿⣿⣶⣶⣶⣶⣿⠿⠛⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀");
                Console.WriteLine(@"⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠉⠉⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
                Console.ReadLine();

            }
            if (BSshipHits == 0)
            {
                Console.WriteLine("Game over. You have been defeated by the Kraken!");
                Console.WriteLine("Press ENTER to try again!");
            }

        }
    }
}
