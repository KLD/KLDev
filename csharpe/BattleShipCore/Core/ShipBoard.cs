using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipCore
{
    public class ShipBoard
    {
        public int[][] Board { private set; get; }

        public int Width { private set; get; }
        public int Height { private set; get; }

        private List<Ship> Ships;

        public ShipBoard(int width, int hieght)
        {
            Width = width;
            Height = hieght;

            Board = Enumerable.Repeat(Enumerable.Repeat(0, width).ToArray(), hieght).ToArray();
        }

        public bool IsDead()
        {
            for (int i = 0; i < Ships.Count(); i++)
            {
                if(Ships[i].IsAlive())
                {
                    return true; 
                }
            }

            return false; 
        }
        public DamageIndicator RevieveDamage(int x, int y)
        {
            //check of x y is within bounds 

            int id = Board[y][x]; 

            if(id <= 0)
            {
                Board[y][x]--; 
                return DamageIndicator.Miss;
            }

            //find the ship 
            Ship shipToBeHit = Ships[id-1]; 

            //send damage to ship 
           return shipToBeHit.ReceiveDamage(x, y); 
        }

        /// <summary>
        /// Attempts to create and place a ship on board. 
        /// </summary>
        /// <param name="x">origin X</param>
        /// <param name="y">Origin Y</param>
        /// <param name="size">Ship length </param>
        /// <param name="dir">Direction of placement</param>
        /// <returnsTrue if ship is place, overwise false></returns>
        public bool PlaceShip(int x, int y, int size, Direction dir)
        {
            int d = (int)dir;
            int lastOx = x +  (size - 1) * (1 - 2 * d) * (1 - d / 2);
            int lastOy = y + (size - 1) * (d % 2 * 2 - 1) * (d / 2);
          
            //input validation check bounds and ship size
            if ( x < 0 || y < 0 || x >= Width || y >= Height ||
                 lastOx < 0 || lastOy < 0 || lastOx >= Width || lastOy >= Height  ||
                 size < 1)
            {
                return false; 
            }
            
            //check if ship is placeable  
            for (int i = 0; i < size; i++)
            {
                //offset x and y 
                int ox = (1 - 2 * d) * (1 - d / 2);
                int oy = (d % 2 * 2 - 1) * (d / 2);

                if (Board[y + oy * i][x + ox * i] >  0)
                {
                    return false; 
                }
            }

            //create ship instence 
            Ship ship = new Ship(Ships.Count + 1, x, y, size, dir);

            //add ship to list 
            Ships.Add(ship);

            //place ship on board 
            for (int i = 0; i < size; i++)
            {
                //offset x and y 
                int ox = (1 - 2 * d) * (1 - d / 2);
                int oy = (d % 2 * 2 - 1) * (d / 2);


                Board[y + oy*i][x + ox*i] = ship.Id; 
            }

            return true; 
        }

        //TODO cobert ship to Ship Display 
        public Ship[] RemainingShips()
        {
            return Ships.ToArray(); 
        }

        
    }
}
