using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvadersRemake.ModelSection
{
    /// <summary>
    /// Diese Klasse verwaltet den Spielablauf.
    /// </summary>
    /// <remarks>
    /// Die <c>Update</c>-Untermethode <c>UpdateGameItemList</c> verwaltet die <c>GameItem.GameItemList</c>,
    /// während <c>UpdateGameCourse</c> den Spielablauf managed.
    /// </remarks>
    public class GameCourseManager : SpaceInvadersRemake.StateMachine.IModel
    {
        /// <summary>
        /// Die Aliens der aktuellen Welle.
        /// </summary>
        private List<IGameItem> currentWave = new List<IGameItem>();

        /// <summary>
        /// Konstruktor; erzeugt ein neues GameCourse-Objekt.
        /// </summary>
        public GameCourseManager()
        {
            GameCourse = new GameCourse();
        }

        /// <summary>
        /// Referenz auf das im Konstruktor erzeugte GameCourse-Objekt.
        /// </summary>
        public GameCourse GameCourse
        {
            get
            {
                return GameCourse;
            }
            private set
            {
                GameCourse = value;
            }
        }

        /// <summary>
        /// Ruft die beiden Untermethoden <c>UpdateGameItemList</c> und <c>UpdateGameCourse</c> auf (in dieser Reihenfolge).
        /// </summary>
        /// <param name="game">Weiterreichung der <c>Game</c>-Klasse</param>
        /// <param name="gameTime">Spielzeit</param>
        /// <param name="state">Weiterreichung des Zustands von dem aus die Methode aufgerufen wurde</param>
        public void Update(Microsoft.Xna.Framework.Game game, Microsoft.Xna.Framework.GameTime gameTime, StateMachine.State state)
        {
            UpdateGameItemList(gameTime);
            UpdateGameCourse(gameTime, state);
        }

        /// <summary>
        /// Dient zur Überprüfung der restlichen Leben des Spielers und ggf. zum Aufruf des Zustandwechsels
        /// im mitgelieferten State (bei Lives=0), sowie der Überprüfung der aktuellen Welle und ggf. der 
        /// Erzeugung einer neuen. Des Weiteren wird auf dem GameCourse-Objekt die SpecialEvent-Methode aufgerufen.
        /// </summary>
        /// <remarks>
        /// Durch den Aufruf der <c>Exit</c>-Methode auf dem <c>State</c>-Objekt wird das Ende des Spiels 
        /// signalisiert. Eine neue Welle wird erzeugt, wenn kein Wellen-Alien der aktuellen Welle mehr 
        /// am Leben ist. Die neu erzeugte Welle wird in <c>currentWave</c> gespeichert.
        /// </remarks>
        /// <param name="gameTime">Spielzeit</param>
        /// <param name="state">Weiterreichung des aufrufenden Zustands</param>
        private void UpdateGameCourse(Microsoft.Xna.Framework.GameTime gameTime, SpaceInvadersRemake.StateMachine.State state)
        {
            if (GameCourse.Player.Lives <= 0)
            {
                state.Exit(Player.Score);
            }
            else
            {
                bool waveAlive = false;
                for (int i = 0; i < currentWave.Count && !waveAlive; i++)
                {
                    if (currentWave[i].IsAlive)
                    {
                        waveAlive = true;
                    }
                }

                if (!waveAlive)
                {
                    currentWave = GameCourse.NextWave(gameTime);
                }
            }

            GameCourse.SpecialEvent(gameTime);
        }

        /// <summary>
        /// Prüft durch Aufruf der <c>Collider.CheckAllCollisions</c>-Methode auf Kollisionen. Danach wird über die
        /// <c>GameItem.GameItemList</c> iteriert, zerstörte Spielobjekte (<c>IsAlive</c>=<c>false</c>) aus der Liste entfernt 
        /// und auf den verbleibenden Objekten die <c>Update</c>-Methode aufgerufen.
        /// </summary>
        private void UpdateGameItemList(Microsoft.Xna.Framework.GameTime gameTime)
        {
            Collider.CheckAllCollisions(GameItem.GameItemList);

            foreach (IGameItem item in GameItem.GameItemList) {
                if (!item.IsAlive)
                {
                    GameItem.GameItemList.Remove(item);
                }
                else
                {
                    item.Update(gameTime);
                }
            }
        }


        /// <summary>
        /// Erledigt die Arbeit, die anfällt, wenn der <c>State</c> entgültig zerstört wird, im Bereich des Models.
        /// </summary>
        /// <remarks>Konkret: Leeren der <c>GameItem.GameItemList</c>.</remarks>
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
