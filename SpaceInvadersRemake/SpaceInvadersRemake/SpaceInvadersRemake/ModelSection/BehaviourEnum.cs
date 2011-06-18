using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvadersRemake.ModelSection
{


    /// <summary>
    /// Enumeration zur Festlegung der AI, d.h. des gewünschten Controllers.
    /// </summary>
    /// <remarks>
    /// Um Erweiterbarkeit zu erlauben ist diese Enum nicht als abgeschlossen anzusehen.
    /// Insbesondere bei switch case muss darrauf geachtet werden.
    /// </remarks>
    public enum BehaviourEnum
    {
        //TODO Überprüfen ob euch das so gefällt @model group -CK    
        //Es sind nur vorhandene AIs aufgeführt (die schon eine konkrete Klasse haben)

        /// <summary>
        /// Stellt eine Bewegung im Block dar.
        /// </summary>
        /// <remarks>
        /// Verhalten: Im kollektiv nach rechts bis der Erste am Rand anstößt danach bewegen sich alle
        /// nach unten und danach nach links bis zum Rand, dann wieder nach unten. Goto Verhalten.
        /// </remarks>
        BlockMovement,
        /// <summary>
        /// Stellt das vom original Space Invaders bekannte Mutterschiffverhalten dar.
        /// </summary>
        /// <remarks>
        /// Verhalten: Bewegung nach Links
        /// </remarks>
        MothershipMovement,
  
        
    }
}
