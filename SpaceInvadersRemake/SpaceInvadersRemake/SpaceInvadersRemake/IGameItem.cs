using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvadersRemake
{
    public interface IGameItem
    {
        int Position
        {
            get;
            set;
        }

        int Velocity
        {
            get;
            set;
        }

        void Move();
    }
}
