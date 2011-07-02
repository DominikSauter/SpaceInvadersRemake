//Implementiert von Anji
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text;
using SpaceInvadersRemake.Settings;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceInvadersRemake.ModelSection;
using SpaceInvadersRemake.Resources;

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
        private Texture2D frame;
        private GraphicsDeviceManager graphics;
        private ButtonRepresentation[] buttonRepresentation;
        private StateMachine.State currentState;
        private SpriteFont font;

        private string gameTitle;   //[Dodo] Spieltitel
    
        /// <summary>
        /// Initialisiert die Menüoberfläche
        /// </summary>
        /// <param name="buttons">MenuControls bzw. Buttons</param>
        /// <param name="graphics"></param>
        public MenuUI(MenuControl[] buttons,  GraphicsDeviceManager graphics, StateMachine.State currentState)
        {
            this.background = ViewContent.UIContent.MenuBackgroundImage;
            this.frame = ViewContent.UIContent.SettingsBackground;
            this.graphics = graphics;
            this.buttonRepresentation = new ButtonRepresentation[buttons.Length];
            this.currentState = currentState;
            this.font = ViewContent.UIContent.Font;

            this.gameTitle = Resource.Game_Titel;

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

            Vector2 position = new Vector2(graphics.PreferredBackBufferWidth / 3, graphics.PreferredBackBufferHeight / 3);
            Vector2 framePosition = new Vector2((graphics.PreferredBackBufferWidth - this.frame.Width) / 2, (graphics.PreferredBackBufferHeight - this.frame.Height) / 2);
            Vector2 selectTitlePosition = framePosition + new Vector2(20, 100);
            Vector2 titlePosition = framePosition + new Vector2(20, 20);

            //[Dodo] Größe und Position des Spieltitels
            Vector2 gameTitleSize = font.MeasureString(this.gameTitle);
            Vector2 gameTitlePosition = new Vector2((graphics.PreferredBackBufferWidth - gameTitleSize.X) / 2, 20);

            spriteBatch.Begin();

            //Im Break-State wird ein schwarzer durchsichtiger Hintergrund gezeichnet
            if (currentState is StateMachine.BreakState)
            {
                spriteBatch.Draw(background, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), new Color(0, 0, 0, 0.5f));
            }
            else 
            {
                //Zeichnen des Hintergrunds
                spriteBatch.Draw(background, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);

                if (currentState is StateMachine.AudioOptionsState || currentState is StateMachine.VideoOptionsState) 
                {
                    //Zeichnen des Menü-Titels
                    if (currentState is StateMachine.AudioOptionsState)
                    {
                        spriteBatch.DrawString(this.font,Resource.Label_AUDIOOPTIONS, titlePosition, Color.White);
                    }
                    else
                    {
                        spriteBatch.DrawString(this.font, Resource.Label_VIDEOOPTIONS, titlePosition, Color.White);
                    }
                    //Frame zeichhen
                    spriteBatch.Draw(this.frame, new Rectangle((int)framePosition.X, (int)framePosition.Y, frame.Width, frame.Height * (3 / 2)), Color.White);
                    position = selectTitlePosition;
                }
                else if (currentState is StateMachine.MainMenuState)
                {
                    //[Dodo] else-if Bedingung für den Spieltitel, welcher nur im Hauptmenü gezeigt werden soll
                    spriteBatch.DrawString(this.font, this.gameTitle, gameTitlePosition, new Color(14, 255, 20));
                }
            }
         spriteBatch.End();

            //Zeichnen der Buttons
            for (int i = 0; i < buttonRepresentation.Length; i++)
            {
                buttonRepresentation[i].Draw(spriteBatch, position);
                position.Y += 60;
            }           
        }
    }
}
