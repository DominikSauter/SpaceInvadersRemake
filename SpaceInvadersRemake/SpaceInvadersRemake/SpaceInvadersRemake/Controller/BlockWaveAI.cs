using System;
using System.Collections.Generic;
using SpaceInvadersRemake.ModelSection;

namespace SpaceInvadersRemake.Controller
{
    /// <summary>
    /// KI die eine Welle kontrolliert in Block Formation.
    /// </summary>
    /// <remarks>
    /// Verhalten einer Block Formation:
    /// 
    /// </remarks>
    public class BlockWaveAI : WaveAI
    {
        /// <summary>
        /// Generiert eine neue  <see cref="BlockWaveAI"/> Klasse.
        /// </summary>
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

        /// <summary>
        /// Eigenschaft Controllees Liste (kontrollierte Objekte)
        /// </summary>
        public override ICollection<IGameItem> Controllees
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
