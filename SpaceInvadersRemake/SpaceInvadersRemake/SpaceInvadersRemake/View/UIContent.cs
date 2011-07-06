using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceInvadersRemake.View
{
    public class UIContent
    {
        public Texture2D MenuButton
        {
            get;
            set;
        }

        public SpriteFont Font
        {
            get;
            set;
        }

        public Texture2D GameBackgroundImage
        {
            get;
            set;
        }

        public Texture2D HUDBackground
        {
            get;
            set;
        }

        public Texture2D MenuBackgroundImage
        {
            get;
            set;
        }

        public Texture2D SettingsButton
        {
            get;
            set;
        }

        public Texture2D SettingsBackground
        {
            get;
            set;
        }

        public Texture2D LiveIcon
        {
            get;
            set;
        }

        //[Anji]
        public Texture2D GameTitle
        {
            get;
            set;
        }

        public List<Texture2D> PowerUpIcons
        {
            get;
            set;
        }

        public Texture2D StarAnimation
        {
            get;
            set;
        }

        public Texture2D SpeedUpIcon
        {
            get;
            set;
        }
    }
}
