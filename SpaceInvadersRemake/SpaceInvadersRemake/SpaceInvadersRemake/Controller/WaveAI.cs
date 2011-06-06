﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceInvadersRemake.ModelSection;

namespace SpaceInvadersRemake.Controller
{
    /// <summary>
    /// Diese Klasse abstrahiert von den verschiedenen KIs zur Steurerung einer Welle von Gegnern
    /// </summary>
    public abstract class WaveAI : AIController
    {

        /// <summary>
        /// Eigenschaft Controllee Liste (kontrollierte Objekt)
        /// </summary>
        public override ICollection<IGameItem> Controllee
        {
            get
            {
                throw new NotImplementedException();
            }
            set { 
            }
        }
    }
}
