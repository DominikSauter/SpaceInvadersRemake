using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceInvadersRemake
{
    public class PlayerShipEngine : ParticleEngine
    {
        private Random random;
        private List<Particle> particles;
        private Texture2D texture;

        public PlayerShipEngine(Microsoft.Xna.Framework.Graphics.Texture2D texture, Vector2 location, float size)
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

        private abstract Particle GenerateNewParticle()
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
