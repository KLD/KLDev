using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipCore
{
    public class PlayerConfig
    {
        public int[] ShipSizes { private set; get; }

        public PlayerConfig(params int[] sizes)
        {
            ShipSizes = sizes; 
        }
    }
}
