//Implementiert von Anji
using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceInvadersRemake.ModelSection;

namespace SpaceInvadersRemake.View
{
    /// <summary>
    /// Die HighscoreUI(HighscoreUserInterface) Klasse stellt die Benutzeroberfläche während der Highscore Anzeige dar.
    /// </summary>
    public class HighscoreUI : IView
    {
        private Texture2D frame;
        private SpriteFont font;
        private Texture2D background;
        private HighscoreManager highscoreManager;
        private GraphicsDeviceManager graphics;

        /// <summary>
        /// Initialisiert die Highscoreoberfläche
        /// </summary>
        public HighscoreUI(HighscoreManager highscoreManager, GraphicsDeviceManager graphics)
        {
            this.font = ViewContent.UIContent.Font;
            this.background = ViewContent.UIContent.MenuBackgroundImage;
            this.frame = ViewContent.UIContent.SettingsBackground;
            this.graphics = graphics;
            this.highscoreManager = highscoreManager;
    
        }

        /// <summary>
        /// Zeichnet die Spieloberfläche zu einem Zeitpunkt des Spiels.
        /// </summary>
        public void Draw(SpriteBatch spriteBatch)
        {
            Vector2 framePosition = new Vector2((graphics.PreferredBackBufferWidth - this.frame.Width) / 2, (graphics.PreferredBackBufferHeight - this.frame.Height) / 2);
            Vector2 namePosition = framePosition + new Vector2(20, 100);
            Vector2 scorePosition = framePosition + new Vector2(frame.Width - 60, 100);
            Vector2 titlePosition = framePosition + new Vector2(20, 20);
            String writeEnabled = "_";

            spriteBatch.Begin();

            //Zeichnen des Hintergrundbildes
            spriteBatch.Draw(this.background, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);
            
            //Zeichnen des Menü-Titels
            spriteBatch.DrawString(this.font, "HIGHSCORE", titlePosition, Color.White);

            //Zeichnen des Highscore Fensters
            spriteBatch.Draw(this.frame, new Rectangle((int)framePosition.X, (int)framePosition.Y, frame.Width, frame.Height * (3/2)), Color.White);

            //Zeichnen der Highscore Einträge
            //Incrementieren der Positionen und dortiges Zeichnen der Elemente
            for (int i = 0; i < highscoreManager.HighscoreEntries.Length; i++) 
            {
                //Names
                String name = highscoreManager.HighscoreEntries[i].Name;
                if (highscoreManager.HighscoreEntries[i] == highscoreManager.NewEntry)
                //Wenn ein neuer Eintrag möglich ist, wird ein Cursor ("_") an die letze Stelle der Liste gesetzt, 
                //wo der neue Eintrag erfolgt werden kann. Ansonsten wird der Name gezeichnet.
                {
                    spriteBatch.DrawString(this.font, name + writeEnabled, namePosition, Color.Cyan);
                }
                else 
                {
                    spriteBatch.DrawString(this.font, name, namePosition, Color.White);
                }

                //Scores
                int score = highscoreManager.HighscoreEntries[i].Score;
                spriteBatch.DrawString(this.font, score.ToString(), scorePosition, Color.White);

                namePosition.Y += 30;
                scorePosition.Y += 30;
            }

          spriteBatch.End();
            
        }
    }
}
