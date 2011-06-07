using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceInvadersRemake.View
{
    /// <summary>
    /// Die GameUI(GameUserInterface) Klasse stellt die Spieloberfläche während des Spiels via der <c>draw</c> Methode dar.
    /// </summary>
    public class GameUI : IView
    {
        private Texture2D gameBackgroundImage;
        private Texture2D hudBackgroundTexture;
        private SpriteFont font;
    
        /// <summary>
        /// Initialisiert die Spieloberfläche
        /// </summary>
        public GameUI()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Zeichnet die Spieloberfläche zu einem Zeitpunkt des Spiels.
        /// </summary>
        /// <param name="gameTime">Zeitpunkt des Spiels, zu dem die <c>draw</c> Methode aufgerufen wird.</param>
        public void Draw(GameTime gameTime)
        {
            throw new System.NotImplementedException();
        }

        private void labelHUD()
        {
            throw new System.NotImplementedException();
        }
    }
}
