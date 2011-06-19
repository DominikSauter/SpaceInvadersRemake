using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvadersRemake.StateMachine
{
    /// <summary>
    /// Stellt den Spielzustand im Programm dar.
    /// </summary>
    public class InGameState : State
    {
        /// <summary>
        /// Erstellt einen neuen Zustand.
        /// </summary>
        /// <param name="stateManager">Referenz zum StateManager</param>
        /// <param name="gameManager">Referenz zur XNA-Game-Klasse</param>
        public InGameState(StateManager stateManager, Microsoft.Xna.Framework.Game gameManager)
            : base (stateManager, gameManager)
        {
        }

        /// <summary>
        /// Wechselt in den BreakState (Pausemenü).
        /// </summary>
        public void Break()
        {
            BreakState newState = new BreakState(this.stateManager, this.game, this);
            this.stateManager.State = newState;
        }

        /// <summary>
        /// Beendet das Spiel und welchselt in die Highscore-Ansicht.
        /// </summary>
        /// <param name="score">Punkte, die der Spieler im Spiel erreicht hat.</param>
        public void Exit(int score)
        {
            HighscoreState newState = new HighscoreState(this.stateManager, this.game, score);
            this.stateManager.State = newState;
            this.Dispose();
        }



        protected override void ControllerInitialize()
        {
            throw new NotImplementedException();
        }

        protected override void ModelInitialize()
        {
            throw new NotImplementedException();
        }

        protected override void ViewInitialize()
        {
            throw new NotImplementedException();
        }
    }
}
