using Microsoft.Xna.Framework;

// Implementiert von Tobias

namespace SpaceInvadersRemake.ModelSection
{
    /// <summary>
    /// Diese Klasse stellt ein Speedboost-PowerUp dar. Dieses PowerUp erhöht die Geschwindigkeit des Spielers.
    /// </summary>
    public class Speedboost : PowerUp
    {
        /// <summary>
        /// Statischer Konstruktor, der das PowerUp beim <c>PowerUpGenerator</c> registriert.
        /// </summary>
        static Speedboost()
        {
            PowerUpGenerator.AddAvailablePowerUp(PowerUpEnum.Speedboost,
                                                 GameItemConstants.SpeedboostFrequency,
                                                 delegate(Vector2 pos, Vector2 vel)
                                                 {
                                                     new Speedboost(pos, vel);
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
            // Spielergeschwindigkeit erhöhen
            player.Velocity = GameItemConstants.SpeedboostFactor * GameItemConstants.PlayerVelocity;
        }

        /// <summary>
        /// Diese Methode wird über ein <c>PowerUpAction</c>-Delegate in der <c>ActivePowerUp</c>-Klasse 
        /// dazu benutzt den Effekt des PowerUps am Spieler rückgängig zu machen.
        /// </summary>
        /// <param name="player">Der Spieler bei dem das PowerUp entfernt werden soll.</param>
        public override void Remove(Player player)
        {
            // Normale Geschwindigkeit zurücksetzen
            player.Velocity = GameItemConstants.PlayerVelocity;
        }

        /// <summary>
        /// Erstellt ein Speedboost-PowerUp
        /// </summary>
        /// <param name="position">Startposition</param>
        /// <param name="velocity">maximale Geschwindigkeit</param>
        public Speedboost(Vector2 position, Vector2 velocity)
            : base(position, velocity)
        {
            type = PowerUpEnum.Speedboost;
            duration = GameItemConstants.SpeedboostDuration;
        }
    }
}
