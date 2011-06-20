using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace SpaceInvadersRemake
{
    public class EffectContent
    {
        public SoundEffect MothershipSound
        {
            get;
            set;
        }

        public Texture2D EngineTexture
        {
            get;
            set;
        }

        public SoundEffect ExplosionSound
        {
            get;
            set;
        }

        public Texture2D ExplosionTexture
        {
            get;
            set;
        }

        public Song GameSong
        {
            get;
            set;
        }

        public Video IntroVideo
        {
            get;
            set;
        }

        public Song MenuSong
        {
            get;
            set;
        }

        public SoundEffect PowerUpSound
        {
            get;
            set;
        }

        public Texture2D PowerUpGlow
        {
            get;
            set;
        }

        public SoundEffect WeaponMultishot
        {
            get;
            set;
        }

        public SoundEffect WeaponPiercingshot
        {
            get;
            set;
        }

        public SoundEffect WeaponPlayer
        {
            get;
            set;
        }

        public SoundEffect WeaponRapidFire
        {
            get;
            set;
        }
    }
}
