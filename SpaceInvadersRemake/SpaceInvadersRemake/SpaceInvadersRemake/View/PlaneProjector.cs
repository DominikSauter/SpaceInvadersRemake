//Implementiert von Dodo
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
        /// Faktor um den die 2D-Spielebene skaliert wird
        /// </summary>
        public static float scaleFactor = 2.0f;

        //private static
        /// <summary>
        /// Rechnet einen Positionsvektor in der 2D Ebene in einen Positionsvektor im 3D Raum um.
        /// </summary>
        /// <param name="itemPosition2D">2D Positionsvektor</param>
        /// <returns>3D Positionsvektor</returns>
        public static Vector3 Convert2DTo3D(Vector2 itemPosition2D)
        {
            return new Vector3(itemPosition2D.X * scaleFactor, 0, itemPosition2D.Y * scaleFactor);
        }


        /// <summary>
        /// Berechnet eine 3D Position der Kamera anhand der 2D-Koordinaten und dem gewünschten Sichtwinkel
        /// auf das Spielerschiff
        /// </summary>
        /// <param name="cameraPosition2D">Position der Kamera in der 2D Ebene</param>
        /// <param name="angle">Winkel der Kamera in Abhängigkeit zum Spielerschiff</param>
        /// <returns>Position der Kamera im 3D-Raum</returns>
        /// <remarks>Wichtig an den 2D-Koordinaten ist eigentlich nur die Y-Koordinate,
        /// da im Spiel eine Zentralperspektive benutzt wird.</remarks>
        public static Vector3 ComputeCameraPosition(Vector2 cameraPosition2D, float angle)
        {
            /* Berechnen der Höhe abhänging von der Y-Position in der 2D-Ebene und dem
             * gewünschten Sichtwinkel auf das Spielerschiff.
             * */
            float yCoord3D = cameraPosition2D.Y / Math.Tan(angle);

            return new Vector3(cameraPosition2D.X, yCoord3D, cameraPosition2D.Y)
        }
    }
}
