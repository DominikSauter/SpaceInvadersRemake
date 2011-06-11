using System;
using Microsoft.Xna.Framework;

namespace SpaceInvadersRemake.ModelSection
{
    /// <summary>
    /// Diese Klasse stellt ein SlowMotion-PowerUp dar. Dieses PowerUp verlangsamt die Spielzeit.
    /// </summary>
    public class SlowMotion : PowerUp
    {
        public override void Apply(Player player)
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

        public override void IsCollidedWith(IGameItem collisionPartner)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Dieses Event wird ausgelöst, wenn ein neues Objekt dieser Klasse erzeugt wurde.
        /// </summary>
        public static event EventHandler Created;

        public override void Remove(Player player)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Konstante, die die Wirkungsdauer des PowerUps festlegt
        /// </summary>
        private const float duration = 0.0f;

        /// <summary>
        /// Erstellt ein SlowMotion-PowerUp
        /// </summary>
        /// <param name="position">Startposition</param>
        /// <param name="velocity">maximale Geschwindigkeit</param>
        public SlowMotion(Vector2 position, Vector2 velocity)
        {
            throw new System.NotImplementedException();
        }
    }
}
