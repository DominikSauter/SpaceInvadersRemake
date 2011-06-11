using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceInvadersRemake.View
{
    /// <summary>
    /// Objekte dieser Klasse stellen eine Partikel Engine für Explosionseffekte zur Verfügung.
    /// </summary>
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

        /// <summary>
        /// Position des Partikel Emitters
        /// </summary>
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

        /// <summary>
        /// Updatet die Partikel Engine und erzeugt neue Partikel bzw. löscht Alte.
        /// </summary>
        public override void Update()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Leitet die Draw()-Methode an die Partikel weiter.
        /// </summary>
        /// <param name="spriteBatch">Objekt zum Zeichnen von 2D Grafiken</param>
        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Startet Partikel-Emitter, sobald Destroyed-Event geworfen wurde.
        /// </summary>
        public void StartExplosion()
        {
            throw new System.NotImplementedException();
        }
    }
}
