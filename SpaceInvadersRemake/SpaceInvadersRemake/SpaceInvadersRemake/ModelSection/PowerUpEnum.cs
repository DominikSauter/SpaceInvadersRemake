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
        /// <summary>
        /// Durchschlagender Schuss
        /// </summary>
        PiercingShot,
        /// <summary>
        /// Schnellfeuer
        /// </summary>
        Rapidfire,
        /// <summary>
        /// Mehrfachschuss
        /// </summary>
        MultiShot,
        /// <summary>
        /// Geschwindigkeitserhöhung
        /// </summary>
        Speedboost,
        /// <summary>
        /// Schutzschild um Spielerschiff
        /// </summary>
        Deflector,
        /// <summary>
        /// Statisches Schutzschild
        /// </summary>
        StaticShield,
        /// <summary>
        /// Zeitlupe
        /// </summary>
        SlowMotion,
    }
}
