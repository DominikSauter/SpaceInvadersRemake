using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvadersRemake.Controller
{
    /// <summary>
    /// Diese Klasse abstrahiert von den verschiedenen Steuerungen durch die KI
    /// </summary>
    /// <remarks>In den Abgeleiteten Klassen wird das Verhalten des Controllers durch die KI bestimmt</remarks>
    public abstract class AIController : SpaceInvadersRemake.Controller.Controller
    {

        public int ShootingFrequency
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
