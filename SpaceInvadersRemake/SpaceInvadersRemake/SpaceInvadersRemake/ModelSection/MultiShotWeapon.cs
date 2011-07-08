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
                int shots = 3;
                float shotDistance = 0.1f;
                shootingDirection.Normalize();
                float xDirectionShifting;
                for (int i = 0; i < shots; i++)
                {
                    xDirectionShifting = - ((shotDistance * (shots - 1)) / 2) + (i * shotDistance); // Errechnet die Verschiebung des Projektils in X-Richtung
                    new Projectile(position, new Vector2(shootingDirection.X + xDirectionShifting, shootingDirection.Y - Math.Abs(xDirectionShifting)), projectileType, projectileHitpoints, projectileVelocity, projectileDamage);
                }
                lastShot = gameTime.TotalGameTime.TotalMilliseconds + (cooldown * (1 / GameItem.TimeFactor));

                if (WeaponFired != null)
                {
                    WeaponFired(this, EventArgs.Empty);
                }
            }
        }
    }
}
