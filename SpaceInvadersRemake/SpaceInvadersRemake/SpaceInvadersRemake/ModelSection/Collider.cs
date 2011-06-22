using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Implmentiert von Tobias Bast

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
        /// <param name="collisionPartner1">Kollisionspartner 1</param>
        /// <param name="collisionPartner2">Kollisionspartner 2</param>
        private static void CheckCollision(IGameItem collisionPartner1, IGameItem collisionPartner2)
        {
            //TODO: Kollisionsberechnung
        }

        /// <summary>
        /// Überprüft alle <c>GameItem</c>s in der angegebenen Liste auf Kollisionen in dem für jeweils ein Paar die <c>CheckCollision</c>-Methode aufgerufen wird. 
        /// Dabei wird ausgeschlossen, dass zwei gleichartige Objekte kollidieren.
        /// </summary>
        /// <param name="gameItemList">Liste aller <c>GameItem</c>s</param>
        public static void CheckAllCollisions(LinkedList<IGameItem> gameItemList)
        {
            //HACK: Kann performanter gelöst werden, indem ItemB nur hinter ItemA in der Liste stehen kann
            foreach (IGameItem ItemA in gameItemList)
                foreach (IGameItem ItemB in gameItemList)
                {
                    if (ItemA.IsAlive && ItemB.IsAlive 
                        && !ItemA.GetType().Equals(ItemB.GetType()))
                    {
                        CheckCollision(ItemA, ItemB);
                    }
                }
        }
    }
}
