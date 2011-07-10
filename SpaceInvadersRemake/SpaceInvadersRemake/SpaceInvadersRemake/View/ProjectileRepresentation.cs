//Implementiert von Anji
using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceInvadersRemake.ModelSection;

namespace SpaceInvadersRemake.View
{
    /// <summary>
    /// Stellt die vom Spieler oder von Gegnern abgefeuerten Projektile dar.
    /// Dabei wird ein 3D Objekt (Rechteck) erzeugt, auf das die ProjektilTextur gezeichnet wird.
    /// Unterschiedliche Projektile, z.B. von Spieler und Aliens werden unterschiedlich dargestellt,
    /// sowie die verschiedenen Projektilarten an sich.
    /// </summary>
    public class ProjectileRepresentation : GameItemRepresentation
    {
        private Texture2D texture;
        private Vector3 position;
        private GraphicsDeviceManager graphics;
        private Vector3 colorProjectile;

        //Punkte der Polygone wo die Textur gezeichnet werden soll
        private VertexPositionColorTexture[] vertices;
        private BasicEffect effect;

        //Hilfsarray, welches die Reihenfolge der Vertices festlegt
        private int[] indices;


        /// <summary>
        /// Erstellt eine Representation eines Projektils.
        /// </summary>
        /// <param name="projectile">Projektil(Typ)</param>
        /// <param name="texture">Projektiltextur</param>
        /// <param name="graphics">DeviceManager</param>
        /// <param name="effect">BasicEffect</param>
        /// <param name="color">Projektilfärbung</param>
        public ProjectileRepresentation(Projectile projectile, Texture2D texture, GraphicsDeviceManager graphics, BasicEffect effect, Vector3 color)
        {
            GameItem = projectile;
            this.texture = texture;
            this.colorProjectile = color;
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

            //3-dimensionales Rechteck aufbauen für die 3 dimensionale Darstellung des Projektils (mit Hitsphere)
            Vector3 leftBot = PlaneProjector.Convert2DTo3D(new Vector2(-texture.Width / 2.0f, -texture.Height / 2.0f));
            Vector3 leftTop = PlaneProjector.Convert2DTo3D(new Vector2(-texture.Width / 2.0f, texture.Height / 2.0f));
            Vector3 rightBot = PlaneProjector.Convert2DTo3D(new Vector2(texture.Width / 2.0f, -texture.Height / 2.0f));
            Vector3 rightTop = PlaneProjector.Convert2DTo3D(new Vector2(texture.Width / 2.0f, texture.Height / 2.0f));

            vertices[0] = new VertexPositionColorTexture(leftBot, Color.Red, new Vector2(0, 0));
            vertices[1] = new VertexPositionColorTexture(leftTop, Color.Red, new Vector2(0, 1));
            vertices[2] = new VertexPositionColorTexture(rightBot, Color.Red, new Vector2(1, 0));
            vertices[3] = new VertexPositionColorTexture(rightTop, Color.Red, new Vector2(1, 1));

        }

        /// <summary>
        /// Zeichnet das Projektil
        /// </summary>
        /// <param name="spriteBatch">spriteBatch</param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            //DephStencilState setzen damit 3D und 2D Objekte gleichzeitig richtig angezeigt werden können
            this.graphics.GraphicsDevice.DepthStencilState = DepthStencilState.Default;

            //Rotationsmatrix für Projektile mit schräger Flugrichtung
            Matrix rotate = Matrix.Identity; 

            //Neue, aktuelle Position des Projektil GameItems
            Vector3 newPosition = PlaneProjector.Convert2DTo3D(GameItem.Position);

            //Wenn sich die X-Richtung verändert, also das Projektil schräg fliegt soll es auch schräg gezeichnet werden
            if (newPosition.Z > this.position.Z || newPosition.Z < this.position.Z)
            {
                if (newPosition.X > this.position.X || newPosition.X < this.position.X) 
                { 
                     //Nach rechts/links drehen abhängig von der Flugrichtung
                     rotate = Matrix.CreateRotationZ(MathHelper.ToRadians((float)(Math.Atan((newPosition.X - this.position.X) / (newPosition.Z - this.position.Z)))));
                }
                this.position = newPosition;
            }


            //Skalierung
            float scaleWidth = 0.1f;
            float scaleHeight = 0.1f;
            

            //Projektil nach 'unten' versetzen, damit es unter dem Schiff erscheint
            Vector3 lower = new Vector3(0, -6, 0);

            //Im Raum Positionieren
            this.World = rotate * Matrix.CreateScale(scaleWidth, 0.0f, scaleHeight) * Matrix.CreateTranslation(this.position + lower);

            //Hitsphere setzen
            ((ModelHitsphere)GameItem.BoundingVolume).World = World;


            effect.TextureEnabled = true;
            effect.Texture = texture;
            effect.View = Camera;
            effect.DiffuseColor = this.colorProjectile;
            effect.Projection = Projection;
            effect.World = this.World;

            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                
                //Das Primitive-Rechteck zeichnen
                graphics.GraphicsDevice.DrawUserIndexedPrimitives(PrimitiveType.TriangleList, vertices, 0, 4, indices, 0, 2);
            }
        }

    }
}
