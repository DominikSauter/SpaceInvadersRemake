﻿using System;
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
        /// Referenz auf das Player-Modelobjekt um jegliche Abfragen im Model zu tätigen.
        /// </summary>
        private Player PlayerGameItem;

        /// <summary>
        /// ParticleEmitter der einen Explosionseffekt erzeugt.
        /// </summary>
        /// <remarks>
        /// Wird Anfangs instanziiert aber erst bei Zerstörung des Schiffs gestartet.
        /// </remarks>
        private Explosion Explosion;

        /// <summary>
        /// ParticleEmitter der einen Effekt erzeugt, welcher den Antrieb des Spielerschiffs darstellt.
        /// </summary>
        private PlayerShipEngine PlayerShipEngine;
    
        /// <summary>
        /// Erstellt eine Representation der Spielerfigur.
        /// </summary>
        public PlayerRepresentation(Player PlayerGameItem, GraphicsDeviceManager graphics)
        {
            this.model = ViewContent.RepresentationContent.PlayerModel;
            this.PlayerGameItem = PlayerGameItem;

            /* Vorläufige Matrizen.
             * Wir müssen noch besprechen wie groß unsre 3D Ebene wird (dementsprechend müssen wir Camera und Projection initialisieren)
             * Das Model muss evtl noch gedreht werden.
             * */
            this.World = Matrix.CreateWorld(PlaneProjector.Convert2DTo3D(this.PlayerGameItem.Position), Vector3.Forward, Vector3.Up);

            //<WAHL>
            this.PlayerShipEngine = null;
            this.Explosion = null;
            this.engineTextures = null;
            this.explosionTextures = null;
            //<WAHL>
        }

        private ParticleEngine createParticleEngine(System.Collections.Generic.List<Texture2D> textures, Vector2 location, float size)
        {
            throw new System.NotImplementedException();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            foreach (ModelMesh mesh in model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.LightingEnabled = true;
                    effect.SpecularColor = new Vector3(1.0f, 1.0f, 1.0f);
                    effect.SpecularPower = 100.0f;
                    effect.DiffuseColor = new Vector3(1.0f, 1.0f, 1.0f);
                    effect.World = this.World * Matrix.CreateTranslation(PlaneProjector.Convert2DTo3D(this.PlayerGameItem.Position));
                    effect.View = Camera;
                    effect.Projection = Projection;
                }

                mesh.Draw();
            }
        }
    }
}
