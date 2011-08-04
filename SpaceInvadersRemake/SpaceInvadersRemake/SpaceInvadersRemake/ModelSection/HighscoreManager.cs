using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Linq;
using System.Diagnostics;

// Implementiert von Tobias

namespace SpaceInvadersRemake.ModelSection
{
    /// <summary>
    /// Diese Klasse stellt das Highscore-Menü dar. Darin werden Highscore-Einträge verwaltet, 
    /// von denen einer, wenn gewollt, von einem Controller bearbeitet werden kann.
    /// </summary>
    public class HighscoreManager : SpaceInvadersRemake.StateMachine.IModel
    {
        // ADDED (by STST): 06.07.2011
        /// <summary>
        /// Max.-Anzahl der Einträge in der Highscore
        /// </summary>
        private const int MAX_ENTRIES = 10;

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
            highscore = loadHighscore();
            NewEntry = null;

            // STST
            NewEntry = NewEntryInHighscore(score, NewEntry);
        }

        /// <summary>
        /// Erstellt ein normales Highscore-Menü
        /// </summary>
        public HighscoreManager()
        {
            highscore = loadHighscore();
            NewEntry = null;
        }

        // ADDED (by STST): 06.07.2011
        private HighscoreEntry NewEntryInHighscore(int score, HighscoreEntry newEntry)
        {
            Debug.Assert(score >= 0, "Übergebener Wert kleiner 0!");

            // Annahmen:
            // - Liste wird in diesem Abschnitt mit Insertion-Sort sortiert.
            // - größte Punktzahl ist erster Eintrag
            

            if (newEntry != null)
                throw new Exception("newEntry ist nicht null.");


            // Sonderbehandlung, falls die Liste leer ist:
            if (this.highscore.Count == 0)
            {
                newEntry = GetNewEntry(score);
                this.highscore.Add(newEntry);
            }
            else
            {
                bool bNewEntry;

                if (this.highscore.Count == MAX_ENTRIES)
                {
                    int min = this.highscore[this.highscore.Count - 1].Score;
                    if (score > min)
                    {
                        this.highscore.RemoveAt(MAX_ENTRIES - 1);
                        bNewEntry = true;
                    }
                    else
                        bNewEntry = false;
                }
                else
                {
                    bNewEntry = true;
                }


                if (bNewEntry)
                {
                    newEntry = GetNewEntry(score);
                    List<HighscoreEntry> newHighscore = new List<HighscoreEntry>(this.highscore.Capacity);

                    HighscoreEntry addAfterThis = this.highscore.Where(x => x.Score >= score).LastOrDefault();
                    if (addAfterThis == null)
                    {
                        newHighscore.Add(newEntry);
                        newHighscore.AddRange(this.highscore);
                    }
                    else
                        foreach (var item in this.highscore)
                        {
                            newHighscore.Add(item);
                            if (item == addAfterThis)
                                newHighscore.Add(newEntry);
                        }

                    this.highscore = newHighscore;
                }
            }

            return newEntry;
        }

        // ADDED (by STST): 06.07.2011
        private HighscoreEntry GetNewEntry(int score)
        {
            return new HighscoreEntry("", score);
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
            // Verhindert das Abspeichern, falls kein Eintrag editiert werden kann oder kein Name eingegeben wurde
            if ((NewEntry == null) || (NewEntry.Name.Equals("")))
                // Misserfolg!!!!
                return false;

            // <STST>
            using (FileStream fs = new FileStream(hscFilePath, FileMode.Create))
            {
                XmlSerializer ser = new XmlSerializer(typeof(List<HighscoreEntry>));
                ser.Serialize(fs, highscore);
            }
            // </STST>

            // Verhindert, dass der Eintrag weiter bearbeitet werden kann
            NewEntry = null;

            // Erfolg!!!!
            return true;
        }

        /// <summary>
        /// Erlaubt die Ausführung der im Model enthalten Spielmechanik.
        /// </summary>
        /// <param name="game">Referenz des Games aus dem XNA Framework.</param>
        /// <param name="gameTime">Bietet die aktuelle Spielzeit an.</param>
        /// <param name="state">Gibt den aktuellen State an von dem diese Funktion aufgerufen wurde.</param>

        public void Update(Microsoft.Xna.Framework.Game game, Microsoft.Xna.Framework.GameTime gameTime, StateMachine.State state)
        {
            // nicht benötigt
        }

        /// <summary>
        /// Führt notwendige Aufräumarbeiten aus.
        /// </summary>
        public void Dispose()
        {
            highscore.Clear();
        }

        /// <summary>
        /// Hält den Pfad der Highscore-Datei
        /// </summary>
        private const string hscFilePath = "highscore.hsc";

        /// <summary>
        /// Lädt die Highscore-Daten aus der Highscore-Datei
        /// </summary>
        /// <returns>geladene Highscore-Liste</returns>
        private List<HighscoreEntry> loadHighscore()
        {
            // <STST>
            List<HighscoreEntry> hsc;

            if (File.Exists(hscFilePath))
                using (FileStream fs = new FileStream(hscFilePath, FileMode.Open))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(List<HighscoreEntry>));
                    try
                    {
                        hsc = (List<HighscoreEntry>)ser.Deserialize(fs);
                    }
                    catch (InvalidOperationException)
                    {
                        hsc = new List<HighscoreEntry>();
                    }
                }
            else
                hsc = new List<HighscoreEntry>();

            return hsc;
            // </STST>

        }
    }
}
