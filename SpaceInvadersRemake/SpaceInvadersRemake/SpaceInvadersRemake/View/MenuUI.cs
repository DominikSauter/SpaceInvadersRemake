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
    /// Sie bekommt eine Liste mit <c>MenuControl</c>-Objekten übergeben, anhand dieser <c>ButtonRepresentations</c>-Objekte erzeugt werden,
    /// die das Menü letzendlich darstellen.
    /// </summary>
    public class MenuUI : IView
    {
        private Texture2D background;
        private GraphicsDeviceManager graphics;
        private ButtonRepresentation[] buttonRepresentation;
    
        /// <summary>
        /// Initialisiert die Menüoberfläche
        /// </summary>
        /// <param name="buttons">MenuControls bzw. Buttons</param>
        /// <param name="graphics"></param>
        public MenuUI(MenuControl[] buttons,  GraphicsDeviceManager graphics)
        {
            this.background = ViewContent.UIContent.MenuBackgroundImage;
            this.graphics = graphics;
            this.buttonRepresentation = new ButtonRepresentation[buttons.Length];

            //Instanziiert ButtonRepresentation-Objekt für jedes MenuControl
            for (int i = 0; i < buttons.Length; i++)
            {
                buttonRepresentation[i] = new ButtonRepresentation(buttons[i]);
            }
        }

        /// <summary>
        /// Zeichnet die Spieloberfläche zu einem Zeitpunkt des Spiels.
        /// </summary>
        public void Draw(SpriteBatch spriteBatch)
        {
            //TODO: position abhängig von fenster höhe, breite
            //TODO: unterscheidung zwischen einstellungsmenü und hauptmenü (state)
            //TODO: überlegen was tun wegen unterschiedlicher buttonLabel Länge, dass Select Buttons alle auf einer Ebene
            Vector2 position = new Vector2(200, 200);
            spriteBatch.Begin();

            //Zeichnen des Hintergrunds
            spriteBatch.Draw(background , new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);

            spriteBatch.End(); // Hab das hierhin gesetzt, weil sonst ein Laufzeitfehler kommt - TB

            //Zeichnen der Buttons
            for (int i = 0; i < buttonRepresentation.Length; i++)
            {
                position.Y += 100 * i;
                buttonRepresentation[i].Draw(spriteBatch, position);
            }           
        }
    }
}
