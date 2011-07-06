using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceInvadersRemake.ModelSection;

namespace SpaceInvadersRemake.StateMachine
{
    // by STST
    /// <summary>
    /// Stellt den Highscore im Spiel dar.
    /// </summary>
    public class HighscoreState : State
    {
        private int? score = null;

        /// <summary>
        /// Erstellt einen neuen Zustand mit der Berücksichtigung des vorherigen States.
        /// </summary>
        /// <param name="stateManager">Referenz zum StateManager</param>
        /// <param name="gameManager">Referenz zur XNA-Game-Klasse</param>
        public HighscoreState(StateManager stateManager, Microsoft.Xna.Framework.Game gameManager)
            : base (stateManager, gameManager)
        { }

        /// <summary>
        /// Erstellt einen neuen Zustand mit der Berücksichtigung des vorherigen States.
        /// </summary>
        /// <param name="stateManager">Referenz zum StateManager</param>
        /// <param name="gameManager">Referenz zur XNA-Game-Klasse</param>
        /// <param name="score">im Spiel erreichte Punkte</param>
        public HighscoreState(StateManager stateManager, Microsoft.Xna.Framework.Game gameManager, int score)
            : base(stateManager, gameManager)
        {
            this.score = score;

            // HACK: unschöne Lösung:
            Initialise();
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
            if (score.HasValue)
            {
                Model = new HighscoreManager(score.Value);
            }
            else
            {
                Model = new HighscoreManager();
            }
        }

        /// <summary>
        /// Initialisierungsmethode für die View.
        /// </summary>
        protected override void ViewInitialize()
        {
            View = new View.ViewManager(this, ((GameManager)this.game).graphics); //teilimplementiert von Dodo
        }

        /// <summary>
        /// Wechselt in das Hauptmenü und damit den Zustand.
        /// </summary>
        public void Exit()
        {
            MainMenuState newState = new MainMenuState(this.stateManager, this.game);
            this.stateManager.State = newState;
            this.Dispose();
        }
    }
}
