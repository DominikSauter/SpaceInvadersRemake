using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace SpaceInvadersRemake.Controller
{

    /// <summary>
    /// Die abstrakte ControllerUpdate Klasse dafür zuständig die verschiedenen <c>GameItem</c> zu kontrollieren.
    /// </summary>
    /// <remarks> 
    /// Sie abstrahiert von den Controller-Verhaltensweisen Benutzer und Künstliche Intelligenz
    /// Um dies zutun benutzt sie das GameItem Interface.
    /// </remarks>
    public abstract class Controller : SpaceInvadersRemake.StateMachine.IController
    {
  

    
       /// <summary>
       /// Eigenschaft Controllee (kontrollierte Objekt)
       /// </summary>
       /// <remarks>Eigenschaft in der das kontrollierte GameItem gespeichert ist.
       /// <c>get</c>
       /// <c>set</c>setzt ein IGameItem als kontrolliertes GameItem ein.</remarks>
        public IGameItem Controllee
        {
            get
            {
                throw new System.NotImplementedException();
}

            set { }

        }

        /// <summary>
        /// 	<c>Update</c> ist die Methode, die  pro Frame aufgerufen wird, damit entschieden wird wie sich Controllee verhalten soll
        /// </summary>
        public  void Update();


    
        /// <summary>
        /// Entscheidet in welche Richtung sich das Controllee bewegen soll
        /// </summary>
        /// <returns>2D Richtungsvektor</returns>
        protected abstract Vector2 Movement();

        /// <summary>
        /// Entscheided ob Controllee schießen soll
        /// </summary>
        /// <c>true</c> = schießen andererseits <c>false</c>
        protected abstract bool Shooting();
    
    }
}
