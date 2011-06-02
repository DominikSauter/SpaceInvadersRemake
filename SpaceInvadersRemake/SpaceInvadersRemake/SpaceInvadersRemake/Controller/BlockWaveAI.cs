using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SpaceInvadersRemake.Controller
{
    /// <summary>
    /// 
    /// </summary>
    public class BlockSwarmAI : SwarmAI
    {

        /// <summary>
        ///   <c>Update</c>ist die Methode, die  pro Frame aufgerufen wird, damit entschieden wird wie sich Controllee verhalten soll
        /// </summary>
        public override void Update()
        {
            throw new NotImplementedException();
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
        /// Entscheidet ob Controllee schießen soll
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
