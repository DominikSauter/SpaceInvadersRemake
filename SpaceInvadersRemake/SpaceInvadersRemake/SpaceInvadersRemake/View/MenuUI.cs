using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceInvadersRemake.View
{
    /// <summary>
    /// Die MenuUI(MenuUserInterface) Klasse stellt die Menüoberfläche des Spiels dar.
    /// </summary>
    public class MenuUI : IView
    {
        private Texture2D menuBackgroundImage;
    
        /// <summary>
        /// Initialisiert die Menüoberfläche
        /// </summary>
        /// <param name="buttonLabels">Beschriftungen der Buttons</param>
        public MenuUI(string[] buttonLabels)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Beinhaltet Objekte der Klasse ButtonRepresentation, die die einzelnen Buttons darstellen.
        /// </summary>
        public SpaceInvadersRemake.ButtonRepresentation[] ButtonRepresentation
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
        /// <param name="gameTime">Zeitpunkt des Spiels, zu dem die <c>draw</c> Methode aufgerufen wird.</param>
        public void Draw(GameTime gameTime);

        /// <summary>
        /// Erstellt ein ButtonRepresentation Objekt welches zu der Liste hinzugefügt wird.
        /// </summary>
        /// <param name="button"> Von dem State übergebener Button</param>
        public void AddButton(Button button)
        {
            throw new System.NotImplementedException();
        }
    }
}
