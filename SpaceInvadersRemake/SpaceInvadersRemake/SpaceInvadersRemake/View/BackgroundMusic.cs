using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using SpaceInvadersRemake.StateMachine;

namespace SpaceInvadersRemake.View
{
    /// <summary>
    /// Diese Klasse kümmert sich um die Wiedergabe der Hintergrundmusik.
    /// </summary>
    public class BackgroundMusic
    {
        private StateMachine.State lastState;

        /// <summary>
        /// Initialisiert die Hintergrundmusik
        /// </summary>
        public BackgroundMusic()
        {
            this.Volume = Settings.GameConfig.Default.MasterVolume * Settings.GameConfig.Default.MusicVolume;
            this.Repeat = true;
            this.Playing = false;
            // this.Volume = Model Wert auslesen bzw unten eine Update() methode implementieren.
        }

        private float volume;
        /// <summary>
        /// Lautstärkeregelung
        /// </summary>
        /// <remarks>
        /// bei 0: lautlos
        /// bei 1: volle Lautstärke
        /// </remarks>
        public float Volume
        {
            get
            {
                return this.volume;
            }
            set
            {
                this.volume = value;
                MediaPlayer.Volume = value;
            }
        }

        /// <summary>
        /// Gibt an ob die Wiedergabe gerade läuft.
        /// true: Hintergrundmusik wird abgespielt
        /// false: Hintergrundmusik wird nicht abgespielt
        /// </summary>
        private bool Playing;

        private bool repeat;
        /// <summary>
        /// Wahrheitswert für die Wiederholung der Hintergrundmusik.
        /// true: Hintergrundmusik wird wiederholt
        /// false: Hintergrundmusik wird einmalig abgespielt
        /// </summary>
        protected bool Repeat
        {
            get
            {
                return this.repeat;
            }
            set
            {
                this.repeat = value;
                MediaPlayer.IsRepeating = value;
            }

        }

        /// <summary>
        /// Stoppt die Wiedergabe der Hintergrundmusik
        /// </summary>
        private void Stop()
        {
            MediaPlayer.Stop();
            this.Playing = false;
        }

        /// <summary>
        /// Pausiert die Wiedergabe der Hintergrundmusik
        /// </summary>
        private void Pause()
        {
            MediaPlayer.Pause();
            this.Playing = false;
        }

        private void Resume()
        {
            MediaPlayer.Resume();
            this.Playing = true;
        }

        /// <summary>
        /// Wiedergabe der Hintergrundmusik
        /// </summary>
        /// <param name="Background">Hintergrundmusik</param>
        public void Play(Song Background)
        {
            MediaPlayer.Play(Background);
            this.Playing = true;
        }

        public void Update(State currentState)
        {
            if (lastState == null)
            {
                lastState = currentState;
            }
            
            if (currentState is InGameState && lastState is MainMenuState)
            {
                Stop();
                Play(ViewContent.EffectContent.GameSong);
                lastState = currentState;
            }
            else if (currentState is BreakState && lastState is InGameState)
            {
                Pause();
                lastState = currentState;
            }
            else if (currentState is InGameState && lastState is BreakState)
            {
                Resume();
                lastState = currentState;
            }
            else if (currentState is HighscoreState && (lastState is InGameState || lastState is BreakState))
            {
                Stop();
                lastState = currentState;
            }
            else if (currentState is MainMenuState && !this.Playing)
            {
                Play(ViewContent.EffectContent.MenuSong);
                lastState = currentState;
            }
            else if (currentState is MainMenuState && lastState is HighscoreState && !this.Playing)
            {
                Play(ViewContent.EffectContent.MenuSong);
                lastState = currentState;
            }
        }
    }
}
