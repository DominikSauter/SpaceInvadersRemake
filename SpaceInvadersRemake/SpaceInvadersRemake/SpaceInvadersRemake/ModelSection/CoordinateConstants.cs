using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace SpaceInvadersRemake.ModelSection
{
    /// <summary>
    /// In dieser Klasse befinden sich die Konstanten für die Richtungen im Spiel-Koordinatensystem und dessen Begrenzungen
    /// </summary>
    public static class CoordinateConstants
    {
        //Directions Definitions


        /// <summary>
        /// Oben
        /// </summary>
        public static Vector2 Up
        {
            get
            {
                return new Vector2(0.0f, 1.0f);
            }
        }
        /// <summary>
        /// Unten
        /// </summary>
        public static Vector2 Down
        {
            get
            {
                return new Vector2(0.0f, -1.0f);
            }
        }
        /// <summary>
        /// Rechts
        /// </summary>
        public static Vector2 Right
        {
            get
            {
                return new Vector2(1.0f, 0.0f);
            }
        }
        /// <summary>
        /// Links
        /// </summary>
        public static Vector2 Left
        {
            get
            {
                return new Vector2(-1.0f, 0.0f);
            }
        }

        /// <summary>
        /// Oberer Rand der Spielebene
        /// </summary>
        public static float TopBorder
        {
            get
            {
                return 75.0f; 
            }
        }

        /// <summary>
        /// Unterer Rand der Spielebene
        /// </summary>
        public static float BottomBorder
        {
            get
            {
                return -75.0f; 
            }
        }

        /// <summary>
        /// Rechter Rand der Spielebene
        /// </summary>
        public static float RightBorder
        {
            get
            {
                return 100.0f; 
            }
        }

        /// <summary>
        /// Linker Rand der Spielebene
        /// </summary>
        public static float LeftBorder
        {
            get
            {
                return -100.0f; 
            }
        }
    }
}
