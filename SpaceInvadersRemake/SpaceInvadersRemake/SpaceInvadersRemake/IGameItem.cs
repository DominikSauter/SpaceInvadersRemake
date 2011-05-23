using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvadersRemake
{
    public interface IGameItem
    {
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

        void Move(Vector2 Direction);

        void IsCollidedWith(IGameItem CollisionPartner);
    }
}
