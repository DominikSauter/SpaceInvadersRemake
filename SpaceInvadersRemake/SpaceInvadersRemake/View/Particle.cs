using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceInvadersRemake.View
{
    /// <summary>
    /// Objekte dieser Klasse stellen einzelne Partikel eines Grafikeffektes dar. Sie werden von einer 
    /// <c>PartikelEngine</c> erzeugt und verwaltet.
    /// 
    /// </summary>
    public class Particle : IView
    {
        /// <summary>
        /// Aktuelle Position des Partikels
        /// </summary>
        public Vector2 Position
        {
            get;
            set;
        }

        /// <summary>
        /// Richtung und Bewegungsgeschwindigkeit des Partikels
        /// </summary>
        public Vector2 Velocity
        {
            get;
            set;
        }

        /// <summary>
        /// Grafische Darstellung des Partikels
        /// </summary>
        public Texture2D Texture
        {
            get;
            set;
        }

        /// <summary>
        /// Farbe des Partikels
        /// </summary>
        public Color Color
        {
            get;
            set;
        }

        /// <summary>
        /// Größe des Partikels
        /// </summary>
        public float Size
        {
            get;
            set;
        }

        /// <summary>
        /// Lebenszeit eines Partikels
        /// </summary>
        public int TimeToLive
        {
            get;
            set;
        }

        private GraphicsDeviceManager graphics;

        /// <summary>
        /// Erzeugt einen einzelnen Partikel.
        /// </summary>
        /// <param name="texture">Grafische Darstellung</param>
        /// <param name="position">Aktuelle position</param>
        /// <param name="velocity">Richtung und Bewegungsgeschwindigkeit</param>
        /// <param name="color">Farbe</param>
        /// <param name="size">Größe</param>
        /// <param name="ttl">Lebenszeit</param>
        public Particle(Texture2D texture, Vector2 position, Vector2 velocity, Color color, float size, int ttl)
        {
            this.Texture = texture;
            this.Position = position;
            this.Velocity = velocity;
            this.Color = color;
            this.Size = size;
            this.TimeToLive = ttl;
        }



        /// <summary>
        /// Updated die Partikelposition
        /// </summary>
        public void Update()
        {
            Position += Velocity;
            this.TimeToLive--;
            //evtl. Rotation hinzufügen: angle += angularVelocity

        }

        public void Draw(SpriteBatch spriteBatch)
        {

            Rectangle sourcerectangle = new Rectangle(0, 0, Texture.Width, Texture.Height);
            Vector2 origin = new Vector2(Texture.Width / 2, Texture.Height / 2);

            spriteBatch.Draw(this.Texture, this.Position, sourcerectangle, this.Color, 0f, origin, this.Size, SpriteEffects.None, 0f);

        }
    }
}
