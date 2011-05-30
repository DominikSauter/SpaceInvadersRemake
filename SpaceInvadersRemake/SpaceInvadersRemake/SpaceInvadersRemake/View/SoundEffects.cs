using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Media;

namespace SpaceInvadersRemake
{
    public class SoundEffects : IMediaplayer
    {
        private SoundEffects explosion;

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

        public void play()
        {
            throw new NotImplementedException();
        }


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

        private SoundEffects fireWeapon;
        private SoundEffects dropPowerUp;

        private void playPowerUp()
        {
            throw new System.NotImplementedException();
        }

        private void playExplosion()
        {
            throw new System.NotImplementedException();
        }

        private void playWeapon()
        {
            throw new System.NotImplementedException();
        }


        public void stop()
        {
            throw new NotImplementedException();
        }

        public void pause()
        {
            throw new NotImplementedException();
        }

        public void resume()
        {
            throw new NotImplementedException();
        }
    }
}
