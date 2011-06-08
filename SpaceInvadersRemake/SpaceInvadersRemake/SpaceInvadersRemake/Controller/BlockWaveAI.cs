using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SpaceInvadersRemake.Controller
{
    /// <summary>
    /// 
    /// </summary>
    public class BlockWaveAI : WaveAI
    {
        public BlockWaveAI()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Entscheidet in welche Richtung sich das Controllees bewegen soll
        /// </summary>
        /// <returns>
        /// 2D Richtungsvektor
        /// </returns>
        protected override Microsoft.Xna.Framework.Vector2 Movement()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Entscheidet ob Controllees schießen soll
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
