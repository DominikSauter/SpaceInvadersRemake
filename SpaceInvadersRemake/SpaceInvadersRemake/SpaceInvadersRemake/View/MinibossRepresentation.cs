using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

using Microsoft.Xna.Framework.Graphics;

namespace SpaceInvadersRemake.View
{
    /// <summary>
    /// Stellt den auf dem Bildschirm sichtbaren Miniboss dar.
    /// </summary>
    /// <remarks>
    /// Hält die PartikelEngines für Explosionen.
    /// </remarks>
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
        /// Referenz auf das Miniboss-Modelobjekt um jegliche Abfragen im Model zu tätigen.
        /// </summary>
        public ModelSection.Miniboss MinibossGameItem
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
