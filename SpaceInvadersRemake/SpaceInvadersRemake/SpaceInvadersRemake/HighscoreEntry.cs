using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvadersRemake
{
    public abstract class HighscoreEntry
    {
        public abstract string Name
        {
            get;
            set;
        }

        public abstract int Score
        {
            get;
            set;
        }
    }
}
