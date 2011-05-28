using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceInvadersRemake
{
    public class ParticleEngine
    {
        private Random random;
        private List<Particle> particles;
        private List<Texture2D> textures;

        public ParticleEngine(System.Collections.Generic.List<Texture2D> textures, Vector2 location)
        {
            throw new System.NotImplementedException();
        }

        public Vector2 EmitterLocation
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        private Particle GenerateNewParticle()
        {
            throw new System.NotImplementedException();
        }

        public void Update()
        {
            throw new System.NotImplementedException();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            throw new System.NotImplementedException();
        }
    }
}
