using System;
using Microsoft.Xna.Framework;
using SpaceInvadersRemake.StateMachine;
using SpaceInvadersRemake.Settings;
using Microsoft.Xna.Framework.Input;
using SpaceInvadersRemake.ModelSection;

// Implementiert von Tobias

//TODO Entscheidung ob Keyboardstate Auslagerung Böse ist oder nicht 

namespace SpaceInvadersRemake.Controller
{
    /// <summary>
    /// Diese Klasse stellt die Menüsteuerung dar.
    /// </summary>
    /// <remarks>
    /// Für die Menüsteurung sind folgende Interaktionsmöglichkeiten vorgesehen:
    /// "Cursor" nach oben/unten
    /// Menüpunkt Bestätigen
    /// Zurück 
    /// Falls ein Menüpunkt Einstellungsmöglichkeiten bietet, werden diese mit rechts/links ausgewählt.
    /// </remarks>
    public class MenuController : IController
    {
        /// <summary>
        /// Generiert eine neue Instanz der <see cref="MenuController"/> Klasse.
        /// </summary>
        public MenuController(IModel controllee)
        {
            this.KBconfig = KeyboardConfig.Default;
            this.Controllee = controllee;
            
            
        }

        /// <summary>
        /// Eigenschaft Controllees (kontrolliertes Objekt)
        /// </summary>
        /// <value>
        /// kontrolliertes Objekt 
        /// </value>
        public IModel Controllee { get; set; }

        /// <summary>
        /// Getter/Setter der Tastatur Konfiguration
        /// </summary>
        /// <value>
        /// Die KBconfig.
        /// </value>
        public KeyboardConfig KBconfig { get; set; }



        /// <summary>
        /// Erlaubt die Ausführung der Steuerung.
        /// </summary>
        public void Update(Game game, GameTime gameTime, State state)
        {

            //KeyboardState Variablen ausgelagert - CK
            //Eingabe erfolgt durch Benutzertastenbelegung sowie einer Standardtaste
            

            if (KeyPressed(KBconfig.Back)|| KeyPressed(Keys.Escape))
            {
                if (state is HighscoreState)
                {
                    ((HighscoreState)state).Exit();
                }
                else
                {
                    try
                    {
                        state.Back();
                    }
                    catch (NullReferenceException e)
                    {
                        //Vermeidet Absturz
                    }
                }
            }
            
            // Prüfe ob das zu kontrollierende Objekt ein Menü ist
            if (Controllee is Menu)
            {
                Menu menu = (Menu)Controllee;

                // Hoch wurde gedrückt
                if (KeyPressed(KBconfig.Up)|| KeyPressed(Keys.Up)) //geändert zu Settingsdatei -CK
                {
                    menu.Up();
                }

                // Runter wurde gedrückt
                if (KeyPressed(KBconfig.Down)|| KeyPressed(Keys.Down)) //geändert zu Settingsdatei -CK
                {
                    menu.Down();
                }

                // Links wurde gedrückt
                if (KeyPressed(KBconfig.Left)|| KeyPressed(Keys.Left)) //geändert zu Settingsdatei -CK
                {
                    menu.Left();
                }

                // Rechts wurde gedrückt
                if (KeyPressed(KBconfig.Right)|| KeyPressed(Keys.Right)) //geändert zu Settingsdatei -CK
                {
                    menu.Right();
                }

                // Bestätigen wurde gedrückt
                if (KeyPressed(KBconfig.Fire)|| KeyPressed(Keys.Enter)) //geändert zu Settingsdatei -CK
                {
                    menu.Action();
                }
            }
        }

        
        /// <summary>
        /// Überprüft ob eine Taste gedrückt wurde
        /// </summary>
        /// <param name="key">Taste die überprüft werden soll</param>
        /// <returns>ob Taste gedrückt wurde</returns>
        private static bool KeyPressed(Keys key)
        {
            if (StateManager.newState.IsKeyDown(key) && !StateManager.oldState.IsKeyDown(key)) //modified by ck
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            // nicht benötigt
        }
    }
}
