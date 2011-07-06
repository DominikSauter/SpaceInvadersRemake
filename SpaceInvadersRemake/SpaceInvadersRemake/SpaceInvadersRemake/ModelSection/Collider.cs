using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Implmentiert von Tobias

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
            if (collisionPartner1.BoundingVolume.Intersects(collisionPartner2.BoundingVolume))
            {
                collisionPartner1.IsCollidedWith(collisionPartner2);
                collisionPartner2.IsCollidedWith(collisionPartner1);
            }
        }

        /// <summary>
        /// Überprüft alle <c>GameItem</c>s in der angegebenen Liste auf Kollisionen in dem für jeweils ein Paar die <c>CheckCollision</c>-Methode aufgerufen wird. 
        /// Dabei wird ausgeschlossen, dass zwei gleichartige Objekte kollidieren.
        /// </summary>
        /// <param name="gameItemList">Liste aller <c>GameItem</c>s</param>
        public static void CheckAllCollisions(LinkedList<IGameItem> gameItemList)
        {
            if (gameItemList.Count == 0)
                return;

            LinkedListNode<IGameItem> ItemA;
            LinkedListNode<IGameItem> ItemB;

            for (ItemA = gameItemList.First; ItemA != null; ItemA = ItemA.Next)
                for (ItemB = ItemA; ItemB != null; ItemB = ItemB.Next)
                {
                    if (ItemA.Value.IsAlive && ItemB.Value.IsAlive
                        && !ItemA.Value.GetType().Equals(ItemB.Value.GetType()))
                    {
                        CheckCollision(ItemA.Value, ItemB.Value);
                    }
                }
        }
    }
}
