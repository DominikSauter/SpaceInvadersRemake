﻿//teilimplementiert von Dodo
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvadersRemake.StateMachine
{
    // by STST
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
        /// Hier ist die Initialisierungsreihenfolge festgelegt.
        /// </summary>
        protected override void Initialise()
        {
            ViewInitialize();
            ControllerInitialize();
            ModelInitialize();
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

        /// <summary>
        /// Initialisierungsmethode für den Controllers.
        /// </summary>
        protected override void ControllerInitialize()
        {
            this.Controller = new SpaceInvadersRemake.Controller.ControllerManager();
        }

        /// <summary>
        /// Initialisierungsmethode für das Model.
        /// </summary>
        protected override void ModelInitialize()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Initialisierungsmethode für die View.
        /// </summary>
        protected override void ViewInitialize()
        {
            View = new View.ViewManager(this, ((GameManager)this.game).graphics);
        }
    }
}
