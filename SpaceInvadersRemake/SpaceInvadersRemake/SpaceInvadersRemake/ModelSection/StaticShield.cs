using System;
using Microsoft.Xna.Framework;

// Implementiert von Tobias

namespace SpaceInvadersRemake.ModelSection
{
    /// <summary>
    /// Diese Klasse stellt ein StaticShield-PowerUp dar. Dieses PowerUp verleiht dem Spieler ein Schild,
    /// das er im Spiel platzieren kann.
    /// </summary>
    public class StaticShield : PowerUp
    {
        /// <summary>
        /// Diese Methode wird über ein <c>PowerUpAction</c>-Delegate in der <c>ActivePowerUp</c>-Klasse 
        /// dazu benutzt den Effekt des PowerUps am Spieler anzuwenden.
        /// </summary>
        /// <param name="player">Der Spieler bei dem das PowerUp angewendet werden soll.</param>
        public override void Apply(Player player)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Diese Methode wird über ein <c>PowerUpAction</c>-Delegate in der <c>ActivePowerUp</c>-Klasse 
        /// dazu benutzt den Effekt des PowerUps am Spieler rückgängig zu machen.
        /// </summary>
        /// <param name="player">Der Spieler bei dem das PowerUp entfernt werden soll.</param>
        public override void Remove(Player player)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Erstellt ein StaticShield-PowerUp
        /// </summary>
        /// <param name="position">Startposition</param>
        /// <param name="velocity">maximale Geschwinigkeit</param>
        public StaticShield(Vector2 position, Vector2 velocity)
            : base(position, velocity)
        {
            throw new System.NotImplementedException();
        }
    }
}
