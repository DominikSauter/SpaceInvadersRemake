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
    class MenuController : IController
    {

        /// <summary>
        /// Erlaubt die Ausführung der im Controller enthalten Spielmechanik.
        /// </summary>
        /// <param name="game">Referenz des Games aus dem XNA Framework.</param>
        /// <param name="gameTime">Bietet die aktuelle Spielzeit an.</param>
        /// <param name="state">Gibt den aktuellen State an von dem diese Funktion aufgerufen wurde.</param>
        public void Update(Game game, GameTime gameTime, State state)
        {
            throw new NotImplementedException();
        }
    }
}
