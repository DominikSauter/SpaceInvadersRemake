using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using SpaceInvadersRemake.ModelSection;
using SpaceInvadersRemake.Settings;


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
            this.KBconfig = Keyboard.Default;
        }

       


        /// <summary>
        /// Getter/Setter der Tastatur Konfiguration
        /// </summary>
        /// <value>
        /// Die KBconfig.
        /// </value>
        public Settings.Keyboard KBconfig
        {
            get;

           private set;


        }

        /// <summary>
        /// Entscheided in welche Richtung sich das Controllees bewegen soll
        /// </summary>
        /// <remarks>Dies geschieht indem der Benutzer die Tasten für die Bewegungsrichtungen drückt.
        /// Welche Tasten dies sind, ist in der Eigenschaft <c>KBconfig</c> hinterlegt</remarks>
        /// <returns>
        /// 2D Richtungsvektor
        /// </returns>
        protected override Vector2 Movement()
        {

            
             throw new NotImplementedException();
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
        protected override bool Shooting()
        {
            throw new NotImplementedException();
        }


    }
}
