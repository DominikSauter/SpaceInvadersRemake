using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace SpaceInvadersRemake.ModelSection
{
    /// <summary>
    /// Diese Klasse dient zur Erstellung sich selbst bewegender Projektile.
    /// </summary>
    public class Projectile : GameItem
    {

        /// <summary>
        /// Gibt die Flugrichtung des Projektils an, d.h. die Verschiebung in X- und Y-Richtung.
        /// </summary>
        public Vector2 FlightDirection
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        /// <summary>
        /// Gibt die Art des Projektils für die Darstellung in der View an.
        /// </summary>
        public ProjectileTypeEnum ProjectileType
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        /// <summary>
        /// Wird geworfen, wenn ein neues Projektil erstellt wird.
        /// </summary>
        public static event EventHandler Created;

        /// <summary>
        /// Wird geworfen, wenn ein Projektil zerstört wird.
        /// </summary>
        public static event EventHandler Destroyed;

        /// <summary>
        /// Wird geworfen, wenn ein Projektil mit einem anderen Spielobjekt kollidiert.
        /// </summary>
        public static event EventHandler Hit;

        public override void IsCollidedWith(IGameItem collisionPartner)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Bewirkt das Bewegen des Projektils in Richtung "FlightDirection" in Abhängigkeit von "Velocity".
        /// </summary>
        /// <remarks>"Velocity" ist eine Modifikation für "FlightDirection", welche auf "Position" addiert wird, um die Bewegung zu simulieren.</remarks>
        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Erstellt ein Projektil
        /// </summary>
        /// <param name="position">Position</param>
        /// <param name="flightDirection">Flugrichtung</param>
        /// <param name="projectileType">Art des Projektils</param>
        /// <param name="hitpoints">Lebenspunkte</param>
        /// <param name="velocity">maximale Geschwindigkeit</param>
        public Projectile(Vector2 position, Vector2 flightDirection, ProjectileTypeEnum projectileType, int hitpoints, Vector2 velocity)
        {
            throw new System.NotImplementedException();
        }
    }
}
