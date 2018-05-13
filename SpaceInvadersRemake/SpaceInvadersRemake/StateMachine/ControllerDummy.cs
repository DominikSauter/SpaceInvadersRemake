using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvadersRemake.StateMachine
{
    // by STST
    // ADDED (by STST): 24.06.2011

    /// <summary>
    /// Implementiert die IController-Schnittstelle. Wird verwendet, falls es keinen IController-Objekt geben soll.
    /// </summary>
    public class ControllerDummy : IController
    {
        /// <summary>
        /// Erlaubt die Ausführung der im Controllers enthalten Spielmechanik.
        /// </summary>
        /// <param name="game">Referenz des Games aus dem XNA Framework.</param>
        /// <param name="gameTime">Bietet die aktuelle Spielzeit an.</param>
        /// <param name="state">Gibt den aktuellen State an von dem diese Funktion aufgerufen wurde.</param>
        public void Update(Microsoft.Xna.Framework.Game game, Microsoft.Xna.Framework.GameTime gameTime, State state)
        { }

        /// <summary>
        /// Führt anwendungsspezifische Aufgaben durch, die mit der Freigabe, der Zurückgabe oder dem Zurücksetzen von nicht verwalteten Ressourcen zusammenhängen.
        /// </summary>
        public void Dispose()
        { }
    }
}
