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
    /// Stellt das auf dem Bildschirm sichtbare Mutterschiff dar.
    /// </summary>
    /// <remarks>
    /// Hält die PartikelEngines für Antrieb und Explosionen.
    /// </remarks>
    public class MothershipRepresentation : GameItemRepresentation
    {
        private Model model;
        private Texture2D mothershiptTexture;
        
        /// <summary>
        /// ParticleEmitter der einen Explosionseffekt erzeugt.
        /// </summary>
        /// <remarks>
        /// Wird Anfangs instanziiert aber erst bei Zerstörung des Schiffs gestartet.
        /// </remarks>
        private Explosion explosion;
        
        /// <summary>
        /// ParticleEmitter der einen Effekt erzeugt, welcher den Antrieb des Mutterschiffs darstellt.
        /// </summary>
        private MothershipEngine mothershipEngine;

        /// <summary>
        /// Referenz auf das MothershipSound-Modelobjekt um jegliche Abfragen im Model zu tätigen.
        /// </summary>
        public Mothership mothershipGameItem;

        /// <summary>
        /// Erstellt eine Representation des Mutterschiff-Aliens.
        /// </summary>
        public MothershipRepresentation(Mothership mothershipGameItem)
        {
            this.model = ViewContent.RepresentationContent.MothershipModel;
            this.mothershipGameItem = mothershipGameItem;
            this.mothershiptTexture = ViewContent.RepresentationContent.MothershipTexture;
            this.World = Matrix.CreateWorld(PlaneProjector.Convert2DTo3D(this.mothershipGameItem.Position), Vector3.Right, Vector3.Up);

            //[WAHL]
            this.mothershipEngine = null;
            this.explosion = null;
            //[/WAHL]
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
                    effect.Texture = this.mothershiptTexture;
                    effect.World = this.World * Matrix.CreateTranslation(PlaneProjector.Convert2DTo3D(this.mothershipGameItem.Position));
                    effect.View = Camera;
                    effect.Projection = Projection;
                }

                mesh.Draw();
            }
        }
    }
}
