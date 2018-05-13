using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceInvadersRemake.View
{
    /// <summary>
    /// Objekte dieser Klasse stellen eine Partikel Engine für den Mutterschiffsantrieb zur Verfügung.
    /// </summary>
    public class MothershipEngine : ParticleEngine
    {
        private Random random;
        private List<Particle> particles;
        private Texture2D texture;
        private float size;
        private Color color;
        private GraphicsDeviceManager graphics;
        private int index;
        private Vector2 baseScreenSize;
        private int timer;

        /// <summary>
        /// Position des Partikel Emitters
        /// </summary>
        public override Vector2 EmitterLocation
        {
            get;
            set;
        }

        /// <summary>
        /// Erstellt eine Partikel Engine für den Raumschiffsantrieb des Mutterschiff-Aliens.
        /// </summary>
        /// <param name="texture">Grafische Darstellung der Partikel</param>
        /// <param name="location">Position des Partikel Emitters</param>
        /// <param name="size">Größe der dargestellten Partikel</param>
        public MothershipEngine(Texture2D texture, Vector2 location, float size, Color color, GraphicsDeviceManager graphics)
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
            this.timer = 2;
        }


        private Particle GenerateNewParticle()
        {
            Vector2 velocity = Vector2.Zero; 
            float sizeParticle = (float)random.NextDouble() * size;
            int ttl = 10 + random.Next(5);
            //evtl Liste mit möglichen Farben anlegen und mit random durchwechseln

            return new Particle(this.texture, this.EmitterLocation, velocity, this.color, sizeParticle, ttl);


        }

        /// <summary>
        /// Updatet die Partikel Engine und erzeugt neue Partikel bzw. löscht Alte.
        /// </summary>
        public override void Update()
        {
            //Skalieren relativ zur Auflösung (Originalgröße bei 800x600 Auflösung)
            Vector2 newScreenSize = new Vector2((float)graphics.GraphicsDevice.PresentationParameters.BackBufferWidth, (float)graphics.GraphicsDevice.PresentationParameters.BackBufferHeight);
            Vector2 factor = new Vector2(newScreenSize.X / baseScreenSize.X, newScreenSize.Y / baseScreenSize.Y);
            this.size *= factor.X;
            this.baseScreenSize = newScreenSize;

            timer--;
            int particlesPerFrame = 1;

            for (int i = 0; i < particlesPerFrame; i++)
            {
                if (timer == 0)
                {
                    particles.Add(GenerateNewParticle());
                    timer = 2;
                }

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
