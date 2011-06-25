using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceInvadersRemake.ModelSection;
using Microsoft.Xna.Framework.Graphics;

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

            //HACK: Fürs erste Buttons mit fixer Beschriftung hinzugefügt, bis Ressource-File verfügbar - TB
            //TODO: DisplayMode durch eigene Klasse ersetzten mit bessere ToString-Methode

            List<DisplayMode> displayModes = ((GameManager)game).GraphicsDevice.Adapter.SupportedDisplayModes.ToList();

            controls.Add(new ListSelect<DisplayMode>("Resolution", 
                                                     displayModes,
                                                     ((GameManager)game).graphics.GraphicsDevice.Adapter.CurrentDisplayMode, 
                                                     delegate(DisplayMode d) 
                                                     {
                                                         ((GameManager)game).graphics.PreferredBackBufferWidth = d.Width;
                                                         ((GameManager)game).graphics.PreferredBackBufferHeight = d.Height;
                                                         ((GameManager)game).graphics.ApplyChanges();
                                                     }));

            List<bool> fullscreen = new List<bool>();
            fullscreen.Add(false);
            fullscreen.Add(true);

            controls.Add(new ListSelect<bool>("Fullscreen",
                                              fullscreen,
                                              ((GameManager)game).graphics.IsFullScreen,
                                              delegate(bool b)
                                              {
                                                  ((GameManager)game).graphics.IsFullScreen = b;
                                                  ((GameManager)game).graphics.ApplyChanges();
                                              }));

            Model = new Menu(controls);
        }

        /// <summary>
        /// Initialisierungsmethode für die View.
        /// </summary>
        protected override void ViewInitialize()
        {
            View = new View.ViewManager(this, ((GameManager)this.game).graphics); //teilimplementiert von Dodo
        }
    }
}
