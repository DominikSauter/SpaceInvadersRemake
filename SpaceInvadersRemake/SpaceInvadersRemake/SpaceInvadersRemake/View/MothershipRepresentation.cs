//Implementiert von Dodo
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
        private GraphicsDeviceManager graphics;
        private Model model;
        private Texture2D mothershipTexture;
        private Vector3 lastPosition;
        private MothershipEngine mothershipEngine;

        /*
         * <WAHL>
         * Wird benötigt falls eine Partikel Engine eingebaut wird
        private Explosion explosion;
         * */


        /// <summary>
        /// Erstellt eine Representation des Mutterschiff-Aliens.
        /// </summary>
        public MothershipRepresentation(Mothership mothershipGameItem, GraphicsDeviceManager graphics)
        {
            this.graphics = graphics;
            this.model = ViewContent.RepresentationContent.MothershipModel;
            GameItem = mothershipGameItem;
            this.mothershipTexture = ViewContent.RepresentationContent.MothershipTexture;
            this.lastPosition = PlaneProjector.Convert2DTo3D(GameItem.Position);
            this.World = Matrix.CreateWorld(lastPosition, Vector3.Right, Vector3.Up);

            //[Anji] Schiffs-Antrieb
            this.mothershipEngine = (MothershipEngine)createParticleEngine(ViewContent.RepresentationContent.MothershipEngineTexture, PlaneProjector.ToScreenCoordinates(lastPosition, graphics), 1f, new Color(255, 96, 167));
      
        }


        //[Anji] Erzeugt eine Partikel Engine für den Schiffsantrieb 
        private ParticleEngine createParticleEngine(Texture2D texture, Vector2 location, float size, Color color)
        {
            this.mothershipEngine = new MothershipEngine(texture, location, size, color, graphics);
            return mothershipEngine;
        }

        /// <summary>
        /// Zeichnet das Mutterschiff auf den Bildschirm
        /// </summary>
        /// <param name="spriteBatch">SpriteBatch zum Zeichnen</param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            Vector3 currentPosition = PlaneProjector.Convert2DTo3D(GameItem.Position);
            //Bei jeder Bewegung wird die Worldmatrix neu gesetzt und die Hitsphere angepasst.
            if (currentPosition.X > this.lastPosition.X || currentPosition.X < this.lastPosition.X)
            {
                this.World = Matrix.CreateWorld(currentPosition, Vector3.Right, Vector3.Up);
                ((ModelHitsphere)GameItem.BoundingVolume).World = World;
                this.lastPosition = currentPosition;
            }

            //[Anji]
            mothershipEngine.EmitterLocation = PlaneProjector.ToScreenCoordinates(lastPosition + new Vector3(-45, 0, 0), graphics);
            mothershipEngine.Draw(spriteBatch);

            /*
             * WICHTIG!
             * Zurücksetzen des DepthStencils um eine fehlerfreie Kombination von 2D-Sprite und 3D-Model 
             * zeichnen zu können.
             * */
            this.graphics.GraphicsDevice.DepthStencilState = DepthStencilState.Default;

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
