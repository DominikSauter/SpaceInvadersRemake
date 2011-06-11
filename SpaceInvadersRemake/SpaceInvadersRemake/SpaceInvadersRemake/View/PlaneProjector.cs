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
        /// <summary>
        /// Rechnet einen Positionsvektor in der 2D Ebene in einen Positionsvektor im 3D Raum um.
        /// </summary>
        /// <param name="vector2D">2D Positionsvektor</param>
        /// <returns>3D Positionsvektor</returns>
        public static Vector3 Convert2DTo3D(Vector2 vector2D)
        {
            throw new System.NotImplementedException();
        }
    }
}
