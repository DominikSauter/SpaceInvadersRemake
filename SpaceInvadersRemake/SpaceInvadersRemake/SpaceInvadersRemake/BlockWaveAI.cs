using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvadersRemake
{
    /// <summary>
    /// 
    /// </summary>
    public class BlockWaveAI : WaveAI
    {

        /// <summary>
        ///   <c>Update</c>ist die Methode, die  pro Frame aufgerufen wird, damit entschieden wird wie sich Controllee verhalten soll
        /// </summary>
        public override void Update()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Entscheided in welche Richtung sich das Controllee bewegen soll
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
        protected override bool CheckShooting()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Eigenschaft Controllee Liste (kontrollierte Objekt)
        /// </summary>
        public override List<IGameItem> Controllee
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
