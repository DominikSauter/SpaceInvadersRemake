using System;
using Microsoft.Xna.Framework;

// Implementiert von Tobias

namespace SpaceInvadersRemake.ModelSection
{
    /// <summary>
    /// Diese abstrakte Klasse ist die Überklasse aller PowerUps die von abgeschossenen Gegnern erzeugt
    /// werden und vom Spieler eingesammelt werden können.
    /// </summary>
    public abstract class PowerUp : GameItem
    {

        /// <summary>
        /// Diese Methode wird über ein <c>PowerUpAction</c>-Delegate in der <c>ActivePowerUp</c>-Klasse 
        /// dazu benutzt den Effekt des PowerUps am Spieler anzuwenden.
        /// </summary>
        /// <param name="player">Der Spieler bei dem das PowerUps angewendet werden soll.</param>
        public abstract void Apply(Player player);

        /// <summary>
        /// Diese Methode wird über ein <c>PowerUpAction</c>-Delegate in der <c>ActivePowerUp</c>-Klasse 
        /// dazu benutzt den Effekt des PowerUps am Spieler rückgängig zu machen.
        /// </summary>
        /// <param name="player">Der Spieler bei dem das PowerUps entfernt werden soll.</param>
        public abstract void Remove(Player player);

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Konstruktor um Redundanz zu vermeiden
        /// </summary>
        /// <param name="position">Startposition</param>
        /// <param name="velocityMultiplier">Maximale Geschwindigkeit</param>
        public PowerUp(Vector2 position, Vector2 velocity)
            : base(position, velocity, 1, 0)
        {
            throw new NotImplementedException();
        }
    }
}
