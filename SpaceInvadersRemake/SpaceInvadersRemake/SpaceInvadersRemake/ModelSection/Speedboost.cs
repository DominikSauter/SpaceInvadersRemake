using Microsoft.Xna.Framework;

// Implementiert von Tobias

namespace SpaceInvadersRemake.ModelSection
{
    /// <summary>
    /// Diese Klasse stellt ein Speedboost-PowerUps dar. Dieses PowerUps erhöht die Geschwindigkeit des Spielers.
    /// </summary>
    public class Speedboost : PowerUp
    {
        /// <summary>
        /// Diese Methode wird über ein <c>PowerUpAction</c>-Delegate in der <c>ActivePowerUp</c>-Klasse 
        /// dazu benutzt den Effekt des PowerUps am Spieler anzuwenden.
        /// </summary>
        /// <param name="player">Der Spieler bei dem das PowerUps angewendet werden soll.</param>
        public override void Apply(Player player)
        {
            //TODO: Wert anpassen
            // Spielergeschwindigkeit erhöhen
            player.Velocity = 1.5f * GameItemConstants.PlayerVelocity;
        }

        /// <summary>
        /// Diese Methode wird über ein <c>PowerUpAction</c>-Delegate in der <c>ActivePowerUp</c>-Klasse 
        /// dazu benutzt den Effekt des PowerUps am Spieler rückgängig zu machen.
        /// </summary>
        /// <param name="player">Der Spieler bei dem das PowerUps entfernt werden soll.</param>
        public override void Remove(Player player)
        {
            // Normale Geschwindigkeit zurücksetzen
            player.Velocity = GameItemConstants.PlayerVelocity;
        }

        /// <summary>
        /// Erstellt ein Speedboost-PowerUps
        /// </summary>
        /// <param name="position">Startposition</param>
        /// <param name="velocity">maximale Geschwindigkeit</param>
        public Speedboost(Vector2 position, Vector2 velocity)
            : base(position, velocity)
        {
            type = PowerUpEnum.Speedboost;
            //TODO: In GameItemConstants auslagern
            duration = 15.0f;
        }
    }
}
