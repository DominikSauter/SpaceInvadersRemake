using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvadersRemake.ModelSection
{
    /// <summary>
    /// Diese abstrakte Klasse ist die Überklasse aller PowerUps.
    /// </summary>
    public abstract class PowerUp : GameItem
    {

        /// <summary>
        /// Diese Methode wird über ein "PowerUpAction"-Delegate in der "ActivePowerUp"-Klasse dazu benutzt den Effekt des PowerUps am Spieler anzuwenden.
        /// </summary>
        /// <param name="player">Der Spieler bei dem das PowerUp angewendet werden soll.</param>
        public abstract void Apply(Player player);

        /// <summary>
        /// Diese Methode wird über ein "PowerUpAction"-Delegate in der "ActivePowerUp"-Klasse dazu benutzt den Effekt des PowerUps am Spieler rückgängig zu machen.
        /// </summary>
        /// <param name="player">Der Spieler bei dem das PowerUp entfernt werden soll.</param>
        public abstract void Remove(Player player);

        /// <summary>
        /// Bewegt das Objekt in die gewünschte Richtung
        /// </summary>
        /// <param name="direction">Bewegungsrichtung</param>
        public override void Move(Microsoft.Xna.Framework.Vector2 direction)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// In dieser Methode wird alles geupdatet, was nicht durch einen Controller beeinflusst werden kann.
        /// </summary>
        /// <param name="gameTime">Spielzeit</param>
        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
