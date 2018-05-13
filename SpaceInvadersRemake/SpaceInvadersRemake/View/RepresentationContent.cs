//Implementiert von Dodo
using System.Collections.Generic;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SpaceInvadersRemake.View
{
    /// <summary>
    /// Utilityklasse welche alle Models, ModelHitspheres und Texturen hält, welche für die Darstellung der
    /// Spielobjekte benötigt werden.
    /// </summary>
    public class RepresentationContent
    {
        /// <summary>
        /// 3D Modell für ein Alienschiff
        /// </summary>
        public Model AlienModel
        {
            get;
            set;
        }

        /// <summary>
        /// Liste von Texturen welche den Aliens zugewiesen werden können.
        /// </summary>
        public List<Texture2D> AlienTextures
        {
            get;
            set;
        }

        /// <summary>
        /// Hitsphere für ein Alien
        /// </summary>
        public ModelHitsphere AlienHitsphere
        {
            get;
            set;
        }

        /*
         * <WAHL>
         * Wird benötigt falls Boss-Gegner eingebaut werden.
        public Model BossModel
        {
            get;
            set;
        }
         * */

        /*
         * <WAHL>
         * Wird benötigt falls Boss-Gegner eingebaut werden.
        public ModelHitsphere BossHitsphere
        {
            get;
            set;
        }
         * */

        /// <summary>
        /// 3D Modell des Spielerschiffs
        /// </summary>
        public Model PlayerModel
        {
            get;
            set;
        }

        /// <summary>
        /// Textur für das Spielerschiff
        /// </summary>
        public Texture2D PlayerTexture
        {
            get;
            set;
        }

        /// <summary>
        /// Hitsphere des Spielerschiffs
        /// </summary>
        public ModelHitsphere PlayerHitsphere
        {
            get;
            set;
        }

        /// <summary>
        /// 3D Modell des Mutterschiffs
        /// </summary>
        public Model MothershipModel
        {
            get;
            set;
        }

        /// <summary>
        /// Textur des Mutterschiffs
        /// </summary>
        public Texture2D MothershipTexture
        {
            get;
            set;
        }

        /// <summary>
        /// Hitsphere des Mutterschiffs
        /// </summary>
        public ModelHitsphere MothershipHitsphere
        {
            get;
            set;
        }

        /// <summary>
        /// Textur für die Schilde
        /// </summary>
        public Texture2D ShieldTexture
        {
            get;
            set;
        }

        /// <summary>
        /// Hitsphere der Schilde
        /// </summary>
        public ModelHitsphere ShieldHitsphere
        {
            get;
            set;
        }

        /// <summary>
        /// Textur für "Utility"-PowerUps
        /// </summary>
        public Texture2D PowerUpTextureUtility
        {
            get;
            set;
        }

        /// <summary>
        /// Textur für "Weapon"-PowerUps
        /// </summary>
        public Texture2D PowerUpTextureWeapon
        {
            get;
            set;
        }

        /// <summary>
        /// 3D Modell für ein PowerUP
        /// </summary>
        public Model PowerUp
        {
            get;
            set;
        }
        
        /// <summary>
        /// Hitsphere für ein PowerUP
        /// </summary>
        public ModelHitsphere PowerUpHitsphere
        {
            get;
            set;
        }

        /// <summary>
        /// Textur für das normale Spielerprojektil
        /// </summary>
        public Texture2D ProjectileNormal
        {
            get;
            set;
        }

        /// <summary>
        /// Hitsphere für das normale Spielerprojektil
        /// </summary>
        public ModelHitsphere ProjectileNormalHitsphere
        {
            get;
            set;
        }

        /// <summary>
        /// Textur für das Piercingshot-Projektil
        /// </summary>
        public Texture2D ProjectilePiercing
        {
            get;
            set;
        }

        /// <summary>
        /// Hitsphere für das Piercingshot-Projektil
        /// </summary>
        public ModelHitsphere ProjectilePiercingHitsphere
        {
            get;
            set;
        }

        /*
         * <WAHL>
         * Wird benötigt falls Boss-Gegner eingebaut werden.
        public Texture2D ProjectileBoss
        {
            get;
            set;
        }
         * */

        /*
         * <WAHL>
         * Wird benötigt falls Boss-Gegner eingebaut werden.
        public ModelHitsphere ProjectileBossHitsphere
        {
            get;
            set;
        }
         * */

        /*
         * <WAHL>
         * Wird benötigt falls eine Mutterschiffwaffe eingebaut wird.
        public Texture2D ProjectileMothership
        {
            get;
            set;
        }
         * */

        /*
         * <WAHL>
         * Wird benötigt falls eine Mutterschiffwaffe eingebaut wird.
        public ModelHitsphere ProjectileMothershipHitsphere
        {
            get;
            set;
        }
         * */

        /// <summary>
        /// Farbkonstante für das Spielerprojektil
        /// </summary>
        public Vector3 PlayerProjektileColor
        {
            get;
            set;
        }

        /// <summary>
        /// Farbkonstante für das Alienprojektil
        /// </summary>
        public Vector3 AlienProjektileColor
        {
            get;
            set;
        }

        /// <summary>
        /// Farbkonstanten für das Piercingshot-Projektil
        /// </summary>
        public Vector3 PlayerPiercingShotProjektileColor
        {
            get;
            set;
        }

        /*
         * <WAHL>
         * Wird benötigt falls eine Mutterschiffwaffe eingebaut wird.
        public Vector3 MothershipProjektileColor
        {
            get;
            set;
        }
         * */

        /*
         * <WAHL>
         * Wird benötigt falls Boss-Gegner eingebaut werden.
        public Vector3 BossProjektileColor
        {
            get;
            set;
        }
         * */

        //Ship Engine Partikeltextur
        public Texture2D ShipEngineTexture
        {
            get;
            set;
        }

        //Mothership Engine Partikeltextur
        public Texture2D MothershipEngineTexture
        {
            get;
            set;
        }

        //Explosions Partikeltextur
        public Texture2D ExplosionTexture
        {
            get;
            set;
        }

        //Glitzer Partikeltextur
        public Texture2D GlitterTexture
        {
            get;
            set;
        }

        //SchildTextur des Spielerschiffs
        public Texture2D ShipShieldTexture
        {
            get;
            set;
        }
    }
}
