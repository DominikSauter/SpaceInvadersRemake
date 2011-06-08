using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvadersRemake.Controller
{
    /// <summary>
    /// Diese Klasse abstrahiert  von den verschiedenen Benutzereingaben
    /// </summary>
    /// <remarks>
    /// In den Abgeleiteten Klassen wird das Verhalten des Controllers durch Benutzereingabe bestimmt.
    /// Von dieser Klasse muss geerbt werden wenn eine neue Benutzereingabe implementiert werden soll.
    /// </remarks>
    public abstract class PlayerController : SpaceInvadersRemake.Controller.Controller
    {

        /// <summary>
        /// Entscheidet in welche Richtung sich das Controllees bewegen soll
        /// </summary>
        /// <returns>
        /// 2D Richtungsvektor
        /// </returns>
        protected override Microsoft.Xna.Framework.Vector2 Movement()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Entscheidet ob Controllees schießen soll
        /// </summary>
        /// <returns>
        /// 	<c>true</c> = schießen andererseits <c>false</c>
        /// </returns>
        protected override bool Shooting()
        {
            throw new NotImplementedException();
        }
    }
}
