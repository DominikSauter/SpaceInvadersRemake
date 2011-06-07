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
    /// Zurück ist durch die Esc Taste zu realisieren
    /// Falls Menüpunkt Einstellungsmöglichkeiten bietet, Auswahl dieser durch links/rechts
    /// </remarks>
    class MenuController : IController
    {

        public void Update(Game game, GameTime gameTime, State state)
        {
            throw new NotImplementedException();
        }
    }
}
