using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceInvadersRemake.Controller;

namespace SpaceInvadersRemake.ModelSection
{
    /// <summary>
    /// Diese Klasse dient dazu die gewünschten Controller Eigenschaften zu übergeben.
    /// // TODO: Was sind Controller-Eigenschaften (STST)
    /// </summary>
    /// <remarks>Indem man diese Struct dem Event Model Created mitgibt, steuert wann z.B. welche Controller Intelligens man haben möchte oder wie hoch die Schussfrequenz des Controllers sein soll.</remarks>
    public struct ControllerParameters
    {
        public ControllerEnum AI
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public List<IGameItem> Controllees
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public DifficultyLevel DifficultyLevel
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    }
}
