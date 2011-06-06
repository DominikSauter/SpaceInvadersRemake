using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace SpaceInvadersRemake.ModelSection
{
    /// <summary>
    /// Diese abstrakte Klasse bildet die Oberklasse für alle Waffenarten, die im Spiel vorkommen.
    /// </summary>
    public abstract class Weapon
    {
        /// <summary>
        /// Der Typ der Projektile.
        /// </summary>
        protected ProjectileTypeEnum projectileType;
        /// <summary>
        /// Die Zeit, die zwischen der Erzeugung zweier Projektile vergehen muss.
        /// </summary>
        protected int cooldown;
        /// <summary>
        /// Die Geschwindigkeit der Projektile.
        /// </summary>
        protected Vector2 projectileVelocity;
        /// <summary>
        /// Der Zeitpunkt, an dem das letzte Projektil erzeugt wurde.
        /// </summary>
        protected GameTime lastShot;
        /// <summary>
        /// Die Lebenspunkte der Projektile.
        /// </summary>
        protected int projectileHitpoints;

        /// <summary>
        /// Diese Methode generiert ein neues Projektil-Objekt an der Stelle von "position" mit der Flugrichtung "shootingDirection" und wirft das Event "WeaponFired".
        /// </summary>
        /// <remarks>Es wird nur dann ein Projektil-Objekt erzeugt, wenn die Zeit "cooldown" seit dem letzten erzeugten Projektil vergangen ist. Der Zeitpunkt, an dem das letzte Projektil abgefeuert wurde, wird in "lastShot" gespeichert. Dem Projektil werden neben "position" und "shootingDirection" die waffenspezifischen Werte "projectileHitpoints", "projectileType" und "projectileVelocity" im Konstruktor übergeben.</remarks>
        public abstract void Fire(Vector2 position, Vector2 shootingDirection, GameTime gameTime);
    }
}
