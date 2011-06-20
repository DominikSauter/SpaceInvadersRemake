using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceInvadersRemake.ModelSection;

namespace SpaceInvadersRemake.StateMachine
{
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

        protected override void ControllerInitialize()
        {
            throw new NotImplementedException();
        }

        protected override void ModelInitialize()
        {
            List<MenuControl> controls = new List<MenuControl>(); //TB

            //TODO: Buttons einfügen

            Model = new Menu(controls); //TB
        }

        protected override void ViewInitialize()
        {
            throw new NotImplementedException();
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
    }
}
