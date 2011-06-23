using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceInvadersRemake.ModelSection;
using Microsoft.Xna.Framework;

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

        /// <summary>
        /// Erstellt eine Instanz eines allgemeinen AlienAI Controllers.
        /// </summary>
        /// <remarks>
        /// Da dies eine Abstrakte Klasse ist, wird dieser Konstruktor innerhalb des Konstruktors der konkreten Klasse aufgerufen.
        /// </remarks>
        /// <param name="shootingFrequency">Die Schussfrequenz.</param>
        /// <param name="controllee">Das GameItem, das der Controller kontrollieren soll..</param>
        protected AlienAI(int shootingFrequency, IGameItem controllee, Vector2 velocityIncrease)
            : base(shootingFrequency, controllee, velocityIncrease)
        {
            //Nichts zu erledigen
        }

        /// <summary>
        /// Entscheidet in welche Richtung sich das Controllee bewegen soll
        /// </summary>
        /// <returns>
        /// 2D Richtungsvektor
        /// </returns>
        protected override Microsoft.Xna.Framework.Vector2 Movement()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Entscheided ob Controllee schießen soll
        /// </summary>
        /// <returns></returns>
        /// <c>true</c>
        ///  = schießen andererseits 
        /// <c>false</c>
        protected override bool Shooting()
        {
            throw new NotImplementedException();
        }
    }
}
