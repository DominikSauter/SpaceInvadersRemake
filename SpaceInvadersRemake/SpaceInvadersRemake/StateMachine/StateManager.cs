using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace SpaceInvadersRemake.StateMachine
{
    // by STST
    /// <summary>
    /// Speichert den aktuellen State und gibt die Aufrufe von der Game-Klasse weiter.
    /// </summary>
    /// <remarks>
    /// Diese Klasse existiert, weil eine Trennung zum XNA-Framework gewünscht war.
    /// </remarks>
    public class StateManager
    {
        private GameManager game;

        /// <summary>
        /// Erstellt einen StateManager.
        /// </summary>
        /// <param name="gameManager">Weiterreichung der Game-Klasse</param>
        public StateManager(GameManager gameManager)
        {
            this.game = gameManager;
            MakeFirstState();
        }

        private void MakeFirstState()
        {
            //[Dodo] Auskommentiert, da wir den State nichtmehr als ersten State brauchen, ausser evtl zum Testen.
            //this.State = new MainMenuState(this, game);

            // Wahl:
            this.State = new IntroState(this, game);
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
        /// Liefert old state.
        /// </summary>
        /// <remarks>
        /// Wird hier benötigt um jedem State die selbe sicht auf den alten KeyboardState zu geben.
        /// Dadurch wird unbeabsichtiges Auslösen von Back verhindert
        /// </remarks>
        public static KeyboardState oldState { get; private set; }
        
        /// <summary>
        /// Liefert new state.
        /// </summary>
        /// <remarks>
        /// Wird hier benötigt um jedem State die selbe sicht auf den neuen KeyboardState zu geben.
        /// Dadurch wird unbeabsichtiges Auslösen von Back verhindert
        /// </remarks>
        public static KeyboardState newState { get; private set; }



        /// <summary>
        /// Ruft die ModelUpdate-Methode vom aktuellen State auf.
        /// </summary>
        public void ModelUpdate(GameTime gameTime)
        {
            this.State.ModelUpdate(gameTime);
        }

        /// <summary>
        /// Ruft die ViewUpdate-Methode vom aktuellen State auf.
        /// </summary>
        public void ViewUpdate(GameTime gameTime)
        {
            this.State.ViewUpdate(gameTime);
            GameManager.MusicPlayer.Update(this.State);     //[Dodo] updated den MusicPlayer
        }

        /// <summary>
        /// Ruft die ControllerUpdate-Methode vom aktuellen State auf.
        /// </summary>
        public void ControllerUpdate(GameTime gameTime)
        {
            //CK
            oldState = StateManager.newState;//
            newState = Keyboard.GetState();//modiefied by ck
            //CK
            
            this.State.ControllerUpdate(gameTime);
        }
    }
}
