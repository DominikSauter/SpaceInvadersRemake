using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceInvadersRemake.View
{
    /// <summary>
    /// Stellt die vom Spieler oder von Gegnern abgefeuerten Projektile dar.
    /// </summary>
    public class ProjectileRepresentation : GameItemRepresentation
    {
        private Texture2D texture;

        /// <summary>
        /// Referenz auf ein Projectile-Modelobjekt um jegliche Abfragen im Model zu tätigen.
        /// </summary>
        public ModelSection.Projectile ProjectileGameItem
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        /// <summary>
        /// Erstellt eine Representation eines Projektils.
        /// </summary>
        public ProjectileRepresentation()
        {
            throw new System.NotImplementedException();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }
    }
}
