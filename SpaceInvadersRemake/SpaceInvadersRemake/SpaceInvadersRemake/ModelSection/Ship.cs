using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

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
            get;
            set;
        }

        /// <summary>
        /// Konstruktor, um redundanten Code zu vermeiden.
        /// </summary>
        /// <param name="position">Startposition</param>
        /// <param name="velocity">Maximale Geschwindigkeit</param>
        /// <param name="hitpoints">Lebenspunkte</param>
        /// <param name="weapon">Waffe</param>
        public Ship(Vector2 position, Vector2 velocity, int hitpoints, Weapon weapon)
            : base(position, velocity, hitpoints)
        {
            this.Weapon = weapon;
        }

    }
}
