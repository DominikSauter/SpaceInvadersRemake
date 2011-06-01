using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Graphics;

namespace SpaceInvadersRemake.View
{
    public class MinibossRepresentation : GameItemRepresentation
    {
        private Texture2D explosionTexture;
        private Model model;
    

        /// <summary>
        /// Erstellt eine Representation eines Minibosses
        /// </summary>
        public MinibossRepresentation()
        {
            throw new System.NotImplementedException();
        }
    
        public override Microsoft.Xna.Framework.Matrix Projection
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

        public override Microsoft.Xna.Framework.Matrix Camera
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

        public override Microsoft.Xna.Framework.Matrix World
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

        public Explosion Explosion
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        private ParticleEngine createParticleEngine(System.Collections.Generic.List<Texture2D> textures, Vector2 location, float size)
        {
            throw new System.NotImplementedException();
        }
    }
}
