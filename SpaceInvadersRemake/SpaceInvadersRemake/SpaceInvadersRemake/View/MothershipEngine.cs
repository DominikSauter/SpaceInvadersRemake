using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceInvadersRemake.View
{
    /// <summary>
    /// Objekte dieser Klasse stellen eine Partikel Engine für den Mutterschiffsantrieb zur Verfügung.
    /// </summary>
    public class MothershipEngine : ParticleEngine
    {
        private Random random;
        private List<Particle> particles;
        private Texture2D texture;

        /// <summary>
        /// Erstellt eine Partikel Engine für den Raumschiffsantrieb des Mutterschiff-Aliens.
        /// </summary>
        /// <param name="texture">Grafische Darstellung der Partikel</param>
        /// <param name="location">position des Partikel Emitters</param>
        /// <param name="size">Größe der dargestellten Partikel</param>
        public MothershipEngine(Microsoft.Xna.Framework.Graphics.Texture2D texture, Vector2 location, float size)
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
        /// <param name="spriteBatch"></param>
        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }
    }
}
