using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvadersRemake.ModelSection
{
    /// <summary>
    /// Implementiert das Interface IModel. Leitet dabei die Update()-Methode an ihr GameCourseManager-Objekt weiter und verwaltet die GameItemListe.
    /// </summary>
    class ModelManager : SpaceInvadersRemake.StateMachine.IModel
    {
        /// <summary>
        /// Konstruktor; erzeugt ein neues GameCourseManager-Objekt.
        /// </summary>
        public ModelManager()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Referenz auf das im Konstruktor erzeugte GameCourseManager-Objekt.
        /// </summary>
        public GameCourseManager GameCourseManager
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        /// <summary>
        /// Iteriert über die GameItemListe, updatet diese und entfernt zerstörte Spielobjekte. Des Weiteren wird die Update()-Methode des "GameCourseManager" aufgerufen.
        /// </summary>
        public void Update(Microsoft.Xna.Framework.Game game, Microsoft.Xna.Framework.GameTime gameTime, StateMachine.State state)
        {
            throw new NotImplementedException();
        }
    }
}
