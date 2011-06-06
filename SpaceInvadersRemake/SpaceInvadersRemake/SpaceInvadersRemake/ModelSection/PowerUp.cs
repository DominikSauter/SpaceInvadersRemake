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
        /// Diese Methode wird über ein <code>PowerUpAction</code>-Delegate in der <code>ActivePowerUp</code>-Klasse dazu benutzt den Effekt des PowerUps am Spieler anzuwenden.
        /// </summary>
        /// <param name="player">Der Spieler bei dem das PowerUp angewendet werden soll.</param>
        public abstract void Apply(Player player);

        /// <summary>
        /// Diese Methode wird über ein <code>PowerUpAction</code>-Delegate in der <code>ActivePowerUp</code>-Klasse dazu benutzt den Effekt des PowerUps am Spieler rückgängig zu machen.
        /// </summary>
        /// <param name="player">Der Spieler bei dem das PowerUp entfernt werden soll.</param>
        public abstract void Remove(Player player);
    }
}
