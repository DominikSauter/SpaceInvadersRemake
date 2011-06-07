﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvadersRemake.ModelSection
{
    /// <summary>
    /// Diese Klasse verwaltet die Kollisionsberechnung
    /// </summary>
    public static class Collider
    {

        /// <summary>
        /// Überprüft, ob zwei GameItems kollidieren
        /// </summary>
        /// <param name="CollisionPartner1">Kollisionspartner 1</param>
        /// <param name="CollisionPartner2">Kollisionspartner 2</param>
        private static void CheckCollision(IGameItem CollisionPartner1, IGameItem CollisionPartner2)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Überprüft alle GameItems in der angegebenen Liste auf Kollisionen
        /// </summary>
        /// <param name="GameItemList">Liste aller GameItems</param>
        public static void CheckAllCollisions(List<IGameItem> GameItemList)
        {
            throw new System.NotImplementedException();
        }
    }
}
