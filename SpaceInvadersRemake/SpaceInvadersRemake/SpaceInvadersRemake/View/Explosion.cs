using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceInvadersRemake.View
{
    public class Explosion : ParticleEngine
    {
        private Random random;
        private List<Particle> particles;
        private Texture2D texture;

        /// <summary>
        /// Erstellt eine Partikel Engine für einen Explosionseffekt.
        /// </summary>
        /// <param name="texture">Grafische Darstellung der Partikel</param>
        /// <param name="location">Position des Partikel Emitters</param>
        /// <param name="size">Größe der dargestellten Partikel</param>
        public Explosion(Microsoft.Xna.Framework.Graphics.Texture2D texture, Vector2 location, float size)
        {
            throw new System.NotImplementedException();
        }

        public override Microsoft.Xna.Framework.Vector2 EmitterLocation
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        private override Particle generateNewParticle()
        {
            throw new System.NotImplementedException();
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }
    }
}
