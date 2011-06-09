using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvadersRemake.StateMachine
{
    /// <summary>
    /// Stellt das Hauptmenü dar.
    /// </summary>
    public class MainMenuState : State
    {
        /// <summary>
        /// Erstellt einen neuen Zustand mit der Berücksichtigung des vorherigen States.
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        /// <summary>
        /// Zeigt die Highscore an und wechselt damit den Zustand.
        /// </summary>
        public void ShowHighscore()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Zeigt die Credits an und wechselt damit den Zustand.
        /// </summary>
        public void ShowCredits()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Zeigt die Optionen an und wechselt damit den Zustand.
        /// </summary>
        public void ShowOptions()
        {
            throw new NotImplementedException();
        }
    }
}
