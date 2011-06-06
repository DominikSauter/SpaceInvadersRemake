using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using SpaceInvadersRemake.StateMachine;

namespace SpaceInvadersRemake.ModelSection
{
    /// <summary>
    /// Regelt den Spielablauf und sorgt dafür, dass der Zustand gewechselt wird, wenn das Spiel vorbei ist, d.h. der Spieler keine Leben mehr hat.
    /// </summary>
    public class GameCourseManager
    {
        /// <summary>
        /// Die Aliens der aktuellen Welle.
        /// </summary>
        private List<IGameItem> currentWave;
        /// <summary>
        /// Das Spielerschiff-Objekt.
        /// </summary>
        private IGameItem player;

        /// <summary>
        /// Konstruktor; erzeugt ein neues GameCourse-Objekt und ruft die Initialize()-Methode auf.
        /// </summary>
        public GameCourseManager()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Referenz auf das im Konstruktor erzeugte GameCourse-Objekt.
        /// </summary>
        public GameCourse GameCourse
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
        /// Wird vom Konstruktor aufgerufen, um das Spiel zu initialisieren.
        /// </summary>
        /// <remarks>Konkret werden das Spielerschiff, sowie die statischen Schilde erzeugt.</remarks>
        private void InitializeGame()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Dient zur Überprüfung der restlichen Leben des Spielers und ggf. zum Aufruf des Zustandwechsels im mitgelieferten State, sowie der Überprüfung der aktuellen Welle und ggf. der Erzeugung einer neuen.
        /// </summary>
        /// <remarks>Durch den Aufruf der Exit()-Methode auf dem State-Objekt wird das Ende des Spiels signalisiert. Eine neue Welle wird erzeugt, wenn kein Wellen-Alien der aktuellen Welle mehr am Leben ist.</remarks>
        public void Update(GameTime gameTime, State state)
        {
            throw new System.NotImplementedException();
        }
    }
}
