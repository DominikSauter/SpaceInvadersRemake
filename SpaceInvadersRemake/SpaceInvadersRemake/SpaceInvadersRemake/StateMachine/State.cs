using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace SpaceInvadersRemake.StateMachine
{
    // TODO: Memento und Exit-Methoden; gibt es nicht 2 verschiedene Exit-Methoden

    /// <summary>
    /// Stellt einen Programmzustand dar und tauscht dabei das MVC aus. Des Weiteren werden die Bereiche Model, View und Controller zusammengehalten.
    /// </summary>
    /// <remarks>
    /// Hinweis zu diesem Abschnitt: In diesem Abschnitt ist mit dem Wort Bereich ein Teil der drei Bereiche im MVC gemeint.
    /// Alle Programmzustände müssen von dieser Klasse ableiten. Diese Unterklasse implementieren dann ihr
    /// eigenes MVC-Muster.
    /// Zur Implementierung des MVC müssen die ModelInitialize, ViewInitialize und ControllerInitialize Methoden überschrieben werden, in der die Initialisierungsarbeiten der einzelnen Bereichen stehen.
    /// Des Weiteren stehen die ModelUpdate, die ViewUpdate und die ControllerUpdate-Methode zur Verfügung, um einen von der Game-Klasse weitergereichten Aufruf in die einzelnen Bereiche zu senden.
    /// TODO: Implementierungsanweisung für Exit
    /// Für einen Zustandswechsel schreiben sie eine Methode im Erbe dieser Klasse mit folgendem Codeausschnitt:
    /// <c>this.stateManager = newState;</c> Diese neue Methode kann dann vom MVC aufgerufen werden und welchselt dann den Zustand.
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
        /// Haupteinstiegspunkt des Models.
        /// </summary>
        public IModel Model
        {
            get;
            protected set;
        }

        /// <summary>
        /// Haupteinstiegspunkt des Controllers.
        /// </summary>
        public IController Controller
        {
            get;
            protected set;
        }

        /// <summary>
        /// Haupteinstiegspunkt der View.
        /// </summary>
        public IView View
        {
            get;
            protected set;
        }

        /// <summary>
        /// Spricht den Controller im vorgegebenen Takt an.
        /// </summary>
        /// <param name="gameTime">Weiterreichung von der Game-Klasse</param>
        public virtual void ControllerUpdate(GameTime gameTime)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Spricht das Model im vorgegebenen Takt an.
        /// </summary>
        /// <param name="gameTime">Weiterreichung von der Game-Klasse</param>
        public virtual void ModelUpdate(GameTime gameTime)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Spricht die View im vorgegebenen Takt an.
        /// </summary>
        /// <param name="gameTime">Weiterreichung von der Game-Klasse</param>
        public virtual void ViewUpdate(GameTime gameTime)
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

        /// <summary>
        /// TODO: Doku
        /// </summary>
        public virtual void ViewExit()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// TODO: Doku
        /// </summary>
        public virtual void ControllerExit()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// TODO: Doku
        /// </summary>
        public virtual void ModelExit()
        {
            throw new System.NotImplementedException();
        }
    }
}
