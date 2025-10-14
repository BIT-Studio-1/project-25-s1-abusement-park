using System.Drawing;
using System.Net;
using System.IO;

namespace MainMap
{
    internal class Program
    {
        static Player? user;
        static char[][]? map;
        static Dictionary<int[], String>? locations;

        public Program() { }

        static void Main(string[] args)
        {
            Console.SetWindowSize(83,35);
            locations = LoadLocations();
            SetupMap();
            DrawMap();
            Nav();
        }


        public static void SetupMap(){
            try
            {
                string filePath = "Map.txt";
                List<char[]> lines = new List<char[]>();

                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                using (StreamReader sr = new StreamReader(fs))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        lines.Add(line.ToCharArray());
                    }
                }
                map = lines.ToArray();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static void DrawMap(){
            for (int i = 0; i < map.Length; i++)
            {
                for (int y = 0; y < map[i].Length; y++)
                {
                    
                    Console.Write(map[i][y]);
                }
                Console.WriteLine();
            }
        }

        public static Dictionary<int[], String> LoadLocations(){
            Dictionary<int[], String> tempDic = new Dictionary<int[], String>();
            tempDic.Add([12,63], "BattleShip");
            tempDic.Add([12,23], "liarsDice");
            tempDic.Add([27,23], "BlackJack");
            tempDic.Add([27,63], "CoinGame");
            tempDic.Add([2,42], "Maze");

            return tempDic;

        }

        public static void Nav(){
            user = new Player(42, 33);
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

                // Only move if next spot is a path (space)
                if ((newY > 0 && newY <= map.Length) && (newX > 0 && newX <= map.GetLength(0)))
                {
                    if (map[newY][newX] == ' ')
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
