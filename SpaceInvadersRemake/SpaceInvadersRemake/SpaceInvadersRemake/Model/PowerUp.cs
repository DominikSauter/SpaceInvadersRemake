using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvadersRemake
{
    public abstract class PowerUp : GameItem
    {
        private int Duration;
    
        public abstract void Apply(Player player);
    }
}
