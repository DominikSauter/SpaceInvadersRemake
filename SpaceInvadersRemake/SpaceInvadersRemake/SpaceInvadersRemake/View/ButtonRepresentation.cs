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
        private Texture2D buttonTexture; //property, falls Menu Zentrieren
        private Texture2D selectTexture; //evtl. auch property, falls Menu Zentrieren
        private SpriteFont font;
        private Color activeColor; //Farbe für aktive Menü-Elemente
        private Color normalColor;


        /// <summary>
        /// Initialisiert die Schaltflächen
        /// </summary>
        /// <param name="menuControl">Schaltflächen-Objekt</param>
        public ButtonRepresentation(MenuControl menuControl)
        {
            this.menuControl = menuControl;
            this.font = ViewContent.UIContent.Font;
            this.buttonTexture = ViewContent.UIContent.MenuButton;
            this.selectTexture = ViewContent.UIContent.SettingsButton; //Der muss noch geändert werden
            this.normalColor = Color.White;
            this.activeColor = new Color(0, 234, 255);     //0, 228, 255
        }
        
        /// <summary>
        /// Zeichnet eine Schlatfläche
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="position">Position für die Beschriftung der Schaltfläche</param>
        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {

            //TODO: schauen welche Vektoren in die schleifen kommen
            //TODO: überlegen was tun wegen unterschiedlicher buttonLabel Länge, dass Select Buttons alle auf einer Ebene
                //Idee: mit MeasureString längste Länge bestimmen, davon Abstand zu Select-Element
            Vector2 fontSize = font.MeasureString(menuControl.Text);
            Vector2 fontCenter = fontSize / 2;

            Vector2 selectPosition = position + new Vector2(fontSize.X + 50, 0); //Position des SelectButtons
            Vector2 selectTextPosition = new Vector2(selectPosition.X + 20, selectPosition.Y); //Position der SelectAnzeige //zentrieren?

            Vector2 shiftPosition = new Vector2(position.X + 50, position.Y); //Eingerückte position

            Vector2 buttonCenter = new Vector2(buttonTexture.Width / 2, buttonTexture.Height / 2); //Mittelpunkt des Buttons
            Vector2 selectFieldCenter = new Vector2(selectTexture.Width / 2, selectTexture.Height / 2); //Mittelpunkt des Select-Feldes

            Vector2 textCenter = position + buttonCenter; //Setzt den Mittelpunkt des Textzugs in die Mitte des Buttons
            Vector2 shiftTextCenter = shiftPosition + buttonCenter; //Setzt den Mittelpunkt des eingerückten Textzugs in die Mitte des eingerückten Buttons
            Vector2 selectTextCenter = selectPosition + selectFieldCenter; //Setzt den Mittelpunkt des Select-Textes in die Mitte des Select-Feldes


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
                Vector2 selectFontSize = font.MeasureString(((ListSelect)menuControl).SelectedItemText);
                Vector2 selectFontCenter = selectFontSize / 2;

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
