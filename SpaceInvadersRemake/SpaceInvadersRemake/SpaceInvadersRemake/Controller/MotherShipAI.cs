using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceInvadersRemake.ModelSection;


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
        public MothershipAI(int shootingFrequency, IGameItem controllee) : base(shootingFrequency, controllee)
        {
            //Nichts zu erledigen.
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
            //Hack für /FA11000W/ (Mutterschiff schießt)
            return false;
        }
    }
}
