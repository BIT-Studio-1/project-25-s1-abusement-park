using System;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.Arm;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Net.Security;
using Maze;

namespace Game_Title
{
    internal class MainMenu
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        private const int SW_MAXIMIZE = 3;

        static void CreepyClown()
        {
            Random rand = new Random();
            Console.Clear();
            Console.WriteLine("                      ..:::::::::::::..\r\n                .:::::''              ``:::.\r\n              .:;'                        `::.\r\n           ..::'                            `::.\r\n          ::'                                  ::.:'\r\n      `::.::                                    ::.\r\n    .::::::::'                                `:.:::.    .:':'\r\n:::::::::::::.          .:.                .:. ` :::::::::':::\r\n:::.::::::::::::'       :::                :::    :::::::::':::'\r\n..::::::::::::'          ' `                ' `   .::::::' :::'\r\n::::::::::::'  `:.   .:::::::.          .:::::::.:: .:' :'.::'\r\n::::::::::::    `::.::'     `::.      .::'     `::.::':'.:::'\r\n::::::::::::      .::'        `:;  . .::'        `:;:'.::''\r\n:::::::::::'.     ::'    .    .:: :  ::'    .    .:::::''\r\n:`::::::::::::.:  `::.  :O: .::;' :  `::.  :O: .::;'::'\r\n   `::::::`::`:.    `:::::::::'   :.   `:::::::::':'''\r\n       `````:`::.     , .         `:.        , . `::.\r\n            :: `::.   :::      ..::::::::..  :::  `::\r\n      .::::'::. `::.  `:'     :::::::::::::; `:'   :;\r\n            ::'    ::.   .::'  ``:::::::;'' :.   .:'\r\n            `::    `::  ::'        ::       .::  :'\r\n             ::.    :'.::::::.    :  :   .::::. .:::.\r\n:.           `::.     :::'  ``::::. .::::'' `::::' `::.\r\n`::.          `::.    `:::. ::.  `::::' .:: ::::;    `::\r\n:.`:.          `::.     `::. `:::.    .::'  ::;'     .:;.\r\n ::`::.          `::.     `::.  `::. .::' .:;':'     :;':.\r\n::':``:::::.       `::.     `::. `::::'  .:;':'     .;':':\r\n: .:`:::':`:::::.   `::.      `:::.   .::;'.:'  .::;'' ';:\r\n..::': :. ::::. `::::::`::..      `:::::'  .:':::'::.:: :':\r\n:' :'.:::. `:: :: ::. .::`::.   .     . .:;':' ::'`:: :::'\r\n: ::.:. `:  `::'  `:: ::'::`::::::::::::;' :: .:' .::: ;:'\r\n::.::.:::: .:: :.  `:':'  ::.:'`::. .::':.::' :: .::''::'\r\n`:::`::.`:.::' ::  .: ::  `::'  `:: :' .::' ::.:.::' :;\r\n   `::::::.`:. .:. :: `::.:: ::  `::. .:: ::.`:::':.:;'\r\n         `::::::::::...:::'  `::.:'`:.::'.:.:;' .:;'\r\n                    `::::::::::::::::::::'.::;:;'");
            int i = rand.Next(1, 10);
            switch (i)
            {
                case 1: Console.WriteLine("I can see you"); break;
                case 2: Console.WriteLine("Are you ready to smile... FOREVER?!"); break;
                case 3: Console.WriteLine("Don't run, we just want to play."); break;
                case 4: Console.WriteLine("88888888ba                           \r\n88      \"8b                          \r\n88      ,8P                          \r\n88aaaaaa8P'  ,adPPYba,   ,adPPYba,   \r\n88\"\"\"\"\"\"8b, a8\"     \"8a a8\"     \"8a  \r\n88      `8b 8b       d8 8b       d8  \r\n88      a8P \"8a,   ,a8\" \"8a,   ,a8\"  \r\n88888888P\"   `\"YbbdP\"'   `\"YbbdP\"' "); break;
                case 5: Console.WriteLine("I can smell you"); break;
                case 6: Console.WriteLine("Hey kid, wanna buy some balloons"); break;
                case 7: Console.WriteLine("We all float down here"); break;
                case 8: Console.WriteLine("Nice eyes you have there, they look perfect to juggle"); break;
                case 9: Console.WriteLine("Don’t be shy… the fun’s just beginning!"); break;
                case 10: Console.WriteLine("Oops! I dropped my nose… guess I’ll have to borrow yours!"); break;
                case 11: Console.WriteLine("The circus left town… but I stayed behind."); break;
                case 12: Console.WriteLine("I used to make people laugh… now I make them disappear."); break;
                default: Console.WriteLine("Hehehehe"); break;
            }
            Console.ReadKey();
            Console.Clear();
        }

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;

            IntPtr consoleWindow = GetConsoleWindow();
            if (consoleWindow != IntPtr.Zero)
            {
                ShowWindow(consoleWindow, SW_MAXIMIZE); // Maximize the console window
            }

            Console.WriteLine("Console is now fullscreen (maximized). If this didn't work, change your terminal settings to windows terminal host.");
            Console.ReadLine(); // Keep the console open

