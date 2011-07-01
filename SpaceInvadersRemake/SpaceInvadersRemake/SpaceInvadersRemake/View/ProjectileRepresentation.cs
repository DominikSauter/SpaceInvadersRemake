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
        private Projectile projectileGameItem;
        private Vector3 position;
        private Vector2 projectileCenter;
        private GraphicsDeviceManager graphics;
        private bool moved;
        private int scale;

        //Punkte der Polygone wo die Textur gezeichnet werden soll
        private VertexPositionColorTexture[] vertices;
        private BasicEffect effect;

        //Hilfs-Array zum Zusammensetzen der Polygone
        private int[] indices;

        /// <summary>
        /// Referenz auf ein Projectile-Modelobjekt um jegliche Abfragen im Model zu tätigen.
        /// </summary>
        public ModelSection.Projectile ProjectileGameItem
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        /// <summary>
        /// Erstellt eine Representation eines Projektils.
        /// </summary>
        public ProjectileRepresentation(Projectile projectile, Texture2D texture, GraphicsDeviceManager graphics)
        {
            this.texture = texture;
            this.projectileGameItem = projectile;
            this.projectileCenter = this.projectileGameItem.Position;
            this.position = PlaneProjector.Convert2DTo3D(projectileCenter);
            this.graphics = graphics;
            this.moved = false;
            this.scale = 3 / 2;
            this.World = Matrix.CreateWorld(this.position, Vector3.Backward, Vector3.Up);
            this.effect = new BasicEffect(graphics.GraphicsDevice);
            //Eckpunkte des Rechtecks
            this.vertices = new VertexPositionColorTexture[4];
            //6 Punkte für zwei polygone, um ein Rechteck zu zeichnen
            this.indices = new int[6];

            //Eckpunkte des Vierecks bzw. der Polygone abhängig von der 2DPosition des Models-Bereichs (Position = Mittelpunkt des Rechtecks)
            vertices[0] = new VertexPositionColorTexture(PlaneProjector.Convert2DTo3D(projectileCenter + new Vector2(-texture.Width / 2, -texture.Height / 2)), Color.Red, new Vector2(0, 0));
            vertices[1] = new VertexPositionColorTexture(PlaneProjector.Convert2DTo3D(projectileCenter + new Vector2(-texture.Width / 2, texture.Height / 2)), Color.Green, new Vector2(0, 1));
            vertices[2] = new VertexPositionColorTexture(PlaneProjector.Convert2DTo3D(projectileCenter + new Vector2(texture.Width / 2, -texture.Height / 2)), Color.Green, new Vector2(1, 0));
            vertices[3] = new VertexPositionColorTexture(PlaneProjector.Convert2DTo3D(projectileCenter + new Vector2(texture.Width / 2, texture.Height / 2)), Color.Green, new Vector2(1, 1));

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
        /// 
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            Vector3 currentPosition = PlaneProjector.Convert2DTo3D(this.projectileGameItem.Position);

            if (currentPosition.Y > position.Y)
            {
                this.position = currentPosition;
                this.moved = true;
            }

            effect.World = this.World;
            effect.TextureEnabled = true;
            effect.Texture = texture;
            effect.View = Camera;
            effect.Projection = Projection;

            if (moved)
            {
                effect.World = this.World * Matrix.CreateTranslation(0, currentPosition.Y, currentPosition.Z);
            }

            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();

                graphics.GraphicsDevice.DrawUserIndexedPrimitives(PrimitiveType.TriangleList, vertices, 0, 4, indices, 0, 2);
            }
        }

    }
}
