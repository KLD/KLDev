using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipCore
{
    public struct Point
    {
        public int X { private set; get; }
        public int Y { private set; get; }

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y; 
        }
    }
}
