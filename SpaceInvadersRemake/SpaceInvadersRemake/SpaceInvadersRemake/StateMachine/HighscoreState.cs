using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvadersRemake.StateMachine
{
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
        {
        }

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
        }

        protected override void ControllerInitialize()
        {
            Controller = new SpaceInvadersRemake.Controller.MenuController(this.Model);
        }

        protected override void ModelInitialize()
        {
            throw new NotImplementedException();
        }

        protected override void ViewInitialize()
        {
            throw new NotImplementedException();
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
