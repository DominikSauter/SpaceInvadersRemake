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
        public StateManager(Game gameManager)
        {
        }

        public State State
        {
            get;
            set;
        }

        /// <summary>
        /// Ruft die Model-Methode vom aktuellen State auf.
        /// </summary>
        public void Model(GameTime gameTime)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Ruft die View-Methode vom aktuellen State auf.
        /// </summary>
        public void View(GameTime gameTime)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Ruft die Controller-Methode vom aktuellen State auf.
        /// </summary>
        public void Controller(GameTime gameTime)
        {
            throw new System.NotImplementedException();
        }
    }
}
