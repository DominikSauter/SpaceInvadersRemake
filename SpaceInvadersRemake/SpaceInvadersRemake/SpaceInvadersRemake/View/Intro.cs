using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SpaceInvadersRemake.View
{
    /// <summary>
    /// Diese Klasse kümmert sich um die Wiedergabe des Introvideos zum Spiel.
    /// </summary>
    public class Intro : IMediaplayer
    {
        private VideoPlayer videoPlayer;
        private float volume;
        private bool repeat;

        /// <summary>
        /// Initialisiert das Introvideo
        /// </summary>
        public Intro()
        {
            this.videoPlayer = new VideoPlayer();
            this.Volume = Settings.GameConfig.Default.MasterVolume;
            this.Repeat = false;
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
                this.videoPlayer.Volume = value;
            }
        }

        /// <summary>
        /// Wahrheitswert ob das Into wiederholt werden soll oder nicht. 
        /// true: Intro wird wiederholt
        /// false: Intro wird einmalig abgespielt
        /// </summary>
        public bool Repeat
        {
            get
            {
                return this.repeat;
            }
            set
            {
                this.repeat = value;
                this.videoPlayer.IsLooped = value;
            }
        }

        /// <summary>
        /// Stoppt die Introwiedergabe
        /// </summary>
        public void Stop()
        {
            this.videoPlayer.Stop();
        }

        /// <summary>
        /// Wiedergabe der Soundeffekte
        /// </summary>
        /// <param name="SoundFX">Soundeffekt</param>
        public void Play(SoundEffect SoundFX)
        {
        }

        /// <summary>
        /// Wiedergabe der Hintergrundmusik
        /// </summary>
        /// <param name="Background">Hintergrundmusik</param>
        public void Play(Song Background)
        {
        }

        /// <summary>
        /// Wiedergabe des Intros
        /// </summary>
        /// <param name="intro">Introvideo</param>
        public void Play(Video intro)
        {
            if (videoPlayer.State == MediaState.Stopped)
            {
                videoPlayer.Play(intro);
            }
        }

        public void drawVideo(SpriteBatch spriteBatch)
        {
            Texture2D videoTexture = null;

            if (videoPlayer.State != MediaState.Stopped)
            {
                videoTexture = videoPlayer.GetTexture();
            }
                

            if (videoTexture != null)
            {
                spriteBatch.Begin();
                spriteBatch.Draw(videoTexture, new Rectangle(0, 0, 400, 300), Color.White);
                spriteBatch.End();
            }
        }
    }
}
