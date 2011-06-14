using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvadersRemake.ModelSection
{
    /// <summary>
    /// Diese Klasse stellt das Highscore-Menü dar. Darin werden Highscore-Einträge verwaltet, 
    /// von denen einer, wenn gewollt, von einem Controller bearbeitet werden kann.
    /// </summary>
    public class HighscoreManager : SpaceInvadersRemake.StateMachine.IModel
    {
        /// <summary>
        /// Die Liste der Highscore-Einträge
        /// </summary>
        private List<HighscoreEntry> highscore;

        /// <summary>
        /// Erstellt ein Highscore-Menü bei dem ein neuer Eintrag hinzugefügt werden soll. Ist die übergebene
        /// Punktzahl hoch genug, so kann der dadurch entstandene Eintrag durch einen Controller bearbeitet werden.
        /// Ansonsten wird die Punktzahl ignoriert und ein normales Highscore-Menü erstellt.
        /// </summary>
        /// <param name="score">Die Punktzahl die in die Highscore-Liste eingetragen werden soll</param>
        public HighscoreManager(int score)
        {
            throw new System.NotImplementedException();
            // TODO: Datenanbindung an Highscore-Datei
        }

        /// <summary>
        /// Erstellt ein normales Highscore-Menü
        /// </summary>
        public HighscoreManager()
        {
            throw new System.NotImplementedException();
            // TODO: Datenanbindung an Highscore-Datei
        }
        
        /// <summary>
        /// Gibt die Highscore-Liste als Array zurück.
        /// </summary>
        public HighscoreEntry[] HighscoreEntries
        {
            get
            {
                return highscore.ToArray();
            }
            private set
            {
            }
        }

        /// <summary>
        /// Gibt, falls vorhanden, den Eintrag zurück, der bearbeitet werden kann.
        /// </summary>
        public HighscoreEntry NewEntry
        {
            get;
            private set;
        }

        /// <summary>
        /// Bestätigt die Bearbeitung des Eintrags und speichert die dadurch veränderte Liste.
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            throw new System.NotImplementedException();
            // TODO: Datenanbindung an Highscore-Datei
        }

        public void Update(Microsoft.Xna.Framework.Game game, Microsoft.Xna.Framework.GameTime gameTime, StateMachine.State state)
        {
            // nicht benötigt
        }

        public void Dispose()
        {
            highscore.Clear();
        }
    }
}
