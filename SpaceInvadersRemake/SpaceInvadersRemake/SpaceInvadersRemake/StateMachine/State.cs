using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace SpaceInvadersRemake.StateMachine
{
    // by STST
    /// <summary>
    /// Stellt einen Programmzustand dar und tauscht dabei das MVC aus. Des Weiteren werden die Bereiche Model, 
    /// View und Controllers zusammengehalten.
    /// </summary>
    /// <remarks>
    /// <para>Hinweis zu diesem Abschnitt: In diesem Abschnitt ist mit dem Wort Bereich ein Teil der drei Bereiche
    /// im MVC gemeint.</para>
    /// <para>Alle Programmzustände müssen von dieser Klasse ableiten. Diese Unterklasse implementieren dann ihr 
    /// eigenes MVC-Muster.</para>
    /// <para>Zur Implementierung des MVC müssen die ModelInitialize, ViewInitialize und ControllerInitialize 
    /// Methoden überschrieben werden, in der die Initialisierungsarbeiten der einzelnen Bereichen stehen. Dabei 
    /// müssen die Model-, View- und Controllers-Eigenschaft gesetzt werden.</para>
    /// <para>Des Weiteren stehen die ModelUpdate, die ViewUpdate und die ControllerUpdate-Methode zur Verfügung, 
    /// um einen von der Game-Klasse weitergereichten Aufruf in die einzelnen Bereiche zu senden.</para>
    /// <para>Für Zustandswechsel werden eigene Methoden in der Unterklasse geschrieben. Die dann vom MVC 
    /// aufgerufen werden können und die Arbeit für einen Zustandswechsel vornehmen. Dabei gibt es zwei 
    /// verschiedene Arten einen Zustandswechsel vorzunehmen. Entweder wird der alte Zustand gespeichert 
    /// (Memento-Funktion) oder er wird verworfen und das Zustandsobjekt wird gelöscht (Zustandsverwerfung). 
    /// Die Methode entscheidet über die Vorgehensweise. Diese Beiden sind im Beispiel dokumentiert.</para>
    /// <para>Falls der Zustand entgültig gelöscht wurde, werden die ModelExit, die ViewExit und die ControllerExit 
    /// Methoden aufgerufen, um die Arbeit in den einzelnen Bereiche zu erledigen.</para>
    /// </remarks>
    /// <example>
    /// Dieses Beispiel zeigt einen Zustandswechsel mit Memento-Funktion in der Break-Methode und mit 
    /// Zustandsverwerfung in der End-Methode.
    /// <code>
    /// InGameState : State
    /// {
    ///     // ...
    ///     
    ///     public void End()
    ///     {
    ///         HighscoreState newState = new HighscoreState(this.stateManager, this.game);
    ///         this.stateManager.State = newState;
    ///         this.Dispose(); // für Zustandsverwerfung
    ///     }
    ///     
    ///     public void Break()
    ///     {
    ///         // für Zustandsspeicherung
    ///         BreakState newState = new BreakState(this.stateManager, this.game, this);
    ///         this.stateManager.State = newState;
    ///     }
    /// }
    /// </code>
    /// </example>
    public abstract class State : IDisposable
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
        /// <param name="gameManager">Referenz zur XNA-Game-Klasse</param>
        /// <param name="previousState">Vorheriger State oder null, falls keiner vorhanden oder nicht gespeichert werden soll.</param>
        public State(StateManager stateManager, Game gameManager, State previousState)
        {
            this.stateManager = stateManager;
            this.previousState = previousState;
            this.game = gameManager;

            Initialise();
        }

        // ADDED (by STST): 23.06.2011
        /// <summary>
        /// Hier ist die Initialisierungsreihenfolge festgelegt.
        /// </summary>
        protected virtual void Initialise()
        {
            ModelInitialize();
            ControllerInitialize();
            ViewInitialize();
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
        /// Diese Eigenschaft darf nur von der ModelInitialise-Methode geändert werden.
        /// </summary>
        public IModel Model
        {
            get;
            protected set; // DESIGN: muss, weil es sonst vom Konstruktor gesetzt werden müsste und nicht im dafür vorgesehender ModelInit-Methode.
        }

        /// <summary>
        /// Haupteinstiegspunkt des Controllers.
        /// Diese Eigenschaft darf nur von der ControllerInitialise-Methode geändert werden.
        /// </summary>
        public IController Controller
        {
            get;
            protected set; // DESIGN: muss, weil es sonst vom Konstruktor gesetzt werden müsste und nicht im dafür vorgesehender ControllerInit-Methode.
        }

        /// <summary>
        /// Haupteinstiegspunkt der View.
        /// Diese Eigenschaft darf nur von der ViewInitialise-Methode geändert werden.
        /// </summary>
        public IView View
        {
            get;
            protected set; // DESIGN: muss, weil es sonst vom Konstruktor gesetzt werden müsste und nicht im dafür vorgesehender ViewInit-Methode.
        }

        /// <summary>
        /// Spricht den Controllers im vorgegebenen Takt an.
        /// </summary>
        /// <remarks>
        /// Um den Aufruf muss sich nicht gekümmert werden.
        /// </remarks>
        /// <param name="gameTime">Weiterreichung von der Game-Klasse</param>
        public virtual void ControllerUpdate(GameTime gameTime)
        {
            // if (this.Controller != null)
            this.Controller.Update(this.game, gameTime, this);
        }

        /// <summary>
        /// Spricht das Model im vorgegebenen Takt an.
        /// </summary>
        /// <param name="gameTime">Weiterreichung von der Game-Klasse</param>
        /// <remarks>
        /// Um den Aufruf muss sich nicht gekümmert werden.
        /// </remarks>
        public virtual void ModelUpdate(GameTime gameTime) 
        {
            // if (this.Model != null)
            this.Model.Update(this.game, gameTime, this);
        }

        /// <summary>
        /// Spricht die View im vorgegebenen Takt an.
        /// </summary>
        /// <remarks>
        /// Um den Aufruf muss sich nicht gekümmert werden.
        /// </remarks>
        /// <param name="gameTime">Weiterreichung von der Game-Klasse</param>
        public virtual void ViewUpdate(GameTime gameTime)
        {
            // if (this.View != null)
            this.View.Update(this.game, gameTime, this);
        }

        /// <summary>
        /// Initialisierungsmethode für den Controllers.
        /// </summary>
        /// <remarks>
        /// Um den Aufruf muss sich nicht gekümmert werden.
        /// </remarks>
        protected abstract void ControllerInitialize();

        /// <summary>
        /// Initialisierungsmethode für das Model.
        /// </summary>
        /// <remarks>
        /// Um den Aufruf muss sich nicht gekümmert werden.
        /// </remarks>
        protected abstract void ModelInitialize();

        /// <summary>
        /// Initialisierungsmethode für die View.
        /// </summary>
        /// <remarks>
        /// Um den Aufruf muss sich nicht gekümmert werden.
        /// </remarks>
        protected abstract void ViewInitialize();
        
        /// <summary>
        /// Führt anwendungsspezifische Aufgaben durch, die mit der Freigabe, der Zurückgabe oder dem Zurücksetzen von nicht verwalteten Ressourcen zusammenhängen.
        /// </summary>
        public void Dispose()
        {
            if (previousState != null)
                previousState.Dispose();

            this.Model.Dispose();
            this.View.Dispose();
            this.Controller.Dispose();
        }

        /// <summary>
        /// Geht in den vorherigen Zustand zurück und löscht diesen Zustand.
        /// </summary>
        /// <exception cref="System.NullReferenceException">Wird geworfen, wenn kein vorhiger Zustand definiert wurde.</exception>
        public void Back()
        {
            if (this.previousState == null)
                throw new NullReferenceException("Back hier nicht verwendet werden, da keiner definiert wurde.");
            this.stateManager.State = this.previousState;
            Dispose();
        }
    }
}
