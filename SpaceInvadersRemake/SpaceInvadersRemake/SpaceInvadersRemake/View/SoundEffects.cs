//Implementiert von Dodo
using System.Collections.Generic;

using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

namespace SpaceInvadersRemake.View
{
    /// <summary>
    /// Diese Klasse kümmert sich um die Wiedergabe der Sound Effekte.
    /// </summary>
    public class SoundEffects : IMediaplayer
    {
        private float volume;
        private List<SoundEffectInstance> soundEffects;

        /// <summary>
        /// Erzeugt ein SoundEffects-Objekt, dass zum Abspielen von Effekten dient.
        /// </summary>
        public SoundEffects()
        {
            this.soundEffects = new List<SoundEffectInstance>();
            this.Volume = Settings.GameConfig.Default.MasterVolume * Settings.GameConfig.Default.EffectVolume;
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
                return this.volume;
            }
            set
            {
                this.volume = value;
                SoundEffect.MasterVolume = value;
            }
        }

        /// <summary>
        /// Wahrheitswert, der festlegt ob ein Effekt wiederholt werden soll.
        /// true: Effekt wird wiederholt
        /// false: Effekt wird einmalig wiedergegeben
        /// </summary>
        public bool Repeat
        {
            get;
            set;
        }

        /// <summary>
        /// Spielt einen Soundeffekt ab.
        /// </summary>
        /// <param name="SoundFX">Soundeffekt</param>
        public void Play(SoundEffect SoundFX)
        {
            this.soundEffects.Add(SoundFX.CreateInstance());
            this.soundEffects[this.soundEffects.Count - 1].Play();
        }

        /// <summary>
        /// Spielt eine Hintergrundmusik ab.
        /// </summary>
        /// <param name="Background">Hintergrundmusik</param>
        public void Play(Song Background)
        {
        }

        /// <summary>
        /// Spielt ein Video ab.
        /// </summary>
        /// <param name="intro">Introvideo</param>
        public void Play(Video intro)
        {
        }

        /// <summary>
        /// Stoppt die Soundwiedergabe
        /// </summary>
        public void Stop()
        {
            foreach (SoundEffectInstance effect in this.soundEffects)
            {
                effect.Stop();
            }
        }
    }
}
