using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvadersRemake.Controller
{
    /// <summary>
    /// Diese Klasse abstrahiert von den verschiedenen Steuerungen durch die KI
    /// </summary>
    /// <remarks>
    /// In den Abgeleiteten Klassen wird das Verhalten des Controllers durch die KI bestimmt
    /// Von dieser KLasse muss geerbt werden um eine KI-Eingabe zu impelmentieren.
    /// </remarks>
    public abstract class AIController : SpaceInvadersRemake.Controller.Controller
    {

        /// <summary>
        /// Getter/Setter der Schussfrequenz.
        /// </summary>
        /// <value>
        /// Die Schussfrequenz.
        /// </value>
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
