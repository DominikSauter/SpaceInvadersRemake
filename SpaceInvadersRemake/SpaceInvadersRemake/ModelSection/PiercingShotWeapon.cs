﻿using System;
using Microsoft.Xna.Framework;

// Implementiert von D. Sauter

namespace SpaceInvadersRemake.ModelSection
{
    /// <summary>
    /// Waffe mit durchschlagenden Geschossen.
    /// </summary>
    public class PiercingShotWeapon : Weapon
    {
        /// <summary>
        /// Wird geworfen, wenn ein Projektil-Objekt erzeugt, d.h. ein Schuss abgegeben wurde.
        /// </summary>
        public static event EventHandler WeaponFired;

        /// <summary>
        /// Konstruktor
        /// </summary>
        public PiercingShotWeapon()
        {
            this.cooldown = (int)(GameItemConstants.PlayerNormalWeaponCooldown * 1.5f);
            this.projectileDamage = GameItemConstants.PiercingProjectileDamage;
            this.projectileHitpoints = GameItemConstants.PiercingProjectileHitpoints;
            this.projectileType = ProjectileTypeEnum.PiercingProjectile;
            this.projectileVelocity = GameItemConstants.PiercingProjectileVelocity;
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
                new Projectile(position, shootingDirection, projectileType, projectileHitpoints, projectileVelocity, projectileDamage);
                lastShot = gameTime.TotalGameTime.TotalMilliseconds + (cooldown * (1 / GameItem.TimeFactor));

                if (WeaponFired != null)
                {
                    WeaponFired(this, EventArgs.Empty);
                }
            }
        }
    }
}
