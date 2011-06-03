using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace SpaceInvadersRemake.Generator
{

    /// <summary>
    /// Die Klasse dient dazu sich Gegner (<c>GameItem</c>) in einer Blockformation generieren zu lassen
    /// </summary>
    public class BlockFormation : FormationGenerator
    {

        protected override  List<IGameItem> CreateFormation(int hitpoints, Microsoft.Xna.Framework.Vector2 velocity)
        {
            throw new NotImplementedException();
        }
    }
}
