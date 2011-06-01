using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace SpaceInvadersRemake.StateMachine
{
    /// <summary>
    /// Speichert den aktuelle State und gibt den Aufruf von der Game-Klasse weiter.
    /// </summary>
    /// <remarks>
    /// Diese Klasse existiert, weil eine Trennung zum XNA-Framework gewünscht war.
    /// </remarks>
    public class StateManager
    {
        /// <summary>
        /// Erstellt einen StateManager.
        /// </summary>
        /// <param name="gameManager">Weiterreichung der Game-Klasse</param>
        public StateManager(Game gameManager)
        {
        }

        /// <summary>
        /// Hält den aktuellen State.
        /// </summary>
        public State State
        {
            get;
            set;
        }

        /// <summary>
        /// Ruft die ModelUpdate-Methode vom aktuellen State auf.
        /// </summary>
        public void ModelUpdate(GameTime gameTime)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Ruft die ViewUpdate-Methode vom aktuellen State auf.
        /// </summary>
        public void ViewUpdate(GameTime gameTime)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Ruft die ControllerUpdate-Methode vom aktuellen State auf.
        /// </summary>
        public void ControllerUpdate(GameTime gameTime)
        {
            throw new System.NotImplementedException();
        }
    }
}
