﻿using System;
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
        private SoundEffect explosion;
        private SoundEffect fireWeaponPiercing;
        private SoundEffect fireWeaponMulti;
        private SoundEffect mothership;
        private SoundEffect fireWeapon;
        private SoundEffect dropPowerUp;


        /// <summary>
        /// Erzeugt ein SoundEffects-Objekt, dass zum Abspielen von Effekten dient.
        /// </summary>
        /// <param name="powerUp">PowerUp-Drop Sound</param>
        /// <param name="explosion">Explosions Sound</param>
        /// <param name="shoot">Feuern-Sound eines normalen Projektils</param>
        /// <param name="piercing">Feuern-Sound eines durchschlagenden Projektils</param>
        /// <param name="multishot">Feuern-Sound eines mehrfacher Projektile</param>
        /// <param name="mothership">Mutterschiff-Erscheinen Sound</param>
        public SoundEffects(SoundEffect powerUp, SoundEffect explosion, SoundEffect shoot, SoundEffect piercing, SoundEffect multishot, SoundEffect mothership)
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
        /// Wahrheitswert, der festlegt ob ein Effekt wiederholt werden soll.
        /// true: Effekt wird wiederholt
        /// false: Effekt wird einmalig wiedergegeben
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
        /// Stoppt die Wiedergabe eines Sound Effekts
        /// </summary>
        public void Stop()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Pausiert die Wiedergabe eines Sound Effekts
        /// </summary>
        public void Pause()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Setzt die Wiedergabe des Sound Effekts fort 
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
