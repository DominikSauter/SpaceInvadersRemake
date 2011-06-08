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
            public get
            {
                return new Vector2(0.0f, 1.0f);
            }
        }
        /// <summary>
        /// Unten
        /// </summary>
        public static Vector2 Down
            {
            public get
            {
                return new Vector2(0.0f, -1.0f);
            }
        }
        /// <summary>
        /// Rechts
        /// </summary>
        public static Vector2 Right
            {
            public get
            {
                return new Vector2(1.0f, 0.0f);
            }
        }
        /// <summary>
        /// Links
        /// </summary>
        public static Vector2 Left
        {
            public get
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
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        /// <summary>
        /// Unterer Rand der Spielebene
        /// </summary>
        public static float BottomBorder
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
        /// Rechter Rand der Spielebene
        /// </summary>
        public static float RightBorder
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
        /// Linker Rand der Spielebene
        /// </summary>
        public static float LeftBorder
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    }
}
