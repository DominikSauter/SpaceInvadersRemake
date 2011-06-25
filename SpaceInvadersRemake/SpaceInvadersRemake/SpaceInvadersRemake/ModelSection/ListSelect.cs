using System;
using System.Collections.Generic;

// Implementiert von Tobias

namespace SpaceInvadersRemake.ModelSection
{
    /// <summary>
    /// Diese Klasse stellt einen Menüeintrag dar, bei dem aus einer Liste von Elementen ein bestimmtes 
    /// Element ausgewählt werden kann. Dabei wird immer nur das ausgewählte Element aus der Liste nach 
    /// außen weitergegeben. Diese Klasse ist generisch und kann für fast alle Typen verwendet werden.
    /// </summary>
    /// <remarks>
    /// Der Typ, der in der Liste genutzt wird, muss die <c>ToString</c>-Methode vernünftig überschreiben,
    /// da diese zum Anzeigen des Wert benutzt wird.
    /// </remarks>
    public class ListSelect<T> : ListSelect
    {
        /// <summary>
        /// Speichert die mit dem Menüelement verbundene Funktion.
        /// </summary>
        private Action<T> action;

        /// <summary>
        /// Speichert die Liste die verwaltet werden soll.
        /// </summary>
        private List<T> list;

        /// <summary>
        /// Speichert den aktuell im Programm aktiven Wert.
        /// </summary>
        private T activeItem;

        /// <summary>
        /// Erstellt ein ListSelect-Objekt
        /// </summary>
        /// <param name="list">Eine Liste von Elementen die verwaltet werden sollen</param>
        /// <param name="active">Der derzeit im Programm aktive Wert</param>
        /// <param name="action">Eine Funktion, die einen Parameter vom Typ in der Liste entgegennimmt, und diesen Parameter anwendet. Dadurch können über dieses Menüelement Daten an einer anderen Stelle des Programms geändert werden.</param>
        public ListSelect(List<T> list, T active, Action<T> action)
        {
            this.list = list;
            this.activeItem = active;
            this.action += action;

            SelectedItem = activeItem;
        }

        /// <summary>
        /// Gibt den ausgewählten Wert zurück.
        /// </summary>
        public T SelectedItem { get; private set; }

        /// <summary>
        /// Gibt die Beschreibung des gewählten Elements zurück. Benutzt <c>ToString</c>
        /// </summary>
        public override string SelectedItemText
        {
            get
            {
                return SelectedItem.ToString();
            }
        }

        /// <summary>
        /// Zeigt an ob das Element aktiv ist.
        /// </summary>
        /// <remarks>
        /// Wenn diese Eigenschaft auf <c>false</c> gesetzt wird, dann muss der Wert von 
        /// <c>SelectedItem</c> auf den von <c>activeItem</c> gesetzt werden.
        /// </remarks>
        public override bool Active
        {
            get
            {
                return Active;
            }
            set
            {
                this.Active = value;
                if (value == false)
                {
                    SelectedItem = activeItem;
                }
            }
        }

        /// <summary>
        /// Führt die mit dem Element verbundene Funktion aus. Dabei wird <c>activeItem</c> als Parameter übergeben.
        /// </summary>
        /// <remarks>
        /// Beim Ausführen muss der Wert von <c>activeItem</c> auf den von <c>SelectedItem</c> gesetzt werden. 
        /// Außerdem sollte das Delegate nur dann aufgerufen werden, wenn sich die beiden Werte unterscheiden.
        /// </remarks>
        public override void Action()
        {
            if ((object)activeItem != (object)SelectedItem)
            {
                activeItem = SelectedItem;
                action(activeItem);
            }
        }

        /// <summary>
        /// Wählt das vorige Element in der Liste aus
        /// </summary>
        public override void Prev()
        {
            int i = list.IndexOf(SelectedItem);
            SelectedItem = list[(i - 1) % list.Count];
        }

        /// <summary>
        /// Wählt das nächste Element in der Liste aus
        /// </summary>
        public override void Next()
        {
            int i = list.IndexOf(SelectedItem);
            SelectedItem = list[(i + 1) % list.Count];
        }
    }
}
