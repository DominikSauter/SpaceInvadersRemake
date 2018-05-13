//Implementiert von Anji
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

using SpaceInvadersRemake.ModelSection;

namespace SpaceInvadersRemake.View
{
    /// <summary>
    /// Diese Klasse kümmert sich um die Darstellung eines <c>MenuControl</c> bzw. eines Schaltflächen-Objekts. 
    /// Dabei wird unterschieden zwischen Buttons und Select-Feldern. Buttons sind gewöhnliche Schaltflächen und bestehen aus einer Textur und einem
    /// Schriftzug. Aktive Buttons werden eingerückt dargestellt und anders coloriert.
    /// Select-Felder haben einen Titel und ein Auswahlfeld(Textur) wo die auswählbaren Einstellungen(Schriftzug) angezeigt werden. Bei aktiven 
    /// Select-Feldern wird nur der Titel anders gefärbt.
    /// </summary>
    public class ButtonRepresentation
    {
        private MenuControl menuControl;
        private Texture2D buttonTexture; 
        private Texture2D selectTexture;
        private SpriteFont font;
        private SpriteFont fontSelect; 
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
            this.fontSelect = ViewContent.UIContent.FontSelect;
            this.buttonTexture = ViewContent.UIContent.MenuButton;
            this.selectTexture = ViewContent.UIContent.SettingsButton;
            this.normalColor = Color.White;
            this.activeColor = new Color(0, 234, 255); 
        }

        /// <summary>
        /// Zeichnet eine Schlatfläche
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="position">Position für die Beschriftung der Schaltfläche</param>
        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            //TODO: überlegen was tun wegen unterschiedlicher buttonLabel Länge, dass Select Buttons alle auf einer Ebene
            //Idee: mit MeasureString längste Länge bestimmen, davon Abstand zu Select-Element

            Vector2 fontSize = font.MeasureString(menuControl.Text);
            //Zentrum des Schriftzugs (abhängig von Schriftart und -größe)
            Vector2 fontCenter = fontSize / 2;

            //Position des SelectButtons
            Vector2 selectPosition = position + new Vector2(fontSize.X + 50, 0);
            //Position der SelectAnzeige
            Vector2 selectTextPosition = new Vector2(selectPosition.X + 20, selectPosition.Y);

            //Eingerückte position des ausgewählten Buttons
            Vector2 shiftPosition = new Vector2(position.X + 50, position.Y);

            //Mittelpunkt des Buttons
            Vector2 buttonCenter = new Vector2(buttonTexture.Width / 2, buttonTexture.Height / 2);
            //Mittelpunkt des Select-Feldes
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
                    //Aktiver Button

                    //Buttontextur
                    spriteBatch.Draw(buttonTexture, shiftPosition, activeColor);
                    //Buttonbeschriftung
                    spriteBatch.DrawString(font, menuControl.Text, shiftTextCenter, activeColor, 0, fontCenter, 1.0f, SpriteEffects.None, 0.5f);
                }
                else
                {
                    //Buttontextur
                    spriteBatch.Draw(buttonTexture, position, normalColor);
                    //Buttonbeschriftung
                    spriteBatch.DrawString(font, menuControl.Text, textCenter, normalColor, 0, fontCenter, 1.0f, SpriteEffects.None, 0.5f);
                }
            }

            //Zeichnen eines Select-Buttons
            else if (menuControl is ListSelect) 
            {
                Vector2 selectFontSize = this.fontSelect.MeasureString(((ListSelect)menuControl).SelectedItemText);
                //Zentrum des Schriftzugs (abhängig von Schriftart und -größe)
                Vector2 selectFontCenter = selectFontSize / 2;

                spriteBatch.Begin();

                //Textur des Select-Feldes
                spriteBatch.Draw(selectTexture, selectPosition, Color.White);

                //Beschriftung des Select-Feldes
                spriteBatch.DrawString(this.fontSelect, ((ListSelect)menuControl).SelectedItemText, selectTextCenter, normalColor, 0, selectFontCenter, 1.0f, SpriteEffects.None, 0.5f);

                //Titel des Select-Buttons
                if (menuControl.Active)
                {
                    //Aktiver Select
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
