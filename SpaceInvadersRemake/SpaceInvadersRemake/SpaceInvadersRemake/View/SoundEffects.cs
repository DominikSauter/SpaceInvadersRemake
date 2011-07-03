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
    public class SoundEffects
    {
        
        /// <summary>
        /// Erzeugt ein SoundEffects-Objekt, dass zum Abspielen von Effekten dient.
        /// </summary>
        
        public SoundEffects()
        {
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
            get;
            set;
        }

        /// <summary>
        /// Stoppt die Wiedergabe eines Sound Effekts
        /// </summary>
        public void Stop()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Wiedergabe der Soundeffekte
        /// </summary>
        public void Play(SoundEffect SoundFX)
        {
            SoundFX.Play();
        }
    }
}
