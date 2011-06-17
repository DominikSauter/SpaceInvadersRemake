using System;
using SpaceInvadersRemake.ModelSection;

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
        protected PlayerController(IGameItem controllee):base(controllee)
        {
            
        }

    }
}
