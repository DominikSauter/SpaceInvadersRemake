using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvadersRemake.ModelSection
{
    /// <summary>
    /// Diese Enumeration bietet IDs für alle PowerUps und den Fall, dass ein PowerUps zufällig bestimmt werden soll.
    /// </summary>
    public enum PowerUpEnum
    {
        /// <summary>
        /// zufälliges PowerUps
        /// </summary>
        Random,
        PiercingShot,
        Rapidfire,
        MultiShot,
        Speedboost,
        Deflector,
        StaticShield,
        SlowMotion,
    }
}
