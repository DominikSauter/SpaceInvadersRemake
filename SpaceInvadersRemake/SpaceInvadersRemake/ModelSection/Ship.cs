using Microsoft.Xna.Framework;

// Implementiert von Tobias

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
        /// <param name="damage">Schaden, der anderen zugefügt wird</param>
        /// <param name="weapon">Waffe</param>
        public Ship(Vector2 position, Vector2 velocity, int hitpoints, int damage, Weapon weapon)
            : base(position, velocity, hitpoints, damage)
        {
            this.Weapon = weapon;
        }

    }
}
