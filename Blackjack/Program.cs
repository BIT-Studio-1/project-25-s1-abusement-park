namespace BlackjackSimple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            //user hand, dealer hand, card, betting amount
            int card, chip, total = 0, dTotal = 0, l = 2;
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
            Console.WriteLine($"{dHand[0]} (this one is face down :/)");
            Console.WriteLine("Dealer must stand on soft 17 * Blackjack payout 3:2");
            Console.WriteLine($"{hand[0]} {hand[1]}");
            //note: can make a place holder card and change the number inside to be whatever is the card in the hand


            //calculate total because if the user gets 21 right off the bat the payout is 3:2
            switch (hand[0])
            {
                case 10:
                case 11:
                case 12:
                case 13:
                    total += 10;
                    break;
                default:
                    total += hand[0];
                    break;
            }

            switch (hand[1])
            {
                case 10:
                case 11:
                case 12:
                case 13:
                    total += 10;
                    break;
                default:
                    total += hand[1];
                    break;
            }


            //total = hand[1] + hand[2];

            if (total == 21)
            {
                Console.WriteLine("you would get money but i havent implemented it, so for now all you get is this:");
                Thread.Sleep(1000);
                Console.WriteLine(":)");
            }

            //the idea here is that it will loop until the user total goes over 21 or stands (ends turn)
            while (turn != "s" && turn != "S" && total !<= 21)
            {
                Console.WriteLine();
                Console.WriteLine(total);
                if (total >= 21)
                {
                    //hopefully this aborts the while loop immediately!
                    break;
                }
                    
                for(int i = 0; i < l; i++)
                {
                    Console.Write($"{hand[i]} ");
                }
                Console.WriteLine();
                Console.WriteLine("S for Stand\nH for Hit");
                turn = Console.ReadLine();
                if (turn == "H")
                {
                    card = rand.Next(1,14);
                    Console.WriteLine(card);
                    hand[l] = card;
                    //have not considered ace here because of reasons i cannot say (im lazy)
                    switch (card)
                    {
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
                    
                    

                    l++;
                }
            }

            //now it is the delears turn, they just flip until soft 17 (ace being an 11 if possible) or they go over 21

            switch (dHand[0])
            {
                case 10:
                case 11:
                case 12:
                case 13:
                    dTotal += 10;
                    break;
                default:
                    dTotal += dHand[0];
                    break;
            }

            switch (dHand[1])
            {
                case 10:
                case 11:
                case 12:
                case 13:
                    dTotal += 10;
                    break;
                default:
                    dTotal += dHand[1];
                    break;
            }

            while (dTotal <= 17)
            {
                
                card = rand.Next(1, 14);
                Console.WriteLine(card);
                switch (card)
                {
                    case 10:
                    case 11:
                    case 12:
                    case 13:
                        dTotal += 10;
                        break;
                    default:
                        dTotal += card;
                        break;
                }
            }

            //win = get money, lose = lose money, tie = you get that money back
            


            Console.ReadLine();

        }
    }
}
