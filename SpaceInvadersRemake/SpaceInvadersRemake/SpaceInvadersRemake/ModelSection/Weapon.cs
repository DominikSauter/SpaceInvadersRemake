using Microsoft.Xna.Framework;

// Implementiert von D. Sauter

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
        /// Die Zeit, die zwischen der Erzeugung zweier Projektile vergehen muss in Milisekunden.
        /// </summary>
        protected int cooldown;

        /// <summary>
        /// Die Geschwindigkeit der Projektile in Distanz pro Sekunde.
        /// </summary>
        protected Vector2 projectileVelocity;

        /// <summary>
        /// Der Zeitpunkt, an dem das letzte Projektil erzeugt wurde in Milisekunden seit Spielstart plus Cooldown.
        /// </summary>
        protected int lastShot;

        /// <summary>
        /// Die Lebenspunkte der Projektile.
        /// </summary>
        protected int projectileHitpoints;

        /// <summary>
        /// Der (Kollisions-)Schaden der Projektile.
        /// </summary>
        protected int projectileDamage;

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
