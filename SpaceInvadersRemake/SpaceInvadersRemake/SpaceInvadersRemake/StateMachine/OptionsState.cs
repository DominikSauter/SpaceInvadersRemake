using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvadersRemake.StateMachine
{
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
        public OptionsState(StateManager stateManager, Microsoft.Xna.Framework.Game gameManager, State previousState)
            : base (stateManager, gameManager, previousState)
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
        /// Wechselt in die Audio-Optionen und damit den Zustand.
        /// </summary>
        public void ShowAudioOptions()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Wechselt in die Video-Optionen und damit den Zustand.
        /// </summary>
        public void ShowVideoOptions()
        { 
            throw new NotImplementedException(); 
        }
    }
}
