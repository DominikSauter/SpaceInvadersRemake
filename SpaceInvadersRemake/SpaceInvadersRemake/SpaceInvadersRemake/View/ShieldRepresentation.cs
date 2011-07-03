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
        private float updateTimer = 0; //für die Animation
        private int update;

        int columns = 5;
        int rows = 5;
        int column = 0;
        int row = 0;
        float frameSize = 1 / 5f; // 1 wäre die Gesamtlänge vom Texture Atlas


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
            this.update = 0;
            //this.updateTimer = 0;


            //Eckpunkte des Rechtecks
            this.vertices = new VertexPositionColorTexture[4];
            //6 Punkte für zwei polygone, um ein Rechteck zu zeichnen
            this.indices = new int[6];

            //Skalierung
            float scaleWidth = 0.015f;
            float scaleHeight = 0.015f;

            //Eckpunkte in 3D ebene "Aufstellen"
            Vector3 erect = new Vector3(0, 50, 0);

            //Viereck aufbauen
            Vector3 leftBot = PlaneProjector.Convert2DTo3D(new Vector2(-texture.Width, -texture.Height));
            Vector3 leftTop = PlaneProjector.Convert2DTo3D(new Vector2(-texture.Width, texture.Height));
            Vector3 rightBot = PlaneProjector.Convert2DTo3D(new Vector2(texture.Width, -texture.Height));
            Vector3 rightTop = PlaneProjector.Convert2DTo3D(new Vector2(texture.Width, texture.Height));

            Vector2 textureLeftBot = new Vector2(0, 0);
            Vector2 textureLeftTop = new Vector2(0, 1 / 5f);
            Vector2 textureRightBot = new Vector2(1 / 5f, 0);
            Vector2 textureRightTop = new Vector2(1 / 5f, 1 / 5f);

            Color color2 = new Color(0, 150, 255);
            Color color1 = new Color(0, 210, 255);
            vertices[0] = new VertexPositionColorTexture(leftBot, color1, textureLeftBot);
            vertices[1] = new VertexPositionColorTexture(leftTop, color1, textureLeftTop);
            vertices[2] = new VertexPositionColorTexture(rightBot, color2, textureRightBot);
            vertices[3] = new VertexPositionColorTexture(rightTop, color2, textureRightTop);


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
            //this.updateTimer += gameTime.TotalGameTime.Seconds; 


            //Animation: Fängt bei erstem Frame (hier links unten) an und geht nach rechts und nach oben alle Frames durch

            this.update++;

            //Nächster Frame bei jedem Update
            if (this.update == 1) //this.updateTimer >= 2
            {
                //this.updateTimer = 0;
                this.update = 0;

                //Aktueller Frame
                float positionColumn = this.column * this.frameSize;
                float positionRow = this.row * this.frameSize;

                //Texturkoordinaten anpassen (zum nächsten Frame bewegen)
                Vector2 textureLeftBot = new Vector2(positionColumn, positionRow);
                Vector2 textureLeftTop = new Vector2(positionColumn, positionRow + frameSize);
                Vector2 textureRightBot = new Vector2(positionColumn + frameSize, positionRow);
                Vector2 textureRightTop = new Vector2(positionColumn + frameSize, positionRow + frameSize);

                //neue FrameTextur setzen
                vertices[0].TextureCoordinate = textureLeftBot;
                vertices[1].TextureCoordinate = textureLeftTop;
                vertices[2].TextureCoordinate = textureRightBot;
                vertices[3].TextureCoordinate = textureRightTop;

                //nächster Frame
                this.column++;

                //wenn letze Spalte fange von Spalte 0 an
                if (this.column == (this.columns - 1))
                {
                    this.column = 0;
                    // wenn letzte Reihe fange von Reihe 0 an
                    if (this.row == (this.rows - 1))
                    {
                        this.row = 0;
                    }
                        // ansonsten nächte Reihe
                    else
                    {
                        this.row++;
                    }
                }

            }

            effect.World = this.World;
            effect.TextureEnabled = true;
            effect.Texture = texture;
            effect.View = Camera;
            effect.Projection = Projection;
            //effect.DiffuseColor = new Vector3(0, 144, 255);
            effect.VertexColorEnabled = true;

            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                graphics.GraphicsDevice.DrawUserIndexedPrimitives(PrimitiveType.TriangleList, vertices, 0, 4, indices, 0, 2);
            }

        }
    }
}
