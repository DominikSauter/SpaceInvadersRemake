using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvadersRemake.ModelSection
{
    /// <summary>
    /// Diese Klasse stellt ein RapidFire-PowerUp dar. Dieses PowerUp verbessert die Waffe des Spielers, sodass diese in schneller Folge feuern kann.
    /// </summary>
    public class Rapidfire : PowerUp
    {
        public override void Apply(Player player)
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

        public override event EventHandler Created;

        public override void Remove(Player player)
        {
            throw new NotImplementedException();
        }
    }
}
