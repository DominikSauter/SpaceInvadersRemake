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
            //Textinhalt aus einer Resourcedatei
            this.CreditsText = Resource.Text_Credits;
            //Anfangsposition der Laufschrift
            this.textPos = new Vector2(0, graphics.PreferredBackBufferHeight);
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
            this.textPos.Y -= this.textSpeed;

            if (this.textPos.Y < -this.font.MeasureString(this.CreditsText).Y)
            {
                this.textPos.Y = graphics.PreferredBackBufferHeight;
            }
        }
    }
}
