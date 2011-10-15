using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Implementiert von Christian (ck)
namespace SpaceInvadersRemake.Settings
{
    /// <summary>
    /// Enthält alle für das Spiel nutzbare Eingabemöglichkeiten.
    /// </summary>
    /// <remarks>
    /// Um Erweiterbarkeit zu erlauben ist diese Enum nicht als abgeschlossen anzusehen.
    /// Insbesondere bei switch case muss darrauf geachtet werden.
    /// <para>
    /// Sofern ein neuer PlayerController implementiert wurde muss er hier auftauchen.
    /// Zusätzlich muss die Switch Anweisung der CreatePlayer Methode angepasst werden, den neuen Controller zu erzeugen.
    /// <see cref="SpaceInvadersRemake.Controller.ControllerManager.CreatePlayerController"/>
    /// 		<seealso cref="SpaceInvadersRemake.Controller.PlayerController"/>
    /// 	</para>
    /// </remarks>
    public enum  SupportedInputEnum
    {
        /// <summary>
        /// Eingabe erfolgt über die Tastatur
        /// </summary>
        Keyboard,


        /// <summary>
        /// Eingabe erfolgt über den XBoxController
        /// </summary>
        XBoxController


    }
}
