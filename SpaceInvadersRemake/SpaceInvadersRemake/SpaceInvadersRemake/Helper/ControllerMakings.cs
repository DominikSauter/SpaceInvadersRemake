using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceInvadersRemake.Controller;

namespace SpaceInvadersRemake.Helper
{
    /// <summary>
    /// Diese Klasse dient dazu die gewünschten Controller Eigenschaften zu übergeben.
    /// </summary>
    /// <remarks>Indem man diese Struct dem Event Model Created mitgibt, steuert wann z.B. welche Controller Intelligens man haben möchte oder wie hoch die Schussfrequenz des Controllers sein soll.</remarks>
    public struct ControllerMakings
    {
        AIEnum desiredController;
        int shootingFrequenz;

    }
}
