using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceInvadersRemake.View
{
    public class PowerUpRepresentation : GameItemRepresentation
    {
        private Texture2D texture;
    
        /// <summary>
        /// Erstellt eine Representation eines PowerUps.
        /// </summary>
        public PowerUpRepresentation()
        {
            throw new System.NotImplementedException();
        }
    
        public override Matrix Projection
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

        public override Matrix Camera
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

        public override Matrix World
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

        public PowerUpGlow PowerUpGlow
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public override void Draw(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        private ParticleEngine createParticleEngine(System.Collections.Generic.List<Texture2D> textures, Vector2 location, float size)
        {
            throw new System.NotImplementedException();
        }
    }
}
