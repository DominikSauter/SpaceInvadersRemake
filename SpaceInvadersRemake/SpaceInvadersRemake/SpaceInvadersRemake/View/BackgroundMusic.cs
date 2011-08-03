//Implementiert von Dodo
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
            //Laden der Anfangslautstärke aus der externen Settingsdatei
            this.Volume = Settings.GameConfig.Default.MasterVolume * Settings.GameConfig.Default.MusicVolume;
            this.Repeat = true;
            this.Playing = false;
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
            System.Diagnostics.Debug.Assert(this.Playing = true, "Der Mediaplayer läuft überhaupt nicht!");
            MediaPlayer.Stop();
            this.Playing = false;
        }

        /// <summary>
        /// Pausiert die Wiedergabe der Hintergrundmusik
        /// </summary>
        private void Pause()
        {
            System.Diagnostics.Debug.Assert(this.Playing = true, "Der Mediaplayer läuft überhaupt nicht!");
            MediaPlayer.Pause();
            this.Playing = false;
        }

        /// <summary>
        /// Führt die pausierte Hintergrundmusik weiter
        /// </summary>
        private void Resume()
        {
            System.Diagnostics.Debug.Assert(this.Playing = false, "Der Mediaplayer ist überhaupt nicht angehalten!");
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

        /// <summary>
        /// Updated den Musikplayer. Je nach letztem und aktuellem State muss die Musik weitergeführt, gestoppt, pausiert oder
        /// ein neues Lied gestartet werden.
        /// </summary>
        /// <param name="currentState">aktueller State</param>
        public void Update(State currentState)
        {
            if (lastState == null)
            {
                lastState = currentState;
            }

                //Wechsel vom Menü ins Spiel
            if (currentState is InGameState && lastState is MainMenuState)
            {
                Stop();
                Play(ViewContent.EffectContent.GameSong);
            }
                //Wechsel vom Pausemenü ins Spiel
            else if (currentState is BreakState && lastState is InGameState)
            {
                Pause();
            }
                //Wechsel vom Spiel ins Pausemenü
            else if (currentState is InGameState && lastState is BreakState)
            {
                Resume();
            }
                //Wechsel vom Spiel oder dem Pausemenü in den Highscore
            else if (currentState is HighscoreState && (lastState is InGameState || lastState is BreakState))
            {
                Stop();
            }
                //Spielstart
            else if (currentState is MainMenuState && !this.Playing)
            {
                Play(ViewContent.EffectContent.MenuSong);
            }
                //Wechsel vom Highscore nach dem Spiel (keine Musik läuft) ins Menü
            else if (currentState is MainMenuState && lastState is HighscoreState && !this.Playing)
            {
                Play(ViewContent.EffectContent.MenuSong);
            }

            lastState = currentState;
        }
    }
}
