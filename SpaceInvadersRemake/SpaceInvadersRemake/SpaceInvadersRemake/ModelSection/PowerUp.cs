using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvadersRemake.ModelSection
{
    /// <summary>
    /// Diese abstrakte Klasse ist die Überklasse aller PowerUps.
    /// </summary>
    public abstract class PowerUp : GameItem
    {
        private int Duration;

        public abstract void Apply(Player player);

        public abstract void Remove(Player player);
    }
}
