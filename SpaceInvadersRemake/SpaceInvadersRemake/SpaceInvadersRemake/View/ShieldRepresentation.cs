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
        private Shield shieldGameItem;
        //3D Raumposition des Schildes
        private Vector3 position;
        private int scale;
        //Eckpunkte des 3D-Rechteck-Models
        private VertexPositionColorTexture[] vertices;
        private BasicEffect effect;

        private int[] indices;

        /// <summary>
        /// Erstellt eine Representation eines stationären Schildes.
        /// </summary>
        public ShieldRepresentation(Shield shield, GraphicsDeviceManager graphics)
        {
            this.texture = ViewContent.RepresentationContent.ShieldTexture;
            this.shieldGameItem = shield;
            this.position = PlaneProjector.Convert2DTo3D(this.shieldGameItem.Position);
            this.graphics = graphics;
            this.World = Matrix.CreateWorld(this.position,Vector3.Forward,Vector3.Up);
            this.effect = new BasicEffect(graphics.GraphicsDevice);
            this.scale = 3 / 2;



            //Eckpunkte des Rechtecks
            this.vertices = new VertexPositionColorTexture[4];
            //6 Punkte für zwei polygone, um ein Rechteck zu zeichnen
            this.indices = new int[6];

            //Eckpunkte des Vierecks bzw. der Polygone abhängig von der 2DPosition des Models-Bereichs (Position = Mittelpunkt des Rechtecks)
            vertices[0] = new VertexPositionColorTexture(PlaneProjector.Convert2DTo3D(this.shieldGameItem.Position), Color.Red, new Vector2(0,0));
            vertices[1] = new VertexPositionColorTexture(PlaneProjector.Convert2DTo3D(this.shieldGameItem.Position + new Vector2(0, texture.Height / 3)), Color.Green, new Vector2(0,1));
            vertices[2] = new VertexPositionColorTexture(PlaneProjector.Convert2DTo3D(this.shieldGameItem.Position + new Vector2(texture.Width * 0.4f, 0)), Color.Green, new Vector2(1,0));
            vertices[3] = new VertexPositionColorTexture(PlaneProjector.Convert2DTo3D(this.shieldGameItem.Position + new Vector2(texture.Width * 0.4f, texture.Height / 3)), Color.Green, new Vector2(1, 1));

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

        /// <summary>
        /// Referenz auf ein Shield-Modelobjekt um jegliche Abfragen im Model zu tätigen.
        /// </summary>
        public ModelSection.Shield ShieldGameItem
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
        }
    }
}
