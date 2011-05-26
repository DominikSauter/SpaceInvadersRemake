using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace SpaceInvadersRemake
{
    public interface IGameItem
    {
        event EventHandler Hit;

        event EventHandler Destroyed;
    
        Vector2 Position
        {
            get;
            set;
        }

        Vector2 Velocity
        {
            get;
            set;
        }

        int Hitpoints
        {
            get;
            set;
        }

        bool IsAlive
        {
            get;
            set;
        }

        void Move(Vector2 direction);

        void IsCollidedWith(IGameItem collisionPartner);

        void Update(GameTime gameTime);

        void Shoot();
    }
}
