//Implementiert von Dodo
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
        private GraphicsDeviceManager graphics;
        private Model model;
        private Texture2D playerTexture;
        private Vector3 lastPosition;
        private int invincibleCount;
        private PlayerShipEngine playerShipEngine;
        //[Anji] Schifftextur während Schild-PowerUp aktiv ist
        private Texture2D shieldTexture;

        /*
         * <WAHL>
         * Wird benötigt wenn eine Partikel Engine eingebaut wird.
        private Explosion explosion;
         * */  
    
        /// <summary>
        /// Erstellt eine Representation der Spielerfigur.
        /// </summary>
        public PlayerRepresentation(Player playerGameItem, GraphicsDeviceManager graphics)
        {
            this.graphics = graphics;
            this.model = ViewContent.RepresentationContent.PlayerModel;
            GameItem = playerGameItem;
            this.playerTexture = ViewContent.RepresentationContent.PlayerTexture;
            this.shieldTexture = ViewContent.RepresentationContent.ShipShieldTexture;
            this.lastPosition = PlaneProjector.Convert2DTo3D(GameItem.Position);
            this.World = Matrix.CreateWorld(this.lastPosition, Vector3.Forward, Vector3.Up);
            this.invincibleCount = 0;

            //[Anji] Schiffs-Antrieb
            this.playerShipEngine = (PlayerShipEngine)createParticleEngine(ViewContent.RepresentationContent.ShipEngineTexture, PlaneProjector.ToScreenCoordinates(lastPosition, graphics), 0.5f, Color.LightBlue); //new Color(190,195,217));
        
        }

        /*
         * <WAHL>
         * Muss implementiert werden wegen des Interfaces. Wird später benötigt wenn eine Partikel Engine eingebaut wird.
         * */
        private ParticleEngine createParticleEngine(Texture2D texture, Vector2 location, float size, Color color)
        {
            this.playerShipEngine = new PlayerShipEngine(texture, location, size, color, graphics);
            return playerShipEngine;
        }

        /// <summary>
        /// Zeichnet das Spielerschiff auf den Bildschirm.
        /// </summary>
        /// <param name="spriteBatch">SpriteBatch zum Zeichnen</param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            Vector3 currentPosition = PlaneProjector.Convert2DTo3D(GameItem.Position);
            Matrix rotation = Matrix.Identity;

            //[Anji] ShipEngine
            playerShipEngine.EmitterLocation = PlaneProjector.ToScreenCoordinates(lastPosition + new Vector3(0, 0, 45), graphics);
            playerShipEngine.Draw(spriteBatch);

            bool invincible = ((Player)this.GameItem).IsInvincible;
            if (invincible)
            {
                if (this.invincibleCount > 8)
                {
                    this.invincibleCount = 0;
                }
                this.invincibleCount++;
            }

            //Je nach Bewegungsrichtung des Spielers wird das Schiff in die entsprechende Richtung geneigt.
            if (currentPosition.X > this.lastPosition.X)
            {
                this.World = Matrix.CreateWorld(currentPosition, Vector3.Forward, Vector3.Up);
                rotation = Matrix.CreateRotationZ(MathHelper.ToRadians(-25));
                this.lastPosition = currentPosition;
            }
            else if (currentPosition.X < this.lastPosition.X)
            {
                this.World = Matrix.CreateWorld(currentPosition, Vector3.Forward, Vector3.Up);
                rotation = Matrix.CreateRotationZ(MathHelper.ToRadians(25));
                this.lastPosition = currentPosition;
            }
            ((ModelHitsphere)GameItem.BoundingVolume).World = this.World;


            /*
             * WICHTIG!
             * Zurücksetzen des DepthStencils um eine fehlerfreie Kombination von 2D-Sprite und 3D-Model 
             * zeichnen zu können.
             * */
            this.graphics.GraphicsDevice.DepthStencilState = DepthStencilState.Default;

            if (invincible && this.invincibleCount == 8)
            {
            }
            else
            {
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
                        effect.World = rotation * this.World;
                        //[Anji] Schifftextur ändern wenn Schild-PowerUp aktiv
                        if (GameItem.Hitpoints > GameItemConstants.PlayerHitpoints)
                        {
                            effect.Texture = this.shieldTexture;
                        }
                    }

                    mesh.Draw();
                }
            }
        }
    }
}
