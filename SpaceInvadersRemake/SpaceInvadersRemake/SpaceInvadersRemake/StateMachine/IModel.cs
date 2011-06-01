using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvadersRemake.StateMachine
{
    interface IModel
    {
        void Update(Microsoft.Xna.Framework.Game game, Microsoft.Xna.Framework.GameTime gameTime, State state);
    }
}
