//Implementiert von Dodo
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
        /// Lautstärkeregelung
        /// </summary>
        /// <remarks>
        /// bei 0: lautlos
        /// bei 1: volle Lautstärke
        /// </remarks>
        float Volume
        {
            get;
            set;
        }

        /// <summary>
        /// Wahrheitswert, der festlegt ob ein Effekt wiederholt werden soll.
        /// true: Effekt wird wiederholt
        /// false: Effekt wird einmalig wiedergegeben
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
