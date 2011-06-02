using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvadersRemake.Controller
{
    class Test
    {
        static void TestMeth()
        {
            ControllerManager cm = new ControllerManager();

            // cm.Controller.Add(new Controller()); // TODO: Kontextsentiv???

            cm.Controller.Add(new KeyboardController());
        }
    }
}
