using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace SpaceInvadersRemake.ModelSection
{
    /// <summary>
    /// Ist für den Spielablauf zuständig und bestimmt u.a. die Abfolge der Wellen und besonderer Ereignisse
    /// während einer Welle, etwa das Auftauchen eines Mutterschiffs.
    /// </summary>
    /// <remarks>Zählt außerdem die Wellen mit.</remarks>
    public class GameCourse
    {
        /// <summary>
        /// Enthält die GameTime zum Zeitpunkt der Erstellung der letzten Welle.
        /// </summary>
        private GameTime waveStartingTime;

        /// <summary>
        /// Objekt um Zufallselemente einzubauen, z.B. zufällige Formationen oder das zufällige Auftauchen eines Mutterschiffs.
        /// </summary>
        private Random random;

        /// <summary>
        /// Konstruktor
        /// </summary>
        public GameCourse()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Zählt die Wellen mit.
        /// </summary>
        public int WaveCounter
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
        /// Referenz auf das Spielerschiff-Objekt.
        /// </summary>
        public SpaceInvadersRemake.ModelSection.IGameItem Player
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
        /// Erzeugt eine neue Welle, d.h. eine Liste von Aliens, die durch einen Controller gesteuert werden.
        /// Die Abfolge der Wellen ist hier anhand des WaveCounters festgelegt. Die Methode setzt außerdem 
        /// bei jedem Aufruf die <c>waveStartingTime</c> auf die aktuelle <c>gameTime</c>.
        /// </summary>
        /// <param name="gameTime">Spielzeit</param>
        public LinkedList<IGameItem> NextWave(GameTime gameTime)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Dient zur Erstellung besonderer Ereignisse während einer Welle, z.B. das Auftauchen eines Mutterschiffs.
        /// </summary>
        /// <remarks>
        /// Hierfür wird die <c>waveStartingTime</c> benötigt, um Ereignisse zu bestimmten Wellen timen zu können.
        /// </remarks>
        /// <param name="gameTime">Spielzeit</param>
        public void SpecialEvent(GameTime gameTime)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Wird vom Konstruktor aufgerufen, um das Spiel zu initialisieren.
        /// </summary>
        /// <remarks>Konkret werden das Spielerschiff, sowie die statischen Schilde erzeugt.</remarks>
        private void InitializeGame()
        {
            throw new System.NotImplementedException();
        }
    }
}
