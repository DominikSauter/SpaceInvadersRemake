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
    public class Particle
    {
        /// <summary>
        /// Erzeugt einen einzelnen Partikel.
        /// </summary>
        /// <param name="texture">Grafische Darstellung</param>
        /// <param name="position">Aktuelle Position</param>
        /// <param name="velocity">Richtung und Bewegungsgeschwindigkeit</param>
        /// <param name="color">Farbe</param>
        /// <param name="size">Größe</param>
        /// <param name="ttl">Lebenszeit</param>
        public Particle(Texture2D texture, Vector2 position, Vector2 velocity, Color color, float size, int ttl)
        {
            throw new System.NotImplementedException();
        }
    
        /// <summary>
        /// Aktuelle Position des Partikels
        /// </summary>
        public Vector2 Position
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
        /// Richtung und Bewegungsgeschwindigkeit des Partikels
        /// </summary>
        public Vector2 Velocity
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
        /// Grafische Darstellung des Partikels
        /// </summary>
        public Texture2D Texture
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
        /// Farbe des Partikels
        /// </summary>
        public Color Color
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
        /// Größe des Partikels
        /// </summary>
        public float Size
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
        /// Lebenszeit eines Partikels
        /// </summary>
        public int TimeToLive
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
        /// Updated die Partikelposition
        /// </summary>
        public void Update()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Zeichnet mit Hilfe des <c>SpriteBatch</c> das Partikel auf den Bildschirm
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            throw new System.NotImplementedException();
        }
    }
}
