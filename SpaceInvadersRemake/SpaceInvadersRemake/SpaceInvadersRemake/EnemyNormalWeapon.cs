﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvadersRemake
{
    public class EnemyNormalWeapon : Weapon
    {
        public override event EventHandler WeaponFired;

        public override void Fire(Vector2 position, Vector2 shootingDirection)
        {
            throw new NotImplementedException();
        }
    }
}
