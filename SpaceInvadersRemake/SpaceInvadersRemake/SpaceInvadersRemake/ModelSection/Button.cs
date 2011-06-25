using System;

// Implementiert von Tobias

namespace SpaceInvadersRemake.ModelSection
{
    /// <summary>
    /// Diese Klasse stellt einen Button im Menü dar
    /// </summary>
    public class Button : MenuControl
    {
        /// <summary>
        /// Speichert die mit dem Button verbundene Funktion (Delegate)
        /// </summary>
        private Action action;

        /// <summary>
        /// Erstellt einen Button
        /// </summary>
        /// <param name="text">Beschriftung</param>
        /// <param name="action">Die Funktion die beim aktivieren des Buttons ausgeführt werden soll.</param>
        public Button(string text, Action action)
        {
            this.Text = text;
            this.Active = false;
            this.action += action;
        }

        /// <summary>
        /// Löst die mit dem Button verbundene Funktion aus.
        /// </summary>
        public override void Action()
        {
            action();
        }
    }
}
