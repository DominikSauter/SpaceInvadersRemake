//Implementiert von Anji
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceInvadersRemake.ModelSection;

namespace SpaceInvadersRemake.View
{
    /// <summary>
    /// Stellt die von Aliens fallengelassenen PowerUps auf dem Bildschirm dar.
    /// </summary>
    /// <remarks>
    /// Hält die PartikelEngines für einen Glitzereffekt.
    /// </remarks>
    public class PowerUpRepresentation : GameItemRepresentation
    {
        private GraphicsDeviceManager graphics;
        private Model model;
        private Texture2D texture;
        private Vector3 position;
        private Color color;

        //Winkel um den das PowerUp Modell immer gedreht wird (in °)
        private float angle;
        private float rotationSpeed;

        /// <summary>
        /// ParticleEmitter der einen Glitzereffekt erzeugt.
        /// </summary>
        private PowerUpGlitter powerUpGlitter;
    
        /// <summary>
        /// Erstellt eine Representation eines PowerUps.
        /// <param name="graphics">GraphicsDeviceManager</param>
        /// <param name="powerUp">übergebenes PowerUp-Objekt</param>
        /// <param name="texture">Textur des PowerUps</param>
        /// </summary>
        public PowerUpRepresentation(PowerUp powerUp, Texture2D texture, Color color, GraphicsDeviceManager graphics)
        {
            GameItem = powerUp;
            this.texture = texture;
            this.model = ViewContent.RepresentationContent.PowerUp;
            this.position = PlaneProjector.Convert2DTo3D(GameItem.Position);
            this.graphics = graphics;

            //Winkel in °
            this.angle = 0.0f;
            this.rotationSpeed = 1.0f;
            this.World = Matrix.CreateWorld(this.position, Vector3.Forward, Vector3.Up);

            this.powerUpGlitter = (PowerUpGlitter)createParticleEngine(ViewContent.RepresentationContent.GlitterTexture, PlaneProjector.ToScreenCoordinates(position, graphics), 0.2f, color);
            this.color = color;

        }



        private ParticleEngine createParticleEngine(Texture2D texture, Vector2 location, float size, Color color)
        {
            //evtl. velocity von gameitem übergeben
            this.powerUpGlitter = new PowerUpGlitter(texture, location, size, color, graphics);
            return powerUpGlitter;
        }

        /// <summary>
        /// Zeichnet das PowerUp.
        /// </summary>
        /// <param name="spriteBatch">spriteBatch</param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            this.angle += rotationSpeed;

            Vector3 currentPosition = PlaneProjector.Convert2DTo3D(GameItem.Position);
            Matrix rotation = Matrix.CreateRotationZ(MathHelper.ToRadians(this.angle));
            this.World = rotation * Matrix.CreateWorld(currentPosition, Vector3.Backward, Vector3.Up);

            //Setzen der Hitsphere
            ((ModelHitsphere)GameItem.BoundingVolume).World = this.World;

            //DephStencilState setzen damit 3D und 2D Objekte gleichzeitig richtig angezeigt werden können
            this.graphics.GraphicsDevice.DepthStencilState = DepthStencilState.Default;

            foreach (ModelMesh mesh in model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.LightingEnabled = true;
                    effect.SpecularColor = new Vector3(1.0f, 1.0f, 1.0f);
                    effect.SpecularPower = 100.0f;
                    effect.DiffuseColor = new Vector3(1.0f, 1.0f, 1.0f);
                    effect.Texture = this.texture;
                    effect.View = Camera;
                    effect.Projection = Projection;
                    effect.World = this.World;
                }

                mesh.Draw();
            }

            //Glitter
            powerUpGlitter.EmitterLocation = PlaneProjector.ToScreenCoordinates(currentPosition, graphics);
            powerUpGlitter.Draw(spriteBatch);

        }
    }
}
