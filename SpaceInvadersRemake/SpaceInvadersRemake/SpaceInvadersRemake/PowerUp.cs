using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvadersRemake
{
    public abstract class PowerUp : GameItem
    {
        public abstract void Apply(Player player);
    }
}
