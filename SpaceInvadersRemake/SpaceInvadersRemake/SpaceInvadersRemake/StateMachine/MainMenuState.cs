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
    /// Stellt das Hauptmenü dar.
    /// </summary>
    public class MainMenuState : State
    {
        /// <summary>
        /// Erstellt einen neuen Zustand.
        /// </summary>
        /// <param name="stateManager">Referenz zum StateManager</param>
        /// <param name="gameManager">Referenz zur XNA-Game-Klasse</param>
        public MainMenuState(StateManager stateManager, Microsoft.Xna.Framework.Game gameManager)
            : base (stateManager, gameManager)
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
            List<MenuControl> controls = new List<MenuControl>(); //TB

            
            controls.Add(new Button(Resource.Label_StartGame, new Action(StartGame)));
            controls.Add(new Button(Resource.Label_Highscore, new Action(ShowHighscore)));
            controls.Add(new Button(Resource.Label_Options, new Action(ShowOptions)));
            controls.Add(new Button(Resource.Label_Credits, new Action(ShowCredits)));
            controls.Add(new Button(Resource.Label_Quit, new Action(Quit)));

            Model = new Menu(controls); //TB
        }

        /// <summary>
        /// Erzeugt einen neuen ViewManager und übergibt den aktuellen State sowie einen GraphicsDeviceManager
        /// </summary>
        protected override void ViewInitialize()
        {
            View = new View.ViewManager(this, ((GameManager)this.game).graphics); //teilimplementiert von Dodo
        }

        /// <summary>
        /// Startet ein neues Spiel und wechselt damit den Zustand.
        /// </summary>
        public void StartGame()
        {
            InGameState newState = new InGameState(this.stateManager, this.game);
            this.stateManager.State = newState;
            this.Dispose();
        }

        /// <summary>
        /// Zeigt die Highscore an und wechselt damit den Zustand.
        /// </summary>
        public void ShowHighscore()
        {
            HighscoreState newState = new HighscoreState(this.stateManager, this.game);
            this.stateManager.State = newState;
            this.Dispose();
        }

        /// <summary>
        /// Zeigt die Credits an und wechselt damit den Zustand.
        /// </summary>
        public void ShowCredits()
        {
            CreditsState newState = new CreditsState(this.stateManager, this.game, this);
            this.stateManager.State = newState;
        }

        /// <summary>
        /// Zeigt die Optionen an und wechselt damit den Zustand.
        /// </summary>
        public void ShowOptions()
        {
            OptionsState newState = new OptionsState(this.stateManager, this.game, this);
            this.stateManager.State = newState;
        }

        // Hab die Methode hinzugefügt, weil ich die für den Quit-Button brauche - TB
        /// <summary>
        /// Beendet das Spiel
        /// </summary>
        public void Quit()
        {
            //TODO: evtl. noch aufräumarbeiten - TB
            this.game.Exit();
        }
    }
}
