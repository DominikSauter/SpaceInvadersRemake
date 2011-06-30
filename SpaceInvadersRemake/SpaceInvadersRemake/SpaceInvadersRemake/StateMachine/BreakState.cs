using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceInvadersRemake.ModelSection;
using SpaceInvadersRemake.Settings;
using SpaceInvadersRemake.Resources;

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

            
            controls.Add(new Button(Resource.Label_ReturnToGame, new Action(Back)));
            //TODO: Wollten wir nicht vom Pausemenü ins Optionsmenu kommen? - TB
            controls.Add(new Button(Resource.Label_QuitGame, new Action(ExitGame)));

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
        /// Spricht die View im vorgegebenen Takt an.
        /// </summary>
        /// <remarks>
        /// Um den Aufruf muss sich nicht gekümmert werden.
        /// </remarks>
        /// <param name="gameTime">Weiterreichung von der Game-Klasse</param>
        public override void ViewUpdate(Microsoft.Xna.Framework.GameTime gameTime)
        {
            //Sorgt dafür, dass das Spiel im Hintergrund des Pausemenüs gerendert wird - TB
            previousState.ViewUpdate(gameTime);
            base.ViewUpdate(gameTime);
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
