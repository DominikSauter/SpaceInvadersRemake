using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceInvadersRemake.ModelSection;

namespace SpaceInvadersRemake.View
{
    /// <summary>
    /// Die MenuUI(MenuUserInterface) Klasse stellt die Menüoberfläche des Spiels dar.
    /// </summary>
    public class MenuUI : IView
    {
        private Texture2D background;
        private GraphicsDeviceManager graphics;
        private ButtonRepresentation[] buttonRepresentation;
    
        /// <summary>
        /// Initialisiert die Menüoberfläche
        /// </summary>
        /// <param name="buttonLabels">Beschriftungen der Controls</param>
        /// <param name="background">Hintergrundbild</param>
        public MenuUI(MenuControl[] buttons,  GraphicsDeviceManager graphics)
        {
            this.background = ViewContent.UIContent.MenuBackgroundImage;
            this.graphics = graphics;


            this.buttonRepresentation = new ButtonRepresentation[buttons.Length];

            for (int i = 0; i < buttons.Length; i++)
            {
                buttonRepresentation[i] = AddButton(buttons[i]);
            }

        }

        /// <summary>
        /// Zeichnet die Spieloberfläche zu einem Zeitpunkt des Spiels.
        /// </summary>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            //Zeichnen des Hintergrunds
            spriteBatch.Draw(background , new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);


                //probieren ob Array.draw geht
            //Buttons zeichnen

            spriteBatch.End();
        }

        /// <summary>
        /// Erstellt ein ButtonRepresentation Objekt welches zu der Liste hinzugefügt wird.
        /// </summary>
        /// <param name="button"> Von dem State übergebener Button</param>
        public ButtonRepresentation AddButton(MenuControl button)
        {
            Color activeColor = Color.AliceBlue;
            Color normalColor = Color.White;

            //Wenn button
            if(button is Button) 
            {
                //active
                if (button.Active)
                {
                new ButtonRepresentation(button.Text, activeColor);
                }
                else 
                {
                    new ButtonRepresentation(button.Text, normalColor);
                }
            }
            throw new System.NotImplementedException();
 
           /* if (button is ListSelect<DisplayMode>) //prüfen ob eine intanz von ListSelect
                if (button.GetType().GetGenericTypeDefinition() == ListSelect<>) { }

                new ButtonRepresentation( );
            } */
            

            //HACK: überlegen wie man eine instanz einer generischen Liste erzeugen kann


            //TODO: überlegen was tun wegen unterschiedlicher buttonLabel Länge, dass Select Buttons alle auf einer Ebene
         
        }
    }
}
