using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvadersRemake.ModelSection
{
    /// <summary>
    /// Diese Klasse stellt ein Deflector-PowerUp dar. Dieses PowerUp verbessert den Spieler, sodass er ein Schild hat, das einen Treffer absorbiert.
    /// </summary>
    public class Deflector : PowerUp
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
