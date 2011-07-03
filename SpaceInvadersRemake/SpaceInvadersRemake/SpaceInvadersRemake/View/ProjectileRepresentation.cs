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
    /// Stellt die vom Spieler oder von Gegnern abgefeuerten Projektile dar.
    /// </summary>
    public class ProjectileRepresentation : GameItemRepresentation
    {
        private Texture2D texture;
        private Vector3 position;
        private GraphicsDeviceManager graphics;
        private bool player; //Gibt an ob das Projektil vom Player stamm
        private Vector3 color;

        //Punkte der Polygone wo die Textur gezeichnet werden soll
        private VertexPositionColorTexture[] vertices;
        private BasicEffect effect;

        //Hilfs-Array zum Zusammensetzen der Polygone
        private int[] indices;


        /// <summary>
        /// Erstellt eine Representation eines Projektils.
        /// </summary>
        public ProjectileRepresentation(Projectile projectile, Texture2D texture, GraphicsDeviceManager graphics, BasicEffect effect, bool player)
        {
            this.texture = texture;
            GameItem = projectile;
            this.player = player;
            this.position = PlaneProjector.Convert2DTo3D(GameItem.Position);
            this.graphics = graphics;
            this.World = Matrix.CreateWorld(this.position, Vector3.Forward, Vector3.Up);
            this.effect = effect;
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

            //Projektilfarbe
            if (player)
            {
                this.color = new Vector3(0, 255, 0);
            }
            else
            {
                this.color = new Vector3(255, 0, 0);
            }

            

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            this.graphics.GraphicsDevice.DepthStencilState = DepthStencilState.Default;

            Vector3 newPosition = PlaneProjector.Convert2DTo3D(GameItem.Position);


            if (newPosition.Z > this.position.Z || newPosition.Z < this.position.Z)
            {
                this.position = newPosition;
            }


            //Skalierung
            float scaleWidth = 0.05f;
            float scaleHeight = 0.1f;

            //Projektil nach 'unten' versetzen, damit es unter dem Schiff erscheint
            Vector3 lower = new Vector3(0, -6, 0);

            //Positionieren
            this.World = Matrix.CreateScale(scaleWidth, 1, scaleHeight) * Matrix.CreateTranslation(this.position + lower);

            effect.TextureEnabled = true;
            effect.Texture = texture;
            effect.View = Camera;
            effect.DiffuseColor = this.color;
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