            Console.WriteLine(@"                                                                                                                      ");
            Console.WriteLine(@"                                                                   .*#                                                ");
            Console.WriteLine(@"                                                             .+% +*##@.                                               ");
            Console.WriteLine(@"                                                            ..--+++**@.                                               ");
            Console.WriteLine(@"                                                                    .@                                                ");
            Console.WriteLine(@"                                                                    .@                                                ");
            Console.WriteLine(@"                                                                    :@                                                ");
            Console.WriteLine(@"                                                                   :%%=                                               ");
            Console.WriteLine(@"                                                                 .* *##%%.                                            ");
            Console.WriteLine(@"                                                               .**=##-*-%==                                           ");
            Console.WriteLine(@"                                                             .+#:**#.:*-:#*#=:                                        ");
            Console.WriteLine(@"                                                          ..@#:.@+#+ -+*. #*:#=#..                                    ");
            Console.WriteLine(@"                                                        .-#*  :#+#=  #+*: .#**.*%-+:.                                 ");
            Console.WriteLine(@"                                                     .- *#+  .+*+#:   +++%. .#+#+.-#+-=:                              ");
            Console.WriteLine(@"                                                  .* *#+.   :#++#.    #+++-   =++#- :#**---                           ");
            Console.WriteLine(@"                                              =%####..    *++*#     .*+++%    .*+*#. .-#*##.%:                        ");
            Console.WriteLine(@"                                     .::=@#######:.....:%####=......@#####=.....*###%:...=###%=:+-:.                  ");
            Console.WriteLine(@"                                     .#####%*+*==:..:+*+*+#%+==:...=##+++-:+###=+=%%*++...==+:..#%%%.                 ");
            Console.WriteLine(@"                                     .######:...-####=....*##***...*%#.....=#####%....-#####-...###%.                 ");
            Console.WriteLine(@"                                     .#*+++#:...-####=....*#*##*..:@%@*....=#####%:...-#####:...#+*%                  ");
            Console.WriteLine(@"                                     .#*+++#.   :#++#=....**###*..%%%@%#...=#**++%.   :#+++#:   #+*#                  ");
            Console.WriteLine(@"                                     .#*+++#.   :#++#-    +*++**.*##@@%#+. =*++++%.   :#+++#:   #+**                  ");
            Console.WriteLine(@"                                     .#*+++#:   :#++#-    +*++*#%##%@@@##*.=+++++#.   :#+++#.   #+*+                  ");
            Console.WriteLine(@"                                     .#*+++#:   .#++*-    ++++#####@@@@%####+++++#.   :#+++#.   #+#+                  ");
            Console.WriteLine(@"                                     .#*+++#:   .#++*-    +++%###%@@@@@@@###%*+++#:   :#+++#.   #+#=                  ");
            Console.WriteLine(@"                                     .#*+++#-   .#++*-    +#####@@@@@@@@@%#####*+#:   :#+++%.   #*#-                  ");
            Console.WriteLine(@"                                      ######-.  .#++*- :+####%%@@@@@@@@@@@@%###**%*+: :#***%....###:                  ");
            Console.WriteLine(@"                                      ######=...:####=.*%%%%%@@@@@@@@@@@@@@%%%%%%%=...-####%:...###:                  ");
            Console.WriteLine(@"                                                                                                                      ");
            Console.WriteLine(@"                                ___  _                                         _        ______          _             ");
            Console.WriteLine(@"                               / _ \| |                                       | |       | ___ \        | |            ");
            Console.WriteLine(@"                              / /_\ \ |__  _   _ ___  ___ _ __ ___   ___ _ __ | |_      | |_/ /_ _ _ __| | __         ");
            Console.WriteLine(@"                              |  _  | '_ \| | | / __|/ _ \ '_ ` _ \ / _ \ '_ \| __|     |  __/ _` | '__| |/ /         ");
            Console.WriteLine(@"                              | | | | |_) | |_| \__ \  __/ | | | | |  __/ | | | |_      | | | (_| | |  |   <          ");
            Console.WriteLine(@"                              \_| |_/_.__/ \__,_|___/\___|_| |_| |_|\___|_| |_|\__|     \_|  \__,_|_|  |_|\_\         ");
            Console.WriteLine();                                                                                                                      
            Console.WriteLine("                                                     This is no ordinary amusement park...                             ");
            Console.WriteLine();                                                                                                                       
            Console.WriteLine("                                                           Press ENTER to proceed                                      ");
            Console.ReadLine();
                                              
            int mainMenuChoice = -1;

