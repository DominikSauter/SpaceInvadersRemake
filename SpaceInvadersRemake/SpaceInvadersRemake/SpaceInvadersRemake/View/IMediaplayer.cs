using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvadersRemake.View
{
    /// <summary>
    /// Interface für Sound- und Videowiedergabe.
    /// </summary>
    public interface IMediaplayer
    {
        float Volume
        {
            get;
            set;
        }

        bool Repeat
        {
            get;
            set;
        }

        /// <summary>
        /// Spielt Sound ab
        /// </summary>
        void Play();

        /// <summary>
        /// Stoppt die Soundwiedergabe
        /// </summary>
        void Stop();
    }
}
