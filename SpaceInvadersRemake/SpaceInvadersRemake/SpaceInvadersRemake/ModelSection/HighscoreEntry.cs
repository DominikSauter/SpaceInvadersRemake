
// Implementiert von Tobias

namespace SpaceInvadersRemake.ModelSection
{
    /// <summary>
    /// Diese Klasse stellt einen Highscore-Eintrag dar.
    /// </summary>
    public class HighscoreEntry
    {
        // ADDED (by STST): 06.07.2011
        /// <summary>
        /// Erstellt einen neuen Highscore-Eintrag
        /// </summary>
        public HighscoreEntry()
        { }

        /// <summary>
        /// Erstellt einen neuen Highscore-Eintrag
        /// </summary>
        /// <param name="name">Name des Spielers</param>
        /// <param name="score">Erreichte Punktzahl</param>
        public HighscoreEntry(string name, int score)
        {
            this.Name = name;
            this.Score = score;
        }

        /// <summary>
        /// Name des Spielers
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Erreichte Punktzahl
        /// </summary>
        public int Score
        {
            get;
            // MODIFIED (by STST): 06.07.2011
            //private set;
            set;
        }
    }
}
