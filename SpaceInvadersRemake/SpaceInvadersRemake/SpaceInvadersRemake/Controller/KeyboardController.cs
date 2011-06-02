using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;



namespace SpaceInvadersRemake.Controller
{

    /// <summary>
    /// Diese Klasse stellt die konkrete Benutzereingabe mithilfe der Tastatur.
    /// </summary>
    /// <remarks>In dieser Klasse wird das Verhalten des Controllers vom einem menschlichen Benutzers
    /// mithilfe der Tastatur bestimmt</remarks>
    public class KeyboardController : PlayerController
    {

       


        /// <summary>
        /// Eigenschaft der Tastatur Konfiguration
        /// </summary>
        /// 
        public Settings.Keyboard KBconfig
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        /// <summary>
        ///   <c>Update</c> ist die Methode, die  pro Frame aufgerufen wird, damit entschieden wird wie sich Controllee verhalten soll
        /// </summary>
        public override void Update()
        {
            throw new NotImplementedException();
           
        }

        /// <summary>
        /// Entscheided in welche Richtung sich das Controllee bewegen soll
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
        /// Entscheided ob Controllee schießen soll
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
