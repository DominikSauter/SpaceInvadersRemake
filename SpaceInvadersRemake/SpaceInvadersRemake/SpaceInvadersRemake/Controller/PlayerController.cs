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
    /// Neue Controller müssen sich zudem unter SupportedInputEnum eintragen.
    /// <see cref="SpaceInvadersRemake.Settings.SupportedInputEnum"/>
    /// </remarks>
    public abstract class PlayerController : SpaceInvadersRemake.Controller.Controller
    {
        /// <summary>
        /// Erstellt eine neue Instanz eines allgemeinen PlayerControllers.
        /// </summary>
        /// <remarks>
        /// Da dies eine Abstrakte Klasse ist, wird dieser innerhalb des Konstruktors der konkreten Klasse aufgerufen.
        /// </remarks>
        /// <param name="controllee"></param>
        protected PlayerController(IGameItem controllee):base(controllee)
        {
            //Es gibt hier nichts zu tun.
        }

    }
}
