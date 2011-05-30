using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvadersRemake
{
    public interface IMediaplayer
    {
        float Volume
        {
            get;
            set;
        }

        bool Repeat
        {
            get;
            set;
        }

        void play();

        void stop();

        void pause();

        void resume();
    }
}
