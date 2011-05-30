using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvadersRemake
{
    public abstract class Weapon
    {
        protected int projectileType;
        protected int cooldown;
        protected Vector2 velocity;

        public abstract event EventHandler WeaponFired;

        public abstract void Fire(Vector2 position, Vector2 shootingDirection);
    }
}
