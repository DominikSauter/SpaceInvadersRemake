using System;
using Microsoft.Xna.Framework;

namespace SpaceInvadersRemake
{
    public class RapidfireWeapon : Weapon
    {
        public override event EventHandler WeaponFired;

        public override void Fire(Vector2 position, Vector2 shootingDirection)
        {
            throw new NotImplementedException();
        }
    }
}
