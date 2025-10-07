namespace Liars_Dice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Welcome Message //
            Console.WriteLine("Welcome to Liars Dice!");
            Console.WriteLine("""
                Each player has five dice. Players roll the dice which are hidden from each other and then take
                turns making bids about the quantity of a specific die face present among all the dice on the table.

                Lowest Bid: One 1
                Highest Bid: Six 6's

                The order of higher bids goes the number or dices then the number on the dice. So a bid of Three 1's
                would be higher then Two 6's. Players can only make higher bids then the last.

                Bidding continues until a player challenges a bid. When a challenge is made,
                everyone reveals their dice, and the players check if the bid was true or not.
                
                If the quantity of the bid is there then the bidding player wins, if not then the challenger wins.

                Press Enter to begin...
                """);

            Console.Write("> ");
            Console.ReadLine();

            // Players Roll //
            int[] playersDice = new int[5];
            int[] computerDice = new int[5];
            Random random = new Random();

            // Player
            for (int i = 0; i < 5; i++)
            {
                playersDice[i] = random.Next(1,7);
            }

            // Computer
            for (int i = 0;i < 5; i++)
            {
                computerDice[i] = random.Next(1, 7);
            }

            Console.Clear();
            Console.WriteLine("Press ENTER to roll...");
            Console.Write("> ");
            Console.ReadLine();

            // Betting //
            bool bullshit = false, playerTurn = true;
            int[] currentBet = new int[2];

            while (bullshit != true)
            {
                if (playerTurn)
                {
                    int[] newBet = new int[2];
                    while (newBet[0] == 0 || newBet[1] == 0)
                    {
                        // Show The Players Dice
                        Console.Clear();
                        Console.WriteLine("Your Dice:");
                        foreach (int dice in playersDice)
                        {
                            Console.Write(dice + " ");
                        }
                        Console.WriteLine("\n");
                        Console.WriteLine("The current bet is: [Number of dice] [Value of dice]");
                        Console.WriteLine($"{currentBet[0]}, {currentBet[1]}");
                        Console.WriteLine("What is your bet? [Number of dice] [Value of dice]");
                        Console.Write("> ");
                        string playerInput = Console.ReadLine();
                        playerInput = playerInput.Replace(" ", string.Empty).Replace(",", string.Empty);

                        // Check if input is valid
                        if (int.TryParse(playerInput, out int result) && (playerInput.Length == 2))
                        {
                            int numberOf = Int32.Parse(playerInput[0].ToString()), valueOf = Int32.Parse(playerInput[1].ToString());
                            if (numberOf > currentBet[0] && numberOf <= 6)
                            {
                                if (valueOf > 0 && valueOf <= 6)
                                {
                                    newBet[0] = numberOf;
                                    newBet[1] = valueOf;
                                }
                                else
                                {
                                    Console.WriteLine($"{playerInput[0]}, {playerInput[1]} is not within the valid betting range. A valid input looks like:\n3 6 or 36 (Three 6's)");
                                    Console.Write("Press ENTER to Continue...");
                                    Console.ReadLine();
                                }
                            }
                            else if (numberOf == currentBet[0] && numberOf > 0)
                            {
                                if (valueOf > currentBet[1] && valueOf <= 6)
                                {
                                    newBet[0] = numberOf;
                                    newBet[1] = valueOf;
                                }
                                else
                                {
                                    Console.WriteLine($"{playerInput[0]}, {playerInput[1]} is not within the valid betting range. A valid input looks like:\n3 6 or 36 (Three 6's)");
                                    Console.Write("Press ENTER to Continue...");
                                    Console.ReadLine();
                                }
                            }
                            else
                            {
                                Console.WriteLine($"{playerInput[0]}, {playerInput[1]} is not within the valid betting range. A valid input looks like:\n3 6 or 36 (Three 6's)");
                                Console.Write("Press ENTER to Continue...");
                                Console.ReadLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine($"{playerInput[0]}, {playerInput[1]} is not a valid input. A valid input looks like:\n3 6 or 36 (Three 6's");
                            Console.Write("Press ENTER to Continue...");
                            Console.ReadLine();
                        }
                    }
                    currentBet[0] = newBet[0];
                    currentBet[1] = newBet[1];
                }
                else
                {
                    return;
                }
            }
        }
    }
}
