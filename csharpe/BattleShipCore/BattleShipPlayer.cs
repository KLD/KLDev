using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipCore
{
    public abstract class BattleShipPlayer
    {
        public ShipBoard ShipBoard;

        public BattleShipPlayer(ShipBoard board)
        {
            ShipBoard = board; 
        }  

        public abstract DirectedPoint PlaceShip(int[][] myBoard, Ship shipToBePlaced, DirectedPoint? prev = null);

        public abstract Point PlayerTurn(int[][] enemyBoard, Point? prev = null);
    }
}
