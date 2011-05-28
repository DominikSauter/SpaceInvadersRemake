using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvadersRemake
{
    public abstract class GameItem : IGameItem
    {

        protected abstract void Destroy();
      
        public abstract event EventHandler Hit;

        public abstract event EventHandler Destroyed;

        public abstract Microsoft.Xna.Framework.Vector2 Position
        {
            get;
           
            set;
          }

        public abstract Microsoft.Xna.Framework.Vector2 Velocity
        {
            get;
 
            set;
        }

        public abstract int Hitpoints
        {
            get;

            set;

        }

        public abstract bool IsAlive
        {
            get;

            set;
        }

        public abstract void Move(Microsoft.Xna.Framework.Vector2 direction);

        public abstract void IsCollidedWith(IGameItem collisionPartner);

        public abstract void Update(Microsoft.Xna.Framework.GameTime gameTime);

        public abstract void Shoot();

    }
}
