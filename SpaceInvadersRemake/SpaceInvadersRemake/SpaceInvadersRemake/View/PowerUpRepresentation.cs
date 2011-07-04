//Implementiert von Anji
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
    /// Stellt die von Aliens fallengelassenen PowerUps auf dem Bildschirm dar.
    /// </summary>
    /// <remarks>
    /// Hält die PartikelEngines für einen Glitzereffekt.
    /// </remarks>
    public class PowerUpRepresentation : GameItemRepresentation
    {
        private Texture2D texture;
        private Vector3 position;
        private GraphicsDeviceManager graphics;

        //Punkte der Polygone wo die Textur gezeichnet werden soll
        private VertexPositionColorTexture[] vertices;
        private BasicEffect effect;

        //Hilfs-Array zum Zusammensetzen der Polygone
        private int[] indices;
    
        /// <summary>
        /// Erstellt eine Representation eines PowerUps.
        /// </summary>
        public PowerUpRepresentation(PowerUp powerUp, Texture2D texture, GraphicsDeviceManager graphics, BasicEffect effect)
        {
            GameItem = powerUp;
            this.texture = texture;
            this.position = PlaneProjector.Convert2DTo3D(GameItem.Position);
            this.graphics = graphics;
            this.effect = effect;
            this.World = Matrix.CreateWorld(this.position, Vector3.Forward, Vector3.Up);

            //Eckpunkte des Rechtecks
            this.vertices = new VertexPositionColorTexture[4];
            //6 Punkte für zwei polygone, um ein Rechteck zu zeichnen
            this.indices = new int[6];

            //1. Polygon: Punkte 0,1,2 im Urzeigersinn
            indices[0] = 0;
            indices[1] = 1;
            indices[2] = 2;
            //2. Polygon: Punkte 1,3,2 im Urzeigersinn
            indices[3] = 1;
            indices[4] = 3;
            indices[5] = 2;

            //Viereck aufbauen
            Vector3 leftBot = PlaneProjector.Convert2DTo3D(new Vector2(-texture.Width, -texture.Height));
            Vector3 leftTop = PlaneProjector.Convert2DTo3D(new Vector2(-texture.Width, texture.Height));
            Vector3 rightBot = PlaneProjector.Convert2DTo3D(new Vector2(texture.Width, -texture.Height));
            Vector3 rightTop = PlaneProjector.Convert2DTo3D(new Vector2(texture.Width, texture.Height));

            vertices[0] = new VertexPositionColorTexture(leftBot, Color.Red, new Vector2(0, 0));
            vertices[1] = new VertexPositionColorTexture(leftTop, Color.Red, new Vector2(0, 1));
            vertices[2] = new VertexPositionColorTexture(rightBot, Color.Red, new Vector2(1, 0));
            vertices[3] = new VertexPositionColorTexture(rightTop, Color.Red, new Vector2(1, 1));

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
        /// 
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            this.graphics.GraphicsDevice.DepthStencilState = DepthStencilState.Default;

            Vector3 newPosition = PlaneProjector.Convert2DTo3D(GameItem.Position);

            if (newPosition.Z > this.position.Z)
            {
                this.position = newPosition;
            }

            //TODO: Skalierung richtig setzen
            float scaleWidth = 0.05f;
            float scaleHeight = 0.1f;

            //Positionieren
            this.World = Matrix.CreateScale(scaleWidth, 1, scaleHeight) * Matrix.CreateTranslation(this.position);

            effect.TextureEnabled = true;
            effect.Texture = texture;
            effect.View = Camera;
            effect.Projection = Projection;
            effect.World = this.World;

            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();

                graphics.GraphicsDevice.DrawUserIndexedPrimitives(PrimitiveType.TriangleList, vertices, 0, 4, indices, 0, 2);
            }
        }
    }
}
