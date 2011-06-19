using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvadersRemake.ModelSection
{
    /// <summary>
    /// Diese statische Klasse wird verwendet um <c>PowerUps</c>s zu generieren. Sie bietet eine Fabrik-Methode 
    /// um zufällige oder ausgewählte <c>PowerUps</c>s zu erzeugen.
    /// </summary>
    /// <remarks>
    /// Diese Klasse wird ausschließlich dazu verwendet zufällige oder ausgewählte <c>PowerUps</c>s zu erzeugen.
    /// Das zufällige auftreten von <c>PowerUps</c>s muss an anderer Stelle gelöst werden.
    /// </remarks>
    public static class PowerUpGenerator
    {
        /// <summary>
        /// Random-Objekt zur zufälligen Generierung von <c>PowerUps</c>s
        /// </summary>
        private static Random random;

        /// <summary>
        /// Diese Methode generiert auf Wunsch ein bestimmtes oder zufälliges <c>PowerUps</c>.
        /// </summary>
        /// <remarks>Bei zufälliger Generierung wird kein <c>StaticShield</c>-PowerUps erzeugt.</remarks>
        /// <param name="type">Typ des PowerUps</param>
        public static void GeneratePowerUp(PowerUpEnum type)
        {
            throw new System.NotImplementedException();
        }
    }
}
