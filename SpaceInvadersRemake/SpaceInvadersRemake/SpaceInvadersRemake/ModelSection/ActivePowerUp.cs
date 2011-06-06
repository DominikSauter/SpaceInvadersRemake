using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvadersRemake.ModelSection
{
    /// <summary>
    /// Diese Klasse stellt ein aktives PowerUp dar, das beim Spieler wirksam ist.
    /// </summary>
    /// <remarks>Die Ausführung der PowerUps auf dem Spieler wird über die Delegates <code>Apply</code> und <code>Remove</code> gelöst. Die Funtionen müssen von den PowerUp-Unterklassen bereitgestellt werden.</remarks>
    public class ActivePowerUp
    {
        public ActivePowerUp(float timeLeft, PowerUpAction apply, PowerUpAction remove)
        {
            throw new System.NotImplementedException();
        }
    
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
    }
}
