using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvadersRemake
{
    public abstract class WaveAI : AIController
    {
        public override abstract SpaceInvadersRemake.IGameItem[] Controllee
        {
            get;

            set;

        }

    }
}
