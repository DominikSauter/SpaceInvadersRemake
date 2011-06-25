//Implementiert von Anji
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
            //TODO: position abhängig von fenster höhe, breite [Check]
            //TODO: unterscheidung zwischen einstellungsmenü und hauptmenü (entweder nen bool definieren und übergeben, oder den currentState vom ViewManager aus weiterreichen)

            Vector2 position = new Vector2(graphics.PreferredBackBufferWidth / 3, graphics.PreferredBackBufferHeight / 3); //Unterscheiden zwischen Menü Arten
            spriteBatch.Begin();

            //Zeichnen des Hintergrunds
            spriteBatch.Draw(background , new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);

            spriteBatch.End();

            //Zeichnen der Buttons
            for (int i = 0; i < buttonRepresentation.Length; i++)
            {
                buttonRepresentation[i].Draw(spriteBatch, position);
                position.Y += 50;
            }           
        }
    }
}
