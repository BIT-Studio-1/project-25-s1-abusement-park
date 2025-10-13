using System.Globalization;
using System.Net.Security;

namespace Game_Title
{
    public class Blackjack
    {
        public static void BlackJackMain()
        {
            Random rand = new Random();
            String input = "";
            do
            {
                input = "";
                //user hand, dealer hand, card, betting amount, l is the location in the hand, starting at 2
                int card, chip, total = 0, dTotal = 0, loc = 2, dLoc = 2;
                //this is for standing / hitting
                string turn = "";
                //probably will never go over 21, however as this 
                int[] hand = new int[21];
                int[] dHand = new int[21];
                Console.WriteLine("Welcome to black jack\n");

                //accept bet here will do later because

                //setting up hands, user and dealer take turns getting cards
                //ace to king
                card = rand.Next(1, 14);
                hand[0] = card;
                card = rand.Next(1, 14);
                dHand[0] = card;
                card = rand.Next(1, 14);
                hand[1] = card;
                //This is always face down until end of round
                card = rand.Next(1, 14);
                dHand[1] = card;

                //this is the table, since it is small i can just do what i want
                Console.WriteLine($" _______    _______ ");
                Console.WriteLine($"|       |  |       |");
                Console.WriteLine($"|       |  |       |");
                Console.WriteLine($"| {dHand[0]}     |  |       |");
                Console.WriteLine($"|       |  |       |");
                Console.WriteLine($"|_______|  |_______|");

                //Console.WriteLine($"{dHand[0]} (this one is face down :/)");
                Console.WriteLine("Dealer must stand on soft 17 * Blackjack payout 3:2");
                Console.WriteLine($" _______    _______ ");
                Console.WriteLine($"|       |  |       |");
                Console.WriteLine($"|       |  |       |");
                Console.WriteLine($"| {hand[0]}     |  |  {hand[1]}    |");
                Console.WriteLine($"|       |  |       |");
                Console.WriteLine($"|_______|  |_______|");
                //note: can make a place holder card and change the number inside to be whatever is the card in the hand


                //calculate total because if the user gets 21 right off the bat the payout is 3:2
                total = GetCard(total, hand[0]);
                total = GetCard(total, hand[1]);


                if (total == 21)
                {
                    Console.WriteLine("you would get money but i havent implemented it, so for now all you get is this:");
                    Thread.Sleep(1000);
                    Console.WriteLine(":)");
                }

                //the idea here is that it will loop until the user total goes over 21 or stands (ends turn)
                while (turn != "s" && turn != "S" && total! <= 21)
                {
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine($"current card total: {total}");
                    if (total >= 21)
                    {
                        //hopefully this aborts the while loop immediately!
                        break;
                    }

                    //visuals go here!
                    Console.WriteLine("\n\tDealer hand:");
                    Console.WriteLine($" _______    _______ ");
                    Console.WriteLine($"|       |  |       |");
                    Console.WriteLine($"|       |  |       |");
                    Console.WriteLine($"| {dHand[0]}" + "|".PadLeft(7 - dHand[0].ToString().Length) + "  |       |");
                    Console.WriteLine($"|       |  |       |");
                    Console.WriteLine($"|_______|  |_______|");
                    Console.WriteLine("Dealer must stand on soft 17 * Blackjack payout 3:2");

                    Console.WriteLine("\n\tYour hand:");
                    //i am doing this the evil way
                    //if you are wondering what the hell you are looking at basically for loops without the curly brackets only register the line below it, i am evil and exploit that >:)
                    for (int i = 0; i < loc; i++)
                        Console.Write($" _______   ");
                    Console.WriteLine();
                    for (int i = 0; i < loc; i++)
                        Console.Write($"|       |  ");
                    Console.WriteLine();
                    for (int i = 0; i < loc; i++)
                        Console.Write($"|       |  ");
                    Console.WriteLine();
                    for (int i = 0; i < loc; i++)
                        Console.Write($"| {hand[i]}" + "|".PadLeft(7 - hand[i].ToString().Length) + "  ");
                    Console.WriteLine();
                    for (int i = 0; i < loc; i++)
                        Console.Write($"|       |  ");
                    Console.WriteLine();
                    for (int i = 0; i < loc; i++)
                        Console.Write($"|_______|  ");
                    Console.WriteLine();


                    Console.WriteLine("\nS for Stand\nH for Hit");
                    turn = Console.ReadLine();

                    if (turn == "H" || turn == "h")
                    {
                        card = rand.Next(1, 14);
                        Console.WriteLine(card);
                        hand[loc] = card;

                        total = GetCard(total, card);

                        loc++;
                    }
                }

                //now it is the delears turn, they just flip until soft 17 (ace being an 11 if possible) or they go over 21

                dTotal = GetCard(dTotal, dHand[0]);
                dTotal = GetCard(dTotal, dHand[1]);


                //we do not want this to run at 17!
                while (dTotal < 17)
                {
                    //these are the visuals
                    Console.Clear();
                    Console.WriteLine($"current card total: {total}");
                    Console.WriteLine($"current dealer card total: {dTotal}");
                    //dealer hand
                    Console.WriteLine("\n\tDealer hand:");
                    for (int i = 0; i < dLoc; i++)
                        Console.Write($" _______   ");
                    Console.WriteLine();
                    for (int i = 0; i < dLoc; i++)
                        Console.Write($"|       |  ");
                    Console.WriteLine();
                    for (int i = 0; i < dLoc; i++)
                        Console.Write($"|       |  ");
                    Console.WriteLine();
                    for (int i = 0; i < dLoc; i++)
                        Console.Write($"| {dHand[i]}" + "|".PadLeft(7 - dHand[i].ToString().Length) + "  ");
                    Console.WriteLine();
                    for (int i = 0; i < dLoc; i++)
                        Console.Write($"|       |  ");
                    Console.WriteLine();
                    for (int i = 0; i < dLoc; i++)
                        Console.Write($"|_______|  ");
                    Console.WriteLine();

                    Console.WriteLine("Dealer must stand on soft 17 * Blackjack payout 3:2");

                    //user hand
                    Console.WriteLine("\n\tYour hand:");
                    for (int i = 0; i < loc; i++)
                        Console.Write($" _______   ");
                    Console.WriteLine();
                    for (int i = 0; i < loc; i++)
                        Console.Write($"|       |  ");
                    Console.WriteLine();
                    for (int i = 0; i < loc; i++)
                        Console.Write($"|       |  ");
                    Console.WriteLine();
                    for (int i = 0; i < loc; i++)
                        Console.Write($"| {hand[i]}" + "|".PadLeft(7 - hand[i].ToString().Length) + "  ");
                    Console.WriteLine();
                    for (int i = 0; i < loc; i++)
                        Console.Write($"|       |  ");
                    Console.WriteLine();
                    for (int i = 0; i < loc; i++)
                        Console.Write($"|_______|  ");
                    Console.WriteLine();
                    //visual end


                    //get card
                    card = rand.Next(1, 14);
                    //Console.WriteLine(card);
                    dHand[dLoc] = card;
                    dTotal = GetCard(dTotal, card);

                    dLoc++;
                    Thread.Sleep(1000);

                }

                //we need a last visual show BECAUSE the DEALER while loop won't do its thang that one last time unfortunately

                //these are the visuals
                Console.Clear();
                Console.WriteLine($"current card total: {total}");
                Console.WriteLine($"current dealer card total: {dTotal}");
                //dealer hand
                Console.WriteLine("\n\tDealer hand:");
                for (int i = 0; i < dLoc; i++)
                    Console.Write($" _______   ");
                Console.WriteLine();
                for (int i = 0; i < dLoc; i++)
                    Console.Write($"|       |  ");
                Console.WriteLine();
                for (int i = 0; i < dLoc; i++)
                    Console.Write($"|       |  ");
                Console.WriteLine();
                for (int i = 0; i < dLoc; i++)
                    Console.Write($"| {dHand[i]}" + "|".PadLeft(7 - dHand[i].ToString().Length) + "  ");
                Console.WriteLine();
                for (int i = 0; i < dLoc; i++)
                    Console.Write($"|       |  ");
                Console.WriteLine();
                for (int i = 0; i < dLoc; i++)
                    Console.Write($"|_______|  ");
                Console.WriteLine();

                Console.WriteLine("Dealer must stand on soft 17 * Blackjack payout 3:2");

                //user hand
                Console.WriteLine("\n\tYour hand:");
                for (int i = 0; i < loc; i++)
                    Console.Write($" _______   ");
                Console.WriteLine();
                for (int i = 0; i < loc; i++)
                    Console.Write($"|       |  ");
                Console.WriteLine();
                for (int i = 0; i < loc; i++)
                    Console.Write($"|       |  ");
                Console.WriteLine();
                for (int i = 0; i < loc; i++)
                    Console.Write($"| {hand[i]}" + "|".PadLeft(7 - hand[i].ToString().Length) + "  ");
                Console.WriteLine();
                for (int i = 0; i < loc; i++)
                    Console.Write($"|       |  ");
                Console.WriteLine();
                for (int i = 0; i < loc; i++)
                    Console.Write($"|_______|  ");
                Console.WriteLine();
                //visual end

                //win = get money, lose = lose money, tie = you get that money back
                Console.WriteLine();
                if (total <= 21)
                {
                    if (dTotal > 21)
                    {
                        Console.WriteLine("dealer went over 21!");
                        Console.WriteLine("win :)");

                    }
                    else if (total > dTotal)
                    {
                        Console.WriteLine("you are higher than dealer!");
                        Console.WriteLine("win :)");
                    }
                    else if (total < dTotal)
                    {
                        Console.WriteLine("dealer is higher than you...");
                        Console.WriteLine("lose :(");
                    }
                    else
                    {
                        Console.WriteLine("same score.");
                        Console.WriteLine("tie :|");
                    }

                }
                else
                {
                    Console.WriteLine("you went over 21...");
                    Console.WriteLine("lose :(");
                }

                do
                {
                    Console.WriteLine("Do you want to play again? (yes/no)");
                    input = Console.ReadLine();
                } while (input != "yes" && input != "no" && input != "YES" && input != "NO");
            } while (input != "no" && input != "NO");

        }

        /*
         * we get a card and add it onto the total depending on various cases
         * named this because i thought it would be different but its actually just calculating the total!
         * @param total - what we add to
         * @param card - switch case, ie the card with the conditions
         * @return
         */
        public static int GetCard(int total, int card)
        {

            switch (card)
            {
                case 1:
                    //only potential error is that an ace can go back down to a 1, fortunately! we know what cards we have in the hand arrays!!
                    if (total < 11)
                    {
                        total += 11;
                    }
                    else
                    {
                        total += 1;
                    }
                    break;
                case 10:
                case 11:
                case 12:
                case 13:
                    total += 10;
                    break;
                default:
                    total += card;
                    break;
            }
            return total;
        }
    }
    }

