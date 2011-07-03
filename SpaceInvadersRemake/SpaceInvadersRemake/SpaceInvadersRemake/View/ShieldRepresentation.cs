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
    /// Stellt die auf dem Bildschirm sichtbaren Schilde dar.
    /// </summary>
    /// <remarks>
    /// Hält die PartikelEngines für Explosionen.
    /// </remarks>
    public class ShieldRepresentation : GameItemRepresentation
    {
        private Texture2D texture;
        private GraphicsDeviceManager graphics;
        //3D Raumposition des Schildes
        private Vector3 position;
        //Eckpunkte des 3D-Rechteck-Models
        private VertexPositionColorTexture[] vertices;
        private BasicEffect effect;
        private GameTime gameTime;
        private float updateTime; //für die Animation

        private int[] indices;


        /// <summary>
        /// Erstellt eine Representation eines stationären Schildes.
        /// </summary>
        public ShieldRepresentation(Shield shield, GraphicsDeviceManager graphics, GameTime gameTime)
        {
            this.texture = ViewContent.RepresentationContent.ShieldTexture;
            GameItem = shield;
            this.gameTime = gameTime;
            this.position = PlaneProjector.Convert2DTo3D(GameItem.Position);
            this.graphics = graphics;
            this.World = Matrix.CreateWorld(this.position, Vector3.Forward, Vector3.Up);
            this.effect = new BasicEffect(graphics.GraphicsDevice);
            this.updateTime = 0;


            //Eckpunkte des Rechtecks
            this.vertices = new VertexPositionColorTexture[4];
            //6 Punkte für zwei polygone, um ein Rechteck zu zeichnen
            this.indices = new int[6];

            //Skalierung
            float scaleWidth = 0.1f;
            float scaleHeight = 0.1f;

            //Eckpunkte in 3D ebene "Aufstellen"
            Vector3 erect = new Vector3(0, 50, 0);

            //Viereck aufbauen
            Vector3 leftBot = PlaneProjector.Convert2DTo3D(new Vector2(-texture.Width, -texture.Height));
            Vector3 leftTop = PlaneProjector.Convert2DTo3D(new Vector2(-texture.Width, texture.Height));
            Vector3 rightBot = PlaneProjector.Convert2DTo3D(new Vector2(texture.Width, -texture.Height));
            Vector3 rightTop = PlaneProjector.Convert2DTo3D(new Vector2(texture.Width, texture.Height));

            //Animation
            int columns = 5;
            int rows = 5;
            int colum = 0;
            int row = 0;
            float frameLength = 1 / 5; // 1 wäre die Gesamtlänge vom Texture Atlas

            //Bei jedem 5ten Update
            //if (updateTime == 5)
            //{
            //    Vector2 textureLeftBot = new Vector2(0, 0);
            //    Vector2 textureLeftTop = new Vector2(0, 1);
            //    Vector2 textureRightBot = new Vector2(1, 0);
            //    Vector2 textureRightTop = new Vector2(1, 1);
            //}


            Vector2 textureLeftBot = new Vector2(0, 0);
            Vector2 textureLeftTop = new Vector2(0, 1);
            Vector2 textureRightBot = new Vector2(1, 0);
            Vector2 textureRightTop = new Vector2(1, 1);

            vertices[0] = new VertexPositionColorTexture(leftBot, Color.Red, textureLeftBot);
            vertices[1] = new VertexPositionColorTexture(leftTop, Color.Red, textureLeftTop);
            vertices[2] = new VertexPositionColorTexture(rightBot, Color.Red, textureRightBot);
            vertices[3] = new VertexPositionColorTexture(rightTop, Color.Red, textureRightTop);

            //Positionieren
            this.World = Matrix.CreateScale(scaleWidth, 1, scaleHeight) * (Matrix.CreateRotationX(MathHelper.ToRadians(45)) * Matrix.CreateTranslation(this.position));

            //1. Polygon: Punkte 0,1,2 im Urzeigersinn
            indices[0] = 0;
            indices[1] = 1;
            indices[2] = 2;
            //2. Polygon: Punkte 1,3,2 im Urzeigersinn
            indices[3] = 1;
            indices[4] = 3;
            indices[5] = 2;

        }

        /// <summary>
        /// ParticleEmitter der einen Explosionseffekt erzeugt.
        /// </summary>
        /// <remarks>
        /// Wird Anfangs instanziiert aber erst bei Zerstörung des Schiffs gestartet.
        /// </remarks>
        public Explosion Explosion
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

        public override void Draw(SpriteBatch spriteBatch)
        {

            this.graphics.GraphicsDevice.DepthStencilState = DepthStencilState.Default;     //[Dodo]

            effect.World = this.World;
            effect.TextureEnabled = true;
            effect.Texture = texture;
            effect.View = Camera;
            effect.Projection = Projection;

            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                graphics.GraphicsDevice.DrawUserIndexedPrimitives(PrimitiveType.TriangleList, vertices, 0, 4, indices, 0, 2);
            }

            //updateTime += (float)gameTime.ElapsedGameTime.TotalSeconds; 
        }
    }
}
