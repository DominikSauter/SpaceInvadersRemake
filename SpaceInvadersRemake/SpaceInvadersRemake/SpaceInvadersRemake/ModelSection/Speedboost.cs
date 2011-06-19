﻿using System;
using Microsoft.Xna.Framework;

namespace SpaceInvadersRemake.ModelSection
{
    /// <summary>
    /// Diese Klasse stellt ein Speedboost-PowerUps dar. Dieses PowerUps erhöht die Geschwindigkeit des Spielers.
    /// </summary>
    public class Speedboost : PowerUp
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
        /// Erstellt ein Speedboost-PowerUps
        /// </summary>
        /// <param name="position">Startposition</param>
        /// <param name="velocity">maximale Geschwindigkeit</param>
        public Speedboost(Vector2 position, Vector2 velocity)
        {
            throw new System.NotImplementedException();
        }

        protected override void Destroy()
        {
            throw new NotImplementedException();
        }
    }
}
