using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvadersRemake
{
    /// <summary>
    /// Die Klasse dient dazu sich Gegner (<c>GameItem</c>) generieren zu lassen
    /// </summary>
    /// <remarks>Abstrakte Fabrik</remarks>
    public abstract class WaveGenerator
    {

       /// <summary>
        /// Generiert eine Welle von Gegnern 
       /// </summary>
       /// <returns></returns>
        protected abstract SpaceInvadersRemake.IGameItem[] GetWave();
 
    }
}
