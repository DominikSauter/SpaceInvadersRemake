using System;
using Microsoft.Xna.Framework;

namespace SpaceInvadersRemake.ModelSection
{
    /// <summary>
    /// Diese Klasse stellt ein RapidFire-PowerUp dar. Dieses PowerUp verbessert die Waffe des Spielers, sodass diese in schneller Folge feuern kann.
    /// </summary>
    public class Rapidfire : PowerUp
    {
        /// <summary>
        /// Diese Methode wird über ein "PowerUpAction"-Delegate in der "ActivePowerUp"-Klasse dazu benutzt den Effekt des PowerUps am Spieler anzuwenden.
        /// </summary>
        /// <param name="player">Der Spieler bei dem das PowerUp angewendet werden soll.</param>
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

        /// <summary>
        /// Diese Methode wird bei einer Kollision mit einem anderen Objekt aufgerufen.
        /// </summary>
        /// <param name="collisionPartner">Das GameItem mit die Kollision stattfand.</param>
        public override void IsCollidedWith(IGameItem collisionPartner)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Dieses Event wird ausgelöst, wenn ein neues Objekt dieser Klasse erzeugt wurde.
        /// </summary>
        public static event EventHandler Created;

        /// <summary>
        /// Diese Methode wird über ein "PowerUpAction"-Delegate in der "ActivePowerUp"-Klasse dazu benutzt den Effekt des PowerUps am Spieler rückgängig zu machen.
        /// </summary>
        /// <param name="player">Der Spieler bei dem das PowerUp entfernt werden soll.</param>
        public override void Remove(Player player)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Konstante, die die Wirkungsdauer des PowerUps festlegt
        /// </summary>
        private const float duration = 0.0f;

        /// <summary>
        /// Erstellt ein Rapidfire-PowerUp
        /// </summary>
        /// <param name="position">Startposition</param>
        /// <param name="velocity">Geschwindigkeit</param>
        public Rapidfire(Vector2 position, Vector2 velocity)
        {
            throw new System.NotImplementedException();
        }
    }
}
