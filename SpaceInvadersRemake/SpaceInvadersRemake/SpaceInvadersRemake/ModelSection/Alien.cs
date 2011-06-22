using System;
using Microsoft.Xna.Framework;

namespace SpaceInvadersRemake.ModelSection
{
    /// <summary>
    /// Diese Klasse stellt ein einfaches gegnerisches Raumschiff (Alien) dar.
    /// </summary>
    public class Alien : Enemy
    {

        /// <summary>
        /// Dieses Event wird ausgelöst, wenn ein Objekt der Klasse mit einem anderen Objekt kollidiert ist.
        /// </summary>
        public static event EventHandler Hit;

        /// <summary>
        /// Dieses Event wird ausgelöst, wenn ein Objekt der Klasse zerstört wurde, d.h. dessen Lebenspunkte auf 0 gesunken sind.
        /// </summary>
        public static event EventHandler Destroyed;

        public override void IsCollidedWith(IGameItem collisionPartner)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Dieses Event wird ausgelöst, wenn ein neues Objekt dieser Klasse erzeugt wurde.
        /// </summary>
        public static event EventHandler Created;

        /// <summary>
        /// Erzeugt ein Alien
        /// </summary>
        /// <param name="position">Startposition</param>
        /// <param name="velocity">maximale Geschwindigkeit</param>
        /// <param name="hitpoints">Lebenspunkte</param>
        /// <param name="weapon">Waffe</param>
        /// <param name="scoreGain">Punktwert des Aliens</param>
        public Alien(Vector2 position, Vector2 velocity, int hitpoints, Weapon weapon, int scoreGain)
            : base(position, velocity, hitpoints, weapon, scoreGain)
        {
            if (Alien.Created != null)
                Alien.Created(this, EventArgs.Empty);
        }

        /// <summary>
        /// Dieses Event wird ausgelöst, wenn es für einen Abschuss Punkte gibt
        /// </summary>
        public static event EventHandler ScoreGained;

        protected override void Destroy()
        {
            IsAlive = false;

            if (Alien.Destroyed != null)
                Alien.Destroyed(this, EventArgs.Empty);
        }
    }
}
