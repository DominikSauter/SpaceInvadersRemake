using System;
using Microsoft.Xna.Framework;

namespace SpaceInvadersRemake.ModelSection
{
    /// <summary>
    /// Diese Klasse stellt einen Minibos dar. Ein anspruchsvollerer Gegner, der nach einer bestimmten Anzahl von Wellen auftaucht.
    /// </summary>
    public class Miniboss : Enemy
    {
        /// <summary>
        /// Diese Methode wird aufgerufen, wenn die Lebenspunkte auf den Wert 0 oder darunter sinken.
        /// </summary>
        protected override void Destroy()
        {
            throw new NotImplementedException();
        }

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
        /// Teilt dem Objekt mit, dass es versuchen soll zu schießen
        /// </summary>
        public override void Shoot()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Dieses Event wird ausgelöst, wenn ein neues Objekt dieser Klasse erzeugt wurde.
        /// </summary>
        public static event EventHandler Created;

        /// <summary>
        /// Erzeugt einen Miniboss
        /// </summary>
        /// <param name="position">Startposition</param>
        /// <param name="velocity">Geschwindigkeit</param>
        /// <param name="hitpoints">Lebenspunkte</param>
        /// <param name="weapon">Waffe</param>
        public Miniboss(Vector2 position, Vector2 velocity, int hitpoints, Weapon weapon)
        {
            throw new System.NotImplementedException();
        }
    }
}
