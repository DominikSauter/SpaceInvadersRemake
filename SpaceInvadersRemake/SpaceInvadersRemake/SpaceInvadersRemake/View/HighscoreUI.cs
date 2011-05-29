using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceInvadersRemake
{
    public class HighscoreUI : IView
    {
        private Texture2D highscoreBackgroundImage;
        private Texture2D font;
    
        public HighscoreUI(string[] buttonLabels)
        {
            throw new System.NotImplementedException();
        }

        public void Show(GameTime gameTime);
    }
}
