using Microsoft.Xna.Framework;

// Implementiert von Tobias

namespace SpaceInvadersRemake.ModelSection
{
    /// <summary>
    /// Diese Klasse stellt ein SlowMotion-PowerUp dar. Dieses PowerUp verlangsamt die Spielzeit.
    /// </summary>
    public class SlowMotion : PowerUp
    {
        /// <summary>
        /// Statischer Konstruktor, der das PowerUp beim <c>PowerUpGenerator</c> registriert.
        /// </summary>
        static SlowMotion()
        {
            PowerUpGenerator.AddAvailablePowerUp(PowerUpEnum.SlowMotion,
                                                 GameItemConstants.SlowMotionFrequency,
                                                 delegate(Vector2 pos, Vector2 vel)
                                                 {
                                                     new SlowMotion(pos, vel);
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
            GameItem.TimeFactor = GameItemConstants.SlowMotionFactor;
        }

        /// <summary>
        /// Diese Methode wird über ein <c>PowerUpAction</c>-Delegate in der <c>ActivePowerUp</c>-Klasse 
        /// dazu benutzt den Effekt des PowerUps am Spieler rückgängig zu machen.
        /// </summary>
        /// <param name="player">Der Spieler bei dem das PowerUp entfernt werden soll.</param>
        public override void Remove(Player player)
        {
            GameItem.TimeFactor = 1.0f;
        }

        /// <summary>
        /// Erstellt ein SlowMotion-PowerUp
        /// </summary>
        /// <param name="position">Startposition</param>
        /// <param name="velocity">maximale Geschwindigkeit</param>
        public SlowMotion(Vector2 position, Vector2 velocity)
            : base (position, velocity)
        {
            type = PowerUpEnum.SlowMotion;
            duration = GameItemConstants.SlowMotionDuration;
        }
    }
}
