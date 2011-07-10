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
    /// Stellt die auf dem Bildschirm sichtbaren Aliens dar.
    /// </summary>
    public class AlienRepresentation : GameItemRepresentation
    {
        //Handler um die Grafikeinstellungen zu tätigen.
        private GraphicsDeviceManager graphics;

        //3D Modell mit dem das Alien angezeigt wird
        private Model model;

        //Modell Textur, da jedem Alien eine zufällige Textur zugewiesen wird
        private Texture2D alienTexture;

        //letzte Position des Aliens
        private Vector3 lastPosition;

        /// <summary>
        /// ParticleEmitter der einen Explosionseffekt erzeugt.
        /// </summary>
        /// <remarks>
        /// Wird Anfangs instanziiert aber erst bei Zerstörung des Schiffs gestartet.
        /// </remarks>
        private Explosion explosion;

        
        /// /// <summary>
        /// Erstellt eine Representation eines Aliens.
        /// </summary>
        /// <param name="alienGameItem">Alien Datenmodell</param>
        /// <param name="randomTexture">Wird zufällig generiert und kann unterschiedliche Texturen zuordnen.</param>
        /// <param name="graphics">Verbindungselement zu Grafikkarte</param>
        public AlienRepresentation(Alien alienGameItem, int randomTexture, GraphicsDeviceManager graphics)
        {
            this.graphics = graphics;
            this.model = ViewContent.RepresentationContent.AlienModel;
            GameItem = alienGameItem;       //Hält das zugehörige Datenmodel des Aliens, für die "isAlive"-Prüfung
            this.lastPosition = PlaneProjector.Convert2DTo3D(GameItem.Position);
            this.World = Matrix.CreateWorld(this.lastPosition, Vector3.Backward, Vector3.Up);

            //zuweisen einer zufälligen Textur, die an Hand von 'randomTexture' vorher im ViewManager ausgewählt wurde
            this.alienTexture = ViewContent.RepresentationContent.AlienTextures[randomTexture];            

            //[WAHL]
            this.explosion = null;
            //[/WAHL]
        }

        private ParticleEngine createParticleEngine(System.Collections.Generic.List<Texture2D> textures, Vector2 location, float size)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Zeichnet das 3D Modell auf den Bildschirm.
        /// </summary>
        /// <param name="spriteBatch">Wird zum Zeichnen von 2D Grafik benötigt</param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            //aktuelle Position des des 3D Modells
            Vector3 currentPosition = PlaneProjector.Convert2DTo3D(GameItem.Position);
            if (currentPosition.X > this.lastPosition.X || currentPosition.X < this.lastPosition.X
                || currentPosition.Z > this.lastPosition.Z || currentPosition.Z < this.lastPosition.Z)
            {
                /* Berechnet die neue Position des 3D Modells falls sich diese geändert haben sollte.
                 * 
                 * Falsche Positionierung im 3D-Raum gefixt - TB
                 * */
                this.World = Matrix.CreateWorld(currentPosition, Vector3.Backward, Vector3.Up);
                ((ModelHitsphere)GameItem.BoundingVolume).World = this.World;
                //Position aktualisieren
                this.lastPosition = currentPosition;
            }

            /*
             * WICHTIG!
             * Zurücksetzen des DepthStencils um eine fehlerfreie Kombination von 2D-Sprite und 3D-Model 
             * zeichnen zu können.
             * */
            this.graphics.GraphicsDevice.DepthStencilState = DepthStencilState.Default;

            foreach (ModelMesh mesh in model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.LightingEnabled = true;
                    effect.SpecularColor = new Vector3(1.0f, 1.0f, 1.0f);
                    effect.SpecularPower = 100.0f;
                    effect.DiffuseColor = new Vector3(1.0f, 1.0f, 1.0f);
                    effect.Texture = this.alienTexture;
                    effect.View = Camera;
                    effect.Projection = Projection;
                    effect.World = this.World;
                }

                mesh.Draw();
            }
        }
    }
}
