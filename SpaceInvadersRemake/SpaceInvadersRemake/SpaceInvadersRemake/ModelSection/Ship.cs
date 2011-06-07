using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvadersRemake.ModelSection
{
    /// <summary>
    /// Abstrakte Oberklasse aller Raumschiffe im Spiel
    /// </summary>
    public abstract class Ship : GameItem
    {
        /// <summary>
        /// Die aktuelle Waffe des Raumschiffs
        /// </summary>
        public Weapon Weapon
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    }
}
