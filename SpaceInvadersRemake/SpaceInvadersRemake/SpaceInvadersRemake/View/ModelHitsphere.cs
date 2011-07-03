using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

// Implementiert von Dodo, Tobias

namespace SpaceInvadersRemake.View
{
    /// <summary>
    /// Objekte dieser Klasse stellen eine Hitbox dar, welche um ein 3D-Model gelegt wird um Kollisionsüberprüfung
    /// zu ermöglichen.
    /// </summary>
    public class ModelHitsphere : ModelSection.IBoundingVolume
    {
        private Matrix world;

        /// <summary>
        /// Erzeugt eine Hitsphere ohne innere Hitspheres
        /// </summary>
        /// <param name="outerSphere">Die äußere Hitsphere</param>
        public ModelHitsphere(BoundingSphere outerSphere)
        {
            this.OuterSphere = outerSphere;
            this.InnerSpheres = null;
            this.World = Matrix.Identity;
        }
        
        /// <summary>
        /// Erzeugt eine Hitsphere mit inneren Hitspheres.
        /// </summary>
        /// <remarks>
        /// Momentan ist noch keine hierarchische Kollisionsberechnung implementiert
        /// </remarks>
        /// <param name="outerSphere">Die äußere Hitsphere</param>
        /// <param name="innerSpheres">Liste mit innere Hitspheres um eine hierarchisches Kollisionsmodel zu ermöglichen.</param>
        public ModelHitsphere(BoundingSphere outerSphere, List<ModelHitsphere> innerSpheres)
            : this(outerSphere)
        {
            this.InnerSpheres = innerSpheres;
        }

        /// <summary>
        /// Kopierkonstruktor, erstellt eine seichte Kopie der BoundingSpheres erstellt aber eine neue World-Matrix
        /// </summary>
        /// <param name="modelHitsphere">Die originale ModelHitsphere</param>
        public ModelHitsphere(ModelHitsphere modelHitsphere)
        {
            this.OuterSphere = modelHitsphere.OuterSphere;
            this.InnerSpheres = modelHitsphere.InnerSpheres;
            this.World = Matrix.Identity;
        }
    
        /// <summary>
        /// Liste von <c>ModelHitsphere</c> Objekten, um eine hierarchische Anordnung von Hitspheres
        /// um ein 3D-Model zu ermöglichen.
        /// </summary>
        public System.Collections.Generic.List<ModelHitsphere> InnerSpheres
        {
            get;
            set;
        }

        /// <summary>
        /// Die äußere Hitsphere
        /// </summary>
        public BoundingSphere OuterSphere
        {
            get;
            set;
        }

        /// <summary>
        /// Die World-Matrix, mit der die Hitsphere vor der Kollisionserkennung Transformiert wird
        /// </summary>
        public Matrix World
        {
            get
            {
                return this.world;
            }
            set
            {
                this.world = value;
                /*if (InnerSpheres != null)
                {
                    foreach (ModelHitsphere sphere in InnerSpheres)
                    {
                        sphere.world = value;
                    }
                }*/
            }
        }

        public bool Intersects(ModelSection.IBoundingVolume other)
        {
            //HACK: Innere Kugeln müssen noch betrachtet werden

            ModelHitsphere otherSphere = (ModelHitsphere)other;

            if (OuterSphere.Transform(World).Intersects(otherSphere.OuterSphere.Transform(otherSphere.World)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}