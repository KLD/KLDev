using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipCore
{
    /// <summary>
    /// The value recieved after launching an attack.
    /// </summary>
    public enum DamageIndicator
    {
        Away, 
        Miss, 
        Hit, 
        Destroy
    }
}
