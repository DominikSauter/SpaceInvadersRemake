using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceInvadersRemake.View
{
    /// <summary>
    /// Representation einen sichtbaren Gegenstands für den Benutzer, welche auf den Bildschirm gezeichnet werden kann.
    /// </summary>
    public abstract class GameItemRepresentation : IView
    {
        /// <summary>
        /// Projektionsmatrix, welche die 3D-Darstellung auf den 2D-Bildschirm projiziert.
        /// </summary>
        public static Matrix Projection
        {
            get;
            set;
        }

        /// <summary>
        /// Kameramatrix, welche die Kameraposition sowie Sichtweite und Blickrichtung festlegt.
        /// </summary>
        public static Matrix Camera
        {
            get;
            set;
        }

        /// <summary>
        /// Positionsmatrix, welche die Position des 3D Models im Raum festlegt.
        /// </summary>
        protected Matrix World;


        /// <summary>
        /// Zeichnet das Objekt auf den Bildschirm
        /// </summary>
        abstract public void Draw(SpriteBatch spriteBatch);

    }
}
