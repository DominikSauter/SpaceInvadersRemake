using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceInvadersRemake.View
{
    /// <summary>
    /// Stellt die von Aliens fallengelassenen PowerUps auf dem Bildschirm dar.
    /// </summary>
    /// <remarks>
    /// Hält die PartikelEngines für einen Glitzereffekt.
    /// </remarks>
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

        /// <summary>
        /// ParticleEmitter der einen Glitzereffekt erzeugt.
        /// </summary>
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

        private ParticleEngine createParticleEngine(System.Collections.Generic.List<Texture2D> textures, Vector2 location, float size)
        {
            throw new System.NotImplementedException();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }
    }
}
