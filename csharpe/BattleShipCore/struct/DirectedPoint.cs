using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;

namespace BattleShipCore
{
    public struct DirectedPoint
    {
        public int X { private set; get; }
        public int Y { private set; get; }
        public Direction Dir { private set; get; }

        public DirectedPoint(int x, int y, Direction d)
        {
            X = x;
            Y = y;
            Dir = d;
        }
    }
}
