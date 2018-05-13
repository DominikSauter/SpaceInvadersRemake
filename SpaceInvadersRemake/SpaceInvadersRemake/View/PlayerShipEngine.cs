using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceInvadersRemake.View
{
    /// <summary>
    /// Objekte dieser Klasse stellen eine Partikel Engine für den Spielerraumschiffsantrieb zur Verfügung.
    /// </summary>
    public class PlayerShipEngine : ParticleEngine
    {
        private Random random;
        private List<Particle> particles;
        private Texture2D texture;
        private float size;
        private Color color;
        private GraphicsDeviceManager graphics;
        private int index;
        private Vector2 baseScreenSize;

        /// <summary>
        /// Position des Partikel Emitters
        /// </summary>
        public override Vector2 EmitterLocation
        {
            get;
            set;
        }

        /// <summary>
        /// Erstellt eine Partikel Engine für den Raumschiffsantrieb der Spielerfigur.
        /// </summary>
        /// <param name="texture">Grafische Darstellung der Partikel</param>
        /// <param name="location">Position des Partikel Emitters</param>
        /// <param name="size">Größe der dargestellten Partikel</param>
        public PlayerShipEngine(Texture2D texture, Vector2 location, float size, Color color, GraphicsDeviceManager graphics)
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

        }


        private Particle GenerateNewParticle()
        {
            //Velocity von den 3D coordinaten ableiten (wegen richtung)
            Vector2 velocity = new Vector2((float)(random.Next(-40, 40)) / 240, 0.5f) * size; //Richtungs- und Geschwindigkeitsvektor
            float sizeParticle = (float)random.NextDouble() * size;
            int ttl = 20 + random.Next(40);
            //evtl Liste mit möglichen Farben anlegen und mit random durchwechseln
            Vector2 position = new Vector2(random.Next(-3, 3), 0) + this.EmitterLocation;

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


            int particlesPerFrame = 2;

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


        /// <summary>
        /// 
        /// </summary>
        /// <param name="spriteBatch"></param>
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
