using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
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
        void Play(SoundEffect SoundFX);

        void Play(Song Background);

        void Play(Video intro);

        /// <summary>
        /// Stoppt die Soundwiedergabe
        /// </summary>
        void Stop();
    }
}
