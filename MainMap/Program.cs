using System.Drawing;
using System.Net;

namespace MainMap
{
    internal class Program
    {
        Player? user;
        int[,]? map;
        Dictionary<int[], String> locations;

        public void Nav(){
            user = new Player(0, 0);
            do
            {
                ConsoleKey key = Console.ReadKey(true).Key;
                int newX = user.x, newY = user.y;

                switch (key)
                {
                    case ConsoleKey.W: newY--; break;
                    case ConsoleKey.S: newY++; break;
                    case ConsoleKey.A: newX--; break;
                    case ConsoleKey.D: newX++; break;
                }

                // Only move if next spot is a path (0)
                if ((newY > 0 && newY <= map.Length) && (newX > 0 && newX <= map.GetLength(0)))
                {
                    if (map[newY, newX] == 0)
                    {
                        // Erase old position
                        Console.SetCursorPosition((user.x * 2), user.y);
                        Console.Write("  ");

                        // Draw new position
                        user.x = newX;
                        user.y = newY;
                        Console.SetCursorPosition((user.x * 2), user.y);
                        Console.Write("@@");
                    }
                }
            }
            while (!locations.ContainsKey((user.GetCoords())));

            //figure out location and load it, then run nav again once game has been finished playing

        }
    }
}
