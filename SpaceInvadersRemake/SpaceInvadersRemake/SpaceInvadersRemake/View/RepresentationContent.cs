using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceInvadersRemake.View
{
    public class RepresentationContent
    {
        public Model AlienModel
        {
            get;
            set;
        }

        public List<Texture2D> AlienTextures
        {
            get;
            set;
        }

        public ModelHitsphere AlienHitsphere
        {
            get;
            set;
        }

        public Model BossModel
        {
            get;
            set;
        }

        public ModelHitsphere BossHitsphere
        {
            get;
            set;
        }

        public Model PlayerModel
        {
            get;
            set;
        }

        public Texture2D PlayerTexture
        {
            get;
            set;
        }

        public ModelHitsphere PlayerHitsphere
        {
            get;
            set;
        }

        public Model MothershipModel
        {
            get;
            set;
        }

        public Model MothershipTexture
        {
            get;
            set;
        }

        public ModelHitsphere MothershipHitsphere
        {
            get;
            set;
        }

        public Texture2D ShieldTexture
        {
            get;
            set;
        }

        public ModelHitsphere ShieldHitsphere
        {
            get;
            set;
        }

        public List<Texture2D> PowerUps
        {
            get;
            set;
        }

        public Texture2D ProjectileNormal
        {
            get;
            set;
        }

        public ModelHitsphere ProjectileNormalHitsphere
        {
            get;
            set;
        }

        public Texture2D ProjectilePiercing
        {
            get;
            set;
        }

        public ModelHitsphere ProjectilePiercingHitsphere
        {
            get;
            set;
        }

        public Texture2D ProjectileBoss
        {
            get;
            set;
        }

        public ModelHitsphere ProjectileBossHitsphere
        {
            get;
            set;
        }

        public Texture2D ProjectileMothership
        {
            get;
            set;
        }

        public ModelHitsphere ProjectileMothershipHitsphere
        {
            get;
            set;
        }

        public List<Texture2D> PowerUpIcons
        {
            get;
            set;
        }
    }
}
