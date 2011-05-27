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

        public event EventHandler WeaponFired;

        public void Fire(Vector2 position, Vector2 shootingDirection)
        {
            throw new System.NotImplementedException();
        }
    }
}
