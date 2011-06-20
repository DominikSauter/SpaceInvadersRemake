using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvadersRemake.StateMachine
{
    /// <summary>
    /// Stellt das Intro dar.
    /// </summary>
    public class IntroState : State
    {
        /// <summary>
        /// Erstellt einen neuen Zustand.
        /// </summary>
        /// <param name="stateManager">Referenz zum StateManager</param>
        /// <param name="gameManager">Referenz zur XNA-Game-Klasse</param>
        public IntroState(StateManager stateManager, Microsoft.Xna.Framework.Game gameManager)
            : base (stateManager, gameManager)
        {
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
        /// Welchselt ins Hauptmenü und damit den Zustand.
        /// </summary>
        public void Exit()
        {
            MainMenuState newState = new MainMenuState(this.stateManager, this.game);
            this.stateManager.State = newState;
            this.Dispose();
        }
    }
}
