using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceInvadersRemake.View
{
    /// <summary>
    /// Die HighscoreUI(HighscoreUserInterface) Klasse stellt die Benutzeroberfläche während der Highscore Anzeige dar.
    /// </summary>
    public class HighscoreUI : IView
    {
        private Texture2D highscoreBackgroundImage;
        private Texture2D font;
    
        /// <summary>
        /// Initialisiert die Highscoreoberfläche
        /// </summary>
        /// <param name="buttonLabels">Beschriftungen der Buttons</param>
        public HighscoreUI(string[] buttonLabels)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Zeichnet die Spieloberfläche zu einem Zeitpunkt des Spiels.
        /// </summary>
        /// <param name="gameTime">Zeitpunkt des Spiels, zu dem die <c>draw</c> Methode aufgerufen wird.</param>
        public void Draw(GameTime gameTime);
    }
}
