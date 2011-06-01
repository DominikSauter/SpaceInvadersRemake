using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

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
        public Matrix Projection
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
        /// Kameramatrix, welche die Kameraposition sowie Sichtweite und Blickrichtung festlegt.
        /// </summary>
        public Matrix Camera
        {
            get;
            set;
        }

        /// <summary>
        /// Positionsmatrix, welche die Position des 3D Models im Raum festlegt.
        /// </summary>
        public Matrix World
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
        /// Zeichnet das Objekt auf den Bildschirm
        /// </summary>
        /// <param name="gameTime"></param>
        abstract public void Draw(GameTime gameTime);

    }
}
