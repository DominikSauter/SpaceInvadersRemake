using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvadersRemake
{
    public abstract class Weapon
    {
        private int projectileType;

        public event EventHandler WeaponFired;

        public int Cooldown
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public void Fire(Vector2 position)
        {
            throw new System.NotImplementedException();
        }
    }
}
