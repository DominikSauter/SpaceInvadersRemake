﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceInvadersRemake.ModelSection;
using Microsoft.Xna.Framework;


namespace SpaceInvadersRemake.Controller
{
    /// <summary>
    /// Diese Klasse stellt die KI des Mutterschiffes da.
    /// </summary>
    public class MothershipAI : AIController
    {
        /// <summary>
        /// Generiert eine neue Instanz der MothershipAI Controllers.
        /// </summary>
        public MothershipAI(float shootingFrequency, IGameItem controllee, Vector2 velocityIncrease)
            : base(shootingFrequency, controllee, velocityIncrease)
        {
            //Nichts zu erledigen.
        }


        /// <summary>
        /// Entscheidet in welche Richtung sich das Controllee bewegen soll
        /// </summary>
        /// <returns>
        /// 2D Richtungsvektor
        /// </returns>
        protected override void Movement(Game game,GameTime gameTime)
        {
            this.Controllee.Move(CoordinateConstants.Right,gameTime);
        }


        /// <summary>
        /// Kümmert sich um das Schießen der GameItem
        /// </summary>
        /// <param name="game">Referenz des Games aus dem XNA Framework.</param>
        /// <param name="gameTime">Bietet die aktuelle Spielzeit an.</param>
        protected override void Shooting(Game game, GameTime gameTime)
        {
            //Hack für /FA11000W/ (Mutterschiff schießt) - ck

        }
    }
}
