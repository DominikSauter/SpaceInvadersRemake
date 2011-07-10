//Implementiert von Dodo
using System;

using SpaceInvadersRemake.Settings;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceInvadersRemake.Resources;

namespace SpaceInvadersRemake.View
{
    public class CreditsUI : SpaceInvadersRemake.View.IView
    {
        private GraphicsDeviceManager graphics;

        private SpriteFont font;
        private Texture2D backgroundImage;

        //Folgende 3 Felder sind für die Laufschrift in den Credits
        private Vector2 textPos;
        private float textSpeed;
        private bool textEnd;
    
        /// <summary>
        /// Erzeugt eine Credits Oberfläche, die ein Hintergrundbild und eine Laufschrift enthält.
        /// </summary>
        /// <param name="graphics">Handlerobjekt für die Grafikkarte</param>
        public CreditsUI(GraphicsDeviceManager graphics)
        {
            this.graphics = graphics;

            this.font = ViewContent.UIContent.Font;
            this.backgroundImage = ViewContent.UIContent.MenuBackgroundImage;

            
            //Laufgeschwindigkeit des Texts
            this.textSpeed = 1.0f;
            //bool ob der Text seine endgültige Position erreicht hat
            textEnd = false;
            //Textinhalt aus einer Resourcedatei
            this.CreditsText = Resource.Text_Credits;
            //Anfangsposition der Laufschrift
            this.textPos = new Vector2((graphics.PreferredBackBufferWidth - font.MeasureString(this.CreditsText).X) / 4, graphics.PreferredBackBufferHeight);
        }

        /// <summary>
        /// Hält die Laufschrift die angezeigt wird.
        /// </summary>
        public String CreditsText
        {
            get;
            private set;
        }

        /// <summary>
        /// Zeichnen der Credits Oberfläche
        /// </summary>
        /// <param name="spriteBatch">Wird zum zeichnen von Sprites benötigt</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(this.backgroundImage, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);
            spriteBatch.DrawString(this.font, this.CreditsText, this.textPos, new Color(14, 255, 20));

            spriteBatch.End();

            //Laufschrift-Aktualisierung
            if (!this.textEnd)
            {
                this.textPos.Y -= this.textSpeed;
            }

            if (this.textPos.Y < (graphics.PreferredBackBufferHeight - this.font.MeasureString(this.CreditsText).Y) / 2)
            {
                this.textEnd = true;
            }
        }
    }
}
