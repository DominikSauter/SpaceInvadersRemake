using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvadersRemake
{
    public abstract class Weapon
    {
        private int projectileType;
        private int cooldown;
        private Vector2 velocity;

        public abstract event EventHandler WeaponFired;

        public abstract void Fire(Vector2 position, Vector2 shootingDirection);
    }
}
