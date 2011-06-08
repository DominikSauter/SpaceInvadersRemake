using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceInvadersRemake.View
{
    public class AlienRepresentation : GameItemRepresentation
    {
        private Texture2D explosionTexture;
        private Model model;

        /// <summary>
        /// Erstellt eine Representation eines Aliens.
        /// </summary>
        public AlienRepresentation()
        {
            throw new System.NotImplementedException();
        }

        public ModelSection.Alien AlienGameItem
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
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
