//Implementiert von Dodo
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
        private GraphicsDeviceManager graphics;

        private SpriteFont font;
        private Texture2D backgroundImage;

        /* ~~~~~~~~~~~~TEST~~~~~~~~~~~~~~~
         * Folgende 3 Felder dienen zum Testen einer Laufschrift in den Credits
         * */
        private Vector2 textPos;
        private float textSpeed;
        private bool textEnd;
    
        public CreditsUI(GraphicsDeviceManager graphics)
        {
            this.graphics = graphics;

            this.font = ViewContent.UIContent.Font;
            this.backgroundImage = ViewContent.UIContent.MenuBackgroundImage;

            /* ~~~~~~~~~~~~TEST~~~~~~~~~~~~~~~
            * Folgende 4 Zuweisungen dienen zum Testen einer Laufschrift in den Credits
            * */
            this.textPos = new Vector2(200.0f, 100.0f);
            this.textSpeed = 1.0f;
            textEnd = false;
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

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(this.backgroundImage, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);
            spriteBatch.DrawString(this.font, this.CreditsText, this.textPos, Color.White);

            spriteBatch.End();

            /* ~~~~~~~~~~~~TEST~~~~~~~~~~~~~~~
            * Folgende if-else-Anweisung dient zum Testen einer Laufschrift in den Credits
            * */
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
