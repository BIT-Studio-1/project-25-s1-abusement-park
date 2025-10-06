using System.Data;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.Arm;

namespace Battleship_V1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
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
            for (int i = 0; i<4; i++)
            {
                Console.WriteLine($"Enter coordinate {i+1}:");
                Console.Write("XY:   ");
                battleshipPos[i] = Console.ReadLine().ToUpper();
            }
            Console.WriteLine();
            Console.WriteLine("Your Battleship positions are:");
            for (int i = 0; i <4; i++)
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

            //Kraken Positions
            List<string> krakenPositions = new List<string> {"F4", "F5", "F6", "F7"};

          
            //Game loop
            List<string> BSuserInputs = new List<string>();
            List<string> BSkrakenAim = new List<string>();
            int krakenCount = 4;
            int BSshipHits = 4;

            while (krakenCount != 0)
            {
                //Grid Layout
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
                Console.WriteLine();
                Console.WriteLine($"Your Battleship has {BSshipHits} hits left until it sinks!");
                Console.WriteLine($"The kraken needs {krakenCount} hits to be deafeated!");
                Console.WriteLine("Current Moves:");
                Console.WriteLine($"{string.Join(", ", BSuserInputs)}");
                Console.WriteLine();
                Console.WriteLine("Enter coordinates to strike:");
                Console.Write("XY:    ");
                string playerHitKraken = Console.ReadLine().ToUpper();
                Console.WriteLine("Firing cannons");
                Thread.Sleep(500); 
                Console.Write(".");
                Thread.Sleep(500);
                Console.Write(".");
                Thread.Sleep(500);
                Console.Write(".");
                Thread.Sleep(500);
                Console.WriteLine();
                
                if (BSuserInputs.Contains(playerHitKraken))
                {
                    Console.WriteLine();
                    Console.WriteLine("You've already hit that space! Try a different coordinate.");
                    continue;
                }               

                if (krakenPositions.Contains(playerHitKraken))
                {
                    Console.WriteLine();
                    Console.WriteLine("You've hit the Kraken!");
                    Console.WriteLine();
                    krakenCount = krakenCount - 1;

                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Miss!");
                    Console.WriteLine();
                }
                
                BSuserInputs.Add(playerHitKraken);

                //Kraken Guess
                Console.WriteLine("It's the Krakens turn!");
                Console.WriteLine();
                string krakenMove;
                Random random = new Random();
                int BSkrakenHits = 0;               
                do
                {
                    char BSgridLetter = (char)('a' + random.Next(0, 7));
                    int BSgridNum = random.Next(1, 7);
                    krakenMove = ($"{BSgridLetter}{BSgridNum}");
                } while (BSkrakenAim.Contains(krakenMove));

                BSkrakenAim.Add(krakenMove);
                Console.WriteLine("Kraken moving");
                Thread.Sleep(500);
                Console.Write(".");
                Thread.Sleep(500);
                Console.Write(".");
                Thread.Sleep(500);
                Console.Write(".");
                Thread.Sleep(500);
                Console.WriteLine();
                Console.WriteLine($"The Kraken hits: {krakenMove.ToUpper()}");

                if (battleshipPos.Contains(krakenMove.ToUpper()))
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

            if (krakenCount == 0)
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
