using System;
using System.Data.SqlTypes;

namespace Game_Title
{
    public class CoinGame
    {
        public static int CoinGameMain(int tickets)
        {
            int wallet = tickets;
            int bet = 0;                  
            // Shows ASCII banner and welcome text
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
            int wins = 0; // counts total wins

            bool keepPlaying = true; // tracks if the player wants to play again or not
            Random rand = new Random();            

            // game loops while the user wants to play
            while (keepPlaying)
            {

                //ticket betting system
                do
                {
                    Console.WriteLine();
                    Console.WriteLine("Current tickets: " + wallet);
                    Console.WriteLine("How many tickets would you like to bet? ");
                    try
                    {
                        bet = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid! Please enter a number");
                    }
                    Console.WriteLine();
                } while (bet == 0);
                Console.Clear();

                string userGuess = " "; // default user input

                // loops while the user hasn't input a valid 'h' or 't'
                while (userGuess[0] != 'h' && userGuess[0] != 't')
                {
                    Console.Write("Enter your guess (Heads/Tails): "); // prompts user
                    userGuess = Console.ReadLine().Trim().ToLower(); // takes in user input and converts to lower
                    if (userGuess == "") // Checks for a blank input
                    {
                        Console.WriteLine("\n!!! Invalid input. Please type 'Heads' or 'Tails'.\n");
                        userGuess = " "; // resets user input for the loop
                    }
                    else if (userGuess[0] != 'h' && userGuess[0] != 't') // checks for a invalid input
                    {
                        Console.WriteLine("\n!!! Invalid input. Please type 'Heads' or 'Tails'.\n");
                    }
                }

                string coinFlip = rand.Next(0, 2) == 0 ? "heads" : "tails"; // randomly generates heads or tails

                // flipping coin animation
                Console.WriteLine("\nFlipping the coin in...");
                for (int i = 3; i > 0; i--)
                {
                    Console.Write(i + "... ");
                    Thread.Sleep(500); // Pause for half a second
                }
                Console.WriteLine("\n");
                Console.WriteLine(@"
      _______       
     /       \
    |  " + (coinFlip == "heads" ? "  H" : "  T") + @"    |                                                                                                     
     \_______/
");
                Console.WriteLine($"The coin landed on: {coinFlip.ToUpper()}!\n"); // states what the coin landed on
                if (userGuess == coinFlip) // checks win condition
                {
                    wins++; // Increment wins counter on correct guess
                    Console.WriteLine("Congrats! You guessed correctly. You win!\n");

                    wallet += bet; //add to wallet for win
                    Console.WriteLine($"You won {bet} tickets!");

                }
                else
                {
                    Console.WriteLine("Sorry, you guessed wrong. Try again!\n");

                    wallet -= bet;  //remove from wallet if you loose
                    Console.WriteLine($"You lost {bet} tickets");
                }

                gamesPlayed++;  // increment games played
                Console.Write("Do you want to play again? (yes/no): "); // prompts user to play again
                string playAgain = Console.ReadLine().Trim().ToLower(); // intakes user input converted to lower

                // Keep asking until valid input is entered
                while (playAgain[0] != 'y' && playAgain[0] != 'n')
                {
                    Console.Write("Invalid input. Please type 'yes' or 'no': ");
                    playAgain = Console.ReadLine().Trim().ToLower();
                    if (playAgain == "") // resets user input for loop
                    {
                        playAgain = " ";
                    }
                }

                if (playAgain[0] == 'n')
                {
                    keepPlaying = false;
                    Console.WriteLine("\nThanks for playing! Goodbye!");
                    Console.WriteLine(@"
  _____          __  __ ______    ______      ________ _____  
 / ____|   /\   |  \/  |  ____|  / __ \ \    / /  ____|  __ \ 
| |  __   /  \  | \  / | |__    | |  | \ \  / /| |__  | |__) |
| | |_ | / /\ \ | |\/| |  __|   | |  | |\ \/ / |  __| |  _  / 
| |__| |/ ____ \| |  | | |____  | |__| | \  /  | |____| | \ \ 
 \_____/_/    \_\_|  |_|______|  \____/   \/   |______|_|  \_\
                    ");

                    Console.WriteLine($"\nGames played: {gamesPlayed}, Wins: {wins}");
                    Console.ReadLine(); // Pause before closing
                    Console.Clear();
                }
               

            }
            return wallet;
        }
    }
}
