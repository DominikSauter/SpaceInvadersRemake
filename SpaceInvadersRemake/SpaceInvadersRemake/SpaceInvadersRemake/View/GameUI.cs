using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceInvadersRemake
{
    public class GameUI : IView
    {
        private Texture2D gameBackgroundImage;
        private Texture2D hudBackgroundTexture;
        private SpriteFont font;
    
        public GameUI()
        {
            throw new System.NotImplementedException();
        }

        public void Show(GameTime gameTime);

        private void labelHUD()
        {
            throw new System.NotImplementedException();
        }
    }
}
