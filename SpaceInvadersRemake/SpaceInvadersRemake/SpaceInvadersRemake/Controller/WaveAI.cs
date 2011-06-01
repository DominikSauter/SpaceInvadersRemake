using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvadersRemake.Controller
{
    /// <summary>
    /// Diese Klasse abstrahiert von den verschiedenen KIs zur Steurerung einer Welle von Gegnern
    /// </summary>
    public abstract class SwarmAI : AIController
    {

        /// <summary>
        /// Eigenschaft Controllee Liste (kontrollierte Objekt)
        /// </summary>
        public override List<IGameItem> Controllee
        {
            get
            {
                throw new NotImplementedException();
            }
            set { 
            }
        }
    }
}
