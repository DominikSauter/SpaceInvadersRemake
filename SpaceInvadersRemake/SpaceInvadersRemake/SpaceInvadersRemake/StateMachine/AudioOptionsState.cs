using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using SpaceInvadersRemake.Settings;
using SpaceInvadersRemake.ModelSection;
using SpaceInvadersRemake.Resources;

namespace SpaceInvadersRemake.StateMachine
{
    // by STST
    /// <summary>
    /// Stellt die Audio Einstellungen im Spiel dar.
    /// </summary>
    public class AudioOptionsState : State
    {
        /// <summary>
        /// Erstellt einen neuen Zustand mit der Berücksichtigung des vorherigen States.
        /// </summary>
        /// <param name="stateManager">Referenz zum StateManager</param>
        /// <param name="gameManager">Referenz zur XNA-Game-Klasse</param>
        /// <param name="previousState">Vorheriger State oder null, falls keiner vorhanden oder nicht gespeichert werden soll.</param>
        public AudioOptionsState(StateManager stateManager, Microsoft.Xna.Framework.Game gameManager, State previousState)
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

            //TODO: Reinladen von Einstellungen
            //TODO: Delegate zu ändern der Lautstärke hinzufügen
            List<float> volume = new List<float>();

            for (int i = 0; i < 11; i++)
            {
                volume.Add((float)i);
            }

            
            controls.Add(new ListSelect<float>(Resource.Label_MasterVolume, volume, 10.0f, delegate(float i) { }));
            controls.Add(new ListSelect<float>(Resource.Label_EffectVolume, volume, 10.0f, delegate(float i) {}));
            controls.Add(new ListSelect<float>(Resource.Label_MusicVolume, volume, 10.0f, delegate(float i) {}));

            Model = new Menu(controls);
        }

        /// <summary>
        /// Initialisierungsmethode für die View.
        /// </summary>
        protected override void ViewInitialize()
        {

            this.View = new View.ViewManager(this, ((GameManager)this.game).graphics); //teilimplementiert von Dodo
        }
    }
}
