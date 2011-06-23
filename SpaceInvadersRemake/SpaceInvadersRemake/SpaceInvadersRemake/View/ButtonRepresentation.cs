﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SpaceInvadersRemake.View
{
    /// <summary>
    /// Diese Klasse kümmert sich um die Darstellung eines Controls.
    /// </summary>
    public class ButtonRepresentation : IView
    {
        private Texture2D buttonTexture;
        private SpriteFont font;
        private string buttonLabel;
        private string settingLabel;
        Color color; //Schriftfarbe, bei Active gefärbt, sonst weis

        /// <summary>
        /// Initialisiert das Button Objekt
        /// </summary>
        public ButtonRepresentation(String buttonLabel, Color color)
        {
            this.buttonTexture = ViewContent.UIContent.MenuButton;
            this.buttonLabel = buttonLabel;
            this.font = ViewContent.UIContent.Font;
            this.settingLabel = null;
            this.color = color;
        }

        public ButtonRepresentation(String buttonLabel, String settingLabel, Color color) 
        {
            this.buttonTexture = ViewContent.UIContent.SettingsButton; //TODO: Select Button Textur ändern
            this.buttonLabel = buttonLabel;
            this.font = ViewContent.UIContent.Font;
            this.settingLabel = settingLabel;
            this.color = color;
        }

        public void DrawButton(SpriteBatch spriteBatch, Vector2 position)
        {
            spriteBatch.Begin();

            //zeichnet Textur
            spriteBatch.Draw(buttonTexture, position, color);

            //zeichnet Beschriftung
            spriteBatch.DrawString(font, buttonLabel, position, color);

            spriteBatch.End();
        }

        public void DrawSelect(SpriteBatch spriteBatch, Vector2 position)
        {
            Vector2 fontSize = font.MeasureString(buttonLabel);
            Vector2 selectPosition = new Vector2(position.X + fontSize.X, fontSize.Y);
            Vector2 selectTextPosition = new Vector2(selectPosition.X + 20, selectPosition.Y);

            spriteBatch.Begin();

            //zeichnet Textur
            spriteBatch.Draw(buttonTexture, selectPosition, color);

            //zeichnet Beschriftung
            spriteBatch.DrawString(font, buttonLabel, position, color);
            spriteBatch.DrawString(font, settingLabel, selectTextPosition, color);

            spriteBatch.End();
        }

    }
}
