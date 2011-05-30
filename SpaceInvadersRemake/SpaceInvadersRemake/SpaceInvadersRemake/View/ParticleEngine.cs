using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceInvadersRemake
{
    public abstract class ParticleEngine
    {
        private Random random;
        private List<Particle> particles;
        private List<Texture2D> textures;

        abstract public Vector2 EmitterLocation
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        private abstract Particle generateNewParticle()
        {
            throw new System.NotImplementedException();
        }

        abstract public void Update()
        {
            throw new System.NotImplementedException();
        }

        abstract public void Draw(SpriteBatch spriteBatch)
        {
            throw new System.NotImplementedException();
        }
    }
}
