using System;
using System.Collections.Generic;
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
    
        /// <summary>
        /// Initialisiert die Menüoberfläche
        /// </summary>
        /// <param name="buttonLabels">Beschriftungen der Controls</param>
        /// <param name="background">Hintergrundbild</param>
        public MenuUI(MenuControl[] buttons,  GraphicsDeviceManager graphics)
        {
            this.background = ViewContent.UIContent.MenuBackgroundImage;
            this.graphics = graphics;
            

            ButtonRepresentation[] tmp = new ButtonRepresentation[buttons.Length];
            for (int i = 0; i < tmp.Length; i++)
            {
                tmp[i] = AddButton(buttons[i]);
            }

        }

        /// <summary>
        /// Beinhaltet Objekte der Klasse ButtonRepresentation, die die einzelnen Controls darstellen.
        /// </summary>
        public ButtonRepresentation[] ButtonRepresentation
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        /// <summary>
        /// Zeichnet die Spieloberfläche zu einem Zeitpunkt des Spiels.
        /// </summary>
        public void Draw(SpriteBatch spriteBatch)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Erstellt ein ButtonRepresentation Objekt welches zu der Liste hinzugefügt wird.
        /// </summary>
        /// <param name="button"> Von dem State übergebener Button</param>
        public ButtonRepresentation AddButton(MenuControl button)
        {
            throw new System.NotImplementedException();
        }
    }
}
