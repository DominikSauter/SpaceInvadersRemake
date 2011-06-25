using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

// Implementiert von D. Sauter

namespace SpaceInvadersRemake.ModelSection
{
    /// <summary>
    /// Diese Klasse enthält Standardwerte der GameItems.
    /// </summary>
    public static class GameItemConstants
    {
        /// <summary>
        /// Die standardmäßige Schussfrequenz der Aliens in Schussanzahl pro Sekunde.
        /// </summary>
        public static float AlienShootingFrequency
        {
            get
            {
                return 3.0f;
            }
        }

        /// <summary>
        /// Die standardmäßige Geschwindigkeitserhöhung der Aliens in Erhöhungswert pro Sekunde.
        /// </summary>
        public static Vector2 AlienVelocityIncrease
        {
            get
            {
                return new Vector2(0.5f, 0.5f);
            }
        }
    }
}
