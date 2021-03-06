﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvadersRemake.StateMachine
{
    // by STST
    /// <summary>
    /// Muss von dem Haupteinstiegspunkt der View implementiert werden.
    /// </summary>
    public interface IView : IDisposable
    {
        /// <summary>
        /// Erlaubt die Ausführung der in der View enthalten Spielmechanik.
        /// </summary>
        /// <param name="game">Referenz des Games aus dem XNA Framework.</param>
        /// <param name="gameTime">Bietet die aktuelle Spielzeit an.</param>
        /// <param name="state">Gibt den aktuellen State an von dem diese Funktion aufgerufen wurde.</param>
        void Update(GameManager game, Microsoft.Xna.Framework.GameTime gameTime, State state);
    }
}
