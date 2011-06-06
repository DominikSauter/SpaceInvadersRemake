using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvadersRemake.ModelSection
{
    public abstract class GameItem : IGameItem
    {

        protected abstract void Destroy();
      
        public abstract event EventHandler Hit;

        public abstract event EventHandler Destroyed;

        public Microsoft.Xna.Framework.Vector2 Position
        {
            get
            {
                throw new System.NotImplementedException();
}

            set { }
          }

        public Microsoft.Xna.Framework.Vector2 Velocity
        {
            get
            {
                throw new System.NotImplementedException();
}

            set { }
        }

        public int Hitpoints
        {
            get
            {
                throw new System.NotImplementedException();
}

            set { }

        }

        public bool IsAlive
        {
            get
            {
                throw new System.NotImplementedException();
}

            set { }
        }

        public abstract void Move(Microsoft.Xna.Framework.Vector2 direction);

        public abstract void IsCollidedWith(IGameItem collisionPartner);

        public abstract void Update(Microsoft.Xna.Framework.GameTime gameTime);

        public virtual void Shoot()
        {
            throw new System.NotImplementedException();
}

        public static List<IGameItem> GameItemList
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public abstract event EventHandler Created;

    }
}
