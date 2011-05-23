using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace SpaceInvadersRemake
{
    
    public abstract class Controller
    {
        //Directions Definitions
        private readonly Vector2 Right = new Vector2(1,0);
        private readonly Vector2 Up = new Vector2(0,1);
        private readonly Vector2 UpRight = new Vector2(1,1);
        private readonly Vector2 Left = new Vector2(-1,0);
        private readonly Vector2 Down = new Vector2(0,-1);
        private readonly Vector2 DownLeft = new Vector2(-1,-1);
        private readonly Vector2 DownRight = new Vector2(1,-1);
        private readonly Vector2 UpLeft = new Vector2(-1,1);
    
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

        public void GetAction()
        {

        
            Vector2 dada = this.

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
