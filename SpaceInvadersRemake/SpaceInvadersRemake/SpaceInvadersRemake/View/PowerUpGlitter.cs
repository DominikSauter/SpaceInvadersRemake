using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceInvadersRemake.View
{
    /// <summary>
    /// Objekte dieser Klasse stellen eine Partikel Engine für einen Glitzereffekt des PowerUps zur Verfügung.
    /// </summary>
    public class PowerUpGlitter : ParticleEngine
    {
        private Random random;
        private List<Particle> particles;
        private Texture2D texture;
        private float size;
        private Color color;
        private GraphicsDeviceManager graphics;
        private int index;
        private Vector2 baseScreenSize;
        private Vector2 scaleFactor;


        /// <summary>
        /// Position des Partikel Emitters
        /// </summary>
        public override Vector2 EmitterLocation
        {
            get;
            set;
        }


        /// <summary>
        /// Erstellt eine Partikel Engine für einen Glitzereffekt für PowerUps
        /// </summary>
        /// <param name="texture">Grafische Darstellung der Partikel</param>
        /// <param name="location">Position des Partikel Emitters</param>
        /// <param name="size">Größe der dargestellten Partikel</param>
        public PowerUpGlitter(Texture2D texture, Vector2 location, float size, Color color, GraphicsDeviceManager graphics)
        {
            this.EmitterLocation = location;
            this.texture = texture;
            this.size = size;
            this.random = new Random();
            this.color = color;
            this.graphics = graphics;
            this.index = 0;
            this.particles = new List<Particle>();
            this.baseScreenSize = new Vector2(800, 600);

            this.scaleFactor = Vector2.One;
        }

        private Particle GenerateNewParticle()
        {
            //Der "Raum" (2D) in dem glitzer Partikel erzeugt werden können
            Vector2 glitterSpace = new Vector2((float)random.Next(-15, 15), (float)random.Next(-10, 10));

            Vector2 position = EmitterLocation + glitterSpace * this.scaleFactor;
            Vector2 velocity = new Vector2(0, 1f) * this.scaleFactor;
            float sizeParticle = (float)random.NextDouble() * this.size;
            int ttl = 10 + random.Next(10);

            return new Particle(this.texture, position, velocity, this.color, sizeParticle, ttl);

        }

        /// <summary>
        /// Updatet die Partikel Engine und erzeugt neue Partikel bzw. löscht Alte.
        /// </summary>
        public override void Update()
        {
            //Skalieren relativ zur Auflösung (Originalgröße bei 800x600 Auflösung)
            Vector2 newScreenSize = new Vector2((float)graphics.GraphicsDevice.PresentationParameters.BackBufferWidth, (float)graphics.GraphicsDevice.PresentationParameters.BackBufferHeight);
            Vector2 factor = new Vector2(newScreenSize.X / baseScreenSize.X, newScreenSize.Y / baseScreenSize.Y);

            if (baseScreenSize != newScreenSize)
            {
                this.size *= factor.X;
                this.scaleFactor *= factor;
                this.baseScreenSize = newScreenSize;
            }


            int particlesPerFrame = 1;

            for (int i = 0; i < particlesPerFrame; i++)
            {

                particles.Add(GenerateNewParticle());
            }

            for (int particle = 0; particle < particles.Count; particle++)
            {
                particles[particle].Update();

                if (particles[particle].TimeToLive <= 0)
                {
                    particles.RemoveAt(particle);
                    particle--;
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Update();

            spriteBatch.Begin();
            for (index = 0; index < particles.Count; index++)
            {
                particles[index].Draw(spriteBatch);
            }

            spriteBatch.End();
        }
    }
}
