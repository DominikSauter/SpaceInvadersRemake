using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvadersRemake.ModelSection
{
    /// <summary>
    /// Diese Klasse wird verwendet um PowerUps zu generieren
    /// </summary>
    public static class PowerUpGenerator
    {
        /// <summary>
        /// Random-Objekt zur zufälligen generierung von PowerUps
        /// </summary>
        private static Random random;

        /// <summary>
        /// Diese Methode generiert auf Wunsch ein bestimmtes oder zufälliges PowerUp
        /// </summary>
        /// <remarks>Bei zufälliger Generierung wird kein StaticShield-PowerUp erzeugt.</remarks>
        /// <param name="type">Typ des PowerUps</param>
        public static void GeneratePowerUp(PowerUpEnum type)
        {
            throw new System.NotImplementedException();
        }
    }
}
