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
            this.normalColor = Color.White;
            this.activeColor = new Color(14, 255, 20);         
        }
        
        /// <summary>
        /// Zeichnet eine Schlatfläche
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="position">Position für die Beschriftung der Schaltfläche</param>
        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            Vector2 fontSize = font.MeasureString(menuControl.Text);
            Vector2 selectPosition = new Vector2(position.X + fontSize.X, fontSize.Y);
            Vector2 selectTextPosition = new Vector2(selectPosition.X + 20, selectPosition.Y);

            spriteBatch.Begin();

            //Zeichnen eines Buttons
            if (menuControl is Button)
            {
                //Buttonbeschriftung
                if (menuControl.Active)
                {
                    //Aktiver Button
                    spriteBatch.DrawString(font, menuControl.Text, new Vector2(position.X + 65, position.Y + 4), activeColor);
                    //Buttontextur
                    spriteBatch.Draw(buttonTexture, position, activeColor);
                }
                else
                {
                    spriteBatch.DrawString(font, menuControl.Text, new Vector2(position.X + 65, position.Y + 4), normalColor);
                    //Buttontextur
                    spriteBatch.Draw(buttonTexture, position, normalColor);
                }
            }

            //Zeichnen eines Select-Buttons
            else 
            {
                //Textur des Select-Buttons
                spriteBatch.Draw(buttonTexture, selectPosition, Color.White);

                //Objekte vom Typ DisplayMode (Verstellen der Auflösung)
                if (menuControl is ListSelect<DisplayMode>) //HACK: menuControl.GetType() == typeof(ListSelect<>): bin mir nicht sicher ob das so funktioniert (Es soll geprüft werden ob der menuControl vom Typ der ListSelect ist.)
                {
                    //Beschriftung des Select-Buttons
                    spriteBatch.DrawString(font, ((ListSelect<DisplayMode>)menuControl).SelectedItem.ToString(), selectTextPosition, normalColor);

                    if (menuControl.Active)
                    {
                        //Aktiver Select-Button
                        spriteBatch.DrawString(font, ((ListSelect<DisplayMode>)menuControl).Text, position, activeColor);
                    }
                    else 
                    { 
                        spriteBatch.DrawString(font, ((ListSelect<DisplayMode>)menuControl).Text, position, normalColor);
                    }
                }

                //Objekte vom Typ float (Lautstärkeregelung)
                if (menuControl is ListSelect<float>) 
                {
                    spriteBatch.DrawString(font, ((ListSelect<float>)menuControl).SelectedItem.ToString(), selectTextPosition, normalColor);

                    if (menuControl.Active)
                    {
                        spriteBatch.DrawString(font, ((ListSelect<float>)menuControl).Text, position, activeColor);
                    }
                    else 
                    { 
                        spriteBatch.DrawString(font, ((ListSelect<float>)menuControl).Text, position, normalColor);
                    }
                }

                //Objekte vom Typ bool (Vollbild an/aus)
                if (menuControl is ListSelect<bool>)
                {
                    spriteBatch.DrawString(font, ((ListSelect<bool>)menuControl).SelectedItem.ToString(), selectTextPosition, normalColor);

                    if (menuControl.Active)
                    {
                        spriteBatch.DrawString(font, ((ListSelect<bool>)menuControl).Text, position, activeColor);
                    }
                    else 
                    { 
                        spriteBatch.DrawString(font, ((ListSelect<bool>)menuControl).Text, position, normalColor);
                    }
                }
            }

          spriteBatch.End(); 

        }
    }
}
