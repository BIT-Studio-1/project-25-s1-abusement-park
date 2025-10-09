using System;

namespace CoinGameASCII
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(
@"    _____      _          _____                      
  / ____|    (_)        / ____|                     
 | |     ___  _ _ __   | |  __  __ _ _ __ ___   ___ 
 | |    / _ \| | '_ \  | | |_ |/ _` | '_ ` _ \ / _ \
 | |___| (_) | | | | | | |__| | (_| | | | | | |  __/
  \_____\___/|_|_| |_|  \_____|\__,_|_| |_| |_|\___|
                                                    ");

            Console.WriteLine("Welcome to the Coin Flip Game!");
            Console.WriteLine("Guess 'Heads' or 'Tails' and try your luck!\n");
            Console.WriteLine("made by RA"); 

            bool keepPlaying = true;
            Random rand = new Random();

            while (keepPlaying)
            {
                Console.Write("Enter your guess (Heads/Tails): ");
                string userGuess = Console.ReadLine().Trim().ToLower();

                if (userGuess != "heads" && userGuess != "tails")
                {
                    Console.WriteLine("\n!!! Invalid input. Please type 'Heads' or 'Tails'.\n");
                    continue;
                }

                string coinFlip = rand.Next(0, 2) == 0 ? "heads" : "tails";

                Console.WriteLine("\nFlipping the coin...");
                Console.WriteLine(@"
      _______
     /       \
    |  " + (coinFlip == "heads" ? "H" : "T") + @"    |
     \_______/
");
                Console.WriteLine($"The coin landed on: {coinFlip.ToUpper()}!\n");

                if (userGuess == coinFlip)
                {
                    Console.WriteLine("Congrats! You guessed correctly. You win!\n");
                }
                else
                {
                    Console.WriteLine("Sorry, you guessed wrong. Try again!\n");
                }

                Console.Write("Do you want to play again? (yes/no): ");
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
                    Console.WriteLine("\nThanks for playing! Goodbye!");
                }
            }
        }
    }
}
