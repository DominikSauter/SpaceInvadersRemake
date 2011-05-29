using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceInvadersRemake
{
    public class MenuUI : IView
    {
        private Texture2D menuBackgroundImage;
        private SpriteFont font;
    
        public MenuUI(string[] buttonLabels)
        {
            throw new System.NotImplementedException();
        }

        public SpaceInvadersRemake.ButtonRepresentation[] ButtonRepresentation
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public void Show(GameTime gameTime);

        public void AddButton(Button button)
        {
            throw new System.NotImplementedException();
        }
    }
}
