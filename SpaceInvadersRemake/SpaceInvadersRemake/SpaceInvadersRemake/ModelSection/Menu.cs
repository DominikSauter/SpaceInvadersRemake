using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvadersRemake.ModelSection
{
    public class Menu : SpaceInvadersRemake.StateMachine.IModel
    {
        private System.Collections.Generic.List<SpaceInvadersRemake.ModelSection.MenuControl> controls;

        public Menu()
        {
            throw new System.NotImplementedException();
        }

        public SpaceInvadersRemake.ModelSection.MenuControl[] Controls
        {
            get
            {
                return controls.ToArray();
            }
        }

        public MenuControl ActiveControl
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public void Action()
        {
            throw new System.NotImplementedException();
        }

        public void Update(Microsoft.Xna.Framework.Game game, Microsoft.Xna.Framework.GameTime gameTime, StateMachine.State state)
        {
            throw new NotImplementedException();
        }

        public void Down()
        {
            throw new System.NotImplementedException();
        }

        public void Up()
        {
            throw new System.NotImplementedException();
        }

        public void Left()
        {
            throw new System.NotImplementedException();
        }

        public void Right()
        {
            throw new System.NotImplementedException();
        }
    }
}
