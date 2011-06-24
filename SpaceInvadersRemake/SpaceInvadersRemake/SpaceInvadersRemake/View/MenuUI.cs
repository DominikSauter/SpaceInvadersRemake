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
        /// <param name="buttons">MenuControl Elemente</param>
        /// <param name="graphics"></param>
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

            //TODO: unterscheidung zwischen ienstellungsmenü und hauptmenü (state)
            Vector2 position = new Vector2(200, 200);
            spriteBatch.Begin();

            //Zeichnen des Hintergrunds
            spriteBatch.Draw(background , new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);


                //probieren ob Array.draw geht
            //Buttons zeichnen
            for (int i = 0; i < buttonRepresentation.Length; i++)
            {
                position.Y += 100 * i;

                if (buttonRepresentation[i].buttonItem is Button)
                {
                    buttonRepresentation[i].DrawButton(spriteBatch, position);
                }
                else
                {
                    buttonRepresentation[i].DrawSelect(spriteBatch, position);
                }
            }


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
            ButtonRepresentation buttonRepresentation;

            //Wenn button
            if (button is Button) 
            {
                //active
                if (button.Active)
                {
                    buttonRepresentation = new ButtonRepresentation(button.Text, activeColor, button);
                }
                else 
                {
                    buttonRepresentation = new ButtonRepresentation(button.Text, normalColor, button);
                }
            }

            else if (button is ListSelect<DisplayMode>) //prüfen ob eine intanz von ListSelect vom Typ DisplayMode
            { 
               if (((ListSelect<DisplayMode>)button).Active) 
               {
                   buttonRepresentation = new ButtonRepresentation(button.Text, ((ListSelect<DisplayMode>)button).SelectedItem.ToString(), activeColor, button);
               } 
               else 
               {
                   buttonRepresentation = new ButtonRepresentation(button.Text, ((ListSelect<DisplayMode>)button).SelectedItem.ToString(), normalColor, button);
               }
            }

            else if (button is ListSelect<float>)
            { 
               if (((ListSelect<float>)button).Active) 
               {
                   buttonRepresentation = new ButtonRepresentation(button.Text, ((ListSelect<float>)button).SelectedItem.ToString(), activeColor, button);
               } 
               else 
               {
                   buttonRepresentation = new ButtonRepresentation(button.Text, ((ListSelect<float>)button).SelectedItem.ToString(), normalColor, button);
               }            
            }

            else
            { 
               if (((ListSelect<bool>)button).Active) 
               {
                   buttonRepresentation = new ButtonRepresentation(button.Text, ((ListSelect<bool>)button).SelectedItem.ToString(), activeColor, button);
               } 
               else 
               {
                   buttonRepresentation = new ButtonRepresentation(button.Text, ((ListSelect<bool>)button).SelectedItem.ToString(), normalColor, button);
               }            
            }

            return buttonRepresentation;

         //TODO: überlegen was tun wegen unterschiedlicher buttonLabel Länge, dass Select Buttons alle auf einer Ebene
         
        }
    }
}
