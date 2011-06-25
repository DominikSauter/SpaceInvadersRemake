using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceInvadersRemake.ModelSection;

namespace SpaceInvadersRemake.StateMachine
{
    // by STST
    /// <summary>
    /// Stellt die Pause im Spiel dar.
    /// </summary>
    public class BreakState : State
    {
        /// <summary>
        /// Erstellt einen neuen Zustand mit der Berücksichtigung des vorherigen States.
        /// </summary>
        /// <param name="stateManager">Referenz zum StateManager</param>
        /// <param name="gameManager">Referenz zur XNA-Game-Klasse</param>
        /// <param name="previousState">Vorheriger State oder null, falls keiner vorhanden oder nicht gespeichert werden soll.</param>
        public BreakState(StateManager stateManager, Microsoft.Xna.Framework.Game gameManager, State previousState)
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
            controls.Add(new Button("Return To Game", new Action(Back)));
            //TODO: Wollten wir nicht vom Pausemenü ins Optionsmenu kommen? - TB
            controls.Add(new Button("Quit Game", new Action(ExitGame)));

            Model = new Menu(controls);
        }

        /// <summary>
        /// Erzeugt einen neuen ViewManager und übergibt den aktuellen State sowie einen GraphicsDeviceManager
        /// </summary>
        protected override void ViewInitialize()
        {
            View = new View.ViewManager(this, ((GameManager)this.game).graphics); //teilimplementiert von Dodo
        }

        /// <summary>
        /// Beendet das Spiel und wechselt damit den Zustand ins Hauptmenü.
        /// </summary>
        public void ExitGame()
        {
            HighscoreState newState = new HighscoreState(this.stateManager, this.game);
            this.stateManager.State = newState;
            this.Dispose();            
        }
    }
}
