using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceInvadersRemake.View
{
    /// <summary>
    /// Stellt das auf dem Bildschirm sichtbare Mutterschiff dar.
    /// </summary>
    /// <remarks>
    /// Hält die PartikelEngines für Antrieb und Explosionen.
    /// </remarks>
    public class MothershipRepresentation : GameItemRepresentation
    {
        private Texture2D explosionTexture;
        private Texture2D engineTexture;
        private Model model;
    
        /// <summary>
        /// Erstellt eine Representation des Mutterschiff-Aliens.
        /// </summary>
        public MothershipRepresentation()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// ParticleEmitter der einen Explosionseffekt erzeugt.
        /// </summary>
        /// <remarks>
        /// Wird Anfangs instanziiert aber erst bei Zerstörung des Schiffs gestartet.
        /// </remarks>
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

        /// <summary>
        /// ParticleEmitter der einen Effekt erzeugt, welcher den Antrieb des Mutterschiffs darstellt.
        /// </summary>
        public MothershipEngine MothershipEngine
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
        /// Referenz auf das MothershipSound-Modelobjekt um jegliche Abfragen im Model zu tätigen.
        /// </summary>
        public ModelSection.Mothership MothershipGameItem
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
        public override void Draw()
        {
            throw new NotImplementedException();
        }

        private ParticleEngine createParticleEngine(System.Collections.Generic.List<Texture2D> textures, Vector2 location, float size)
        {
            throw new System.NotImplementedException();
        }
    }
}
