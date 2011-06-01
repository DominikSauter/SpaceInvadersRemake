using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvadersRemake
{
    /// <summary>
    /// Objekte dieser Klasse stellen eine Hitbox dar, welche um ein 3D-Model gelegt wird um Kollisionsüberprüfung
    /// zu ermöglichen.
    /// </summary>
    public class ModelHitsphere
    {
        /// <summary>
        /// Erzeugt eine kugelförmige Hitbox.
        /// </summary>
        public ModelHitsphere()
        {
            throw new System.NotImplementedException();
        }
    
        /// <summary>
        /// Liste von <c>ModelHitsphere</c> Objekten, um eine hierarchische Anordnung von Hitboxen
        /// um ein 3D-Model zu ermöglichen.
        /// </summary>
        public System.Collections.Generic.List<ModelHitsphere> Hitspheres
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
        /// Radius der kugelförmigen Hitbox.
        /// </summary>
        public int Radius
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