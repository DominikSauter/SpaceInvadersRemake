﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace SpaceInvadersRemake.ModelSection
{
    public class PlayerNormalWeapon : Weapon
    {
        public override event EventHandler WeaponFired;

        public override void Fire(Vector2 position, Vector2 shootingDirection)
        {
            throw new NotImplementedException();
        }
    }
}
