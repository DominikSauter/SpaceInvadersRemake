//Implementiert von Dodo
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        /// Wiedergabe der Soundeffekte
        /// </summary>
        public void Play(SoundEffect SoundFX)
        {
            this.soundEffects.Add(SoundFX.CreateInstance());
            this.soundEffects[this.soundEffects.Count - 1].Play();
        }

        public bool Repeat
        {
            get;
            set;
        }

        public void Play(Song Background)
        {
        }

        public void Play(Video intro)
        {
        }

        public void Stop()
        {
            foreach (SoundEffectInstance effect in this.soundEffects)
            {
                effect.Stop();
            }
        }
    }
}
