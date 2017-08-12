using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipCore
{
    public class BattleShipGameController
    {
        public BattleShipPlayer[] Players;

        /**
         * Events 
         */ 

        public BattleShipGameController(params BattleShipPlayer[] players)
        {
            Players = players; 
        }

        public DamageIndicator LaunchAttack(int playerAttacker, int playerAttacked, Point p)
        {
            return Players[playerAttacked].ShipBoard.RevieveDamage(p.X, p.Y); 
        }

        public bool PlaceShip(int player, DirectedPoint dp, int size)
        {
           return  Players[player].ShipBoard.PlaceShip(dp.X, dp.Y, size, dp.Dir); 
        }


    }
}
