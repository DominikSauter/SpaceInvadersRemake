﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace SpaceInvadersRemake.ModelSection
{
    /// <summary>
    /// Waffe des Mutterschiffs.
    /// </summary>
    public class MothershipWeapon : Weapon
    {
        /// <summary>
        /// Wird geworfen, wenn ein Projektil-Objekt erzeugt, d.h. ein Schuss abgegeben wurde.
        /// </summary>
        public static event EventHandler WeaponFired;

        /// <summary>
        /// Konstruktor
        /// </summary>
        public MothershipWeapon()
        {
            throw new System.NotImplementedException();
        }

        public override void Fire(Vector2 position, Vector2 shootingDirection, GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
