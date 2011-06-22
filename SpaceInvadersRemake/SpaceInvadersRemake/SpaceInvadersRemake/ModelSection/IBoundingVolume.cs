using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvadersRemake.ModelSection
{
    /// <summary>
    /// Schnittstelle für Umgebungsvolumen. Bietet Funktionalität zur Kollisionsberechnung.
    /// </summary>
    public interface IBoundingVolume
    {
        /// <summary>
        /// Überprüft ob sich das Umgebungsvolumen mit einem anderen überschneidet.
        /// </summary>
        /// <param name="other">Das andere Umgebungsvolumen</param>
        /// <returns>Gibt an ob Überschneidung erfolgt</returns>
        bool Intersects(IBoundingVolume other);
    }
}
