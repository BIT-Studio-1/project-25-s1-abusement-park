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

        static void Main(string[] args)
        {
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

            Console.Clear();
            Console.WriteLine(@"                       ..:::::::::::::..                                               ");
            Console.WriteLine(@"                 .:::::''              ``:::.                                          ");
            Console.WriteLine(@"               .:;'                        `::.                                        ");
            Console.WriteLine(@"            ..::'                            `::.                                      ");
            Console.WriteLine(@"           ::'                                  ::.:'                                  ");
            Console.WriteLine(@"       `::.::                                    ::.                    __________________________________________________________       ");
            Console.WriteLine(@"     .::::::::'                                `:.:::.    .:':'        |                                                          |      ");
            Console.WriteLine(@" :::::::::::::.          .:.                .:. ` :::::::::':::        |                                                          |      ");
            Console.WriteLine(@" :::.::::::::::::'       :::                :::    :::::::::':::'      |                                                          |      ");
            Console.WriteLine(@" ..::::::::::::'          ' `                ' `   .::::::' :::'       |                                                          |      ");
            Console.WriteLine(@" ::::::::::::'  `:.   .:::::::.          .:::::::.:: .:' :'.::'        \                                                         /       ");
            Console.WriteLine(@" ::::::::::::    `::.::'     `::.      .::'     `::.::':'.:::'          \                                                       /        ");
            Console.WriteLine(@" ::::::::::::      .::'        `:;  . .::'        `:;:'.::''              ----       -- ---------------------------------------          ");
            Console.WriteLine(@" :::::::::::'.     ::'    .    .:: :  ::'    .    .:::::''                    \    /                                                     ");
            Console.WriteLine(@" :`::::::::::::.:  `::.  :O: .::;' :  `::.  :O: .::;'::'                       \  /                                                      ");
            Console.WriteLine(@"    `::::::`::`:.    `:::::::::'   :.   `:::::::::':'''                                ");
            Console.WriteLine(@"        `````:`::.     , .         `:.        , . `::.                                 ");
            Console.WriteLine(@"             :: `::.   :::      ..::::::::..  :::  `::                                 ");
            Console.WriteLine(@"       .::::'::. `::.  `:'     :::::::::::::; `:'   :;                                 ");
            Console.WriteLine(@"             ::'    ::.   .::'  ``:::::::;'' :.   .:'                                  ");
            Console.WriteLine(@"             `::    `::  ::'        ::       .::  :'                                   ");
            Console.WriteLine(@"              ::.    :'.::::::.    :  :   .::::. .:::.                                 ");
            Console.WriteLine(@" :.           `::.     :::'  ``::::. .::::'' `::::' `::.                               ");
            Console.WriteLine(@" `::.          `::.    `:::. ::.  `::::' .:: ::::;    `::                              ");
            Console.WriteLine(@" :.`:.          `::.     `::. `:::.    .::'  ::;'     .:;.                             ");
            Console.WriteLine(@"  ::`::.          `::.     `::.  `::. .::' .:;':'     :;':.                            ");
            Console.WriteLine(@" ::':``:::::.       `::.     `::. `::::'  .:;':'     .;':':                            ");
            Console.WriteLine(@" : .:`:::':`:::::.   `::.      `:::.   .::;'.:'  .::;'' ';:                            ");
            Console.WriteLine(@" ..::': :. ::::. `::::::`::..      `:::::'  .:':::'::.:: :':                           ");
            Console.WriteLine(@" :' :'.:::. `:: :: ::. .::`::.   .     . .:;':' ::'`:: :::'                            ");
            Console.WriteLine(@" : ::.:. `:  `::'  `:: ::'::`::::::::::::;' :: .:' .::: ;:'                            ");
            Console.WriteLine(@" ::.::.:::: .:: :.  `:':'  ::.:'`::. .::':.::' :: .::''::'                             ");
            Console.WriteLine(@" `:::`::.`:.::' ::  .: ::  `::'  `:: :' .::' ::.:.::' :;                               ");
            Console.WriteLine(@"    `::::::.`:. .:. :: `::.:: ::  `::. .:: ::.`:::':.:;'                               ");
            Console.WriteLine(@"          `::::::::::...:::'  `::.:'`:.::'.:.:;' .:;'                                  ");
            Console.WriteLine(@"                     `::::::::::::::::::::'.::;:;'                                     ");
                                        
            int mainMenuChoice = -1;

            while (mainMenuChoice != 0)
            {
                Console.WriteLine();
                Console.WriteLine("What game do you want to play?");
                Console.WriteLine("[1] Liars Dice");
                Console.WriteLine("[2] Battleships");
                Console.WriteLine("[3] Blackjack");
                Console.WriteLine("[4] Heads or Tails");
                Console.WriteLine("[5] Amazin' Maze");
                Console.WriteLine("[0] Exit");
                Console.Write("\n> ");
                try
                {
                    mainMenuChoice = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    
                }

                Console.Clear();
                switch (mainMenuChoice)
                {
                    case 1:
                        LiarsDiceGame.LiarsDiceMain();
                        break;
                    case 2:
                        BattleShip.BattleShipMain();
                        break;
                    case 3:
                        Blackjack.BlackJackMain();
                        break;
                    case 4:
                        CoinGame.CoinGameMain();
                        break;
                    case 5:
                        Mazing.MazingMain();
                        break;
                    case 0:
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
