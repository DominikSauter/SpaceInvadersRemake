using System.Collections.Generic;
using SpaceInvadersRemake.StateMachine;

// Implementiert von D. Sauter

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
        private LinkedList<IGameItem> currentWave = new LinkedList<IGameItem>();

        /// <summary>
        /// Konstruktor; erzeugt eine neue GameItem.GameItemList, sowie ein neues GameCourse-Objekt (in dieser Reihenfolge).
        /// </summary>
        public GameCourseManager()
        {
            GameItem.GameItemList = new LinkedList<IGameItem>();
            GameCourse = new GameCourse();
        }

        /// <summary>
        /// Referenz auf das im Konstruktor erzeugte GameCourse-Objekt.
        /// </summary>
        public GameCourse GameCourse { get; private set; }

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
                ((InGameState)state).Exit(GameCourse.Player.Score);
            }
            else
            {
                bool waveAlive = false;
                for (LinkedListNode<IGameItem> item = currentWave.First; item != null; item = item.Next)
                {
                    if (item.Value.IsAlive)
                    {
                        waveAlive = true;
                        break;
                    }
                    else
                    {
                        item = item.Previous;   // HACK: Evt. schönere Lösung für das item=null-Problem bei gelöschten items suchen
                        currentWave.Remove(item.Next);
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

            for (LinkedListNode<IGameItem> item = GameItem.GameItemList.First; item != null; item = item.Next)
            {
                if (item.Value.IsAlive)
                {
                    item.Value.Update(gameTime);
                }
                else
                {
                    item = item.Previous;   // HACK: Evt. schönere Lösung für das item=null-Problem bei gelöschten items suchen
                    GameItem.GameItemList.Remove(item.Next);
                }
            }
        }

        /// <summary>
        /// Erledigt die Arbeit, die anfällt, wenn der <c>State</c> entgültig zerstört wird, im Bereich des Models.
        /// </summary>
        /// <remarks>Konkret: Leeren der <c>GameItem.GameItemList</c>.</remarks>
        public void Dispose()
        {
            GameItem.GameItemList = null;
        }
    }
}
