using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvadersRemake.ModelSection
{
    /// <summary>
    /// Diese Klasse stellt einen Menüeintrag dar, bei dem aus einer Liste von Elementen ein bestimmtes Element ausgewählt werden kann. Dabei wird immer nur das ausgewählte Element aus der Liste nach außen weitergegeben. Diese Klasse ist generisch und kann für fast alle Typen verwendet werden.
    /// </summary>
    /// <remarks>Der Typ, der in der Liste genutzt wird, sollte die "ToString"-Methode vernünftig überschreiben, da diese zum Anzeigen benutzt wird.</remarks>
    public class ListSelect<T> : MenuControl
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
        /// <param name="action">Eine Funktion, die einen Parameter vom Typ in der Liste entgegennimmt, und diesen Parameter anwendet. Dadurch können über dieses Menüelement Daten an einer anderen Stelle des Programms geändert werden.</param>
        public ListSelect(List<T> list, Action<T> action)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Zeigt den ausgewählten Wert an.
        /// </summary>
        public T SelectedItem
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
        /// Zeigt an ob das Element aktiv ist.
        /// </summary>
        /// <remarks>Wenn diese Eigenschaft auf "false" gesetzt wird, dann muss "SelectedItem" auf "activeItem" gesetzt werden.</remarks>
        public override bool Active
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
        /// Führt die mit dem Element verbundene Funktion aus. Dabei wird "activeItem" als Parameter übergeben.
        /// </summary>
        /// <remarks>Beim Ausführen muss "activeItem" auf "SelectedItem" gesetzt werden. Außerdem sollte Delegate nur dann aufgerufen werden, wenn sich die beiden Werte unterscheiden.</remarks>
        public override void Action()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Wählt den vorigen Eintrag des Controls aus, wenn dies möglich ist.
        /// </summary>
        public override void Prev()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Wählt den nächten Eintrag des Controls aus, wenn dies möglich ist.
        /// </summary>
        public override void Next()
        {
            throw new NotImplementedException();
        }
    }
}
