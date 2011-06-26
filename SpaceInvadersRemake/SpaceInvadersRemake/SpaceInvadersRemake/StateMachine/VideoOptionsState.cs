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

            // Unterstützte Anzeigemodi von der Grafikkarte holen
            List<DisplayMode> displayModes = ((GameManager)game).GraphicsDevice.Adapter.SupportedDisplayModes.ToList();

            // Anzeigemodi in Auflösungsklassen überführen
            List<Resolution> resolutionList = new List<Resolution>();
            foreach (DisplayMode mode in displayModes)
            {
                resolutionList.Add(new Resolution(mode));
            }

            // Die aktuelle Auflösung auslesen
            Resolution currentResolution = new Resolution(((GameManager)game).graphics.PreferredBackBufferWidth,
                                                          ((GameManager)game).graphics.PreferredBackBufferHeight);

            // Ein neues ListSelect samt anonymen Delegate hinzufügen
            controls.Add(new ListSelect<Resolution>("Resolution", 
                                                     resolutionList,
                                                     currentResolution, 
                                                     delegate(Resolution resolution) 
                                                     {
                                                         ((GameManager)game).graphics.PreferredBackBufferWidth = resolution.Width;
                                                         ((GameManager)game).graphics.PreferredBackBufferHeight = resolution.Height;
                                                         ((GameManager)game).graphics.ApplyChanges();
                                                     }));

            // Liste für Vollbild erstellen
            List<OnOff> fullscreen = new List<OnOff>();
            fullscreen.Add(new OnOff(false));
            fullscreen.Add(new OnOff(true));

            // Ein neues ListSelect samt anonymen Delegate hinzufügen
            controls.Add(new ListSelect<OnOff>("Fullscreen",
                                              fullscreen,
                                              new OnOff(((GameManager)game).graphics.IsFullScreen),
                                              delegate(OnOff onOff)
                                              {
                                                  ((GameManager)game).graphics.IsFullScreen = onOff.On;
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
