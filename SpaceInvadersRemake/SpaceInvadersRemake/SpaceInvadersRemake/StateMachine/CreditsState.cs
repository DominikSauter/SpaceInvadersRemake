using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvadersRemake.StateMachine
{
    // by STST
    /// <summary>
    /// Stellt den Credits-Screen dar.
    /// </summary>
    public class CreditsState : State
    {
        /// <summary>
        /// Erstellt einen neuen Zustand mit der Berücksichtigung des vorherigen States.
        /// </summary>
        /// <param name="stateManager">Referenz zum StateManager</param>
        /// <param name="gameManager">Referenz zur XNA-Game-Klasse</param>
        /// <param name="previousState">Vorheriger State oder null, falls keiner vorhanden oder nicht gespeichert werden soll.</param>
        public CreditsState(StateManager stateManager, Microsoft.Xna.Framework.Game gameManager, State previousState)
            : base(stateManager, gameManager, previousState)
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

        /// <summary>
        /// Erzeugt einen neuen ViewManager und übergibt den aktuellen State sowie einen GraphicsDeviceManager
        /// </summary>
        protected override void ViewInitialize()
        {
            View = new View.ViewManager(this, ((GameManager)this.game).graphics); //teilimplementiert von Dodo
        }
    }
}
