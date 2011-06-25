using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceInvadersRemake.ModelSection;

namespace SpaceInvadersRemake.StateMachine
{
    // by STST
    /// <summary>
    /// Stellt die Videoeinstellungen dar.
    /// </summary>
    public class VideoOptionsState : State
    {
        /// <summary>
        /// Erstellt einen neuen Zustand mit der Berücksichtigung des vorherigen States.
        /// </summary>
        /// <param name="stateManager">Referenz zum StateManager</param>
        /// <param name="gameManager">Referenz zur XNA-Game-Klasse</param>
        /// <param name="previousState">Vorheriger State oder null, falls keiner vorhanden oder nicht gespeichert werden soll.</param>
        public VideoOptionsState(StateManager stateManager, Microsoft.Xna.Framework.Game gameManager, State previousState)
            : base (stateManager, gameManager, previousState)
        {
        }

        protected override void ControllerInitialize()
        {
            Controller = new SpaceInvadersRemake.Controller.MenuController(this.Model);
        }

        protected override void ModelInitialize()
        {
            // von Tobias
            List<MenuControl> controls = new List<MenuControl>();

            //HACK: Fürs erste Buttons mit fixer Beschriftung hinzugefügt, bis Ressource-File verfügbar - TB
            //TODO: ListSelects einfügen, wenn klar ist woher die Daten dafür kommen

            Model = new Menu(controls);
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
