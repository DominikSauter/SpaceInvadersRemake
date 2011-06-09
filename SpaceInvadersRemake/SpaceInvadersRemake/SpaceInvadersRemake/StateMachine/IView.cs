using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvadersRemake.StateMachine
{
    /// <summary>
    /// Muss von dem Haupteinstiegspunkt der View implementiert werden.
    /// </summary>
    public interface IView
    {
        /// <summary>
        /// Erlaubt die Ausführung der in der View enthalten Spielmechanik.
        /// </summary>
        /// <param name="game">Referenz des Games aus dem XNA Framework.</param>
        /// <param name="gameTime">Bietet die aktuelle Spielzeit an.</param>
        /// <param name="state">Gibt den aktuellen State an von dem diese Funktion aufgerufen wurde.</param>
        void Update(Microsoft.Xna.Framework.Game game, Microsoft.Xna.Framework.GameTime gameTime, State state);

        /// <summary>
        /// Erledigt die Arbeit, die anfällt, wenn der State entgültig zerstört wird, im Bereich der View.
        /// </summary>
        /// <remarks>
        /// Um den Aufruf muss sich nicht gekümmert werden.
        /// </remarks>
        void Exit();
    }
}
