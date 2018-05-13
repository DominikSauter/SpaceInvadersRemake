using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceInvadersRemake.ModelSection;
using SpaceInvadersRemake.Settings;
using SpaceInvadersRemake.Resources;

namespace SpaceInvadersRemake.StateMachine
{
    // by STST
    /// <summary>
    /// Stellt die Einstellungen dar.
    /// </summary>
    public class OptionsState : State
    {
        /// <summary>
        /// Erstellt einen neuen Zustand mit der Berücksichtigung des vorherigen States.
        /// </summary>
        /// <param name="stateManager">Referenz zum StateManager</param>
        /// <param name="gameManager">Referenz zur XNA-Game-Klasse</param>
        /// <param name="previousState">Vorheriger State oder null, falls keiner vorhanden oder nicht gespeichert werden soll.</param>
        public OptionsState(StateManager stateManager, GameManager gameManager, State previousState)
            : base (stateManager, gameManager, previousState)
        {
        }

        /// <summary>
        /// Initialisierungsmethode für den Controllers.
        /// </summary>
        protected override void ControllerInitialize()
        {
            Controller = new SpaceInvadersRemake.Controller.MenuController(this.Model);
        }

        /// <summary>
        /// Initialisierungsmethode für das Model.
        /// </summary>
        protected override void ModelInitialize()
        {
            // von Tobias
            List<MenuControl> controls = new List<MenuControl>();

            // Buttons für Video- und Audiomenü einfügen
            controls.Add(new Button(Resource.Label_Video, new Action(ShowVideoOptions)));
            controls.Add(new Button(Resource.Label_Audio, new Action(ShowAudioOptions)));


            // Hier wird die Sprachauswahl und Controllerauswahl initialisiert, wenn das Optionsmenü nicht aus dem Pausemenü aufgerufen wurde

            if (!(previousState is BreakState))
            {
                // Liste von Sprachen anlegen
                List<string> languageList = new List<string>();
                string german = Resources.Resource.Language_de_DE;
                languageList.Add(german);
                string english = Resources.Resource.Language_en_US;
                languageList.Add(english);



                //<ck>
                // Aktive Sprache
                string activeLanguage;

                // Aktive Sprache auf Deutsch setzen sofern GameConfig CultureInfo auf Deutsch gesetzt ist
                if (Settings.GameConfig.Default.Language.CompareInfo.Name.Equals("de-DE"))
                {
                    activeLanguage = german;
                }


                //Aktive Sprache auf Englisch setzen sofern GameConfig CultureInfo nicht auf Deutsch gesetzt ist
                else
                {
                    activeLanguage = english;
                }
                //</ck>


                // Erstelle das neue ListSelect
                //TODO @Tobi Füge zu Sprachauswahl hinweis "Es Erfolgt ein Neustart Löscht aktuellen Spielfortschritt" 
                //Resource.Warning_Restart (Kannst Text gerne ändern..isn prototyp)
                controls.Add(new ListSelect<string>(Resources.Resource.Label_Language,
                             languageList,
                             activeLanguage,
                             delegate(string language)
                             {
                                 //HACK: If-Konstrukt nur gewählt, weil es nur zwei verschieden Sprachen gibt. Bei mehr Sprachen müssen eigene Klassen ähnlich wie Resolution angelegt werden
                                 if (language.Equals(german))
                                 {
                                     //<ck>
                                     //Setze die Sprache auf Deutsch und speichere dies in GameConfig
                                     Settings.GameConfig.Default.Language = new System.Globalization.CultureInfo("de-DE");
                                     Settings.GameConfig.Default.Save();


                                     //Zuweisen der Sprache aus der Gameconfig
                                     Resource.Culture = Settings.GameConfig.Default.Language;
                                     //Neustart des Spiels
                                     stateManager.State = new IntroState(this.stateManager, this.game);
                                     //</ck>


                                 }
                                 else if (language.Equals(english))
                                 {
                                     //<ck>
                                     //Setze die Sprache auf Englisch und speichere dies in GameConfig
                                     Settings.GameConfig.Default.Language = new System.Globalization.CultureInfo("en-US");
                                     Settings.GameConfig.Default.Save();

                                     //Zuweisen der Sprache aus der Gameconfig
                                     Resource.Culture = Settings.GameConfig.Default.Language;

                                     //Neustart des Spiels
                                     stateManager.State = new MainMenuState(this.stateManager, this.game);

                                     //</ck>

                                 }
                             }));


                //Controller Einstellungen
                
                //<ck>

                // Liste von Eingabemöglichkeiten anlegen
                List<string> controllerList = new List<string>();
               
                string xbox = Resources.Resource.Label_XBoxController;
                controllerList.Add(xbox);
                string keyboard = Resources.Resource.Label_Keyboard;
                controllerList.Add(keyboard);



                
                // Aktive Eingabemöglichkeit
                string activeController;
                string activeController2;
                string activeController3;
                string activeController4;

               
                //TODO Für alle Spieler Auswahlmöglichkeit für Inputs Achtung nur Player 1 darf Keyboard benutzen !

                
                switch(Settings.GameConfig.Default.Input){

                    case SupportedInputEnum.XBoxController:


                        activeController = xbox;
                        break;


                    case SupportedInputEnum.Keyboard:
                        
                       activeController = keyboard;
                       break;

                    default:
                       activeController = keyboard;
                       break;
                

                }
                
               
                //</ck>




                controls.Add(new ListSelect<string>(Resources.Resource.Label_Input,
                             controllerList,
                             activeController,
                             delegate(string controller)
                             {
                                 if(controller.Equals(xbox))
                                 {
                                     Settings.GameConfig.Default.Input = SupportedInputEnum.XBoxController;
                                     Settings.GameConfig.Default.Save();
                                 } else if (controller.Equals(keyboard))
                                 {
                                     Settings.GameConfig.Default.Input = SupportedInputEnum.Keyboard;
                                     Settings.GameConfig.Default.Save();
 
                                 }
                             }));
 



            }

            // Neues Menü mit den angelegten Steuerelementen erstellen
            Model = new Menu(controls);
        }

        /// <summary>
        /// Initialisierungsmethode für die View.
        /// </summary>
        protected override void ViewInitialize()
        {
            View = new View.ViewManager(this, ((GameManager)this.game).graphics); //teilimplementiert von Dodo
        }

        /// <summary>
        /// Wechselt in die Audio-Optionen und damit den Zustand.
        /// </summary>
        public void ShowAudioOptions()
        {
            AudioOptionsState newState = new AudioOptionsState(this.stateManager, this.game, this);
            this.stateManager.State = newState;
        }

        /// <summary>
        /// Wechselt in die Video-Optionen und damit den Zustand.
        /// </summary>
        public void ShowVideoOptions()
        {
            VideoOptionsState newState = new VideoOptionsState(this.stateManager, this.game, this);
            this.stateManager.State = newState;
        }
    }
}
