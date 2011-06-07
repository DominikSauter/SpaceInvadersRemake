using System;
using Microsoft.Xna.Framework;

namespace SpaceInvadersRemake.ModelSection
{
    /// <summary>
    /// Diese Klasse stellt ein Schild dar, das den Spieler vor feindlichem Beschuss schützt, aber auch seine eigenen Projektile aufhält.
    /// </summary>
    public class Shield : GameItem
    {

        /// <summary>
        /// Dieses Event wird ausgelöst, wenn ein Objekt der Klasse mit einem anderen Objekt kollidiert ist.
        /// </summary>
        public static event EventHandler Hit;

        /// <summary>
        /// Dieses Event wird ausgelöst, wenn ein Objekt der Klasse zerstört wurde, d.h. dessen Lebenspunkte auf 0 gesunken sind.
        /// </summary>
        public static event EventHandler Destroyed;

        /// <summary>
        /// Bewegt das Objekt in die gewünschte Richtung
        /// </summary>
        /// <param name="direction">Bewegungsrichtung</param>
        public override void Move(Microsoft.Xna.Framework.Vector2 direction)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Diese Methode wird bei einer Kollision mit einem anderen Objekt aufgerufen.
        /// </summary>
        /// <param name="collisionPartner">Das GameItem mit die Kollision stattfand.</param>
        public override void IsCollidedWith(IGameItem collisionPartner)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// In dieser Methode wird alles geupdatet, was nicht durch einen Controllers beeinflusst werden kann.
        /// </summary>
        /// <param name="gameTime">Spielzeit</param>
        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Dieses Event wird ausgelöst, wenn ein neues Objekt dieser Klasse erzeugt wurde.
        /// </summary>
        public static event EventHandler Created;

        /// <summary>
        /// Erzeugt ein Schild
        /// </summary>
        /// <param name="position">Position</param>
        /// <param name="hitpoints">Lebenspunkte</param>
        public Shield(Vector2 position, int hitpoints)
        {
            throw new System.NotImplementedException();
        }
    }
}
