using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvadersRemake.ModelSection
{


    /// <summary>
    /// Enumeration zur Festlegung der AI, d.h. des gewünschten Controllers.
    /// </summary>
    public enum BehaviourEnum
    {
        KeyboardController,//HACK Umbenennen in gewünschtes Verhalten bsp: statt BlockSwarm schreibe im BlockMovement -CK
        BlockSwarm,
        Miniboss,
        Alien,
        Mothership,
        
    }
}
