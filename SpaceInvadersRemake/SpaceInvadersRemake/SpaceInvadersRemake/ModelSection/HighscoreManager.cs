using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

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
            highscore = loadHighscore();
            NewEntry = null;

            if (highscore.Count < 10) // falls noch nicht 10 Eintäge vorhanden, wird der neue Eintrag einfach eingefügt
            {
                NewEntry = new HighscoreEntry("", score);
                highscore.Add(NewEntry);
                
            }
            else // falls schon alle 10 Einträge vorhanden sind, dann wird überprüft ob die Punktzahl hoch genug ist
            {
                for (int i = 0; i < 10; i++)
                {
                    if (score > highscore[i].Score)
                    {
                        highscore.RemoveAt(i);
                        NewEntry = new HighscoreEntry("", score);
                        highscore.Add(NewEntry);
                        break;
                    }
                }
            }

            // Sortiert die Highscore-Liste mit dem anonymen Delegate
            highscore.Sort(delegate(HighscoreEntry a, HighscoreEntry b) 
                           { 
                               // TODO: Der Vergleich muss evlt. umgedreht werden, je nachdem wierum die Liste sortiert wird
                               if (a.Score < b.Score) 
                                   return -1; 
                               else if (a.Score == b.Score) 
                                   return 0; 
                               else return 1; 
                           });
        }

        /// <summary>
        /// Erstellt ein normales Highscore-Menü
        /// </summary>
        public HighscoreManager()
        {
            highscore = loadHighscore();
            NewEntry = null;
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
            // Verhindert das Abspeichern, falls kein Eintrag editiert werden kann oder kein Name eingegeben wurde
            if ((NewEntry == null) || (NewEntry.Name.Equals("")))
                // Misserfolg!!!!
                return false;

            // Ertellt bei jedem Abspeichern eine neue Highscore-Datei
            FileStream outputFile = new FileStream(hscFilePath, FileMode.Create, FileAccess.Write);
            StreamWriter swOutput = new StreamWriter(outputFile);

            // Speichert die Highscore-Liste ab
            for (int i = 0; i < highscore.Count; i++)
            {
                swOutput.WriteLine(highscore[i].Name + " " + highscore[i].Score.ToString());
            }

            // Schließt die Datei
            swOutput.Close();
            outputFile.Close();

            // Verhindert, dass der Eintrag weiter bearbeitet werden kann
            NewEntry = null;

            // Erfolg!!!!
            return true;
        }

        public void Update(Microsoft.Xna.Framework.Game game, Microsoft.Xna.Framework.GameTime gameTime, StateMachine.State state)
        {
            // nicht benötigt
        }

        public void Dispose()
        {
            highscore.Clear();
        }

        // Hält den Pfad der Highscore-Datei
        private const string hscFilePath = "highscore.hsc";

        // Lädt die Highscore-Daten aus der Highscore-Datei
        private List<HighscoreEntry> loadHighscore()
        {
            // neue Highscore-Liste zur Rückgabe
            List<HighscoreEntry> hscList = new List<HighscoreEntry>();

            // temporäre Variablen
            int count = 0;
            int score = 0;
            string line = null;
            string name = null;
            string[] entryData = null;

            // Öffne die Highscore-Datei und erstelle ein StreamReader-Objekt zum zeilenwiesen Auslesen
            FileStream inputFile = new FileStream(hscFilePath, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader srInput = new StreamReader(inputFile);

            // Lese nacheinander jede Zeile der Datei ein un wandle sie in einen Highscore-Eintrag um.
            // Dabei wird sichergestellt, dass maximal 10 Einträge eingelesen werden.
            while (((line = srInput.ReadLine()) != null) && (count < 10))
            {
                entryData = line.Split(' ');
               
                name = entryData[0];
                score = Convert.ToInt32(entryData[1]);

                hscList.Add(new HighscoreEntry(name, score));

                count++;
            }

            // Schließe die Datei
            srInput.Close();
            inputFile.Close();

            // Gebe die Liste zurück
            return hscList;
        }
    }
}
