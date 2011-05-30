using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace SpaceInvadersRemake.StateMachine
{
    /// <summary>
    /// Stellt einen Programmzustand dar.
    /// </summary>
    /// <remarks>
    /// Alle Programmzustände müssen von dieser Klasse ableiten.
    /// Diese Unterklasse implementieren dann ihr eigenes MVC-Muster.
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
        /// <remarks>Falls ein Memento Implementiert werden soll, wird zur Verwendung <code>this.stateManager = this.previousState</code> genutzt oder es wird null für keinen vorherigen State verwendet.</remarks>
        protected readonly State previousState = null;
        /// <summary>
        /// Durchreichung der Game-Klasse
        /// </summary>
        protected readonly Game game;

        /// <summary>
        /// Erstellt einen neuen Zustand mit der Berücksichtigung des vorherigen States.
        /// </summary>
        /// <param name="stateManager">Referenz zum StateManager</param>
        /// <param name="previousState">Vorheriger State oder null, falls keiner vorhanden oder nicht gespeichert werden soll.</param>
        /// <param name="gameManager">Referenz zur XNA-Game-Klasse</param>
        public State(StateManager stateManager, State previousState, Game gameManager)
        {
            this.stateManager = stateManager;
            this.previousState = previousState;
            this.game = gameManager;
        }

        /// <summary>
        /// Erstellt einen neuen Zustand ohne vorherigen State.
        /// </summary>
        /// <param name="stateManager">Referenz zum StateManager</param>
        /// <param name="gameManager">Referenz zur XNA-Game-Klasse</param>
        public State(StateManager stateManager, Game gameManager)
        {
            this.stateManager = stateManager;
            this.previousState = null;
            this.game = gameManager;
        }

        /// <summary>
        /// Spricht den Controller im vorgegebenen Takt an.
        /// </summary>
        /// <param name="gameTime">Weiterreichung von der Game-Klasse</param>
        public void Controller(GameTime gameTime)
        {
            throw new System.NotImplementedException();
}

        /// <summary>
        /// Spricht das Model im vorgegebenen Takt an.
        /// </summary>
        /// <param name="gameTime">Weiterreichung von der Game-Klasse</param>
        public void Model(GameTime gameTime)
        {
            throw new System.NotImplementedException();
}

        /// <summary>
        /// Spricht das Model im vorgegebenen Takt an.
        /// </summary>
        /// <param name="gameTime">Weiterreichung von der Game-Klasse</param>
        public void View(GameTime gameTime)
        {
            throw new System.NotImplementedException();
}

        /// <summary>
        /// Initialisierungsmethode für den Controller.
        /// </summary>
        protected abstract void ControllerInitialize();

        /// <summary>
        /// Initialisierungsmethode für das Model.
        /// </summary>
        protected abstract void ModelInitialize();

        /// <summary>
        /// Initialisierungsmethode für die View.
        /// </summary>
        protected abstract void ViewInitialize();

    }
}
