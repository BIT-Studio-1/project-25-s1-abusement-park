using System;
using System.Globalization;
using System.Net.Security;

namespace Game_Title
{
    public class Blackjack
    {
        public static void BlackJackMain()
        {
            Random rand = new Random();
            //this is the play again input
            String input = "";
            //temporary money holder - not linked up to global ticket count so for now this is just playing money given by your grandma
            double wallet = 100;

            string start = "";
            do
            {
                Console.Clear();
                Console.WriteLine("Welcome to black jack!!\n");
                Console.WriteLine("[P]lay the game");
                Console.WriteLine("Check the [R]ules");
                Console.WriteLine("[E]xit");
                start = Console.ReadLine();
                if (start == "R" || start == "r")
                {
                    Console.WriteLine("\nThis game is you vs the house. The goal is to win tickets by creating a card total higher\nthan the dealers but not exceeding 21, or by getting a total in the hope that the dealer busts (over 21)");
                    Console.WriteLine("\nNumber cards are the value of their number. Jack, Queen, and King are all valued at 10.\nThe ace can be a 1 or 11, depending on whether the total would be a bust (over 21)");
                    Console.WriteLine("\nThe dealer cannot hit on a soft 17. Blackjack payout is 3:2. Winning payout is 2:1");
                    Console.WriteLine("\nPress any button to continue.");
                    Console.ReadLine();
                }
            } while (start != "P" && start != "p" && start != "E" && start != "e");

            if (start == "P" || start == "p")
            {
                //this is the game!
                do
                {
                    input = "";

                    //user hand, dealer hand, card, betting amount, l is the location in the hand, starting at 0
                    int card, total = 0, dTotal = 0, loc = 0, dLoc = 0;
                    double chip = 0;
                    //turn is for standing / hitting
                    string turn = "";
                    //probably will never go over 21, since this is based on random cards its possible for 21 ones to appear in a hand
                    int[] hand = new int[21];
                    int[] dHand = new int[21];


                    //accept bet here will do later because
                    do
                    {
                        Console.Clear();
                        Console.WriteLine($"How many chips are you betting? You have {wallet} tickets. Lowest bid is one ticket.");
                        chip = Convert.ToDouble(Console.ReadLine());
                        if (chip > wallet)
                        {
                            Console.WriteLine("You're not that rich, buddy.");
                            Console.WriteLine("\nPress any button to continue.");
                            Console.ReadLine();
                        }
                    } while (chip <= 0 || chip > wallet);


                    //setting up hands, user and dealer take turns getting cards
                    //ace to king
                    card = rand.Next(1, 14);
                    hand[0] = card;
                    card = rand.Next(1, 14);
                    dHand[0] = card;
                    card = rand.Next(1, 14);
                    hand[1] = card;
                    //This is always face down until end of round, when the dealer reveals their cards
                    card = rand.Next(1, 14);
                    dHand[1] = card;


                    //calculate total because if the user gets 21 right off the bat the payout is 3:2
                    total = GetCard(total, hand[0], hand, loc, false);
                    loc++;
                    total = GetCard(total, hand[1], hand, loc, false);
                    loc++;

                    String dCard = dHand[0].ToString();
                    switch (dCard)
                    {
                        case "14":
                        case "1":
                            dCard = "A";
                            break;
                        case "11":
                            dCard = "J";
                            break;
                        case "12":
                            dCard = "Q";
                            break;
                        case "13":
                            dCard = "K";
                            break;
                        default:
                            break;
                    }

                    //visuals go here!
                    //this is here because you want to see what you have when you get blackjack (21) right of the bat!
                    //this is the only special hand visual: one card must be face down! (being second card)
                    Console.WriteLine("\n\tDealer hand:");
                    Console.WriteLine($" _______    _______ ");
                    Console.WriteLine($"|       |  |       |");
                    Console.WriteLine($"|       |  |       |");
                    Console.WriteLine($"| {dCard}" + "|".PadLeft(7 - dCard.Length) + "  |       |");
                    Console.WriteLine($"|       |  |       |");
                    Console.WriteLine($"|_______|  |_______|");
                    Console.WriteLine("Dealer must stand on soft 17 * Blackjack payout 3:2");

                    Console.WriteLine("\n\tYour hand:");

                    BJVisuals(hand, loc);


                    if (total < 21)
                    {
                        //the idea here is that it will loop until the user total goes over 21 or stands (ends turn)
                        while (turn != "s" && turn != "S" && total! <= 21)
                        {
                            Console.Clear();
                            Console.WriteLine();
                            Console.WriteLine($"Your bid amount: {chip}");
                            Console.WriteLine($"Current card total: {total}");
                            if (total >= 21)
                            {
                                //hopefully this aborts the while loop immediately!
                                break;
                            }

                            //because this hand for the dealer is specical i gotta do it here i know its redundant but i just gotta. im sorry. jk. deal with it.
                            dCard = dHand[0].ToString();
                            switch (dCard)
                            {
                                case "14":
                                case "1":
                                    dCard = "A";
                                    break;
                                case "11":
                                    dCard = "J";
                                    break;
                                case "12":
                                    dCard = "Q";
                                    break;
                                case "13":
                                    dCard = "K";
                                    break;
                                default:
                                    break;
                            }

                            //visuals go here!
                            //this is the only special hand visual: one card must be face down! (being second card)
                            Console.WriteLine("\n\tDealer hand:");
                            Console.WriteLine($" _______    _______ ");
                            Console.WriteLine($"|       |  |       |");
                            Console.WriteLine($"|       |  |       |");
                            Console.WriteLine($"| {dCard}" + "|".PadLeft(7 - dCard.Length) + "  |       |");
                            Console.WriteLine($"|       |  |       |");
                            Console.WriteLine($"|_______|  |_______|");
                            Console.WriteLine("Dealer must stand on soft 17 * Blackjack payout 3:2");

                            Console.WriteLine("\n\tYour hand:");

                            BJVisuals(hand, loc);

                            Console.WriteLine("\nS for Stand\nH for Hit");
                            turn = Console.ReadLine();

                            if (turn == "H" || turn == "h")
                            {
                                card = rand.Next(1, 14);
                                Console.WriteLine(card);
                                hand[loc] = card;

                                total = GetCard(total, card, hand, loc, false);

                                loc++;
                            }
                        }

                        //now it is the delears turn, they just flip until soft 17 (ace being an 11 if possible) or they go over 21

                        dTotal = GetCard(dTotal, dHand[0], dHand, dLoc, true);
                        dLoc++;
                        dTotal = GetCard(dTotal, dHand[1], dHand, dLoc, true);
                        dLoc++;

                        //we do not want this to run at 17!
                        while (dTotal < 17)
                        {
                            //these are the visuals
                            Console.Clear();
                            Console.WriteLine($"current card total: {total}");
                            Console.WriteLine($"current dealer card total: {dTotal}");
                            //dealer hand
                            Console.WriteLine("\n\tDealer hand:");
                            BJVisuals(dHand, dLoc);

                            Console.WriteLine("Dealer must stand on soft 17 * Blackjack payout 3:2");

                            //user hand
                            Console.WriteLine("\n\tYour hand:");
                            BJVisuals(hand, loc);

                            Console.WriteLine();
                            //visual end


                            //get card
                            card = rand.Next(1, 14);
                            //Console.WriteLine(card);
                            dHand[dLoc] = card;
                            dTotal = GetCard(dTotal, card, dHand, dLoc, true);

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
                        BJVisuals(dHand, dLoc);

                        Console.WriteLine("Dealer must stand on soft 17 * Blackjack payout 3:2");

                        //user hand
                        Console.WriteLine("\n\tYour hand:");
                        BJVisuals(hand, loc);

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
                                wallet += chip;

                            }
                            else if (total > dTotal)
                            {
                                Console.WriteLine("you are higher than dealer!");
                                Console.WriteLine("win :)");
                                wallet += chip;
                            }
                            else if (total < dTotal)
                            {
                                Console.WriteLine("dealer is higher than you...");
                                Console.WriteLine("lose :(");
                                wallet -= chip;
                            }
                            else
                            {
                                Console.WriteLine("same score.");
                                Console.WriteLine("tie :|");
                                //no change to wallet
                            }

                        }
                        else
                        {
                            Console.WriteLine("you went over 21...");
                            Console.WriteLine("lose :(");
                            wallet -= chip;
                        }
                    }
                    else
                    {
                        Console.WriteLine("You got blackjack!");
                        Console.WriteLine("You win!");
                        //the payout is 3:2
                        wallet += (chip / 2);
                    }


                        do
                        {
                            Console.WriteLine("Do you want to play again? (yes/no)");
                            input = Console.ReadLine();
                        } while (input != "yes" && input != "no" && input != "YES" && input != "NO");
                    } while (input != "no" && input != "NO") ;
                
            }
        }

