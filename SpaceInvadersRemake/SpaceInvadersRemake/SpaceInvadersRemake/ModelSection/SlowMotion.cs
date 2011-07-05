using Microsoft.Xna.Framework;

// Implementiert von Tobias

namespace SpaceInvadersRemake.ModelSection
{
    /// <summary>
    /// Diese Klasse stellt ein SlowMotion-PowerUps dar. Dieses PowerUps verlangsamt die Spielzeit.
    /// </summary>
    public class SlowMotion : PowerUp
    {
        /// <summary>
        /// Diese Methode wird über ein <c>PowerUpAction</c>-Delegate in der <c>ActivePowerUp</c>-Klasse 
        /// dazu benutzt den Effekt des PowerUps am Spieler anzuwenden.
        /// </summary>
        /// <param name="player">Der Spieler bei dem das PowerUps angewendet werden soll.</param>
        public override void Apply(Player player)
        {
            //TODO: Es muss noch eine möglichkeit geben, einen globalen Faktor für die Spielzeit zu setzen
        }

        /// <summary>
        /// Diese Methode wird über ein <c>PowerUpAction</c>-Delegate in der <c>ActivePowerUp</c>-Klasse 
        /// dazu benutzt den Effekt des PowerUps am Spieler rückgängig zu machen.
        /// </summary>
        /// <param name="player">Der Spieler bei dem das PowerUps entfernt werden soll.</param>
        public override void Remove(Player player)
        {
            //TODO: Spielgeschwindigkeit zurücksetzen, siehe Apply()
        }

        /// <summary>
        /// Erstellt ein SlowMotion-PowerUps
        /// </summary>
        /// <param name="position">Startposition</param>
        /// <param name="velocity">maximale Geschwindigkeit</param>
        public SlowMotion(Vector2 position, Vector2 velocity)
            : base (position, velocity)
        {
            type = PowerUpEnum.SlowMotion;
        }
    }
}
