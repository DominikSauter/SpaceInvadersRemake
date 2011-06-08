using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace SpaceInvadersRemake.ModelSection
{
    /// <summary>
    /// Generiert eine Liste von Gegner-Objekten aus einem Positions-Array.
    /// </summary>
    /// <remarks>Vorgefertigte Arrays für bestimmte Formationen sind in der Klasse bereits verfügbar.</remarks>
    public static class FormationGenerator
    {
        /// <summary>
        /// Positionsangaben für eine Block-Formation.
        /// </summary>
        public static Vector2[] BlockFormation
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        /// <summary>
        /// Positionsangaben für eine Totenkopf-Formation.
        /// </summary>
        public static Microsoft.Xna.Framework.Vector2[] SkullFormation
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        /// <summary>
        /// Positionsangaben für eine Dreieck-Formation.
        /// </summary>
        public static Vector2[] TriangleFormation
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        /// <summary>
        /// Positionsangaben für eine Kreis-Formation.
        /// </summary>
        public static Vector2[] CircleFormation
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        /// <summary>
        /// Erzeugt eine Liste von Gegner-Objekten aus einem Vector2-Array.
        /// </summary>
        /// <returns></returns>
        public static List<IGameItem> CreateFormation(int hitpoints, Vector2 velocity, Vector2[] formation)
        {
            throw new System.NotImplementedException();
        }

    }
}
