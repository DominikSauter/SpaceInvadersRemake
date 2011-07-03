using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

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
            this.Volume = 1.0f;     //muss noch vom model oder aus ner resource datei ausgelesn werden.
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

        public bool Playing
        {
            get;
            set;
        }

        /// <summary>
        /// Wahrheitswert für die Wiederholung der Hintergrundmusik.
        /// true: Hintergrundmusik wird wiederholt
        /// false: Hintergrundmusik wird einmalig abgespielt
        /// </summary>
        public bool Repeat
        {
            get;
            set;
        }

        /// <summary>
        /// Stoppt die Wiedergabe der Hintergrundmusik
        /// </summary>
        public void Stop()
        {
            MediaPlayer.Stop();
            this.Playing = false;
        }

        /// <summary>
        /// Langsames Einblenden der Hintegrundmusik
        /// </summary>
        public void FadeIn()
        {
            while (Volume < 1.0f)
            {
                Volume += 0.001f;
            }
        }

        /// <summary>
        /// Langsames Ausblenden der Hintergrundmusik
        /// </summary>
        public void FadeOut()
        {
            while (Volume > 0.0f)
            {
                Volume -= 0.001f;
            }
        }

        /// <summary>
        /// Wiedergabe der Hintergrundmusik
        /// </summary>
        /// <param name="Background">Hintergrundmusik</param>
        public void Play(Song Background)
        {
            MediaPlayer.IsRepeating = this.Repeat;
            MediaPlayer.Play(Background);
            this.Playing = true;
        }

        public void Update(StateMachine.State currentState)
        {
            if (lastState == null)
            {
                lastState = currentState;
            }
        }
    }
}
