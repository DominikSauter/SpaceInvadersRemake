using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvadersRemake
{
    public class MenuInterface : IView
    {
        public MenuInterface(string[] buttonLabels)
        {
            throw new System.NotImplementedException();
        }

        public SpaceInvadersRemake.ButtonRepresentation[] ButtonRepresentation
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

        public void AddButton(Button button)
        {
            throw new System.NotImplementedException();
        }
    }
}
