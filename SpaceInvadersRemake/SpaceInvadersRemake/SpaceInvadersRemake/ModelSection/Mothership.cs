using System;
using Microsoft.Xna.Framework;

namespace SpaceInvadersRemake.ModelSection
{
    /// <summary>
    /// Diese Klasse stellt ein Mutterschiff dar, das in zufälligen Intervallen im Spiel vorkommt.
    /// </summary>
    public class Mothership : Enemy
    {

        /// <summary>
        /// Dieses Event wird ausgelöst, wenn ein Objekt der Klasse mit einem anderen Objekt kollidiert ist.
        /// </summary>
        public static event EventHandler Hit;

        /// <summary>
        /// Dieses Event wird ausgelöst, wenn ein Objekt der Klasse zerstört wurde, d.h. dessen Lebenspunkte auf 0 gesunken sind.
        /// </summary>
        public static event EventHandler Destroyed;

        public override void Move(Microsoft.Xna.Framework.Vector2 direction)
        {
            throw new NotImplementedException();
        }

        public override void IsCollidedWith(IGameItem collisionPartner)
        {
            throw new NotImplementedException();
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        public override void Shoot()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Dieses Event wird ausgelöst, wenn ein neues Objekt dieser Klasse erzeugt wurde.
        /// </summary>
        public static event EventHandler Created;//HACK change EventHandler<ControllerEventArgs>

        /// <summary>
        /// Erzeugt ein Mutterschiff
        /// </summary>
        /// <param name="position">Startposition</param>
        /// <param name="velocity">maximale Geschwindigkeit</param>
        /// <param name="hitpoints">Lebenspunkte</param>
        /// <param name="weapon">Waffe</param>
        /// <param name="scoreGain">Punktwert des Mutterschiffs</param>
        public Mothership(Vector2 position, Vector2 velocity, int hitpoints, Weapon weapon, int scoreGain)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Dieses Event wird ausgelöst, wenn es für einen Abschuss Punkte gibt
        /// </summary>
        public static event EventHandler ScoreGained;
    }
}
