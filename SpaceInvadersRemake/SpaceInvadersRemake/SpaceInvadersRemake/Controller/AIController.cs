using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceInvadersRemake.ModelSection;
using Microsoft.Xna.Framework;

//IMplementiert von Chris
namespace SpaceInvadersRemake.Controller
{
    /// <summary>
    /// Diese Klasse abstrahiert von den verschiedenen Steuerungen durch die KI
    /// </summary>
    /// <remarks>
    /// In den Abgeleiteten Klassen wird das Verhalten des Controllers durch die KI bestimmt
    /// Von dieser KLasse muss geerbt werden um eine KI-Eingabe zu impelmentieren.
    /// </remarks>
    public abstract class AIController : SpaceInvadersRemake.Controller.Controller
    {

        /// <summary>
        /// Erstellt eine neue Instanz eines algemeinen AIControllers.
        /// </summary>
        /// <remarks>
        /// Da dies eine Abstrakte Klasse ist, wird dieser Konstruktor innerhalb des Konstruktors der konkreten Klasse aufgerufen.
        /// </remarks>
        /// <param name="shootingFrequencyMultiplier">Die Schussfrequenz.</param>
        /// <param name="controllee">Das GameItem, das der Controller kontrollieren soll.</param>
        protected AIController(int shootingFrequency, IGameItem controllee, Vector2 velocityIncrease)
            : base(controllee)
        {
            this.ShootingFrequency = shootingFrequency;
            this.VelocityIncrease = velocityIncrease;
        }

        /// <summary>
        /// Getter/Setter der Schussfrequenz.
        /// </summary>
        /// <value>
        /// Die Schussfrequenz.
        /// </value>
       protected int ShootingFrequency
       {
           get;

           set;
       }

       public Vector2 VelocityIncrease { get; set; }
    }
}
