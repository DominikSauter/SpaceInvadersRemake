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
    /// Stellt die auf dem Bildschirm sichtbaren Schilde dar (genauer gesagt ein Exemplar).
    /// Dabei wird ein 3 dimensionales Rechteck erstellt, auf welches eine animierte Textur gesetzt wird.
    /// Bei der Textur haldelt es sich um ein Texture-Atlas, der mehrere 'Frames' beinhaltet. Bei jedem Update() bzw. 
    /// Draw() Aufruf wird der nächste Frame angezeigt, sodass eine Animation entsteht.
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
        private int update;

        //Hilfsarray, welches die Reihenfolge der Vertices festlegt
        private int[] indices;


        /// <summary>
        /// Erstellt eine Representation eines stationären Schildes.
        /// </summary>
        public ShieldRepresentation(Shield shield, GraphicsDeviceManager graphics)
        {
            this.texture = ViewContent.RepresentationContent.ShieldTexture;
            GameItem = shield;
            this.position = PlaneProjector.Convert2DTo3D(GameItem.Position);
            this.graphics = graphics;
            this.World = Matrix.CreateWorld(this.position, Vector3.Forward, Vector3.Up);
            this.effect = new BasicEffect(graphics.GraphicsDevice);
            this.update = 0;


            //Eckpunkte des Rechtecks
            this.vertices = new VertexPositionColorTexture[4];
            //6 Punkte für zwei polygone, um ein Rechteck zu zeichnen
            this.indices = new int[6];

            //Skalierung
            float scaleWidth = 0.03f;
            float scaleHeight = 0.03f;

            //Eckpunkte in 3D ebene "Aufstellen"
            Vector3 erect = new Vector3(0, 50, 0);

            //Viereck aufbauen
            Vector3 leftBot = PlaneProjector.Convert2DTo3D(new Vector2(-texture.Width / 2.0f, -texture.Height / 2.0f));
            Vector3 leftTop = PlaneProjector.Convert2DTo3D(new Vector2(-texture.Width / 2.0f, texture.Height / 2.0f));
            Vector3 rightBot = PlaneProjector.Convert2DTo3D(new Vector2(texture.Width / 2.0f, -texture.Height/2.0f));
            Vector3 rightTop = PlaneProjector.Convert2DTo3D(new Vector2(texture.Width / 2.0f, texture.Height / 2.0f));

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
            this.World = Matrix.CreateScale(scaleWidth, 0.0f, scaleHeight) * (Matrix.CreateRotationX(MathHelper.ToRadians(45)) * Matrix.CreateTranslation(this.position));

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

        /// <summary>
        /// Zeichnet das animierte Schild.
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            //DephStencilState setzen damit 3D und 2D Objekte gleichzeitig richtig angezeigt werden können
            this.graphics.GraphicsDevice.DepthStencilState = DepthStencilState.Default;   

            //Update Zähler um zu wissen wann das Frame welchseln soll.
            this.update++;

            //Texture Atlas Informationen
            int columns = 5;
            int rows = 5;
            int column = 0;
            int row = 0;
            float frameSize = 1 / 5f; // 1 wäre die Gesamtlänge vom Texture-Atlas

            //Animation: Fängt bei erstem Frame, in diesem Fall links unten, an und geht nach rechts und nach oben alle Frames durch
            //Geht zum nächsten Frame bei jedem Update
            if (this.update == 1) 
            {
                //Zähler zurücksetzen
                this.update = 0;

                //Aktueller Frame
                float positionColumn = column * frameSize;
                float positionRow = row * frameSize;

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
                column++;

                //Wenn die letzte Spalte erreicht ist, gehe zur ersten Spalte.
                if (column == (columns - 1))
                {
                    column = 0;

                    //Wenn die letze Reihe erreicht ist, fange wieder von vorne an.
                    if (row == (rows - 1))
                    {
                        row = 0;
                    }
                    //nächste Reihe
                    else
                    {
                        row++;
                    }
                }
            }

            //Setzt die Schildfarbe abhängig von den relativen HitPoints
            float relativeHP = (float)GameItem.Hitpoints / (float)GameItemConstants.ShieldHitpoints;

            //Verlauf von Grün über Gelb nach Rot
            Color shieldColor = new Color(1.0f - relativeHP, relativeHP, 0.0f);

            //Eckpunkte Einfärben, die die Schildfarbe definieren
            for (int i = 0; i < vertices.Length; i++)
            {
                vertices[i].Color = shieldColor;
            }

            effect.World = this.World;
            effect.TextureEnabled = true;
            effect.Texture = texture;
            effect.View = Camera;
            effect.Projection = Projection;
            effect.VertexColorEnabled = true;

            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();

                //Zeichnen des Rechteck Primitives mit der Schildtextur
                graphics.GraphicsDevice.DrawUserIndexedPrimitives(PrimitiveType.TriangleList, vertices, 0, 4, indices, 0, 2);
            }

        }
    }
}
