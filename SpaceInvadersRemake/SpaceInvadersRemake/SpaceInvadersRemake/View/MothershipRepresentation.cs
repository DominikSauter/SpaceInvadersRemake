using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using SpaceInvadersRemake.ModelSection;

namespace SpaceInvadersRemake.View
{
    /// <summary>
    /// Stellt das auf dem Bildschirm sichtbare Mutterschiff dar.
    /// </summary>
    /// <remarks>
    /// Hält die PartikelEngines für Antrieb und Explosionen.
    /// </remarks>
    public class MothershipRepresentation : GameItemRepresentation
    {
        private Model model;
        private Texture2D mothershipTexture;
        private Vector3 lastPosition;
        
        /// <summary>
        /// ParticleEmitter der einen Explosionseffekt erzeugt.
        /// </summary>
        /// <remarks>
        /// Wird Anfangs instanziiert aber erst bei Zerstörung des Schiffs gestartet.
        /// </remarks>
        private Explosion explosion;
        
        /// <summary>
        /// ParticleEmitter der einen Effekt erzeugt, welcher den Antrieb des Mutterschiffs darstellt.
        /// </summary>
        private MothershipEngine mothershipEngine;

        /// <summary>
        /// Erstellt eine Representation des Mutterschiff-Aliens.
        /// </summary>
        public MothershipRepresentation(Mothership mothershipGameItem)
        {
            this.model = ViewContent.RepresentationContent.MothershipModel;
            GameItem = mothershipGameItem;
            this.mothershipTexture = ViewContent.RepresentationContent.MothershipTexture;
            this.lastPosition = PlaneProjector.Convert2DTo3D(GameItem.Position);
            this.World = Matrix.CreateWorld(lastPosition, Vector3.Right, Vector3.Up);

            //[WAHL]
            this.mothershipEngine = null;
            this.explosion = null;
            //[/WAHL]
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Vector3 currentPosition = PlaneProjector.Convert2DTo3D(GameItem.Position);
            if (currentPosition.X > this.lastPosition.X || currentPosition.X < this.lastPosition.X)
            {
                this.World = Matrix.CreateWorld(currentPosition, Vector3.Right, Vector3.Up);
                this.lastPosition = currentPosition;
            }

            foreach (ModelMesh mesh in model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.LightingEnabled = true;
                    effect.SpecularColor = new Vector3(1.0f, 1.0f, 1.0f);
                    effect.SpecularPower = 100.0f;
                    effect.DiffuseColor = new Vector3(1.0f, 1.0f, 1.0f);
                    effect.Texture = this.mothershipTexture;
                    effect.World = this.World;
                    effect.View = Camera;
                    effect.Projection = Projection;
                }

                mesh.Draw();
            }
        }
    }
}
