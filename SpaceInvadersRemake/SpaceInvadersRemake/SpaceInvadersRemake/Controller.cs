using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace SpaceInvadersRemake
{
    
    public abstract class Controller
    {
  
        public Controller(IGameItem controls)
        {
            throw new System.NotImplementedException();
        }
    
        public IGameItem IGameItem
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public void Update()
        {

        
            // Vector2 dada = this. // STST: Fehler

            throw new System.NotImplementedException();
        }

        private Vector2 CheckMovement()
        {
            throw new System.NotImplementedException();
        }

        private bool CheckShooting()
        {
            throw new System.NotImplementedException();
        }
    }
}
