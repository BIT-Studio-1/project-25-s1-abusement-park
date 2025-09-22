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

            // Show The Players Dice
            Console.Clear();
            Console.WriteLine("You rolled:");
            foreach (int dice in playersDice)
            {
                Console.Write(dice + " ");
            }
            Console.WriteLine();
            Console.ReadLine();

            // Betting //
            bool bullshit = false, playerTurn = true;
            int[] currentBet = new int[2];

            Console.WriteLine("The current bet is: [Number of dice] [Value of dice]");
            Console.WriteLine($"{currentBet[0]}{currentBet[0]}");

            while (bullshit != true)
            {
                if (playerTurn)
                {
                    int[] newBet = new int[2];
                    while (newBet[0] == 0 || newBet[1] == 0)
                    {
                        Console.WriteLine("What is your bet? [Number of dice] [Value of dice]");
                        Console.Write("> ");
                        string playerInput = Console.ReadLine();

                    }
                }
                else
                {

                }
            }
        }
    }
}
