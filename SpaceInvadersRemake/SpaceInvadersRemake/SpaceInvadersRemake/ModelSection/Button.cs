using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvadersRemake.ModelSection
{
    /// <summary>
    /// Diese Klasse stellt einen Button im Menü dar
    /// </summary>
    public class Button : MenuControl
    {
        /// <summary>
        /// Speichert die mit dem Button verbundene Funktion
        /// </summary>
        private Action action;
        /// <summary>
        /// Erstellt einen Button
        /// </summary>
        /// <param name="text">Beschriftung</param>
        /// <param name="action">Die Funktion die beim aktivieren des Buttons ausgeführt werden soll.</param>
        public Button(string text, Action action)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Führt die mit dem Element verbundene Funktion aus.
        /// </summary>
        public override void Action()
        {
            throw new NotImplementedException();
        }
    }
}
