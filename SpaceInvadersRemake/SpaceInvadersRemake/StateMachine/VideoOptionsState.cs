﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceInvadersRemake.ModelSection;
using Microsoft.Xna.Framework.Graphics;
using SpaceInvadersRemake.Settings;
using SpaceInvadersRemake.Resources;

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
        public VideoOptionsState(StateManager stateManager, GameManager gameManager, State previousState)
            : base (stateManager, gameManager, previousState)
        {
        }

        /// <summary>
        /// Initialisierungsmethode für den Controllers.
        /// </summary>
        protected override void ControllerInitialize()
        {
            //CK
            Controller = new SpaceInvadersRemake.Controller.MenuController(this.Model);
        }

        /// <summary>
        /// Initialisierungsmethode für das Model.
        /// </summary>
        protected override void ModelInitialize()
        {
            // von Tobias
            List<MenuControl> controls = new List<MenuControl>();


            // Unterstützte Anzeigemodi von der Grafikkarte holen
            List<DisplayMode> displayModes = ((GameManager)game).GraphicsDevice.Adapter.SupportedDisplayModes.ToList();

            // Anzeigemodi in Auflösungsklassen überführen
            List<Resolution> resolutionList = new List<Resolution>();
            foreach (DisplayMode mode in displayModes)
            {
                // Zu kleine Auflösungen rauswerfen
                if ((mode.Width < 800) || (mode.Width < 600))
                {
                    continue;
                }
                resolutionList.Add(new Resolution(mode));
            }

            // Die aktuelle Auflösung auslesen
            Resolution currentResolution = new Resolution(((GameManager)game).graphics.PreferredBackBufferWidth,
                                                          ((GameManager)game).graphics.PreferredBackBufferHeight);

            // Ein neues ListSelect samt anonymen Delegate hinzufügen
            controls.Add(new ListSelect<Resolution>(Resource.Label_Resolution, 
                                                     resolutionList,
                                                     currentResolution, 
                                                     delegate(Resolution resolution) 
                                                     {
                                                         ((GameManager)game).graphics.PreferredBackBufferWidth = resolution.Width;
                                                         ((GameManager)game).graphics.PreferredBackBufferHeight = resolution.Height;
                                                         ((GameManager)game).graphics.ApplyChanges();
                                                         //<ck> In Settingsdatei speichern
                                                         Settings.GameConfig.Default.graphicsWidth = ((GameManager)game).graphics.PreferredBackBufferWidth;
                                                         Settings.GameConfig.Default.graphicsHeight = ((GameManager)game).graphics.PreferredBackBufferHeight;
                                                         Settings.GameConfig.Default.Save();
                                                         //</ck>
                                                     }));

            // Liste für Vollbild erstellen
            List<OnOff> fullscreen = new List<OnOff>();
            fullscreen.Add(new OnOff(false));
            fullscreen.Add(new OnOff(true));

            // Ein neues ListSelect samt anonymen Delegate hinzufügen
            controls.Add(new ListSelect<OnOff>(Resource.Label_Fullscreen,
                                              fullscreen,
                                              new OnOff(((GameManager)game).graphics.IsFullScreen),
                                              delegate(OnOff onOff)
                                              {
                                                  ((GameManager)game).graphics.IsFullScreen = onOff.On;
                                                  ((GameManager)game).graphics.ApplyChanges();
                                                  //<ck> Speichert in Settings
                                                  Settings.GameConfig.Default.Fullscreen = onOff.On;
                                                  Settings.GameConfig.Default.Save();
                                                  //</ck>
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
