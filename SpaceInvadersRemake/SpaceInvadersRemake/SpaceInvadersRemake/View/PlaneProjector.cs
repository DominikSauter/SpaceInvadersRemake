//Implementiert von Dodo
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
        public static float scaleFactor = 4.0f;

        //private static
        /// <summary>
        /// Rechnet einen Positionsvektor in der 2D Ebene in einen Positionsvektor im 3D Raum um.
        /// </summary>
        /// <param name="itemPosition2D">2D Positionsvektor</param>
        /// <returns>3D Positionsvektor</returns>
        public static Vector3 Convert2DTo3D(Vector2 itemPosition2D)
        {
            return new Vector3(itemPosition2D.X * scaleFactor, 0, -itemPosition2D.Y * scaleFactor);
        }
    }
}