        /*
         * these are the visuals, moved to a method to clear space. the visual of a suit depends on 
         */
        public static void BJVisuals(int[] hand, int loc)
        {
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
            {
                String card = hand[i].ToString();
                switch (card)
                {
                    case "14":
                    case "1":
                        card = "A";
                        break;
                    case "11":
                        card = "J";
                        break;
                    case "12":
                        card = "Q";
                        break;
                    case "13":
                        card = "K";
                        break;
                    default:
                        break;
                }
                Console.Write($"| {card}" + "|".PadLeft(7 - card.Length) + "  ");
            }
            Console.WriteLine();

            for (int i = 0; i < loc; i++)
                Console.Write($"|       |  ");
            Console.WriteLine();
            for (int i = 0; i < loc; i++)
                Console.Write($"|_______|  ");
            Console.WriteLine();
        }


        /*
         * we get a card and add it onto the total depending on various cases
         * named this because i thought it would be different but its actually just calculating the total!
         * @param total - what we add to
         * @param card - switch case, ie the card with the conditions
         * @param hand - we need this for the ace conditions, changing the ace to allows for some stuff
         * @param loc - the location, helps find where the ace we are changing is
         * @param dealer - we do not want the dealer to change their total if they have an ace
         * @return
         */
        public static int GetCard(int total, int card, int[] hand, int loc, bool dealer)
        {

            switch (card)
            {
                case 1:
                    //only potential error is that an ace can go back down to a 1, fortunately! we know what cards we have in the hand arrays!!
                    if (total < 11)
                    {
                        total += 11;
                        hand[loc] = 14;
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
                    //we will have an ace check here - this is in case you get a 10 and have two aces, you will have 12 instead of 22 (player only)
                    if (dealer == false)
                    {
                        if (total > 21)
                        {
                            //check all values in the hand
                            for (int i = 0; i < hand.Length; i++)
                            {
                                //if one is ace (value 11) it gets turned to ace (value 1)
                                if (hand[i] == 14)
                                {
                                    hand[i] = 1;
                                    total -= 10;
                                }
                            }
                        }
                    }
                    break;
                default:
                    total += card;
                    //we will have an ace check here - this is in case you get a 10 and have two aces, you will have 12 instead of 22 (player only)
                    if (dealer == false)
                    {
                        if (total > 21)
                        {
                            //check all values in the hand
                            for (int i = 0; i < hand.Length; i++)
                            {
                                //if one is ace (value 11) it gets turned to ace (value 1)
                                if (hand[i] == 14)
                                {
                                    hand[i] = 1;
                                    total -= 10;
                                }
                            }
                        }
                    }
                    break;
            }
            return total;
        }
    }
}

