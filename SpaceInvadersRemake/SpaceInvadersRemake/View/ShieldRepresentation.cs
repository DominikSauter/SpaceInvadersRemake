//Implementiert von Anji
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

        //Hilfsarrays für Texturkoordinaten
        private Vector2[] leftRectTexCoords;
        private Vector2[] middleRectTexCoords;
        private Vector2[] rightRectTexCoords;

        //Hilfsgrößen zur Texturkoordinatenberechnung
        private int shieldSize;
        private int borderSize;
        private float relBorderSize;

        //Texture Atlas Informationen
        int columns = 5;
        int rows = 5;
        int column = 0;
        int row = 0;
        float frameSize = 1 / 5f; // 1 wäre die Gesamtlänge vom Texture-Atlas



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

            // UNDONE: alter Code - TB
            ////Eckpunkte des Rechtecks
            //this.vertices = new VertexPositionColorTexture[4];
            ////6 Punkte für zwei polygone, um ein Rechteck zu zeichnen
            //this.indices = new int[6];

            ////Skalierung
            //float scaleWidth = 0.03f;
            //float scaleHeight = 0.03f;

            ////Eckpunkte in 3D ebene "Aufstellen"
            //Vector3 erect = new Vector3(0, 50, 0);

            ////Viereck aufbauen
            //Vector3 leftBot = PlaneProjector.Convert2DTo3D(new Vector2(-texture.Width / 2.0f, -texture.Height / 2.0f));
            //Vector3 leftTop = PlaneProjector.Convert2DTo3D(new Vector2(-texture.Width / 2.0f, texture.Height / 2.0f));
            //Vector3 rightBot = PlaneProjector.Convert2DTo3D(new Vector2(texture.Width / 2.0f, -texture.Height/2.0f));
            //Vector3 rightTop = PlaneProjector.Convert2DTo3D(new Vector2(texture.Width / 2.0f, texture.Height / 2.0f));

            //Vector2 textureLeftBot = new Vector2(0, 0);
            //Vector2 textureLeftTop = new Vector2(0, 1 / 5f);
            //Vector2 textureRightBot = new Vector2(1 / 5f, 0);
            //Vector2 textureRightTop = new Vector2(1 / 5f, 1 / 5f);

            //Color color2 = new Color(0, 150, 255);
            //Color color1 = new Color(0, 210, 255);
            //vertices[0] = new VertexPositionColorTexture(leftBot, color1, textureLeftBot);
            //vertices[1] = new VertexPositionColorTexture(leftTop, color1, textureLeftTop);
            //vertices[2] = new VertexPositionColorTexture(rightBot, color2, textureRightBot);
            //vertices[3] = new VertexPositionColorTexture(rightTop, color2, textureRightTop);


            ////Positionieren
            //this.World = Matrix.CreateScale(scaleWidth, 0.0f, scaleHeight) * (Matrix.CreateRotationX(MathHelper.ToRadians(45)) * Matrix.CreateTranslation(this.position));

            ////1. Polygon: Punkte 0,1,2 im Urzeigersinn
            //indices[0] = 0;
            //indices[1] = 1;
            //indices[2] = 2;
            ////2. Polygon: Punkte 1,3,2 im Urzeigersinn
            //indices[3] = 1;
            //indices[4] = 3;
            //indices[5] = 2;


            // neuer Code - TB

            //Eckpunkte der Rechtecke
            this.vertices = new VertexPositionColorTexture[12];
            //18 Punkte für 6 polygone, um 3 Rechtecke zu zeichnen
            this.indices = new int[18];

            //Skalierung
            float scaleWidth = 0.03f;
            float scaleHeight = 0.03f;

            //Größe des Schilds
            shieldSize = 750;
            //Größe des Schildrandes
            borderSize = 75;
            //Relative Größe des Randes zum ganzen Schild
            relBorderSize = (float)borderSize / (float)shieldSize;

            //Vierecke aufbauen
            Vector3[] leftRect = new Vector3[4];
            Vector3[] middleRect = new Vector3[4];
            Vector3[] rightRect = new Vector3[4];

            leftRect[0] = PlaneProjector.Convert2DTo3D(new Vector2(-texture.Width / 2.0f, -texture.Height / 2.0f)); //links unten
            leftRect[1] = PlaneProjector.Convert2DTo3D(new Vector2(-texture.Width / 2.0f, texture.Height / 2.0f)); //links oben
            leftRect[2] = PlaneProjector.Convert2DTo3D(new Vector2(-texture.Width / 2.0f + borderSize, -texture.Height / 2.0f)); //rechts unten
            leftRect[3] = PlaneProjector.Convert2DTo3D(new Vector2(-texture.Width / 2.0f + borderSize, texture.Height / 2.0f)); //rechts oben

            middleRect[0] = PlaneProjector.Convert2DTo3D(new Vector2(-texture.Width / 2.0f + borderSize, -texture.Height / 2.0f)); //links unten
            middleRect[1] = PlaneProjector.Convert2DTo3D(new Vector2(-texture.Width / 2.0f + borderSize, texture.Height / 2.0f)); //links oben
            middleRect[2] = PlaneProjector.Convert2DTo3D(new Vector2(texture.Width / 2.0f - borderSize, -texture.Height / 2.0f)); //rechts unten
            middleRect[3] = PlaneProjector.Convert2DTo3D(new Vector2(texture.Width / 2.0f - borderSize, texture.Height / 2.0f)); //rechts oben

            rightRect[0] = PlaneProjector.Convert2DTo3D(new Vector2(texture.Width / 2.0f - borderSize, -texture.Height / 2.0f)); //links unten
            rightRect[1] = PlaneProjector.Convert2DTo3D(new Vector2(texture.Width / 2.0f - borderSize, texture.Height / 2.0f)); //links oben
            rightRect[2] = PlaneProjector.Convert2DTo3D(new Vector2(texture.Width / 2.0f, -texture.Height / 2.0f)); //rechts unten
            rightRect[3] = PlaneProjector.Convert2DTo3D(new Vector2(texture.Width / 2.0f, texture.Height / 2.0f)); //rechts oben

            //Texturkoordinaten berechnen
            leftRectTexCoords = new Vector2[4];
            middleRectTexCoords = new Vector2[4];
            rightRectTexCoords = new Vector2[4];

            leftRectTexCoords[0] = new Vector2(0, 0); //links unten
            leftRectTexCoords[1] = new Vector2(0, 1 / 5f); //links oben
            leftRectTexCoords[2] = new Vector2(relBorderSize / 5f, 0); //rechts unten
            leftRectTexCoords[3] = new Vector2(relBorderSize / 5f, 1 / 5f); //rechts oben

            middleRectTexCoords[0] = new Vector2(relBorderSize / 5f, 0); //links unten
            middleRectTexCoords[1] = new Vector2(relBorderSize / 5f, 1 / 5f); //links oben
            middleRectTexCoords[2] = new Vector2((1.0f - relBorderSize) / 5f, 0); //rechts unten
            middleRectTexCoords[3] = new Vector2((1.0f - relBorderSize) / 5f, 1 / 5f); //rechts oben

            rightRectTexCoords[0] = new Vector2((1.0f - relBorderSize) / 5f, 0); //links unten
            rightRectTexCoords[1] = new Vector2((1.0f - relBorderSize) / 5f, 1 / 5f); //links oben
            rightRectTexCoords[2] = new Vector2(1.0f / 5f, 0); //rechts unten
            rightRectTexCoords[3] = new Vector2(1.0f / 5f, 1 / 5f); //rechts oben


            //Vertices erstellen
            for (int i = 0; i < 4; i++)
            {
                //linkes Viereck
                vertices[i] = new VertexPositionColorTexture(leftRect[i], Color.White, leftRectTexCoords[i]);
                //mittleres Viereck
                vertices[i+4] = new VertexPositionColorTexture(middleRect[i], new Color(0, 1.0f, 0), middleRectTexCoords[i]);
                //rechtes Viereck
                vertices[i + 8] = new VertexPositionColorTexture(rightRect[i], Color.White, rightRectTexCoords[i]);
            }
        
            //Indizes zuweisen
            for (int i = 0; i < 3; i++)
            {
                indices[6 * i + 0] = 0 + i * 4;
                indices[6 * i + 1] = 1 + i * 4;
                indices[6 * i + 2] = 2 + i * 4;
                indices[6 * i + 3] = 1 + i * 4;
                indices[6 * i + 4] = 3 + i * 4;
                indices[6 * i + 5] = 2 + i * 4;
            }

            //Positionieren
            this.World = Matrix.CreateScale(scaleWidth, 0.0f, scaleHeight) * (Matrix.CreateRotationX(MathHelper.ToRadians(45)) * Matrix.CreateTranslation(this.position));

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

            //Animation: Fängt bei erstem Frame, in diesem Fall links unten, an und geht nach rechts und nach oben alle Frames durch
            //Geht zum nächsten Frame bei jedem Update
            if (this.update == 1) 
            {
                //Zähler zurücksetzen
                this.update = 0;

                //Aktueller Frame
                float positionColumn = column * frameSize;
                float positionRow = row * frameSize;

                //UNDONE: alter Code - TB
                ////Texturkoordinaten anpassen (zum nächsten Frame bewegen)
                //Vector2 textureLeftBot = new Vector2(positionColumn, positionRow);
                //Vector2 textureLeftTop = new Vector2(positionColumn, positionRow + frameSize);
                //Vector2 textureRightBot = new Vector2(positionColumn + frameSize, positionRow);
                //Vector2 textureRightTop = new Vector2(positionColumn + frameSize, positionRow + frameSize);

                ////neue FrameTextur setzen
                //vertices[0].TextureCoordinate = textureLeftBot;
                //vertices[1].TextureCoordinate = textureLeftTop;
                //vertices[2].TextureCoordinate = textureRightBot;
                //vertices[3].TextureCoordinate = textureRightTop;

                //neuer Code - TB

                //Texturkoordinaten der Vierecke anpassen
                leftRectTexCoords[0] = new Vector2(positionColumn, positionRow); //links unten
                leftRectTexCoords[1] = new Vector2(positionColumn, positionRow + frameSize); //links oben
                leftRectTexCoords[2] = new Vector2(positionColumn + relBorderSize / 5f, positionRow); //rechts unten
                leftRectTexCoords[3] = new Vector2(positionColumn + relBorderSize / 5f, positionRow + frameSize); //rechts oben

                middleRectTexCoords[0] = new Vector2(positionColumn + relBorderSize / 5f, positionRow); //links unten
                middleRectTexCoords[1] = new Vector2(positionColumn + relBorderSize / 5f, positionRow + frameSize); //links oben
                middleRectTexCoords[2] = new Vector2(positionColumn + frameSize - relBorderSize / 5f, positionRow); //rechts unten
                middleRectTexCoords[3] = new Vector2(positionColumn + frameSize - relBorderSize / 5f, positionRow + frameSize); //rechts oben

                rightRectTexCoords[0] = new Vector2(positionColumn + frameSize - relBorderSize / 5f, positionRow); //links unten
                rightRectTexCoords[1] = new Vector2(positionColumn + frameSize - relBorderSize / 5f, positionRow + frameSize); //links oben
                rightRectTexCoords[2] = new Vector2(positionColumn + frameSize, positionRow); //rechts unten
                rightRectTexCoords[3] = new Vector2(positionColumn + frameSize, positionRow + frameSize); //rechts oben

                // Texturkoordinaten setzen
                for (int i = 0; i < 4; i++)
                {
                    //linkes Viereck
                    vertices[i].TextureCoordinate = leftRectTexCoords[i];
                    //mittleres Viereck
                    vertices[i + 4].TextureCoordinate = middleRectTexCoords[i];
                    //rechtes Viereck
                    vertices[i + 8].TextureCoordinate = rightRectTexCoords[i];
                }

                //nächster Frame
                this.column++;

                //Wenn die letzte Spalte erreicht ist, gehe zur ersten Spalte.
                if (this.column == (this.columns - 1))
                {
                    this.column = 0;

                    //Wenn die letze Reihe erreicht ist, fange wieder von vorne an.
                    if (this.row == (this.rows - 1))
                    {
                        this.row = 0;
                    }
                    //nächste Reihe
                    else
                    {
                        this.row++;
                    }
                }
            }

            //Setzt die Schildfarbe abhängig von den relativen HitPoints
            float relativeHP = (float)GameItem.Hitpoints / (float)GameItemConstants.ShieldHitpoints;

            //Verlauf von Grün über Gelb nach Rot
            Color shieldColor = new Color(1.0f - relativeHP, relativeHP, 0.0f);

            //UNDONE: alter Code - TB
            ////Eckpunkte Einfärben, die die Schildfarbe definieren
            //for (int i = 0; i < vertices.Length; i++)
            //{
            //    vertices[i].Color = shieldColor;
            //}

            // neuer Code - TB
            //Eckpunkte des mittleren Rechtecks Einfärben, die die Schildfarbe definieren
            for (int i = 4; i < 8; i++)
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
                //UNDONE: alter Code - TB
                //graphics.GraphicsDevice.DrawUserIndexedPrimitives(PrimitiveType.TriangleList, vertices, 0, 4, indices, 0, 2);
                //neuer Code - TB
                graphics.GraphicsDevice.DrawUserIndexedPrimitives(PrimitiveType.TriangleList, vertices, 0, 12, indices, 0, 6);
            }

        }
    }
}
