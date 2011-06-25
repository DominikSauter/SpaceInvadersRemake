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
            this.activeColor = new Color(0, 255, 186);         
        }
        
        /// <summary>
        /// Zeichnet eine Schlatfläche
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="position">Position für die Beschriftung der Schaltfläche</param>
        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {

            //TODO: Einrücken ausprobieren bei aktiven Buttons [Check]
            //TODO: Schriftzug bei Buttons Zentrieren
            //TODO: überlegen was tun wegen unterschiedlicher buttonLabel Länge, dass Select Buttons alle auf einer Ebene
                //Idee: mit MeasureString längste Länge bestimmen, davon Abstand zu Select-Element
            Vector2 fontSize = font.MeasureString(menuControl.Text);
            Vector2 selectPosition = new Vector2(position.X + fontSize.X, fontSize.Y);
            Vector2 selectTextPosition = new Vector2(selectPosition.X + 20, selectPosition.Y);
            Vector2 shiftPosition = new Vector2(position.X + 50, position.Y);

            spriteBatch.Begin();

            //Zeichnen eines Buttons
            if (menuControl is Button)
            {
                //Buttonbeschriftung
                if (menuControl.Active)
                {
                    //Buttontextur
                    spriteBatch.Draw(buttonTexture, shiftPosition, activeColor);
                    //Aktiver Button
                    spriteBatch.DrawString(font, menuControl.Text, new Vector2(shiftPosition.X + 65, shiftPosition.Y + 4), activeColor);
                }
                else
                {                    
                    //Buttontextur
                    spriteBatch.Draw(buttonTexture, position, normalColor);

                    spriteBatch.DrawString(font, menuControl.Text, new Vector2(position.X + 65, position.Y + 4), normalColor);
                }
            }

            //TODO: evtl. Farbe bei aktiver Beschriftung auch setzen
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
