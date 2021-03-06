﻿using System.Collections.Generic;
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
        public AudioOptionsState(StateManager stateManager, GameManager gameManager, State previousState)
            : base (stateManager, gameManager, previousState)
        {
        }

        /// <summary>
        /// Initialisierungsmethode für den Controllers.
        /// </summary>
        protected override void ControllerInitialize()
        {
            //von Christian
            Controller = new SpaceInvadersRemake.Controller.MenuController(this.Model);
        }

        /// <summary>
        /// Initialisierungsmethode für das Model.
        /// </summary>
        protected override void ModelInitialize()
        {
            // von Tobias
            List<MenuControl> controls = new List<MenuControl>();

            List<float> volume = new List<float>();

            for (int i = 0; i < 11; i++)
            {
                volume.Add((float)i);
            }

            
            controls.Add(new ListSelect<float>(Resource.Label_MasterVolume, 
                                               volume, 
                                               Settings.GameConfig.Default.MasterVolume * 10.0f, 
                                               delegate(float i) 
                                               {
                                                   // Wert übernehmen
                                                   if (SpaceInvadersRemake.View.ViewManager.EffectPlayer != null)
                                                        SpaceInvadersRemake.View.ViewManager.EffectPlayer.Volume = (i / 10.0f) * Settings.GameConfig.Default.EffectVolume;
                                                   GameManager.MusicPlayer.Volume = (i / 10.0f) * Settings.GameConfig.Default.MusicVolume;
                                                   //Settings speichern
                                                   Settings.GameConfig.Default.MasterVolume = i / 10.0f;
                                                   Settings.GameConfig.Default.Save();
                                               }));

            controls.Add(new ListSelect<float>(Resource.Label_EffectVolume,
                                               volume, 
                                               Settings.GameConfig.Default.EffectVolume * 10.0f,
                                               delegate(float i) 
                                               {
                                                   // Wert übernehmen
                                                   if (SpaceInvadersRemake.View.ViewManager.EffectPlayer != null)
                                                       SpaceInvadersRemake.View.ViewManager.EffectPlayer.Volume = (i / 10.0f) * Settings.GameConfig.Default.MasterVolume;
                                                   //<ck> Settings speichern 
                                                   Settings.GameConfig.Default.EffectVolume = i / 10.0f;
                                                   Settings.GameConfig.Default.Save();
                                                   //</ck>
                                               }));

            controls.Add(new ListSelect<float>(Resource.Label_MusicVolume, 
                                               volume, 
                                               Settings.GameConfig.Default.MusicVolume * 10.0f, 
                                               delegate(float i) 
                                               {
                                                   // Wert übernehmen
                                                   GameManager.MusicPlayer.Volume = Settings.GameConfig.Default.MasterVolume * (i / 10.0f);
                                                   //<ck> Settings speichern
                                                   Settings.GameConfig.Default.MusicVolume = i / 10.0f;
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

            this.View = new View.ViewManager(this, this.game.graphics); //teilimplementiert von Dodo
        }
    }
}
