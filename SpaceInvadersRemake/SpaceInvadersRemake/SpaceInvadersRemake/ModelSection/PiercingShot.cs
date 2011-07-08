using System;
using Microsoft.Xna.Framework;

// Implementiert von Tobias

namespace SpaceInvadersRemake.ModelSection
{
    /// <summary>
    /// Diese Klasse stellt ein PiercingShot-PowerUp dar. Dieses PowerUp verbessert die Waffe des Spielers,
    /// sodass die Projektile einen Gegner durchschlagen können.
    /// </summary>
    public class PiercingShot : PowerUp
    {
        /// <summary>
        /// Statischer Konstruktor, der das PowerUp beim <c>PowerUpGenerator</c> registriert.
        /// </summary>
        static PiercingShot()
        {
            PowerUpGenerator.AddAvailablePowerUp(PowerUpEnum.PiercingShot,
                                                 GameItemConstants.PiercingShotFrequency,
                                                 delegate(Vector2 pos, Vector2 vel)
                                                 {
                                                     new PiercingShot(pos, vel);
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
            // Setzt neue Waffe
            player.Weapon = new PiercingShotWeapon();
        }

        /// <summary>
        /// Diese Methode wird über ein <c>PowerUpAction</c>-Delegate in der <c>ActivePowerUp</c>-Klasse 
        /// dazu benutzt den Effekt des PowerUps am Spieler rückgängig zu machen.
        /// </summary>
        /// <param name="player">Der Spieler bei dem das PowerUp entfernt werden soll.</param>
        public override void Remove(Player player)
        {
            //Normale Waffe zurücksetzen
            player.Weapon = GameItemConstants.PlayerWeapon;
        }

        /// <summary>
        /// Erstellt ein PiercingShot-PowerUp
        /// </summary>
        /// <param name="position">Startposition</param>
        /// <param name="velocity">maximale Geschwindigkeit</param>
        public PiercingShot(Vector2 position, Vector2 velocity)
            : base(position, velocity)
        {
            type = PowerUpEnum.PiercingShot;
            duration = GameItemConstants.PiercingShotDuration;
        }
    }
}
