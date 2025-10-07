namespace BlackjackSimple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            //user hand, delear hand, card, betting amount
            int card, chip, total = 0, dTotal = 0;
            string turn = "";
            //probably will never go over 21, however as this 
            int[] hand = new int[21];
            int[] dHand = new int[21];
            Console.WriteLine("Welcome to black jack");

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

            //the idea here is that it will loop until the user busts (over 21) or stands (ends turn)
            while (turn != "s" && turn != "S")
            {
                Console.WriteLine("S for Stand");
                turn = Console.ReadLine();
            }

            Console.ReadLine();

        }
    }
}
