using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using SpaceInvadersRemake.StateMachine;

//TODO: Diskussion über Designentscheidungen

// UNDER CONSTRUCTION -CK


namespace SpaceInvadersRemake.Controller
{
    /// <summary>
    /// Diese Klasse stellt die Menüsteuerung dar.
    /// </summary>
    /// <remarks>
    /// Für die Menüsteurung sind folgende Interaktionsmöglichkeiten vorgesehen:
    /// "Cursor" nach oben/unten
    /// Menüpunkt Bestätigen
    /// Zurück 
    /// Falls ein Menüpunkt Einstellungsmöglichkeiten bietet, werden diese mit rechts/links ausgewählt.
    /// </remarks>
    class MenuController : IComander
    {

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
