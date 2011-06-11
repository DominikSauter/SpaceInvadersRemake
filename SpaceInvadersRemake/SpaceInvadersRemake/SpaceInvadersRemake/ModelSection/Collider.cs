using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvadersRemake.ModelSection
{
    /// <summary>
    /// Diese statische Klasse bietet eine öffentliche Funktion zur Kollisionsberechnung aller Spielobjekte
    /// </summary>
    public static class Collider
    {

        /// <summary>
        /// Überprüft, ob zwei <c>GameItem</c>s kollidieren
        /// </summary>
        /// <param name="CollisionPartner1">Kollisionspartner 1</param>
        /// <param name="CollisionPartner2">Kollisionspartner 2</param>
        private static void CheckCollision(IGameItem CollisionPartner1, IGameItem CollisionPartner2)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Überprüft alle <c>GameItem</c>s in der angegebenen Liste auf Kollisionen in dem für jeweils ein Paar die <c>CheckCollision</c>-Methode aufgerufen wird. 
        /// Dabei wird ausgeschlossen, dass zwei gleichartige Objekte kollidieren.
        /// </summary>
        /// <param name="GameItemList">Liste aller <c>GameItem</c>s</param>
        public static void CheckAllCollisions(List<IGameItem> GameItemList)
        {
            throw new System.NotImplementedException();
        }
    }
}
