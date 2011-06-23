using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace SpaceInvadersRemake.View
{
    /// <summary>
    /// Utilityklasse um Umrechnungen zwischen den verschiedenen Ebenen zu ermöglichen.
    /// </summary>
    /// <remarks>
    /// Speziell Umrechung von der 2D Ebene der Spiellogik in den 3D Raum.
    /// </remarks>
    public static class PlaneProjector
    {
        public static float scaleFactor = 10.0f;

        //private static
        /// <summary>
        /// Rechnet einen Positionsvektor in der 2D Ebene in einen Positionsvektor im 3D Raum um.
        /// </summary>
        /// <param name="vector2D">2D Positionsvektor</param>
        /// <returns>3D Positionsvektor</returns>
        public static Vector3 Convert2DTo3D(Vector2 vector2D)
        {
            return new Vector3(vector2D.X * scaleFactor, 0, vector2D.Y * scaleFactor);
        }
    }
}
