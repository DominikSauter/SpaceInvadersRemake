using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvadersRemake.Controller
{
    public abstract class AlienAI : AIController
    {
        public AlienAI(WaveAI wave)
        { }

        protected override Microsoft.Xna.Framework.Vector2 Movement()
        {
            throw new NotImplementedException();
        }

        protected override bool Shooting()
        {
            throw new NotImplementedException();
        }
    }
}
