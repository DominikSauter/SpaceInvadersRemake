using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace SpaceInvadersRemake.ModelSection
{
    /// <summary>
    /// In dieser Klasse befinden sich die Richtungskonstanten
    /// </summary>
    public static class DirectionsConstants
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
    }
}
