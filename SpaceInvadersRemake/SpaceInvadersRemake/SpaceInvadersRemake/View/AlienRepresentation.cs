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
    /// Stellt die auf dem Bildschirm sichtbaren Aliens dar.
    /// </summary>
    /// <remarks>
    /// Hält die PartikelEngines für Explosionen.
    /// </remarks>
    public class AlienRepresentation : GameItemRepresentation
    {
        private Model model;

        /// <summary>
        /// Referenz auf ein Alien-Modelobjekt um jegliche Abfragen im Model zu tätigen.
        /// </summary>
        private Alien alienGameItem;

        /// <summary>
        /// ParticleEmitter der einen Explosionseffekt erzeugt.
        /// </summary>
        /// <remarks>
        /// Wird Anfangs instanziiert aber erst bei Zerstörung des Schiffs gestartet.
        /// </remarks>
        private Explosion explosion;

        /// <summary>
        /// Erstellt eine Representation eines Aliens.
        /// </summary>
        public AlienRepresentation(Alien alienGameItem)
        {
            this.model = ViewContent.RepresentationContent.AlienModel;
            this.alienGameItem = alienGameItem;

            this.World = Matrix.CreateWorld(PlaneProjector.Convert2DTo3D(this.alienGameItem.Position), Vector3.Forward, Vector3.Up);

            //[WAHL]
            this.explosion = null;
            //[/WAHL]
        }

        private ParticleEngine createParticleEngine(System.Collections.Generic.List<Texture2D> textures, Vector2 location, float size)
        {
            throw new System.NotImplementedException();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            foreach (ModelMesh mesh in model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.LightingEnabled = true;
                    effect.SpecularColor = new Vector3(1.0f, 1.0f, 1.0f);
                    effect.SpecularPower = 100.0f;
                    effect.DiffuseColor = new Vector3(1.0f, 1.0f, 1.0f);
                    effect.World = this.World * Matrix.CreateTranslation(PlaneProjector.Convert2DTo3D(this.alienGameItem.Position));
                    effect.View = Camera;
                    effect.Projection = Projection;
                }

                mesh.Draw();
            }
        }
    }
}
