using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvadersRemake.View
{
    /// <summary>
    /// Diese Klasse verwaltet alle für den aktuellen Spielzustand benötigten View Objekte.
    /// Die Ezeugung der Objekte wird durch Events gesteuert. Sobald die <c>draw()</c> Methode in der State Machine aufgerufen
    /// wird, wird die Liste mit den View Objekten durchgegangen und bei jedem Objekt die <c>draw()</c> Methode aufgerufen.
    /// </summary>
    class ViewManager
    {
        /// <summary>
        /// Liste mit den View Objekten
        /// </summary>
        public List<IView> ViewItemList
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    }
}
