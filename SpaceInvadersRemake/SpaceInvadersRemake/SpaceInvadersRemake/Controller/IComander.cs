using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvadersRemake.Controller
{
    /// <summary>
    /// Muss von allen Klassen implementiert werden, die ein etwas kontrollieren.
    /// </summary>
    interface IComander
    {
        /// <summary>
        /// Erlaubt die Ausführung der Steuerung.
        /// </summary>
        /// <remarks>
        /// Wird vom ControllerManager aufgerufen immer dann wenn eine Interaktion des Controllers
        /// benötigt wird. In der Regel innerhalb des Gameloops.
        /// </remarks>
        void Update();
    }
}
