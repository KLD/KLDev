using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipCore
{
    /// <summary>
    /// Represent a ship placed in a battleship game, that can recieve attacks, and get destroyed. 
    /// </summary>
    public class Ship
    {
        #region Properties
        /// <summary>
        /// Unique ship Id per player 
        /// </summary>
        public int Id { private set; get; }

        /// <summary>
        /// True means is alive, false hit.
        /// </summary>
        public bool[] HealthPoint { private set; get; }

        /// <summary>
        /// X coordenate.
        /// </summary>
        public int X { private set; get; }

        /// <summary>
        /// Y coordenate.
        /// </summary>
        public int Y { private set; get; }

        /// <summary>
        /// Ship direction on map.
        /// </summary>
        public Direction Dir { private set; get; }
        #endregion
        #region Constructors
        /// <summary>
        /// Creates a ship. 
        /// </summary>
        /// <param name="id">Ship id.</param>
        /// <param name="x">x origin coordenate.</param>
        /// <param name="y">y origin coordenate.</param>
        /// <param name="size">ship size.</param>
        /// <param name="dir">placement direction</param>
        public Ship(int id, int x, int y, int size, Direction dir)
        {
            Id = id;
            X = x;
            Y = y;
            Dir = dir;

            HealthPoint = Enumerable.Repeat(true, size).ToArray(); 
        }
        #endregion
        #region Methods
        /// <summary>
        /// True if ship has at least one health
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Size of ship. 
        /// </summary>
        /// <returns></returns>
        public int Size()
        {
            return HealthPoint.Length; 
        }

        /// <summary>
        /// Revieve damage at given coordenates.  
        /// </summary>
        /// <param name="x">attack x coordenate.</param>
        /// <param name="y">attack x coordenate.</param>
        /// <returns>Hit if hit or destroy when ship loses all it's health. Otherwise Miss.</returns>
        public DamageIndicator ReceiveDamage(int x, int y)  
        {
           int i = Math.Abs((X - x) + (Y - y));

           DamageIndicator dmg = HealthPoint[i] ? DamageIndicator.Hit : DamageIndicator.Miss; 
            
           HealthPoint[i] = false; 

           return IsAlive()? dmg : DamageIndicator.Destroy; 
        }
        #endregion
    }
}
