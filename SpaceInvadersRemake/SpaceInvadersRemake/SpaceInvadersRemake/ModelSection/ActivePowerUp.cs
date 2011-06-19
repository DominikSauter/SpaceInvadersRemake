using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace SpaceInvadersRemake.ModelSection
{
    /// <summary>
    /// Diese Klasse stellt ein aktives PowerUps dar, das beim Spieler wirksam ist.
    /// </summary>
    /// <remarks>Die Ausführung der PowerUps auf dem Spieler wird über die Delegates <c>Apply</c> und <c>Remove</c> gelöst. Die Funtionen müssen von den <c>PowerUps</c>-Unterklassen bereitgestellt werden.</remarks>
    public class ActivePowerUp
    {
        /// <summary>
        /// Erzeugt ein <c>ActivePowerUp</c>
        /// </summary>
        /// <param name="timeLeft">Die Wirkungsdauer des PowerUps</param>
        /// <param name="apply">Die Funktion, mit der das PowerUps angewendet wird</param>
        /// <param name="remove">Die Funktion, mit der das PowerUps rückgängig gemacht wird</param>
        public ActivePowerUp(float timeLeft, PowerUpAction apply, PowerUpAction remove)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Die verbleibende Wirkungsdauer des PowerUps
        /// </summary>
        public float TimeLeft
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        /// <summary>
        /// Die Funktion (Delegate), mit der das PowerUps rückgängig gemacht wird
        /// </summary>
        public PowerUpAction Remove
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        /// <summary>
        /// Die Funktion (Delegate), mit der das PowerUps angewendet wird
        /// </summary>
        public PowerUpAction Apply
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        /// <summary>
        /// Der Typ des PowerUps
        /// </summary>
        public PowerUpEnum Type
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        /// <summary>
        /// Aktualisiert die verbleibende Zeit des ActivePowerUp
        /// </summary>
        /// <param name="gameTime">aktuelle Spielzeit</param>
        public void Update(GameTime gameTime)
        {
            throw new System.NotImplementedException();
        }
    }
}
