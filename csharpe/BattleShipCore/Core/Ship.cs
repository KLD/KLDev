using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipCore
{
    public class Ship
    {
        public int Id { private set; get; }

        /// <summary>
        /// True means is alive, false hit
        /// </summary>
        public bool[] HealthPoint { private set; get; }

        public int X { private set; get; }
        public int Y { private set; get; }

        public Direction Dir { private set; get; }

        public Ship(int id, int x, int y, int size, Direction dir)
        {
            Id = id;
            X = x;
            Y = y;
            Dir = dir;

            HealthPoint = Enumerable.Repeat(true, size).ToArray(); 
        }

        public bool IsAlive()
        {
            for (int i = 0; i < HealthPoint.Length; i++)
            {
                if(HealthPoint[i])
                {
                    return true; 
                }
            }

            return false; 
        }
        public int Size()
        {
            return HealthPoint.Length; 
        }

        public DamageIndicator ReceiveDamage(int x, int y) //TODO 
        {
           int i = Math.Abs((X - x) + (Y - y));

           DamageIndicator dmg = HealthPoint[i] ? DamageIndicator.Hit : DamageIndicator.Miss; 
            
           HealthPoint[i] = false; 

           return IsAlive()? dmg : DamageIndicator.Destroy; 
        }
    }
}
