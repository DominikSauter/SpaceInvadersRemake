using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvadersRemake
{
    public interface Mediaplayer2
    {
        float Volume
        {
            get;
            set;
        }

        void play();
    }
}
