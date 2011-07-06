using System;
using Microsoft.Xna.Framework;

// Implementiert von D. Sauter

namespace SpaceInvadersRemake.ModelSection
{
    /// <summary>
    /// Waffe mit mehreren Schüssen gleichzeitig.
    /// </summary>
    public class MultiShotWeapon : Weapon
    {
        /// <summary>
        /// Wird geworfen, wenn ein Projektil-Objekt erzeugt, d.h. ein Schuss abgegeben wurde.
        /// </summary>
        public static event EventHandler WeaponFired;

        /// <summary>
        /// Konstruktor
        /// </summary>
        public MultiShotWeapon()
        {
            this.cooldown = GameItemConstants.PlayerNormalWeaponCooldown;
            this.projectileDamage = GameItemConstants.PlayerNormalProjectileDamage;
            this.projectileHitpoints = GameItemConstants.PlayerNormalProjectileHitpoints;
            this.projectileType = ProjectileTypeEnum.PlayerNormalProjectile;
            this.projectileVelocity = GameItemConstants.PlayerNormalProjectileVelocity;
            this.lastShot = -cooldown;
        }

        /// <summary>
        /// Diese Methode generiert ein neues Projektil-Objekt und wirft das Event "WeaponFired".
        /// </summary>
        /// <remarks>
        /// Es wird nur dann ein Projektil-Objekt erzeugt, wenn die Zeit <c>cooldown</c> seit dem letzten erzeugten
        /// Projektil vergangen ist. Der Zeitpunkt, an dem das letzte Projektil abgefeuert wurde, wird in 
        /// <c>lastShot</c> gespeichert. Dem Projektil werden neben <c>position</c> und <c>shootingDirection</c>
        /// die waffenspezifischen Werte <c>projectileHitpoints</c>, <c>projectileType</c>, <c>projectileVelocity</c> und <c>projectileDamage</c> 
        /// im Konstruktor übergeben.
        /// </remarks>
        /// <param name="position">Position der abgefeuerten Projektile</param>
        /// <param name="shootingDirection">Bewegungsrichtung der Projektile</param>
        /// <param name="gameTime">Spielzeit</param>
        public override void Fire(Vector2 position, Vector2 shootingDirection, GameTime gameTime)
        {
            if (gameTime.TotalGameTime.TotalMilliseconds >= lastShot)
            {
                // TODO: Schussrichtung-Berechnung neu überdenken (jetzige Berechnung nicht allgemein gültig)
                int shots = 3;
                float distance = 0.2f;
                for (int i = 0; i < shots; i++)
                {
                    new Projectile(position, shootingDirection + new Vector2((i - (shots / 2)) * distance, 0.0f), projectileType, projectileHitpoints, projectileVelocity, projectileDamage);
                }
                lastShot = gameTime.TotalGameTime.TotalMilliseconds + cooldown;

                if (WeaponFired != null)
                {
                    WeaponFired(this, EventArgs.Empty);
                }
            }
        }
    }
}
