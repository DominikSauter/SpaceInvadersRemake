﻿//Implementiert von Anji
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

        //Winkel um den das PowerUp Modell immer gedreht wird (in °)
        private float angle;
        private float rotationSpeed;
        
    
        /// <summary>
        /// Erstellt eine Representation eines PowerUps.
        /// <param name="graphics">GraphicsDeviceManager</param>
        /// <param name="powerUp">übergebenes PowerUp-Objekt</param>
        /// <param name="texture">Textur des PowerUps</param>
        /// </summary>
        public PowerUpRepresentation(PowerUp powerUp, Texture2D texture, GraphicsDeviceManager graphics)
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

            //[WAHL]
            this.PowerUpGlow = null;
            //[/WAHL]
        }

        /// <summary>
        /// ParticleEmitter der einen Glitzereffekt erzeugt.
        /// </summary>
        public PowerUpGlow PowerUpGlow
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        private ParticleEngine createParticleEngine(System.Collections.Generic.List<Texture2D> textures, Vector2 location, float size)
        {
            throw new System.NotImplementedException();
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

        }
    }
}
