using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvadersRemake
{
    public abstract class Effects : IView
    {
        void Show(GameTime gameTime);
    }
}
