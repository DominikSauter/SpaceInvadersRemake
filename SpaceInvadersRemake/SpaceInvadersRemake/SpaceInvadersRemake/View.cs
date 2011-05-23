using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvadersRemake
{
    public interface View
    {
        SpriteFont font
        {
            get;
            set;
        }
    
        void show();
    }
}
