﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvadersRemake.ModelSection
{
    class ModelManager : SpaceInvadersRemake.StateMachine.IModel
    {
        public GameCourseManager GameCourseManager
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public void Update(Microsoft.Xna.Framework.Game game, Microsoft.Xna.Framework.GameTime gameTime, StateMachine.State state)
        {
            throw new NotImplementedException();
        }
    }
}
