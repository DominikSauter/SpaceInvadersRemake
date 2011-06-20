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
    public class BackgroundMusic : IMediaplayer
    {
        /// <summary>
        /// Initialisiert die Hintergrundmusik
        /// </summary>
        public BackgroundMusic()
        {
            throw new System.NotImplementedException();
        }

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
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Wahrheitswert für die Wiederholung der Hintergrundmusik.
        /// true: Hintergrundmusik wird wiederholt
        /// false: Hintergrundmusik wird einmalig abgespielt
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
        /// Stoppt die Wiedergabe der Hintergrundmusik
        /// </summary>
        public void Stop()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Langsames Einblenden der Hintegrundmusik
        /// </summary>
        public void FadeIn()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Langsames Ausblenden der Hintergrundmusik
        /// </summary>
        public void FadeOut()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Wiedergabe der Soundeffekte
        /// </summary>
        /// <param name="SoundFX">Soundeffekt</param>
        public void Play(SoundEffect SoundFX)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Wiedergabe der Hintergrundmusik
        /// </summary>
        /// <param name="Background">Hintergrundmusik</param>
        public void Play(Song Background)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Wiedergabe des Intros
        /// </summary>
        /// <param name="intro">Introvideo</param>
        public void Play(Video intro)
        {
            throw new NotImplementedException();
        }
    }
}
