using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvadersRemake
{
    public abstract class GameItemRepresentation : IView
    {
        public Matrix Projection
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public Matrix Camera
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public Matrix World
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public void Show(GameTime gameTime);
    }
}
