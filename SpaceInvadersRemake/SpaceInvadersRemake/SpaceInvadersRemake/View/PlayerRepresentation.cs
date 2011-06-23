using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using SpaceInvadersRemake.ModelSection;

namespace SpaceInvadersRemake.View
{
    /// <summary>
    /// Stellt die auf dem Bildschirm sichtbare Spielerfigur dar.
    /// </summary>
    /// <remarks>
    /// Hält die PartikelEngines für Antrieb und Explosionen.
    /// </remarks>
    public class PlayerRepresentation : GameItemRepresentation
    {
        private List<Texture2D> explosionTextures;
        private List<Texture2D> engineTextures;
        private Model model;
    
        /// <summary>
        /// Erstellt eine Representation der Spielerfigur.
        /// </summary>
        public PlayerRepresentation(Player PlayerGameItem)
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
        /// ParticleEmitter der einen Effekt erzeugt, welcher den Antrieb des Spielerschiffs darstellt.
        /// </summary>
        public PlayerShipEngine PlayerShipEngine
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
        /// Referenz auf das Player-Modelobjekt um jegliche Abfragen im Model zu tätigen.
        /// </summary>
        public ModelSection.Player PlayerGameItem
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
