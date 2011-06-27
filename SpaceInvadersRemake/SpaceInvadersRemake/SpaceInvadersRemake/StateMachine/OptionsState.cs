using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceInvadersRemake.ModelSection;
using SpaceInvadersRemake.Settings;

namespace SpaceInvadersRemake.StateMachine
{
    // by STST
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
            // von Tobias
            List<MenuControl> controls = new List<MenuControl>();

         
            
            
            controls.Add(new Button(Resource.Label_Video, new Action(ShowVideoOptions)));
            controls.Add(new Button(Resource.Label_Audio, new Action(ShowAudioOptions)));
            //TODO: SOllte es nicht noch einen State für das Steuerungsmenü geben? - TB

            Model = new Menu(controls);
        }

        /// <summary>
        /// Initialisierungsmethode für die View.
        /// </summary>
        protected override void ViewInitialize()
        {
            View = new View.ViewManager(this, ((GameManager)this.game).graphics); //teilimplementiert von Dodo
        }

        /// <summary>
        /// Wechselt in die Audio-Optionen und damit den Zustand.
        /// </summary>
        public void ShowAudioOptions()
        {
            AudioOptionsState newState = new AudioOptionsState(this.stateManager, this.game, this);
            this.stateManager.State = newState;
        }

        /// <summary>
        /// Wechselt in die Video-Optionen und damit den Zustand.
        /// </summary>
        public void ShowVideoOptions()
        {
            VideoOptionsState newState = new VideoOptionsState(this.stateManager, this.game, this);
            this.stateManager.State = newState;
        }
    }
}
