﻿using Microsoft.Xna.Framework;

// Implementiert von Tobias

namespace SpaceInvadersRemake.ModelSection
{
    /// <summary>
    /// Diese Klasse stellt ein Deflector-PowerUp dar. Dieses PowerUp verbessert den Spieler, sodass er ein Schild hat, das einen Treffer absorbiert.
    /// </summary>
    public class Deflector : PowerUp
    {

        /// <summary>
        /// Statischer Konstruktor, der das PowerUp beim <c>PowerUpGenerator</c> registriert.
        /// </summary>
        static Deflector()
        {
            PowerUpGenerator.AddAvailablePowerUp(PowerUpEnum.Deflector,
                                                 GameItemConstants.DeflectorFrequency,
                                                 delegate(Vector2 pos, Vector2 vel)
                                                 {
                                                     new Deflector(pos, vel);
                                                 });
        }

        /// <summary>
        /// Zeigt an ob das PowerUp beim PowerUpGenerator registriert ist
        /// </summary>
        public static bool IsRegistered = false;

        /// <summary>
        /// Diese Methode wird über ein <c>PowerUpAction</c>-Delegate in der <c>ActivePowerUp</c>-Klasse 
        /// dazu benutzt den Effekt des PowerUps am Spieler anzuwenden.
        /// </summary>
        /// <param name="player">Der Spieler bei dem das PowerUp angewendet werden soll.</param>
        public override void Apply(Player player)
        {
            //HACK: Im Moment verdoppelt der Deflector nur die HP, evtl. muss noch eine bessere Lösung gefunden werden
            player.Hitpoints = (int)(2.0f * GameItemConstants.PlayerHitpoints);
        }

        /// <summary>
        /// Diese Methode wird über ein <c>PowerUpAction</c>-Delegate in der <c>ActivePowerUp</c>-Klasse 
        /// dazu benutzt den Effekt des PowerUp am Spieler rückgängig zu machen.
        /// </summary>
        /// <param name="player">Der Spieler bei dem das PowerUps entfernt werden soll.</param>
        public override void Remove(Player player)
        {
            // Der Deflector muss beim Spieler nichts zurücksetzen
        }

        /// <summary>
        /// Erstellt ein Deflector-PowerUp
        /// </summary>
        /// <param name="position">Startposition</param>
        /// <param name="velocity">maximale Geschwindigkeit</param>
        public Deflector(Vector2 position, Vector2 velocity)
            : base(position, velocity)
        {
            type = PowerUpEnum.Deflector;
            duration = 0.0f;
        }
    }
}
