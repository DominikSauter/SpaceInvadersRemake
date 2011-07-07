using Microsoft.Xna.Framework;
using SpaceInvadersRemake.ModelSection;

//Implemntiert von Christian (ck)
namespace SpaceInvadersRemake.Controller
{
    /// <summary>
    /// Stellt die abstrakte Oberklasse aller einzeln agierenden Alien da.
    /// </summary>
    /// <remarks>
    /// Von dieser Klasse ist zu erben wenn man eine Alien KI implementieren möchte.
    /// </remarks>
    public abstract class AlienAI : AIController
    {
        // MODIFIED (by STST): 2.7.2011
        /// <summary>
        /// Erstellt eine Instanz eines allgemeinen AlienAI Controllers.
        /// </summary>
        /// <param name="controllerManager">Verweis auf Verwaltungsklasse</param>
        /// <param name="shootingFrequency">Die Schussfrequenz.</param>
        /// <param name="controllee">Das GameItem, das der Controller kontrollieren soll..</param>
        /// <param name="velocityIncrease">Erhöhungsrate der Geschwindigkeit.</param>
        /// <remarks>
        /// Da dies eine Abstrakte Klasse ist, wird dieser Konstruktor innerhalb des Konstruktors der konkreten Klasse aufgerufen.
        /// </remarks>
        protected AlienAI(ControllerManager controllerManager, int shootingFrequency, IGameItem controllee, Vector2 velocityIncrease)
            : base(controllerManager, shootingFrequency, controllee, velocityIncrease)
        {
            //Nichts zu erledigen
        }



    }
}
