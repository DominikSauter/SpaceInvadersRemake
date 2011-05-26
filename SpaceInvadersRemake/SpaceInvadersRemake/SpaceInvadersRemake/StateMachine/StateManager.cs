using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace SpaceInvadersRemake
{
    public class StateManager
    {
        // Wahrscheinlich wird Game irgendwann gebraucht
        public StateManager(Game gameManager)
        {
        }

        public State State
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public void Model(GameTime gameTime)
        {
            throw new System.NotImplementedException();
        }

        public void View(GameTime gameTime)
        {
            throw new System.NotImplementedException();
        }

        public void Controller(GameTime gameTime)
        {
            throw new System.NotImplementedException();
        }
    }
}
