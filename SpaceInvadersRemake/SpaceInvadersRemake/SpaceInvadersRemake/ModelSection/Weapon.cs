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
        /// Diese Methode generiert ein neues Projektil-Objekt und wirft das Event "WeaponFired".
        /// </summary>
        /// <remarks>
        /// Es wird nur dann ein Projektil-Objekt erzeugt, wenn die Zeit <c>cooldown</c> seit dem letzten erzeugten
        /// Projektil vergangen ist. Der Zeitpunkt, an dem das letzte Projektil abgefeuert wurde, wird in 
        /// <c>lastShot</c> gespeichert. Dem Projektil werden neben <c>position</c> und <c>shootingDirection</c>
        /// die waffenspezifischen Werte <c>projectileHitpoints</c>, <c>projectileType</c> und <c>projectileVelocity</c> 
        /// im Konstruktor übergeben.
        /// </remarks>
        /// <param name="position">Position der abgefeuerten Projektile</param>
        /// <param name="shootingDirection">Bewegungsrichtung der Projektile</param>
        /// <param name="gameTime">Spielzeit</param>
        public abstract void Fire(Vector2 position, Vector2 shootingDirection, GameTime gameTime);
    }
}
