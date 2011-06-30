//Implementiert von Dodo
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
        private Model model;
        private Texture2D playerTexture;
        private Vector3 lastPosition;
        private bool playerMoved;

        /// <summary>
        /// Referenz auf das PlayerDamage-Modelobjekt um jegliche Abfragen im Model zu tätigen.
        /// </summary>
        private Player playerGameItem;

        /// <summary>
        /// ParticleEmitter der einen Explosionseffekt erzeugt.
        /// </summary>
        /// <remarks>
        /// Wird Anfangs instanziiert aber erst bei Zerstörung des Schiffs gestartet.
        /// </remarks>
        private Explosion explosion;

        /// <summary>
        /// ParticleEmitter der einen Effekt erzeugt, welcher den Antrieb des Spielerschiffs darstellt.
        /// </summary>
        private PlayerShipEngine playerShipEngine;
    
        /// <summary>
        /// Erstellt eine Representation der Spielerfigur.
        /// </summary>
        public PlayerRepresentation(Player playerGameItem)
        {
            this.model = ViewContent.RepresentationContent.PlayerModel;
            this.playerGameItem = playerGameItem;
            this.playerTexture = ViewContent.RepresentationContent.PlayerTexture;
            this.playerMoved = false;
            this.lastPosition = PlaneProjector.Convert2DTo3D(this.playerGameItem.Position);
            this.World = Matrix.CreateWorld(this.lastPosition, Vector3.Backward, Vector3.Up);

            //<WAHL>
            this.playerShipEngine = null;
            this.explosion = null;
            //<WAHL>
        }

        private ParticleEngine createParticleEngine(System.Collections.Generic.List<Texture2D> textures, Vector2 location, float size)
        {
            throw new System.NotImplementedException();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Vector3 currentPosition = PlaneProjector.Convert2DTo3D(this.playerGameItem.Position);
            float direction = 0.0f;
            if (currentPosition.X > this.lastPosition.X)
            {
                playerMoved = true;
                this.lastPosition = currentPosition;
                direction = -1.0f;
            }
            else if (currentPosition.X < lastPosition.X)
            {
                playerMoved = true;
                this.lastPosition = currentPosition;
                direction = 1.0f;
            }

            foreach (ModelMesh mesh in model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.LightingEnabled = true;
                    effect.SpecularColor = new Vector3(1.0f, 1.0f, 1.0f);
                    effect.SpecularPower = 100.0f;
                    effect.DiffuseColor = new Vector3(1.0f, 1.0f, 1.0f);
                    effect.Texture = this.playerTexture;
                    effect.View = Camera;
                    effect.Projection = Projection;
                    if (this.playerMoved)
                    {
                        effect.World = this.World * Matrix.CreateRotationZ(MathHelper.ToRadians(direction * 25)) * Matrix.CreateTranslation(currentPosition.X, 0, 0);
                    }
                    else
                    {
                        effect.World = this.World * Matrix.CreateTranslation(lastPosition.X, 0, 0);
                    }
                }

                mesh.Draw();
            }
            playerMoved = false;
        }
    }
}
