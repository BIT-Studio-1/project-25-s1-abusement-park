using System;

namespace Game_Title
{
    public class CoinGame
    {
        public static void CoinGameMain()
        // Shows ASCII banner and welcome text
        {
            Console.WriteLine(
@"   _____      _          _____                      
  / ____|    (_)        / ____|                     
 | |     ___  _ _ __   | |  __  __ _ _ __ ___   ___ 
 | |    / _ \| | '_ \  | | |_ |/ _` | '_ ` _ \ / _ \
 | |___| (_) | | | | | | |__| | (_| | | | | | |  __/
  \_____\___/|_|_| |_|  \_____|\__,_|_| |_| |_|\___|
                                                    ");

            Console.WriteLine("Welcome to the Coin Flip Game!");
            Console.WriteLine("Guess 'Heads' or 'Tails' and try your luck!\n");
            Console.WriteLine("made by RA");

            int gamesPlayed = 0; // counts total rounds played
            int wins = 0;

            bool keepPlaying = true;
            Random rand = new Random();


            while (keepPlaying)
            {
                gamesPlayed++;  // increment games played every round

                Console.Write("Enter your guess (Heads/Tails): ");
                string userGuess = Console.ReadLine().Trim().ToLower();

                if (userGuess != "heads" && userGuess != "tails")
                {
                    Console.WriteLine("\n!!! Invalid input. Please type 'Heads' or 'Tails'.\n");      //Add input validation to only accept 'Heads' or 'Tails
                    continue;
                }

                string coinFlip = rand.Next(0, 2) == 0 ? "heads" : "tails";

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\nFlipping the coin in...");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Blue;
                for (int i = 3; i > 0; i--)
                {
                    Console.Write(i + "... ");
                    System.Threading.Thread.Sleep(500); // Pause for half a second
                }
                Console.WriteLine("\n");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(@"
      _______       
     /       \
    |  " + (coinFlip == "heads" ? "  H" : "  T") + @"    |                                                                                                     
     \_______/
");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"The coin landed on: {coinFlip.ToUpper()}!\n");
                Console.ResetColor();
                if (userGuess == coinFlip)
                {
                    wins++; // Increment wins counter on correct guess
                    Console.Beep(); //Add beep for correct guess
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Congrats! You guessed correctly. You win!\n");                  //Highlights "Congrats! You guessed correctly. You win!" in green for positive feedback
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;                                         //Add red color to incorrect guess message
                    Console.WriteLine("Sorry, you guessed wrong. Try again!\n");
                    Console.ResetColor();
                }
                // (Added input validation for "play again" prompt)
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Do you want to play again? (yes/no): ");
                Console.ResetColor();
                string playAgain = Console.ReadLine().Trim().ToLower();

                // Keep asking until valid input is entered
                while (playAgain != "yes" && playAgain != "no")
                {
                    Console.Write("Invalid input. Please type 'yes' or 'no': ");
                    playAgain = Console.ReadLine().Trim().ToLower();
                }

                if (playAgain != "yes")
                {
                    keepPlaying = false;

                    if (playAgain == "no")
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\nThanks for playing! Goodbye!");
                        Console.ResetColor();

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(@"
                       _____          __  __ ______    ______      ________ _____  
                      / ____|   /\   |  \/  |  ____|  / __ \ \    / /  ____|  __ \ 
                     | |  __   /  \  | \  / | |__    | |  | \ \  / /| |__  | |__) |
                     | | |_ | / /\ \ | |\/| |  __|   | |  | |\ \/ / |  __| |  _  / 
                     | |__| |/ ____ \| |  | | |____  | |__| | \  /  | |____| | \ \ 
                      \_____/_/    \_\_|  |_|______|  \____/   \/   |______|_|  \_\
                     ");
                        Console.ResetColor();

                        Console.WriteLine($"\nGames played: {gamesPlayed}, Wins: {wins}");
                        Console.ReadLine(); // Pause before closing
                    }
            }
        }
    }
}
