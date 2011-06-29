using System;
using Microsoft.Xna.Framework;

// Implementiert von D. Sauter

namespace SpaceInvadersRemake.ModelSection
{
    /// <summary>
    /// Standard-Waffe eines Gegners.
    /// </summary>
    public class EnemyNormalWeapon : Weapon
    {
        /// <summary>
        /// Wird geworfen, wenn ein Projektil-Objekt erzeugt, d.h. ein Schuss abgegeben wurde.
        /// </summary>
        public static event EventHandler WeaponFired;

        /// <summary>
        /// Konstruktor
        /// </summary>
        public EnemyNormalWeapon()
        {
            this.cooldown = 200;
            this.projectileDamage = GameItemConstants.EnemyNormalProjectileDamage;
            this.projectileHitpoints = GameItemConstants.EnemyNormalProjectileHitpoints;
            this.projectileType = ProjectileTypeEnum.EnemyNormalProjectile;
            this.projectileVelocity = GameItemConstants.EnemyNormalProjectileVelocity;
            this.lastShot = -cooldown;
        }

        public override void Fire(Vector2 position, Vector2 shootingDirection, GameTime gameTime)
        {
            if (gameTime.TotalGameTime.Milliseconds >= lastShot)
            {
                new Projectile(position, shootingDirection, projectileType, projectileHitpoints, projectileVelocity, projectileDamage);
                lastShot = gameTime.TotalGameTime.Milliseconds + cooldown;

                WeaponFired(this, null);
            }
        }
    }
}
