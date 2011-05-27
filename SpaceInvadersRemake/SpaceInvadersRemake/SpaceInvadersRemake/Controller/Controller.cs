﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace SpaceInvadersRemake
{

    /// <summary>
    /// Die abstrakte Controller Klasse dafür zuständig die verschiedenen <c>GameItem</c> zu kontrollieren.
    /// </summary>
    /// <remarks> Um dies zutun benutzt sie das GameItem Interface
    /// Im Architekturstil MVC fungiert sie als Controller
    /// </remarks>
    public abstract class Controller
    {
  

    
       /// <summary>
       /// Eigenschaft Controllee (kontrollierte Objekt)
       /// </summary>
       /// <remarks>Eigenschaft in der das kontrollierte GameItem gespeichert ist.
       /// <c>get</c>
       /// <c>set</c>setzt ein IGameItem als kontrolliertes GameItem ein.</remarks>
        public abstract IGameItem Controllee
        {
            get;

            set;
           
        }

        /// <summary>
        /// <c>Update</c>ist die Methode, die  pro Frame aufgerufen wird, damit entschieden wird wie sich Controllee verhalten soll
        /// </summary>
        /// 
        public abstract void Update();


    
        /// <summary>
        /// Entscheided in welche Richtung sich das Controllee soll
        /// </summary>
        /// <returns>2D Richtungsvektor</returns>
        protected abstract Vector2 CheckMovement();

        /// <summary>
        /// Entscheided ob Controllee schießen soll
        /// </summary>
        /// <returns>true = schießen</returns>
        protected abstract bool CheckShooting();
    
    }
}