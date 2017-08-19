using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipCore
{
    public class HumanConsoleBattleShipPlayer : BattleShipPlayer
    {
        public HumanConsoleBattleShipPlayer(ShipBoard board) : base(board)
        {
        }

        //TODO get input form use for placing the ship 
        public override DirectedPoint PlaceShip(int[][] myBoard, Ship shipToBePlaced, DirectedPoint? prev = default(DirectedPoint?))
        {
            if (prev != null)
            {
                Console.WriteLine($"Error {prev} is invalid point.");
               
            }

            return new DirectedPoint();//remove me

        }

        public override Point PlayerTurn(int[][] enemyBoard, Point? prev = default(Point?))
        {
            throw new NotImplementedException();
        }
    }
}
