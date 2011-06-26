using System;
using Microsoft.Xna.Framework;

// Implementiert von D. Sauter

namespace SpaceInvadersRemake.ModelSection
{
    /// <summary>
    /// Standard-Waffe des Spielers.
    /// </summary>
    public class PlayerNormalWeapon : Weapon
    {
        /// <summary>
        /// Wird geworfen, wenn ein Projektil-Objekt erzeugt, d.h. ein Schuss abgegeben wurde.
        /// </summary>
        public static event EventHandler WeaponFired;

        /// <summary>
        /// Konstruktor
        /// </summary>
        public PlayerNormalWeapon()
        {
            this.cooldown = 1.0f;
            this.projectileDamage = GameItemConstants.PlayerNormalProjectileDamage;
            this.projectileHitpoints = GameItemConstants.PlayerNormalProjectileHitpoints;
            this.projectileType = ProjectileTypeEnum.PlayerNormalProjectile;
            this.projectileVelocity = GameItemConstants.PlayerNormalProjectileVelocity;
            //this.lastShot = gameTime.TotalGameTime.
        }

        public override void Fire(Vector2 position, Vector2 shootingDirection, GameTime gameTime)
        {
            int miliCooldown = (int)(cooldown * 1000);
            if (gameTime.TotalGameTime.Milliseconds >= (lastShot + miliCooldown))
            {
                new Projectile(position, shootingDirection, projectileType, projectileHitpoints, projectileVelocity, projectileDamage);
                //lastShot = gameTime.TotalGameTime.;

                WeaponFired(this, null);
            }
        }
    }
}
