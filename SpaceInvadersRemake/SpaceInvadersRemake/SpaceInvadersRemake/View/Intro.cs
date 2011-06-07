using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

namespace SpaceInvadersRemake.View
{
    /// <summary>
    /// Diese Klasse kümmert sich um die Wiedergabe des Introvideos zum Spiel.
    /// </summary>
    public class Intro : IMediaplayer
    {
        private Video intro;

        /// <summary>
        /// Initialisiert das Introvideo
        /// </summary>
        public Intro()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Lautstärkeregelung der Audiowiedergabe
        /// Bei 0 lautlos
        /// </summary>
        public float Volume
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Wahrheitswert ob das Into wiederholt werden soll oder nicht. 
        /// true: Intro wird wiederholt
        /// false: Intro wird einmalig abgespielt
        /// </summary>
        public bool Repeat
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Stoppt die Introwiedergabe
        /// </summary>
        public void Stop()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Pausiert die Introwiedergabe
        /// </summary>
        public void Pause()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Setzt die Wiedergabe des Intros fort
        /// </summary>
        public void Resume()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Wiedergabe der Soundeffekte
        /// </summary>
        public void Play(SoundEffect SoundFX)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Wiedergabe der Hintergrundmusik
        /// </summary>
        public void Play(Song Background)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Wiedergabe des Intros
        /// </summary>
        public void Play(Video intro)
        {
            throw new NotImplementedException();
        }
    }
}
