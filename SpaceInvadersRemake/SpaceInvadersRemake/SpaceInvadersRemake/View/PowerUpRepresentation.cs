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

        /// <summary>
        /// Referenz auf ein PowerUps-Modelobjekt um jegliche Abfragen im Model zu tätigen.
        /// </summary>
        public ModelSection.PowerUp PowerUpGameItem
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        /// <summary>
        /// Zeichnet das Spielerschiff auf den Bildschirm.
        /// </summary>
        /// <param name="gameTime">Spielzeit</param>
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
