using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvadersRemake
{
    /// <summary>
    /// Stellt einen Programmzustand dar.
    /// </summary>
    /// <remarks>
    /// Alle Programmzustände müssen von dieser Klasse ableiten.
    /// <code>this.stateManager = newState</code> verwenden um einen neuen State zu implementieren.
    /// </remarks>
    public abstract class State
    {
        /// <summary>
        /// Verweis auf den StateManager
        /// </summary>
        protected readonly StateManager stateManager;
        /// <summary>
        /// Zur Speicherung vom vorherigen Zustand.
        /// </summary>
        /// <remarks>Zur Verwendung <code>this.stateManager = this.previousState</code> verwenden.</remarks>
        protected readonly State previousState = null;


        public State(StateManager stateManager)
        {
            this.stateManager = stateManager;
        }

        public State(StateManager stateManager, State previousState)
        {
            this.stateManager = stateManager;
            this.previousState = previousState;
        }

    }
}
