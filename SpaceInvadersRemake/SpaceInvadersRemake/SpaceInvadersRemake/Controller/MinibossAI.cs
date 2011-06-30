using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceInvadersRemake.ModelSection;
using Microsoft.Xna.Framework;

namespace SpaceInvadersRemake.Controller
{
    /// <summary>
    /// Stellt die abstrakte Oberklasse der Miniboss KIs da.
    /// </summary>
    /// <remarks>
    /// Jeder konkreter Miniboss muss von dieser Klasse erben.
    /// </remarks>
    public abstract class MinibossAI : AIController
    {
        /// <summary>
        /// Erstellt eine neue Instanz eines allgemeinen MinibossAI Kontrollers.
        /// </summary>
        /// <remarks>
        /// Da dies eine Abstrakte Klasse ist, wird dieser Konstruktor innerhalb des Konstruktors der konkreten Klasse aufgerufen.
        /// </remarks>
        /// <param name="shootingFrequencyMultiplier">Die Schussfrequenz.</param>
        /// <param name="controllee">Das GameItem, das der Controller kontrollieren soll.</param>
        protected MinibossAI(float shootingFrequency, IGameItem controllee, Vector2 velocityIncrease)
            : base(shootingFrequency, controllee, velocityIncrease)
        {
           //Nichts zu erledigen
        }


    }
}
