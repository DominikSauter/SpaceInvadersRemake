using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvadersRemake.ModelSection
{
    /// <summary>
    /// Dieses Delegate wird verwendet um die Auswirkungen eines PowerUps am Spieler anzubringen und wieder rückgängig zu machen.
    /// </summary>
    /// <param name="player">Betroffener Spieler</param>
    public delegate void PowerUpAction(Player player);
}
