//"Implementiert" von Dodo
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceInvadersRemake.View
{
    /// <summary>
    /// Interface für View Objekte, die gezeichnet werden sollen.
    /// </summary>
    public interface IView
    {
        /// <summary>
        /// 	<c>draw</c> Methode die von den Unterklassen implementiert wird.
        /// </summary>
        void Draw(SpriteBatch spriteBatch);
    }
}
