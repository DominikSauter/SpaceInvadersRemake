using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceInvadersRemake.View
{
    /// <summary>
    /// Erzeugt und Verwaltet alle Partikel und dient als Partikel Emitter. 
    /// </summary>
    public abstract class ParticleEngine
    {
        private Random random;
        private List<Particle> particles;
        private List<Texture2D> textures;

        /// <summary>
        /// Position an der alle Partikel standardmäßig erzeugt werden.
        /// </summary>
        abstract public Vector2 EmitterLocation
        {
            get;
            set;
        }

        private Particle generateNewParticle()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Erstellt (unter Verwendung von <c>generateNewParticle()</c>) und Zerstört Partikel
        /// </summary>
        abstract public void Update();

        /// <summary>
        /// Zeichnet alle Partikel indem es deren <c>Draw()</c> Methode aufruft.
        /// </summary>
        /// <param name="spriteBatch"></param>
        abstract public void Draw(SpriteBatch spriteBatch);
    }
}
