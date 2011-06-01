using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace SpaceInvadersRemake.View
{
    /// <summary>
    /// Interface für View Objekte, die gezeichnet werden sollen.
    /// </summary>
    public interface IView
    {
        /// <summary>
        /// <c>draw</c> Methode die von den Unterklassen implementiert wird.
        /// </summary>
        /// <param name="gameTime"> Zeitpunkt des Spiels zudem <c>draw</c> aufgerufen wird. </param>
        void Draw(GameTime gameTime);
    }
}
