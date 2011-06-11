using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvadersRemake.ModelSection
{
    /// <summary>
    /// Die abstrakte Oberklasse aller gegnerischen Raumschiffe im Spiel.
    /// </summary>
    public abstract class Enemy : Ship
    {
        /// <summary>
        /// Die Punktzahl die dem Spieler bei Zertörung gutgeschrieben wird
        /// </summary>
        public int ScoreGain
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
