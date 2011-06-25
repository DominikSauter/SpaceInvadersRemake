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
        /// Dieses Event wird ausgelöst, wenn ein Objekt der Klasse mit einem anderen Objekt kollidiert ist.
        /// </summary>
        public static event EventHandler Hit;

        /// <summary>
        /// Dieses Event wird ausgelöst, wenn ein Objekt der Klasse zerstört wurde, d.h. dessen Lebenspunkte auf 0 gesunken sind.
        /// </summary>
        public static event EventHandler Destroyed;

        public override bool Move(Microsoft.Xna.Framework.Vector2 direction)
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

        public override void Shoot(GameTime gameTime)
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
        /// <param name="velocityMultiplier">maximale Geschwindigkeit</param>
        /// <param name="hitpointsMultiplier">Lebenspunkte</param>
        /// <param name="damageMultiplier">Schaden, der anderen zugefügt wird</param>
        /// <param name="weapon">Waffe</param>
        /// <param name="scoreGainMultiplier">Punktwert des Minibosses</param>
        public Miniboss(Vector2 position, Vector2 velocity, int hitpoints, int damage, Weapon weapon, int scoreGain)
            : base(position, velocity, hitpoints, damage, weapon, scoreGain)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Dieses Event wird ausgelöst, wenn es für einen Abschuss Punkte gibt
        /// </summary>
        public static event EventHandler ScoreGained;

        protected override void Destroy()
        {
            throw new NotImplementedException();
        }
    }
}
