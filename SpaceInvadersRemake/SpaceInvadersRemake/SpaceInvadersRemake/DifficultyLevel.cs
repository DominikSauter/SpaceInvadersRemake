using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvadersRemake
{
    public abstract class DifficultyLevel
    {
        public abstract int Hitpoints
        {
            get;
            set;
        }

        public abstract Vector2 Velocity
        {
            get;
            set;
        }

        public abstract int ShootingFrequency
        {
            get;
            set;
        }

        public abstract Vector2 VelocityIncrease
        {
            get;
            set;
        }
    }
}
