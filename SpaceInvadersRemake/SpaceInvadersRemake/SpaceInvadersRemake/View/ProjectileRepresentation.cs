﻿//Implementiert von Anji
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

        //Punkte der Polygone wo die Textur gezeichnet werden soll
        private VertexPositionColorTexture[] vertices;
        private BasicEffect effect;

        //Hilfs-Array zum Zusammensetzen der Polygone
        private int[] indices;


        /// <summary>
        /// Erstellt eine Representation eines Projektils.
        /// </summary>
        public ProjectileRepresentation(Projectile projectile, Texture2D texture, GraphicsDeviceManager graphics)
        {
            this.texture = texture;
            GameItem = projectile;
            this.position = PlaneProjector.Convert2DTo3D(GameItem.Position);
            this.graphics = graphics;
            this.World = Matrix.CreateWorld(this.position, Vector3.Forward, Vector3.Up);
            this.effect = new BasicEffect(graphics.GraphicsDevice);
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

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            Vector3 newPosition = PlaneProjector.Convert2DTo3D(GameItem.Position);

            if (newPosition.Z > this.position.Z || newPosition.Z < this.position.Z)
            {
                this.position = newPosition;
            }

            //Skalierung
            float scaleWidth = 0.05f;
            float scaleHeight = 0.1f;

            //Viereck aufbauen
            Vector3 leftBot = PlaneProjector.Convert2DTo3D(new Vector2(-texture.Width * scaleWidth, -texture.Height * scaleHeight));
            Vector3 leftTop = PlaneProjector.Convert2DTo3D(new Vector2(-texture.Width * scaleWidth, texture.Height * scaleHeight));
            Vector3 rightBot = PlaneProjector.Convert2DTo3D(new Vector2(texture.Width * scaleWidth, -texture.Height * scaleHeight));
            Vector3 rightTop = PlaneProjector.Convert2DTo3D(new Vector2(texture.Width * scaleWidth, texture.Height * scaleHeight));

            vertices[0] = new VertexPositionColorTexture(leftBot, Color.Red, new Vector2(0, 0));
            vertices[1] = new VertexPositionColorTexture(leftTop, Color.Red, new Vector2(0, 1));
            vertices[2] = new VertexPositionColorTexture(rightBot, Color.Red, new Vector2(1, 0));
            vertices[3] = new VertexPositionColorTexture(rightTop, Color.Red, new Vector2(1, 1));

            this.World = Matrix.CreateTranslation(this.position);

            ////Positionen der Eckpunkte berechnen abhängig von der Skalierung und der 2DPosition des Models-Bereichs (Position = Mittelpunkt des Rechtecks)
            //Vector3 leftBot = this.position + PlaneProjector.Convert2DTo3D(new Vector2(- texture.Width * scaleWidth, - texture.Height * scaleHeight));
            //Vector3 leftTop = this.position + PlaneProjector.Convert2DTo3D(new Vector2(- texture.Width * scaleWidth, texture.Height * scaleHeight));
            //Vector3 rightBot = this.position + PlaneProjector.Convert2DTo3D(new Vector2(texture.Width * scaleWidth, - texture.Height * scaleHeight));
            //Vector3 rightTop = this.position + PlaneProjector.Convert2DTo3D(new Vector2(texture.Width * scaleWidth, texture.Height * scaleHeight));

            ////Eckpunkte des Vierecks bzw. der Polygone eintragen
            //vertices[0] = new VertexPositionColorTexture(leftBot, Color.Red, new Vector2(0, 0));
            //vertices[1] = new VertexPositionColorTexture(leftTop, Color.Green, new Vector2(0, 1));
            //vertices[2] = new VertexPositionColorTexture(rightBot, Color.Yellow, new Vector2(1, 0));
            //vertices[3] = new VertexPositionColorTexture(rightTop, Color.Blue, new Vector2(1, 1));

            ////Eckpunkte des Vierecks bzw. der Polygone abhängig von der 2DPosition des Models-Bereichs (Position = Mittelpunkt des Rechtecks)
            //vertices[0] = new VertexPositionColorTexture(this.position, Color.Red, new Vector2(0, 0));
            //vertices[1] = new VertexPositionColorTexture(this.position + PlaneProjector.Convert2DTo3D(new Vector2(0, texture.Height / 5)), Color.Green, new Vector2(0, 1));
            //vertices[2] = new VertexPositionColorTexture(this.position + PlaneProjector.Convert2DTo3D(new Vector2(texture.Width / 8, 0)), Color.Yellow, new Vector2(1, 0));
            //vertices[3] = new VertexPositionColorTexture(this.position + PlaneProjector.Convert2DTo3D(new Vector2(texture.Width / 8, texture.Height / 5)), Color.Blue, new Vector2(1, 1));

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
