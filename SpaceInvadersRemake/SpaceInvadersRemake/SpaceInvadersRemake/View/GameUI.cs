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
    
        /// <summary>
        /// Initialisiert die Spieloberfläche
        /// </summary>
        /// <param name="font">Schriftart mit welcher der HUD beschriftet wird.</param>
        /// <param name="background">Hintergrundbild</param>
        /// <param name="hud">HUD-Hintergrund</param>
        /// <param name="powerUpIcons">Liste von powerUpIcons</param>
        public GameUI(GameCourseManager gameCourseMngr, GraphicsDeviceManager graphics)
        {
            this.graphics = graphics;
            this.spriteBatch = new SpriteBatch(this.graphics.GraphicsDevice);

            this.Lives = ((Player)gameCourseMngr.GameCourse.Player).Lives;
            this.Score = ((Player)gameCourseMngr.GameCourse.Player).Score;

        }

        public int Lives
        {
            get;
            private set;
        }

        public int Score
        {
            get;
            private set;
        }

        /// <summary>
        /// Zeichnet die Spieloberfläche zu einem Zeitpunkt des Spiels.
        /// </summary>
        /// <param name="gameTime">Spielzeit</param>
        public void Draw(GameTime gameTime)
        {
            //Counter, der angibt wie oft die HUD Grafik (32x60) gezeichnet werden muss.
            int hudTileCount = graphics.PreferredBackBufferWidth / this.hudBackgroundTexture.Width;


            spriteBatch.Begin();

            spriteBatch.Draw(this.gameBackgroundImage, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);
            
            for(int tileCount = 0; tileCount < hudTileCount; tileCount++)
            {
                spriteBatch.Draw(this.hudBackgroundTexture, new Vector2((float)(tileCount*this.hudBackgroundTexture.Width),
                    (float)(graphics.PreferredBackBufferHeight - this.hudBackgroundTexture.Height)), Color.White);
            }

            for(int liveCount = 0; liveCount < this.Lives; liveCount++)
            {

            }

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
