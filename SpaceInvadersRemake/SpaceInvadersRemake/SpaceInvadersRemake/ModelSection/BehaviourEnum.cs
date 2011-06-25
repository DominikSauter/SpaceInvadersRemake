using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Implementiert von D. Sauter in Zusammenarbeit mit der Controller-Gruppe

namespace SpaceInvadersRemake.ModelSection
{
    /// <summary>
    /// Enumeration zur Festlegung der AI, d.h. des gewünschten Controllers.
    /// </summary>
    /// <remarks>
    /// Um Erweiterbarkeit zu erlauben ist diese Enum nicht als abgeschlossen anzusehen.
    /// Insbesondere bei switch case muss darauf geachtet werden.
    /// </remarks>
    public enum BehaviourEnum
    {
        /// <summary>
        /// Stellt eine Bewegung im Block dar.
        /// </summary>
        /// <remarks>
        /// Verhalten: Im Kollektiv nach rechts bis der Erste am Rand anstößt, danach bewegen sich alle
        /// nach unten und danach nach links bis zum Rand, dann wieder nach unten. Goto Verhalten.
        /// </remarks>
        BlockMovement,

        /// <summary>
        /// Stellt das vom originalen Space Invaders bekannte Mutterschiffverhalten dar.
        /// </summary>
        /// <remarks>
        /// Verhalten: Bewegung nach links
        /// </remarks>
        MothershipMovement
    }
}
