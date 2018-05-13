using Microsoft.Xna.Framework;
using SpaceInvadersRemake.ModelSection;

//Implemntiert von Christian (ck)
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
        // MODIFIED (by STST): 2.7.2011
        /// <summary>
        /// Erstellt eine neue Instanz eines allgemeinen MinibossAI Kontrollers.
        /// </summary>
        /// <param name="controllerManager">Verweis auf Verwaltungsklasse</param>
        /// <param name="shootingFrequency">Die Schussfrequenz.</param>
        /// <param name="controllee">Das GameItem, das der Controller kontrollieren soll.</param>
        /// <param name="velocityIncrease">Geschwindigkeitserhöhung</param>
        /// <remarks>
        /// Da dies eine Abstrakte Klasse ist, wird dieser Konstruktor innerhalb des Konstruktors der konkreten Klasse aufgerufen.
        /// </remarks>
        protected MinibossAI(ControllerManager controllerManager, float shootingFrequency, IGameItem controllee, Vector2 velocityIncrease)
            : base(controllerManager, shootingFrequency, controllee, velocityIncrease)
        {
           //Nichts zu erledigen
        }


    }
}
