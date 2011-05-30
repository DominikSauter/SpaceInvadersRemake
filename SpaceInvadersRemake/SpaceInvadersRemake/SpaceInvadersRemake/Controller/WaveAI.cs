using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvadersRemake
{
    /// <summary>
    /// Diese Klasse abstrahiert von den verschiedenen KIs zur Steurerung einer Welle von Gegnern
    /// </summary>
    public abstract class WaveAI : AIController
    {

        /// <summary>
        /// Eigenschaft Controllee Liste (kontrollierte Objekt)
        /// </summary>
        public abstract override List<IGameItem> Controllee
        {
            get;
            set;
        }
    }
}
