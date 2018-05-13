
// Implementiert von Tobias

namespace SpaceInvadersRemake.ModelSection
{
    /// <summary>
    /// Diese Klasse bildet eine abstrakte Oberklasse für <c>ListSelect</c>. 
    /// Sie ist nur dazu da um eine Typprüfung auf <c>ListSelect</c> zu ermöglichen,
    /// und den Programmieraufwand bei Benutzung von <c>ListSelect</c> zu verringern.
    /// </summary>
    public abstract class ListSelect : MenuControl
    {
        /// <summary>
        /// Gibt die Beschreibung des ausgewählten Items zurück
        /// </summary>
        public abstract string SelectedItemText
        {
            get;
        }
    }
}
