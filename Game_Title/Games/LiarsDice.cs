namespace Game_Title
{
    public class LiarsDiceGame
    {
        static void PrintDice(int[] playersDice)
        {
            string[] dice1 =  { "   ████████████████████      ", "   ████████████████████      ", "   █████████████████████      ", "  ██████████████████████     ", "  ██████████████████████     ", "  ███████████████████████     "};
            string[] dice2 =  { " ██                    ██    ", " ██                    ██    ", " ██                     ██    ", " █                      █    ", " █                      █    ", " █     ██         ██    ██    "};
            string[] dice3 =  { "█                        █   ", "█                        █   ", "█    ██                   █   ", "█  █████          █████  █   ", "█  █████          █████  █   ", "█    ██████     ██████    █   "};
            string[] dice4 =  { "█                        █   ", "█    ████                █   ", "█  ██████                 █   ", "█ ██████          ██████ █   ", "█ ██████          ██████ █   ", "█    ██████     ██████    █   "};
            string[] dice5 =  { "█                        █   ", "█   ██████               █   ", "█  ██████                 █   ", "█  ████            ████  █   ", "█  █████          █████  █   ", "█      ██         ██      █   "};
            string[] dice6 =  { "█                        █   ", "█    ████                █   ", "█    ██                   █   ", "█                        █   ", "█                        █   ", "█                         █   "};
            string[] dice7 =  { "█           ██           █   ", "█                        █   ", "█           ██            █   ", "█                        █   ", "█          ████          █   ", "█     ████       ████     █   "};
            string[] dice8 =  { "█         ██████         █   ", "█                        █   ", "█         ██████          █   ", "█                        █   ", "█         ██████         █   ", "█    ██████     ██████    █   "};
            string[] dice9 =  { "█         ██████         █   ", "█                        █   ", "█         ██████          █   ", "█                        █   ", "█         ██████         █   ", "█    ██████     ██████    █   "};
            string[] dice10 = { "█           ██           █   ", "█                        █   ", "█           ██            █   ", "█                        █   ", "█          ████          █   ", "█     ████       ████     █   "};
            string[] dice11 = { "█                        █   ", "█                 ████   █   ", "█                   ██    █   ", "█                        █   ", "█                        █   ", "█                         █   "};
            string[] dice12 = { "█                        █   ", "█                ██████  █   ", "█                 ██████  █   ", "█  ████            ████  █   ", "█  █████          █████  █   ", "█      ██         ██      █   "};
            string[] dice13 = { "█                        █   ", "█                 ████   █   ", "█                 ██████  █   ", "█ ██████          ██████ █   ", "█ ██████          ██████ █   ", "█    ██████     ██████    █   "};
            string[] dice14 = { "█                        █   ", "█                        █   ", "█                   ██    █   ", "█  █████          █████  █   ", "█  █████          █████  █   ", "█    ██████     ██████    █   "};
            string[] dice15 = { " ██                    ██    ", " ██                    ██    ", " ██                     ██    ", " █                      █    ", " █                      █    ", " █     ██         ██     █    "};
            string[] dice16 = { "   ████████████████████      ", "   ████████████████████      ", "   █████████████████████      ", "  ██████████████████████     ", "  ██████████████████████     ", "  ███████████████████████     "};

            foreach (int dice in playersDice)
            {
                Console.Write(dice1[dice - 1]);
            }
            Console.WriteLine();
            foreach (int dice in playersDice)
            {
                Console.Write(dice2[dice - 1]);
            }
            Console.WriteLine();
            foreach (int dice in playersDice)
            {
                Console.Write(dice3[dice - 1]);
            }
            Console.WriteLine();
            foreach (int dice in playersDice)
            {
                Console.Write(dice4[dice - 1]);
            }
            Console.WriteLine();
            foreach (int dice in playersDice)
            {
                Console.Write(dice5[dice - 1]);
            }
            Console.WriteLine();
            foreach (int dice in playersDice)
            {
                Console.Write(dice6[dice - 1]);
            }
            Console.WriteLine();
            foreach (int dice in playersDice)
            {
                Console.Write(dice7[dice - 1]);
            }
            Console.WriteLine();
            foreach (int dice in playersDice)
            {
                Console.Write(dice8[dice - 1]);
            }
            Console.WriteLine();
            foreach (int dice in playersDice)
            {
                Console.Write(dice9[dice - 1]);
            }
            Console.WriteLine();
            foreach (int dice in playersDice)
            {
                Console.Write(dice10[dice - 1]);
            }
            Console.WriteLine();
            foreach (int dice in playersDice)
            {
                Console.Write(dice11[dice - 1]);
            }
            Console.WriteLine();
            foreach (int dice in playersDice)
            {
                Console.Write(dice12[dice - 1]);
            }
            Console.WriteLine();
            foreach (int dice in playersDice)
            {
                Console.Write(dice13[dice - 1]);
            }
            Console.WriteLine();
            foreach (int dice in playersDice)
            {
                Console.Write(dice14[dice - 1]);
            }
            Console.WriteLine();
            foreach (int dice in playersDice)
            {
                Console.Write(dice15[dice - 1]);
            }
            Console.WriteLine();
            foreach (int dice in playersDice)
            {
                Console.Write(dice16[dice - 1]);
            }
            Console.WriteLine();
        }

        public static void LiarsDiceMain()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Sets the dice constants //
            const int DICECOUNT = 5, PLAYERS = 2, TOTALDICE = DICECOUNT * PLAYERS, DICEFACECOUNT = 6;
            string calledBullshit = "";

            // Welcome Message //
            Console.WriteLine("Welcome to Liars Dice!");
            Console.WriteLine($"""
                Each player has {DICECOUNT} dice. Players roll the dice which are hidden from each other and then take
                turns making bids about the quantity of a specific die face present among all the dice on the table.

                Lowest Bid: 1, 1
                Highest Bid: {TOTALDICE}, {DICEFACECOUNT}

                The order of higher bids goes the number or dices then the number on the dice. So a bid of 3, 1
                would be higher then 2, 6. Players can only make higher bids then the last.

                Bidding continues until a player challenges a bid. When a challenge is made,
                everyone reveals their dice, and the players check if the bid was true or not.
                
                If the quantity of the bid is there then the bidding player wins, if not then the challenger wins.

                Press Enter to begin...
                """);

            // User input
            Console.Write("> ");
            Console.ReadLine();

            // Players Roll //
            int[] playersDice = new int[DICECOUNT];
            int[] computerDice = new int[DICECOUNT];
            Random random = new Random();

            // Player
            for (int i = 0; i < DICECOUNT; i++)
            {
                playersDice[i] = random.Next(1,(DICEFACECOUNT + 1));
            }

            // Computer
            for (int i = 0;i < DICECOUNT; i++)
            {
                computerDice[i] = random.Next(1, (DICEFACECOUNT + 1));
            }

            // Prompt to "roll"
            Console.Clear();
            Console.WriteLine("Press ENTER to roll...");
            Console.Write("> ");
            Console.ReadLine();

            // Betting //
            bool bullshit = false, playerTurn = true, firstTurn = true;
            int[] currentBet = new int[2];

            while (bullshit != true)
            { 
                if (playerTurn)
                {
                    // Player betting //
                    int[] newBet = new int[2];
                    while ((newBet[0] == 0 || newBet[1] == 0) && bullshit == false)
                    {
                        // Show The Players Dice
                        Console.Clear();
                        PrintDice(playersDice);
                        Console.WriteLine("\n");
                        Console.WriteLine("The current bet is: [Number of dice] [Value of dice]");
                        Console.WriteLine($"{currentBet[0]}, {currentBet[1]}");
                        Console.WriteLine("What is your bet? [Number of dice] [Value of dice] or call 'bullshit'");
                        Console.Write("> ");
                        string playerInput = Console.ReadLine();

                        // Strips the user input
                        playerInput = playerInput.Replace(" ", string.Empty).Replace(",", string.Empty);

                        // Check if input is valid
                        if (int.TryParse(playerInput, out int result) && ((playerInput.Length == 2) || (playerInput.Length == 3)))
                        {
                            // Splits the user input into its own variables
                            int numberOf = 0, valueOf = 0;
                            if (playerInput.Length == 2)
                            {
                                numberOf = Int32.Parse(playerInput[0].ToString());
                                valueOf = Int32.Parse(playerInput[1].ToString());
                            }
                            else
                            {
                                numberOf = Int32.Parse(playerInput[0].ToString()) * 10 + Int32.Parse(playerInput[1].ToString());
                                valueOf = Int32.Parse(playerInput[2].ToString());
                            }

                            // Checks if the user input is within the betting boundaries
                            if (numberOf > currentBet[0] && numberOf <= TOTALDICE)
                            {
                                if (valueOf > 0 && valueOf <= DICEFACECOUNT)
                                {
                                    newBet[0] = numberOf;
                                    newBet[1] = valueOf;
                                }
                                else
                                {
                                    Console.WriteLine($"{numberOf}, {valueOf} is not within the valid betting range. A valid input looks like:\n3 6 or 36 (Three 6's)\nThe highest bet is 10, 6!");
                                    Console.Write("Press ENTER to Continue...");
                                    Console.ReadLine();
                                }
                            }
                            else if (numberOf == currentBet[0] && numberOf > 0)
                            {
                                if (valueOf > currentBet[1] && valueOf <= DICEFACECOUNT)
                                {
                                    newBet[0] = numberOf;
                                    newBet[1] = valueOf;
                                }
                                else
                                {
                                    Console.WriteLine($"{numberOf}, {valueOf} is not within the valid betting range. A valid input looks like:\n3 6 or 36 (Three 6's)\nThe highest bet is 10, 6!");
                                    Console.Write("Press ENTER to Continue...");
                                    Console.ReadLine();
                                }
                            }
                            else
                            {
                                Console.WriteLine($"{numberOf}, {valueOf} is not within the valid betting range. A valid input looks like:\n3 6 or 36 (Three 6's)\nThe highest bet is 10, 6!");
                                Console.Write("Press ENTER to Continue...");
                                Console.ReadLine();
                            }
                        }
                        else
                        {
                            // Checks if the player called bullshit
                            if (playerInput.ToLower() == "bullshit")
                            {
                                if (firstTurn == true)
                                {
                                    Console.WriteLine("You can't call bullshit on the first turn!");
                                    Console.Write("Press ENTER to Continue...");
                                    Console.ReadLine();
                                }
                                else
                                {
                                    bullshit = true;
                                    calledBullshit = "player";
                                } 
                            }
                            // User feed back for not a valid option
                            else
                            {
                                Console.WriteLine($"That was not a valid input. A valid input looks like:\n3 6 or 36 (Three 6's)\nThe highest bet is 10, 6!");
                                Console.Write("Press ENTER to Continue...");
                                Console.ReadLine();
                            }
                        }
                    }

                    // Sets the bet
                    if (bullshit == false)
                    {
                        currentBet[0] = newBet[0];
                        currentBet[1] = newBet[1];
                        playerTurn = false;
                    }
                    firstTurn = false;
                }
                else
                {
                    // Computer Betting //
                    int[] newBet = new int[2];
                    Console.Clear();
                    Console.WriteLine("The current bet is: [Number of dice] [Value of dice]");
                    Console.WriteLine($"{currentBet[0]}, {currentBet[1]}");
                    Console.Write("\nThe computer is thinking");
                    for (int i=0;i<3;i++)
                    {
                        Console.Write(".");
                        Thread.Sleep(1000);
                    }
                    
                    // Generates a random chance for the computer to call bullshit
                    int bullshitChance = random.Next(15);
                    switch (bullshitChance)
                    {
                        case 0:
                            // Calls bullshit
                            bullshit = true;
                            calledBullshit = "computer";
                            Console.WriteLine("\n\nI call BULLSHIT!");
                            Console.WriteLine("\nPress ENTER to continue...");
                            Console.ReadLine();
                            break;
                        default:
                            // Makes a bet of same count
                            if (currentBet[1] < DICEFACECOUNT)
                            {
                                newBet[0] = currentBet[0];
                                newBet[1] = random.Next((currentBet[1] + 1), (DICEFACECOUNT + 1));
                            }
                            else
                            {
                                // Makes a bet of higher count or forces bullshit
                                if (currentBet[0] == TOTALDICE)
                                {
                                    bullshit = true;
                                    calledBullshit = "computer";
                                    Console.WriteLine("I call BULLSHIT!");
                                    Console.WriteLine("\nPress ENTER to continue...");
                                    Console.ReadLine();
                                }
                                else
                                {
                                    newBet[0] = currentBet[0] + 1;
                                    newBet[1] = random.Next(1, (DICEFACECOUNT + 1));
                                }
                            }
                            break;
                    }

                    // Sets the bet
                    if (bullshit == false)
                    {
                        currentBet[0] = newBet[0];
                        currentBet[1] = newBet[1];
                        playerTurn = true;
                    }
                }
            }

            // Counts the total of dice in every hand //
            int ones = 0, twos = 0, threes = 0, fours = 0, fives = 0, sixes = 0;
            foreach (int diceValue in playersDice)
            {
                switch (diceValue)
                {
                    case 1:
                        ones++;
                        break;
                    case 2:
                        twos++;
                        break;
                    case 3:
                        threes++;
                        break;
                    case 4:
                        fours++;
                        break;
                    case 5:
                        fives++;
                        break;
                    case 6:
                        sixes++;
                        break;
                }
            }

            foreach (int diceValue in computerDice)
            {
                switch (diceValue)
                {
                    case 1:
                        ones++;
                        break;
                    case 2:
                        twos++;
                        break;
                    case 3:
                        threes++;
                        break;
                    case 4:
                        fours++;
                        break;
                    case 5:
                        fives++;
                        break;
                    case 6:
                        sixes++;
                        break;
                }
            }

            Console.Clear();
            Console.Write("Calculating Outcome");
            for (int i = 0; i < 3; i++)
            {
                Console.Write(".");
                Thread.Sleep(2000);
            }

            // Checks if the bet is correct
            bool bullshitCorrect = false;
            switch (currentBet[1]) 
            {
                case 1:
                    if (currentBet[0] >= ones)
                    {
                        bullshitCorrect = true;
                    }
                    break;
                case 2:
                    if (currentBet[0] >= twos)
                    {
                        bullshitCorrect = true;
                    }
                    break;
                case 3:
                    if (currentBet[0] >= threes)
                    {
                        bullshitCorrect = true;
                    }
                    break;
                case 4:
                    if (currentBet[0] >= fours)
                    {
                        bullshitCorrect = true;
                    }
                    break;
                case 5:
                    if (currentBet[0] >= fives)
                    {
                        bullshitCorrect = true;
                    }
                    break;
                case 6:
                    if (currentBet[0] >= sixes)
                    {
                        bullshitCorrect = true;
                    }
                    break;
            }

            Console.WriteLine("\n\n--- Total Dice Counts ---");
            Console.WriteLine($"Ones: {ones}\nTwos: {twos}\nThrees: {threes}\nFours: {fours}\nFives: {fives}\nSixes: {sixes}");

            // Tells who won //
            if (bullshitCorrect)
            {
                Console.WriteLine($"\nThe {calledBullshit} Won!");
                Console.WriteLine($"There wasn't {currentBet[0]}, {currentBet[1]}'s...");
            }
            else
            {
                Console.WriteLine($"\nThe {calledBullshit} Lost!");
                Console.WriteLine($"There was {currentBet[0]}, {currentBet[1]}'s!");
            }

            Console.WriteLine("Press ENTER to exit the game...");
            Console.ReadLine();
        }
    }
}
