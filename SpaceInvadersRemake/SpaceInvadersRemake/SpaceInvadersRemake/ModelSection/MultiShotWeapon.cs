using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

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

        public override void Fire(Vector2 position, Vector2 shootingDirection, GameTime gameTime)
        {
            if (gameTime.TotalGameTime.TotalMilliseconds >= lastShot)
            {
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
