//Implementiert von Anji

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
    /// Die HighscoreUI(HighscoreUserInterface) Klasse stellt die Benutzeroberfläche während der Highscore Anzeige dar.
    /// </summary>
    public class HighscoreUI : IView
    {
        private Texture2D highscoreBackgroundImage;
        private Texture2D frame;
        private SpriteFont font;
        private HighscoreManager highscoreManager;
        private SpriteBatch spriteBatch;
        private GraphicsDeviceManager graphics; //um Auflösung zu verändern

        /// <summary>
        /// Initialisiert die Highscoreoberfläche
        /// </summary>
        public HighscoreUI(SpriteFont font, Texture2D background, HighscoreManager highscoreManager, GraphicsDeviceManager graphics, Texture2D frame)
        {
            this.font = ViewContent.UIContent.Font;
            this.background = ViewContent.UIContent.MenuBackgroundImage;
            this.frame = ViewContent.UIContent.SettingsBackground;
    
        }

        /// <summary>
        /// Zeichnet die Spieloberfläche zu einem Zeitpunkt des Spiels.
        /// </summary>
        /// <param name="gameTime">Spielzeit</param>
        public void Draw(GameTime gameTime)
        {
            //Zeichnen des Hintergrundbildes
            spriteBatch.Begin();
            spriteBatch.Draw(highscoreBackgroundImage, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight),Color.White);
            

            //Zeichnen des Highscore Fensters
            spriteBatch.Draw(frame, new Rectangle(100, 100, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferWidth), Color.White);

            //Zeichnen der Highscore Einträge
            Vector2 name_Position = new Vector2(200, 200);
            Vector2 score_Position = new Vector2(400, 200);
            String writeEnabled = "_";

            //Incrementieren der Positionen und Zeichnen der Elemente an den Positionen
            for (int i = 0; i < highscoreManager.HighscoreEntries.Length; i++) 
            {
                //Names
                String name = highscoreManager.HighscoreEntries[i].Name;
                if (highscoreManager.HighscoreEntries[i] == highscoreManager.NewEntry)
                //Wenn ein neuer Eintrag möglich ist, wird ein Cursor ("_") an die letze Stelle der Liste gesetzt, 
                //wo der neue Eintrag erfolgt werden kann. Ansonsten wird der Name gezeichnet.
                {
                    spriteBatch.DrawString(font, name + writeEnabled, name_Position, Color.Cyan);
                }
                else 
                {
                    spriteBatch.DrawString(font, name, name_Position, Color.White);
                }

                //Scores
                int score = highscoreManager.HighscoreEntries[i].Score;
                spriteBatch.DrawString(font, score.ToString(), score_Position, Color.White);

                name_Position.Y += name_Position.Y + i * 100;
                score_Position.Y += score_Position.Y + i * 100;
            }

          spriteBatch.End();
            
        }
    }
}
