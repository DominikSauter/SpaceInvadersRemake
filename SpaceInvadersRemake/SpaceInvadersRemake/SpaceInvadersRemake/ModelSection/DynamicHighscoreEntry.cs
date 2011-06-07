using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvadersRemake.ModelSection
{
    /// <summary>
    /// Diese Klasse stellt einen dynamischen Highscore-Eintrag dar. Dabei kann nur der Name durch einen Controllers verändert werden, die Punktzahl nicht.
    /// </summary>
    public class DynamicHighscoreEntry : HighscoreEntry
    {
        /// <summary>
        /// Erstellt einen dynamischen Highscore-Eintrag
        /// </summary>
        /// <param name="score">Erreichte Punktzahl</param>
        public DynamicHighscoreEntry(int score)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Setzt das übergebene Zeichen ans Ende des Namens
        /// </summary>
        /// <param name="sign">Zeichen, das angefügt werden soll</param>
        public void AddSign(char sign)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Löscht das letzte Zeichen des Namens. Ist kein Zeichen mehr vorhanden, dann passiert nichts.
        /// </summary>
        public void RemoveSign()
        {
            throw new System.NotImplementedException();
        }
    }
}
