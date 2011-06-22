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
    /// Die GameUI(GameUserInterface) Klasse stellt die Spieloberfläche während des Spiels via der <c>Draw()</c> Methode dar.
    /// </summary>
    public class GameUI : IView
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private Texture2D gameBackgroundImage;
        private Texture2D hudBackgroundTexture;
        private SpriteFont font;
        private List<Texture2D> powerUpIcons;
        private Texture2D liveIcon;
        private int lives;
        private int score;

        /// <summary>
        /// Initialisiert die Spieloberfläche
        /// </summary>
        /// <param name="gameCourseMngr"></param>
        /// <param name="graphics"></param>
        public GameUI(GameCourseManager gameCourseMngr, GraphicsDeviceManager graphics)
        {
            this.graphics = graphics;
            this.spriteBatch = ViewManager.spriteBatch;

            this.lives = ((Player)gameCourseMngr.GameCourse.Player).Lives;
            this.score = ((Player)gameCourseMngr.GameCourse.Player).Score;
            this.font = ViewContent.UIContent.Font;
            this.gameBackgroundImage = ViewContent.UIContent.GameBackgroundImage;
            this.hudBackgroundTexture = ViewContent.UIContent.HUDBackground;
            this.liveIcon = ViewContent.UIContent.LiveIcon;
            //this.powerUpIcons

        }

        /// <summary>
        /// Zeichnet die Spieloberfläche zu einem Zeitpunkt des Spiels.
        /// </summary>
        /// <param name="gameTime">Spielzeit</param>
        public void Draw(GameTime gameTime)
        {
            //Counter, der angibt wie oft die HUD Grafik (32x60) gezeichnet werden muss.
            int hudTileCount = graphics.PreferredBackBufferWidth / this.hudBackgroundTexture.Width;

            //Farbe für die Spielerleben Icons, abhängig von der Anzahl der Leben
            Color liveColor;

            //Vektor mit Länge/Breite für den String welcher die Punktzahl darstellt
            Vector2 scoreStringLength = this.font.MeasureString(this.score.ToString());

            /*Festlegen der Farben
             * */
            if (this.lives == 1)
            {
                liveColor = Color.Red;
            }
            else if (this.lives == 2)
            {
                liveColor = Color.Yellow;
            }
            else
            {
                liveColor = Color.Green;
            }


            spriteBatch.Begin();

            spriteBatch.Draw(this.gameBackgroundImage, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);
            
            for(int tileCount = 0; tileCount < hudTileCount; tileCount++)
            {
                spriteBatch.Draw(this.hudBackgroundTexture, new Vector2((float)(tileCount*this.hudBackgroundTexture.Width),
                    (float)(graphics.PreferredBackBufferHeight - this.hudBackgroundTexture.Height)), Color.White);
            }

            for(int liveCount = 0; liveCount < this.lives; liveCount++)
            {
                spriteBatch.Draw(this.liveIcon, new Vector2((float)((liveCount+1)*this.liveIcon.Width),
                    (float)(graphics.PreferredBackBufferHeight - this.liveIcon.Height)), Color.White);
            }

            spriteBatch.DrawString(this.font, this.score.ToString(), new Vector2((float)(graphics.PreferredBackBufferWidth - scoreStringLength.X),
                (float)(graphics.PreferredBackBufferHeight - scoreStringLength.Y)), Color.Green);

            spriteBatch.End();
        }

        /// <summary>
        /// Zeichnet Punkte und Leben des Spielers, sowie die Dauer des eingesammelten PowerUps
        /// </summary>
        private void labelHUD() {
            throw new System.NotImplementedException();
        }
    }
}
