using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Media;

namespace SpaceInvadersRemake
{
    public class BackgroundMusic : IMediaplayer
    {
        private Song menuSong;

        public BackgroundMusic()
        {
            throw new System.NotImplementedException();
        }

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

        public void Play()
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

        private Song gameSong;

        private void playGameSong()
        {
            throw new System.NotImplementedException();
        }

        private void playMenuSong()
        {
            throw new System.NotImplementedException();
        }


        public void Stop()
        {
            throw new NotImplementedException();
        }

        public void Pause()
        {
            throw new NotImplementedException();
        }

        public void Resume()
        {
            throw new NotImplementedException();
        }

        public void FadeIn()
        {
            throw new System.NotImplementedException();
        }

        public void FadeOut()
        {
            throw new System.NotImplementedException();
        }
    }
}
