using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace SpaceInvadersRemake.ModelSection
{
    /// <summary>
    /// Waffe eines Minibosses.
    /// </summary>
    public class MinibossWeapon : Weapon
    {
        /// <summary>
        /// Wird geworfen, wenn ein Projektil-Objekt erzeugt, d.h. ein Schuss abgegeben wurde.
        /// </summary>
        public static event EventHandler WeaponFired;

        /// <summary>
        /// Konstruktor
        /// </summary>
        public MinibossWeapon()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Diese Methode generiert ein neues Projektil-Objekt an der Stelle von "position" mit der Flugrichtung "shootingDirection" und wirft das Event "WeaponFired".
        /// </summary>
        public override void Fire(Vector2 position, Vector2 shootingDirection, GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
