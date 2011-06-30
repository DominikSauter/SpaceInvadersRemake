using System;
using Microsoft.Xna.Framework;
using SpaceInvadersRemake.StateMachine;
using SpaceInvadersRemake.Settings;
using Microsoft.Xna.Framework.Input;
using SpaceInvadersRemake.ModelSection;
using System.Text;

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

        //Private Felder
        private Keys[] validKeys = { Keys.Q, Keys.W, Keys.E, Keys.R, Keys.T, Keys.Z, Keys.U, Keys.I, 
                                       Keys.P, Keys.A, Keys.S, Keys.D, Keys.F, Keys.G, Keys.H, Keys.J, 
                                       Keys.K, Keys.L, Keys.Y, Keys.X, Keys.C, Keys.V, Keys.B, Keys.N, Keys.M };
        private string mystring = "";

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

            if (KeyPressed(KBconfig.Back) || KeyPressed(Keys.Escape))
            {
                MenuBack(state);
            }

            // Prüfe ob das zu kontrollierende Objekt ein Menü ist
            if (Controllee is Menu)
            {
                MenuNavigation();

            }
           
            //Eingabe des Namens im Hghscore
            if (Controllee is HighscoreManager)
                HighscoreInput();
            
        }

        /// <summary>
        /// Kümmert sich darum das ein neuer Eintrag im Highscore eingegeben wird
        /// </summary>
        private void HighscoreInput()
        {
            HighscoreManager highscore = (HighscoreManager)Controllee;
            if (highscore.NewEntry != null)
            {
                Keys[] input = StateManager.newState.GetPressedKeys();

                //Erlaube nur ein Key gleichzeitig
                if (input.GetLength(0) == 1)
                {
                    if (KeyPressed(input[0]))
                    {

                        //Usereingabe mit Enter beendet --> Übergabe des Strings an Higscore
                        if ((input[0].Equals(Keys.Enter)))
                        {

                            if (mystring.Length > 0)
                            {
                                highscore.NewEntry.Name = mystring;
                            }
                            //Es wurde kein Name angegeben
                            else
                            {
                                highscore.NewEntry.Name = Resources.Resource.NoName;
                            }

                            mystring = "";

                        }
                        else if (input[0].Equals(Keys.Back))
                        {
                            //HACK falls Back löscht zuviel zeichen
                            mystring.Remove(mystring.Length - 1);

                        }


                      //Namenseingabe Zeichenbasiert
                        else
                        {
                            foreach (Keys item in validKeys)
                            {
                                if (item.Equals(input[0]))
                                {
                                    mystring += item.ToString();

                                }
                            }
                        }

                    }




                }

            }
        }

        /// <summary>
        /// Navigiert ein Menu zurück
        /// </summary>
        /// <param name="state">Der aktuelle State.</param>
        private static void MenuBack(State state)
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

        /// <summary>
        /// Navigiert durchs Menu.
        /// </summary>
        private void MenuNavigation()
        {
            Menu menu = (Menu)Controllee;

            // Hoch wurde gedrückt
            if (KeyPressed(KBconfig.Up) || KeyPressed(Keys.Up)) //geändert zu Settingsdatei -CK
            {
                menu.Up();
            }

            // Runter wurde gedrückt
            if (KeyPressed(KBconfig.Down) || KeyPressed(Keys.Down)) //geändert zu Settingsdatei -CK
            {
                menu.Down();
            }

            // Links wurde gedrückt
            if (KeyPressed(KBconfig.Left) || KeyPressed(Keys.Left)) //geändert zu Settingsdatei -CK
            {
                menu.Left();
            }

            // Rechts wurde gedrückt
            if (KeyPressed(KBconfig.Right) || KeyPressed(Keys.Right)) //geändert zu Settingsdatei -CK
            {
                menu.Right();
            }

            // Bestätigen wurde gedrückt
            if (KeyPressed(KBconfig.Fire) || KeyPressed(Keys.Enter)) //geändert zu Settingsdatei -CK
            {
                menu.Action();
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
