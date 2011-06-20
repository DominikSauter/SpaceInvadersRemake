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
    /// Die HighscoreUI(HighscoreUserInterface) Klasse stellt die Benutzeroberfläche während der Highscore Anzeige dar.
    /// </summary>
    public class HighscoreUI : IView
    {
        private Texture2D highscoreBackgroundImage;
        private Texture2D font;

        /// <summary>
        /// Initialisiert die Highscoreoberfläche
        /// </summary>
        public HighscoreUI(SpriteFont font, Texture2D background, HighscoreEntry[] highscoreEntries)
        {
            throw new System.NotImplementedException();
        }

        public HighscoreEntry[] HighscoreEntries
        {
            get;
            set;
        }

        /// <summary>
        /// Zeichnet die Spieloberfläche zu einem Zeitpunkt des Spiels.
        /// </summary>
        /// <param name="gameTime">Spielzeit</param>
        public void Draw(GameTime gameTime)
        {
            throw new System.NotImplementedException();
        }
    }
}
