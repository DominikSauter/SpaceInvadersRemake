//Implementiert von Anji
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

using SpaceInvadersRemake.ModelSection;

namespace SpaceInvadersRemake.View
{
    /// <summary>
    /// Diese Klasse kümmert sich um die Darstellung eines <c>MenuControl</c> bzw. eines Schaltflächen-Objekts. 
    /// </summary>
    public class ButtonRepresentation
    {
        private MenuControl menuControl;
        private Texture2D buttonTexture;
        private Texture2D selectTexture; 
        private SpriteFont font;
        //Farbe für aktive Menü-Elemente
        private Color activeColor; 
        private Color normalColor;

        private Vector2 fontSize;
        private Vector2 fontCenter;


        /// <summary>
        /// Initialisiert die Schaltflächen
        /// </summary>
        /// <param name="menuControl">Schaltflächen-Objekt</param>
        public ButtonRepresentation(MenuControl menuControl)
        {
            this.menuControl = menuControl;
            this.font = ViewContent.UIContent.Font;
            this.buttonTexture = ViewContent.UIContent.MenuButton;
            this.selectTexture = ViewContent.UIContent.SettingsButton;
            this.normalColor = Color.White;
            this.activeColor = new Color(0, 234, 255);
            //Größe des Schriftzugs
            this.fontSize = font.MeasureString(menuControl.Text);
            //Mitte des Schriftzugs
            this.fontCenter = fontSize / 2;
        }
        
        /// <summary>
        /// Zeichnet eine Schlatfläche
        /// </summary>
        /// <param name="spriteBatch">spriteBatch</param>
        /// <param name="position">Position für die Beschriftung der Schaltfläche</param>
        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            //Größe des Schriftzugs
            Vector2 fontSize = font.MeasureString(menuControl.Text);
            //Mitte des Schriftzugs
            Vector2 fontCenter = fontSize / 2;

            //Position von Select-Feld und Select-Textur
            Vector2 selectPosition = position + new Vector2(fontSize.X + 50, 0); 
            Vector2 selectTextPosition = new Vector2(selectPosition.X + 20, selectPosition.Y); 

            //Eingerückte Position des ausgewählten Buttons
            Vector2 shiftPosition = new Vector2(position.X + 50, position.Y); 

            //Mitte des Buttons und des Select-Feldes
            Vector2 buttonCenter = new Vector2(buttonTexture.Width / 2, buttonTexture.Height / 2); 
            Vector2 selectFieldCenter = new Vector2(selectTexture.Width / 2, selectTexture.Height / 2); 


            //Setzt den Mittelpunkt des Textzugs in die Mitte des Buttons
            Vector2 textCenter = position + buttonCenter;

            //Setzt den Mittelpunkt des eingerückten Textzugs in die Mitte des eingerückten Buttons
            Vector2 shiftTextCenter = shiftPosition + buttonCenter;

            //Setzt den Mittelpunkt des Select-Textes in die Mitte des Select-Feldes
            Vector2 selectTextCenter = selectPosition + selectFieldCenter; 


            //Zeichnen eines Buttons
            if (menuControl is Button)
            {
                spriteBatch.Begin();

                //Buttonbeschriftung
                if (menuControl.Active)
                {
                    //Buttontextur
                    spriteBatch.Draw(buttonTexture, shiftPosition, activeColor);
                    //Aktiver Button
                    spriteBatch.DrawString(font, menuControl.Text, shiftTextCenter, activeColor, 0 , fontCenter, 1.0f, SpriteEffects.None, 0.5f);
                }
                else
                {                    
                    //Buttontextur
                    spriteBatch.Draw(buttonTexture, position, normalColor);

                    spriteBatch.DrawString(font, menuControl.Text, textCenter, normalColor, 0, fontCenter, 1.0f, SpriteEffects.None, 0.5f);
                }
            }

            //TODO: evtl. Farbe bei aktiver Beschriftung auch setzen
            //Zeichnen eines Select-Buttons
            else if (menuControl is ListSelect) // Anpassung für beliebige ListSelect von Tobias
            {


                spriteBatch.Begin();

                //Textur des Select-Feldes
                spriteBatch.Draw(selectTexture, selectPosition, Color.White);

                //Beschriftung des Select-Feldes
                spriteBatch.DrawString(font, ((ListSelect)menuControl).SelectedItemText, selectTextCenter, normalColor, 0, selectFontCenter, 1.0f, SpriteEffects.None, 0.5f);
                if (menuControl.Active)
                {
                    //Titel des Select-Buttons
                    spriteBatch.DrawString(font, menuControl.Text, position, activeColor);
                }
                else
                {
                    spriteBatch.DrawString(font, menuControl.Text, position, normalColor);
                }

            }

          spriteBatch.End(); 

        }
    }
}
