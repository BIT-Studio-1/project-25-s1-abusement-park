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
            Console.WriteLine("Welcome to black jack");

            //accept bet here will do later because

            //setting up hands, user and dealer take turns getting cards
            //ace to king
            card = rand.Next(1, 14);
            Console.WriteLine(card);
            hand[1] = card;
            card = rand.Next(1, 14);
            Console.WriteLine(card);
            dHand[1] = card;
            card = rand.Next(1, 14);
            Console.WriteLine(card);
            hand[2] = card;
            //This is always face down until end of round
            card = rand.Next(1, 14);
            Console.WriteLine("Card face down");
            dHand[2] = card;

            //calculate total because if the user gets 21 right off the bat the payout is 3:2
            //nothing fancy, we know these two cards regardless
            total = hand[1] + hand[2];

            //the idea here is that it will loop until the user total goes over 21 or stands (ends turn)
            while (turn != "s" && turn != "S" && total !>= 21)
            {
                Console.WriteLine("S for Stand\nH for Hit");
                turn = Console.ReadLine();
                if (turn == "H")
                {
                    card = rand.Next(1,14);
                    Console.WriteLine(card);
                    hand[l + 2] = card;
                }
            }

            Console.ReadLine();

        }
    }
}
