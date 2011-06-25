using System;
using Microsoft.Xna.Framework;
using SpaceInvadersRemake.StateMachine;
using SpaceInvadersRemake.Settings;
using Microsoft.Xna.Framework.Input;
using SpaceInvadersRemake.ModelSection;

// Implementiert von Tobias

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
            newState = Keyboard.GetState();
        }

        /// <summary>
        /// Eigenschaft Controllees (kontrolliertes Objekt)
        /// </summary>
        /// <value>
        /// kontrolliertes Objekt 
        /// </value>
        public IModel Controllee { get; set; }


        public KeyboardConfig KBconfig { get; set; }

        // Wird genutzt um einfachen Tastendruck zu erkennen
        private KeyboardState oldState;
        private KeyboardState newState;


        /// <summary>
        /// Erlaubt die Ausführung der Steuerung.
        /// </summary>
        public void Update(Game game, GameTime gameTime, State state)
        {
            oldState = newState;
            newState = Keyboard.GetState();

            if (KeyPressed(Keys.Escape))
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

            // Prüfe ob das zu kontrollierende Objekt ein Menü ist
            if (Controllee is Menu)
            {
                Menu menu = (Menu)Controllee;

                // Pfeil-Hoch wurde gedrückt
                if (KeyPressed(Keys.Up))
                {
                    menu.Up();
                }

                // Pfeil-Runter wurde gedrückt
                if (KeyPressed(Keys.Down))
                {
                    menu.Down();
                }

                // Pfeil-Links wurde gedrückt
                if (KeyPressed(Keys.Left))
                {
                    menu.Left();
                }

                // Pfeil-Rechts wurde gedrückt
                if (KeyPressed(Keys.Right))
                {
                    menu.Right();
                }

                // Enter wurde gedrückt
                if (KeyPressed(Keys.Enter))
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
        private bool KeyPressed(Keys key)
        {
            if (newState.IsKeyDown(key) && !oldState.IsKeyDown(key))
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
