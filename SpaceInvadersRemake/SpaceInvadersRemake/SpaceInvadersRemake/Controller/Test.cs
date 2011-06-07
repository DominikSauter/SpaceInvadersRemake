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

            // cm.Controllers.Add(new Controllers()); // TODO: Kontextsentiv???

            cm.Controllers.Add(new KeyboardController());
        }
    }
}
