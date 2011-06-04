using System;
using Microsoft.Xna.Framework;

namespace SpaceInvadersRemake
{
    public class Projectile : GameItem
    {

        public Vector2 FlightDirection
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public ProjectileTypeEnum ProjectileType
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        protected override void Destroy()
        {
            throw new NotImplementedException();
        }

        public override event EventHandler Hit;

        public override event EventHandler Destroyed;

        public override void Move(Microsoft.Xna.Framework.Vector2 direction)
        {
            throw new NotImplementedException();
        }

        public override void IsCollidedWith(IGameItem collisionPartner)
        {
            throw new NotImplementedException();
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        public override void Shoot()
        {
            throw new NotImplementedException();
        }

        public override event EventHandler Created;
    }
}
