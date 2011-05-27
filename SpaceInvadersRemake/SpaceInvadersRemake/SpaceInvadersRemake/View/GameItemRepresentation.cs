using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace SpaceInvadersRemake
{
    public abstract class GameItemRepresentation : IView
    {
        abstract public Matrix Projection
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public abstract Matrix Camera
        {
            get;
            set;
        }

        abstract public Matrix World
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        abstract public void Show(GameTime gameTime);
    }
}
