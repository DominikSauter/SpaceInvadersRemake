﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using SpaceInvadersRemake.ModelSection;
using SpaceInvadersRemake.Settings;
using Microsoft.Xna.Framework.Input;

namespace SpaceInvadersRemake.Controller
{

    /// <summary>
    /// Diese Klasse stellt die konkrete Benutzereingabe mithilfe der Tastatur.
    /// </summary>
    /// <remarks>In dieser Klasse wird das Verhalten des Controllers vom einem menschlichen Benutzer
    /// mithilfe der Tastatur bestimmt</remarks>
    public class KeyboardController : PlayerController
    {
        /// <summary>
        /// Generiert eine neue Instanz der <see cref="KeyboardController"/> Klasse.
        /// </summary>
        public KeyboardController(IGameItem controllee): base(controllee)
        {
            this.KBconfig = KeyboardConfig.Default;
        }

       //Private fields
       private KeyboardState kState;


        /// <summary>
        /// Getter/Setter der Tastatur Konfiguration
        /// </summary>
        /// <value>
        /// Die KBconfig.
        /// </value>
       public Settings.KeyboardConfig KBconfig { get; set; }




       /// <summary>
       /// Kümmert sich um die Bewegung der GameItem
       /// </summary>
       /// <param name="game">Referenz des Games aus dem XNA Framework.</param>
       /// <param name="gameTime">Bietet die aktuelle Spielzeit an.</param>
        protected override void Movement(Game game,GameTime gameTime)
        {
            KeyboardState kState = Keyboard.GetState();
            Vector2 direction = Vector2.Zero;

            if (kState.IsKeyDown(KBconfig.Left))
            {
                direction += CoordinateConstants.Left;
            }

            if (kState.IsKeyDown(KBconfig.Right))
            {
                direction += CoordinateConstants.Right;
            }


            this.Controllee.Move(direction, gameTime);
            
             
        }

        /// <summary>
        /// Entscheided ob Controllees schießen soll
        /// </summary>
        /// <remarks>Dies geschieht indem der Benutzer die Taste für schießen drückt.
        /// Welche Taste dies ist, ist in der Eigenschaft <c>KBconfig</c> hinterlegt
        /// </remarks>
        /// <returns>
        ///   <c>true</c> = schießen andererseits <c>false</c>
        /// </returns>
        protected override void Shooting(Game game,GameTime gameTime)
        {
            

            if (kState.IsKeyDown(KBconfig.Fire))
            {
                this.Controllee.Shoot(gameTime);
            }

            
        }
    }
}
