using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceInvadersRemake.View
{
    public class CreditsUI : SpaceInvadersRemake.View.IView
    {
        private SpriteBatch spriteBatch;
        private GraphicsDeviceManager graphics;

        private SpriteFont font;
        private Texture2D backgroundImage;

        //TEST-TEST
        private Vector2 textPos;
        private float textSpeed;
        private bool textEnd;
    
        public CreditsUI(GraphicsDeviceManager graphics)
        {
            this.spriteBatch = ViewManager.spriteBatch;
            this.graphics = graphics;

            this.font = ViewContent.UIContent.Font;
            this.backgroundImage = ViewContent.UIContent.MenuBackgroundImage;

            //TEXT-TEST
            this.textPos = new Vector2(200.0f, 100.0f);
            this.textSpeed = 1.0f;
            textEnd = false;

            //TEXT-TEST für die Credits
            this.CreditsText = "~ Space Invaders Remake ~\n"
                + "~~~~~~~~~~~~~~~~~~~~~~~~\n"
                + "\n"
                + "An diesem Projekt waren beteiligt:\n"
                + "Anjela \"Anji\" Mayer\n"
                + "Christian Klotz\n"
                + "Dominik Sauter\n"
                + "Dominik \"Dodo\" Schaufelberger\n"
                + "Steffen Stehmann\n"
                + "Tobias \"der Doofe\" Bast\n"
                + "\n"
                + "Wir danken einfach allen! Ihr seid super!!!";
        }

        public String CreditsText
        {
            get;
            private set;
        }

        public void Draw()
        {
            spriteBatch.Begin();

            spriteBatch.Draw(this.backgroundImage, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);
            spriteBatch.DrawString(this.font, this.CreditsText, this.textPos, Color.White);

            spriteBatch.End();

            if (!this.textEnd)
            {
                this.textPos.Y -= this.textSpeed;
            }

            if (this.textPos.Y == (graphics.PreferredBackBufferHeight - this.font.MeasureString(this.CreditsText).Y) / 2)
            {
                this.textEnd = true;
            }
        }
    }
}
