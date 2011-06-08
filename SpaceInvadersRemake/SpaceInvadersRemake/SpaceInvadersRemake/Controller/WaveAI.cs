using System.Collections.Generic;
using SpaceInvadersRemake.ModelSection;

namespace SpaceInvadersRemake.Controller
{
    /// <summary>
    /// Diese Klasse abstrahiert von den verschiedenen KIs zur Steurerung einer Welle von Gegnern
    /// </summary>
    /// <remarks>
    /// Von dieser Klasse ist für die Implementierung einer Wellen KI zu erben.
    /// </remarks>
    public abstract class WaveAI : AIController
    {
         
        /// <summary>
        /// Eigenschaft Controllees Liste (kontrollierte Objekt)
        /// </summary>
        public abstract System.Collections.Generic.ICollection<IGameItem> Controllees
        {
            get;

           set; 

        }
    }
}
