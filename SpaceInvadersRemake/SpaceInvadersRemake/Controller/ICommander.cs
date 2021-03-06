﻿using SpaceInvadersRemake.StateMachine;

//Implemntiert von Christian (ck)
namespace SpaceInvadersRemake.Controller
{
    /// <summary>
    /// Muss von allen Klassen implementiert werden, die ein etwas kontrollieren.
    /// </summary>
    public interface ICommander
    {
        /// <summary>
        /// Erlaubt die Ausführung der Steuerung.
        /// </summary>
        /// <remarks>
        /// Wird vom ControllerManager aufgerufen immer dann wenn eine Interaktion des Controllers
        /// benötigt wird. In der Regel innerhalb des Gameloops.
        /// </remarks>
        /// <param name="game">Referenz des Games aus dem XNA Framework.</param>
        /// <param name="gameTime">Bietet die aktuelle Spielzeit an.</param>
        /// <param name="state">Gibt den aktuellen State an von dem diese Funktion aufgerufen wurde.</param>
        void Update(Microsoft.Xna.Framework.Game game, Microsoft.Xna.Framework.GameTime gameTime, State state);
    }
}