            while (mainMenuChoice != 0)
            {

                Console.Clear();
                Console.WriteLine(@"                         ..:::::::::::::..                                               ");
                Console.WriteLine(@"                   .:::::''              ``:::.                                          ");
                Console.WriteLine(@"                 .:;'                        `::.                                        ");
                Console.WriteLine(@"              ..::'                            `::.                                      ");
                Console.WriteLine(@"             ::'                                  ::.:'                                  ");
                Console.WriteLine(@"         `::.::                                    ::.                    __________________________________________________________      ");
                Console.WriteLine(@"       .::::::::'                                `:.:::.    .:':'        |                                                          |     ");
                Console.WriteLine(@"   :::::::::::::.          .:.                .:. ` :::::::::':::        |    Step right up, kiddies and creeps...                  |     ");
                Console.WriteLine(@"   :::.::::::::::::'       :::                :::    :::::::::':::'      |    to a place where screams are music and laughter hides |     ");
                Console.WriteLine(@"   ..::::::::::::'          ' `                ' `   .::::::' :::'       |    in the shadows. Welcome to the Abusement Park-a park  |     ");
                Console.WriteLine(@"   ::::::::::::'  `:.   .:::::::.          .:::::::.:: .:' :'.::'        \        that never lets you leave smiling... alive.      /      ");
                Console.WriteLine(@"   ::::::::::::    `::.::'     `::.      .::'     `::.::':'.:::'          \                                                       /       ");
                Console.WriteLine(@"   ::::::::::::      .::'        `:;  . .::'        `:;:'.::''              ----      -- ----------------------------------------         ");
                Console.WriteLine(@"   :::::::::::'.     ::'    .    .:: :  ::'    .    .:::::''                    \   /                                                     ");
                string eyes = @"   :`::::::::::::.:  `::.  :O: .::;' :  `::.  :O: .::;'::'                       \_/ ";
                foreach (char i in eyes)
                {
                    if (i == 'O')
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.Write(i);
                }
                Console.WriteLine();
                Console.WriteLine(@"      `::::::`::`:.    `:::::::::'   :.   `:::::::::':'''                                                                                 ");
                Console.WriteLine(@"          `````:`::.     , .         `:.        , . `::.                                    What game do you want to play?                ");
                Console.WriteLine(@"               :: `::.   :::      ..::::::::..  :::  `::                                    [1] Liars Dice                                ");
                Console.WriteLine(@"         .::::'::. `::.  `:'     :::::::::::::; `:'   :;                                    [2] Battleships                               ");
                Console.WriteLine(@"               ::'    ::.   .::'  ``:::::::;'' :.   .:'                                     [3] Blackjack                                 ");
                Console.WriteLine(@"               `::    `::  ::'        ::       .::  :'                                      [4] Heads or Tails                            ");
                Console.WriteLine(@"                ::.    :'.::::::.    :  :   .::::. .:::.                                    [5] Amazin' Maze                              ");
                Console.WriteLine(@"   :.           `::.     :::'  ``::::. .::::'' `::::' `::.                                  [0] Exit                                       ");
                Console.WriteLine(@"   `::.          `::.    `:::. ::.  `::::' .:: ::::;    `::                                                                               ");
                Console.WriteLine(@"   :.`:.          `::.     `::. `:::.    .::'  ::;'     .:;.                                                                              ");
                Console.WriteLine(@"    ::`::.          `::.     `::.  `::. .::' .:;':'     :;':.                                                                             ");
                Console.WriteLine(@"   ::':``:::::.       `::.     `::. `::::'  .:;':'     .;':':                                                                             ");
                Console.WriteLine(@"   : .:`:::':`:::::.   `::.      `:::.   .::;'.:'  .::;'' ';:                                                                             ");
                Console.WriteLine(@"   ..::': :. ::::. `::::::`::..      `:::::'  .:':::'::.:: :':                                                                            ");
                Console.WriteLine(@"   :' :'.:::. `:: :: ::. .::`::.   .     . .:;':' ::'`:: :::'                                                                             ");
                Console.WriteLine(@"   : ::.:. `:  `::'  `:: ::'::`::::::::::::;' :: .:' .::: ;:'                                                                             ");
                Console.WriteLine(@"   ::.::.:::: .:: :.  `:':'  ::.:'`::. .::':.::' :: .::''::'                                                                              ");
                Console.WriteLine(@"   `:::`::.`:.::' ::  .: ::  `::'  `:: :' .::' ::.:.::' :;                                                                                ");
                Console.WriteLine(@"      `::::::.`:. .:. :: `::.:: ::  `::. .:: ::.`:::':.:;'                                                                                ");
                Console.WriteLine(@"            `::::::::::...:::'  `::.:'`:.::'.:.:;' .:;'                                                                                   ");
                Console.WriteLine(@"                       `::::::::::::::::::::'.::;:;'                                                                                      ");
                Console.WriteLine();
               
                Console.Write("\n> ");
                try
                {
                    mainMenuChoice = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    mainMenuChoice = -1;
                }

                Console.Clear();
                switch (mainMenuChoice)
                {
                    case 1:
                        LiarsDiceGame.LiarsDiceMain();
                        CreepyClown();
                        break;
                    case 2:
                        BattleShip.BattleShipMain();
                        CreepyClown();
                        break;
                    case 3:
                        Blackjack.BlackJackMain();
                        CreepyClown();
                        break;
                    case 4:
                        CoinGame.CoinGameMain();
                        CreepyClown();
                        break;
                    case 5:
                        Mazing.MazingMain();
                        CreepyClown();
                        break;
                    case 0:
                        CreepyClown();
                        break;
                    default:
                        Console.WriteLine("That wasn't an option...");
                        Console.Write("Press ENTER to continue...");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}
