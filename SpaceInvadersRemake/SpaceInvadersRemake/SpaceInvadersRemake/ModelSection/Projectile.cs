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

        /// <summary>
        /// Wird nicht verwendet.
        /// </summary>
        public override void Move(Microsoft.Xna.Framework.Vector2 direction)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Nimmt die Konsequenzen am Projektil vor, die nach einer Kollision mit einem anderen IGameItem ("collisionPartner") fällig sind.
        /// </summary>
        /// <remarks>Die Kollisionsbehandlung erfolgt kontextsensitiv, also unterschiedlich, je nachdem, mit welchem Typ von IGameItem das Projektil kollidiert ist.</remarks>
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
        /// Dem Konstruktor werden Startposition ("position") des Projektils, Flugrichtung ("flightDirection"), Projektiltyp ("projectileType"), Lebenspunkte ("hitpoints") und Geschwindigkeit ("velocity") übergeben.
        /// </summary>
        public Projectile(Vector2 position, Vector2 flightDirection, ProjectileTypeEnum projectileType, int hitpoints, Vector2 velocity)
        {
            throw new System.NotImplementedException();
        }
    }
}
