using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Media;

namespace SpaceInvadersRemake.View
{
    /// <summary>
    /// Diese klasse kümmert sich um die Wiedergabe der Hintergrundmusik.
    /// </summary>
    public class BackgroundMusic : IMediaplayer
    {
        private Song menuSong;

        /// <summary>
        /// Initialisiert Hintergrundmusik
        /// </summary>
        public BackgroundMusic()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Lautstärkeregelung
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
        /// Wiedergabe der Hintergrundmusik
        /// </summary>
        public void Play()
        {
            throw new NotImplementedException();
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

        private Song gameSong;

        private void playGameSong()
        {
            throw new System.NotImplementedException();
        }

        private void playMenuSong()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Stoppt die Wiedergabe der Hintergrundmusik
        /// </summary>
        public void Stop()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Langsammes Einblenden der Hintegrundmusik
        /// </summary>
        public void FadeIn()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Langsammes Ausblenden der Hintergrundmusik
        /// </summary>
        public void FadeOut()
        {
            throw new System.NotImplementedException();
        }
    }
}
