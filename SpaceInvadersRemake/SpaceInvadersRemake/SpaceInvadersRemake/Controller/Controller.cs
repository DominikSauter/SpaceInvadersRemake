using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using SpaceInvadersRemake.ModelSection;

namespace SpaceInvadersRemake.Controller
{

    /// <summary>
    /// Die abstrakte ControllerUpdate Klasse ist dafür zuständig die verschiedenen <c>GameItem</c> zu kontrollieren.
    /// </summary>
    /// <remarks> 
    /// Sie abstrahiert von den Controller-Verhaltensweisen Benutzer und Künstliche Intelligenz im GameState
    /// Um dies zutun benutzt sie das GameItem Interface.
    /// Von dieser Klasse ist nicht zu erben, sondern von ihren Unterklassen.
    /// <see cref="PlayerController"/>
    /// <see cref="AIController"/>
    /// </remarks>
    public abstract class Controller : ICommander
    {
  

    
       /// <summary>
       /// Eigenschaft Controllees (kontrollierte Objekt)
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
        /// Entscheidet in welche Richtung sich das Controllees bewegen soll
        /// </summary>
        /// <returns>2D Richtungsvektor</returns>
        protected abstract Vector2 Movement();

        /// <summary>
        /// Entscheided ob Controllees schießen soll
        /// </summary>
        /// <c>true</c> = schießen andererseits <c>false</c>
        protected abstract bool Shooting();

        /// <summary>
        /// Erlaubt die Ausführung der Steuerung.
        /// </summary>
        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
