using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    public class Player{

        public int x { get; set; }
        public int y { get; set; }

        public Player(int[] mazeStart)
        {
            x = mazeStart[0];
            y = mazeStart[1];
        }
        public Player(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
