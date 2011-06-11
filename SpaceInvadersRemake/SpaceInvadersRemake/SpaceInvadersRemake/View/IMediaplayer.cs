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
        /// <summary>
        /// Musiklautstärke
        /// </summary>
        float Volume
        {
            get;
            set;
        }

        /// <summary>
        /// Musikstücke werden wiederholt oder nicht.
        /// </summary>
        bool Repeat
        {
            get;
            set;
        }

        /// <summary>
        /// Spielt einen Soundeffekt ab.
        /// </summary>
        /// <param name="SoundFX">Soundeffekt</param>
        void Play(SoundEffect SoundFX);

        /// <summary>
        /// Spielt eine Hintergrundmusik ab.
        /// </summary>
        /// <param name="Background">Hintergrundmusik</param>
        void Play(Song Background);

        /// <summary>
        /// Spielt ein Video ab.
        /// </summary>
        /// <param name="intro">Introvideo</param>
        void Play(Video intro);

        /// <summary>
        /// Stoppt die Soundwiedergabe
        /// </summary>
        void Stop();
    }
}
