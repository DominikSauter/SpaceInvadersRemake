using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework;

namespace SpaceInvadersRemake.View
{
    /// <summary>
    /// Die ViewContent Klasse beinhaltet den für die View benötigten Content.
    /// </summary>
    public static class ViewContent
    {
        /// <summary>
        /// Schriftart
        /// </summary>
        public static SpriteFont Font
        {
            get;
            set;
        }

        /// <summary>
        /// Spiel Hintergrund
        /// </summary>
        public static Texture2D GameBackgroundImage
        {
            get;
            set;
        }

        /// <summary>
        /// Menü Hintergrund
        /// </summary>
        public static Texture2D MenuBackgroundImage
        {
            get;
            set;
        }

        /// <summary>
        /// HUD Hintergrund
        /// </summary>
        public static Texture2D HUDBackgroundTexture
        {
            get;
            set;
        }

        /// <summary>
        /// Button Hintergrund
        /// </summary>
        public static Texture2D ButtonBackgroundTexture
        {
            get;
            set;
        }

        /// <summary>
        /// Kugelförmige Hitbox des 3D Spielermodels
        /// </summary>
        public static ModelHitsphere PlayerHitsphere
        {
            get;
            set;
        }

        /// <summary>
        /// Hintergrundmusik im Menü 
        /// </summary>
        public static Song MenuSong
        {
            get;
            set;
        }

        /// <summary>
        /// Hintergrundmusik im Spiel
        /// </summary>
        public static Song GameSong
        {
            get;
            set;
        }

        /// <summary>
        /// Sound Effekt für die Waffe des Spielers
        /// </summary>
        public static SoundEffect WeaponEffectPlayer
        {
            get;
            set;
        }

        /// <summary>
        /// Sound Effekt für Explosionen
        /// </summary>
        public static SoundEffect ExplosionEffect
        {
            get;
            set;
        }

        /// <summary>
        /// Sound Effekt für das Erscheinen eines PowerUp's
        /// </summary>
        public static SoundEffect PowerUpEffect
        {
            get;
            set;
        }

        /// <summary>
        /// 3D Model des Spielers
        /// </summary>
        public static Model PlayerModel
        {
            get;
            set;
        }

        /// <summary>
        /// 3D Model eines gegnerischen Bosses
        /// </summary>
        public static Model BossModel
        {
            get;
            set;
        }

        /// <summary>
        /// 3D Model der gegnerischen Alienschiffe
        /// </summary>
        public static Model Alien1Model
        {
            get;
            set;
        }

        /// <summary>
        /// 3D Model der gegnerischen Alienschiffe
        /// </summary>
        public static Model Alien2Model
        {
            get;
            set;
        }

        /// <summary>
        /// 3D Model der gegnerischen Alienschiffe
        /// </summary>
        public static Model Alien3Model
        {
            get;
            set;
        }

        /// <summary>
        /// 3D Model der gegnerischen Alienschiffe
        /// </summary>
        public static Model Alien4Model
        {
            get;
            set;
        }

        /// <summary>
        /// 3D Model der gegnerischen Alienschiffe
        /// </summary>
        public static Model Alien5Model
        {
            get;
            set;
        }

        /// <summary>
        /// 3D Model des Mutterschiffes
        /// </summary>
        public static Model MothershipModel
        {
            get;
            set;
        }

        /// <summary>
        /// Kugelförmige Hitbox eines 3D Alienschiffes
        /// </summary>
        public static ModelHitsphere Alien1Hitsphere
        {
            get;
            set;
        }

        /// <summary>
        /// Kugelförmige Hitbox eines 3D Alienschiffes
        /// </summary>
        public static ModelHitsphere Alien2Hitsphere
        {
            get;
            set;
        }

        /// <summary>
        /// Kugelförmige Hitbox eines 3D Alienschiffes
        /// </summary>
        public static ModelHitsphere Alien3Hitsphere
        {
            get;
            set;
        }

        /// <summary>
        /// Kugelförmige Hitbox eines 3D Alienschiffes
        /// </summary>
        public static ModelHitsphere Alien4Hitsphere
        {
            get;
            set;
        }

        /// <summary>
        /// Kugelförmige Hitbox eines 3D Alienschiffes
        /// </summary>
        public static ModelHitsphere Alien5Hitsphere
        {
            get;
            set;
        }

        /// <summary>
        /// Kugelförmige Hitbox des 3D Mutterschiffs
        /// </summary>
        public static ModelHitsphere MothershipHitsphere
        {
            get;
            set;
        }

        /// <summary>
        /// Kugelförmige Hitbox des 3D Gegner Bosses
        /// </summary>
        public static ModelHitsphere BossHitsphere
        {
            get;
            set;
        }

        /// <summary>
        /// Textur des Standardprojektils des Spielers und der Aliens
        /// </summary>
        /// <remarks>
        /// Durch Färben der Hintergrundfläche können unterschiedliche Projektile
        /// für Spieler und Alien erstellt werden.
        /// </remarks>
        public static Texture2D ProjectileNormal
        {
            get;
            set;
        }

        /// <summary>
        /// Textur des PowerUps
        /// </summary>
        public static Texture2D PowerUp
        {
            get;
            set;
        }

        /// <summary>
        /// Textur der Schilde
        /// </summary>
        public static Texture2D ShieldTexture
        {
            get;
            set;
        }

        /// <summary>
        /// Textur des PiercingShot Projektils des Spielers
        /// </summary>
        public static Texture2D ProjectilePiercing
        {
            get;
            set;
        }

        /// <summary>
        /// Textur des Mutterschiffprojektils
        /// </summary>
        public static Texture2D MothershipProjectile
        {
            get;
            set;
        }

        /// <summary>
        /// Textur des Projektils vom gegnerischen Boss
        /// </summary>
        public static Texture2D BossProjectile
        {
            get;
            set;
        }

        /// <summary>
        /// Kugelförmige Hitbox der 3D Schilde
        /// </summary>
        public static ModelHitsphere ShieldHitsphere
        {
            get;
            set;
        }

        /// <summary>
        /// Introvideo
        /// </summary>
        public static Video IntroVideo
        {
            get;
            set;
        }

        /// <summary>
        /// Textur der Explosion
        /// </summary>
        public static Texture2D ExplosionTextures
        {
            get;
            set;
        }

        /// <summary>
        /// Glitzertextur des PowerUps
        /// </summary>
        public static Texture2D PowerUpGlowTexture
        {
            get;
            set;
        }

        /// <summary>
        /// Textur für den Antrieb der Raumschiffe
        /// </summary>
        public static Texture2D EngineTexture
        {
            get;
            set;
        }

        /// <summary>
        /// Sound Effekt der PiercingShot Waffe des Spielers
        /// </summary>
        public static SoundEffect WeaponEffectPiercingshot
        {
            get;
            set;
        }

        /// <summary>
        /// Sound der Multishot Waffe des Spielers
        /// </summary>
        public static SoundEffect WeaponEffectMultishot
        {
            get;
            set;
        }

        /// <summary>
        /// Sound Effekt des vorbeifliegenden Kamikaze Aliens
        /// </summary>
        public static SoundEffect AlienKamikazeEffect
        {
            get;
            set;
        }

        /// <summary>
        /// Sound Effekt des vorbeifliegenden Mutterschiffs
        /// </summary>
        public static SoundEffect AlienMothershipEffect
        {
            get;
            set;
        }

        /// <summary>
        /// Grafik die Anzeigt welches PowerUp gerade activiert ist
        /// </summary>
        public static Texture2D PowerUpIcon
        {
            get;
            set;
        }

        public static ModelHitsphere ProjectileNormalHitsphere
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public static ModelHitsphere ProjectilePiercingHitsphere
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public static ModelHitsphere ProjectileBossHitsphere
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
        /// Lädt den Content aus der GameManager Klasse in die ViewContent Klasse
        /// </summary>
        public static void LoadContent(ContentManager Content)
        {
            GameBackgroundImage = Content.Load<Texture2D>("Images/InGame_Hintergrund");
            MenuBackgroundImage = Content.Load<Texture2D>("Images/Menü_Hintergrund");
            ProjectileNormal = Content.Load<Texture2D>("Graphics/Projektil");
        }

        /// <summary>
        /// Berechnet die kugelförmigen Hitboxen der 3D Modelle
        /// </summary>
        public static void ComputeHitspheres()
        {
            PlayerHitsphere = computeBigModelHitsphere(PlayerModel);
            Alien1Hitsphere = computeBigModelHitsphere(Alien1Model);
            Alien2Hitsphere = computeBigModelHitsphere(Alien2Model);
            Alien3Hitsphere = computeBigModelHitsphere(Alien3Model);
            Alien4Hitsphere = computeBigModelHitsphere(Alien4Model);
            Alien5Hitsphere = computeBigModelHitsphere(Alien5Model);
            MothershipHitsphere = computeBigModelHitsphere(MothershipModel);
            ShieldHitsphere = computeBigTextureHitsphere(ShieldTexture);
            ProjectileNormalHitsphere = computeBigTextureHitsphere(ProjectileNormal);
            //<WAHL>
            //ProjectilePiercingHitsphere = computeBigTextureHitsphere(ProjectilePiercing);
            //BossHitsphere = computeBigModelHitsphere(BossModel);
            //ProjectileBossHitsphere = computeBigTextureHitsphere(BossProjectile);
            //</WAHL>

        }

        /// <summary>
        /// Erstellt anhand eines 3D Models eine Hitbox, die das komplette Model umgibt.
        /// </summary>
        /// <param name="model3D">Model von dem die Hitbox zu berechnen ist.</param>
        /// <returns>Hitbox für das 3D Model</returns>
        private static ModelHitsphere computeBigModelHitsphere(Model model3D)
        {
            double maxRadius = 0;
            foreach (ModelMesh mesh in model3D.Meshes)
            {
                //Mesh-Mittelpunkt
                Vector3 meshCenter = mesh.BoundingSphere.Center;

                //Vektornorm für den Abstand des Mesh-Mittelpunkt zum Model-Mittelpunkt
                //(laut "http://sharky.bluecog.co.nz/?p=119" ist der Mesh-Mittelpunkt relativ zum Model-Mittelpunkt)
                double centerDistance = Math.Sqrt(Math.Pow(meshCenter.X, 2.0) + Math.Pow(meshCenter.Y, 2.0) + Math.Pow(meshCenter.Z, 2.0));

                //möglicher Radius für die Hitbox, anhand des Abstands zum Model-Zentrum und dem Radius der Hitbox um das Mesh
                double possibleRadius = centerDistance + mesh.BoundingSphere.Radius;

                if (possibleRadius > maxRadius)
                {
                    maxRadius = possibleRadius;
                }
            }

            return new ModelHitsphere((int)maxRadius, new List<ModelHitsphere>());
        }

        /// <summary>
        ///  Erstellt anhand einer 2D Grafik eine Hitbox, welche die komplette Grafik umgibt.
        /// </summary>
        /// <param name="graphic">Grafik von der die Hitbox zu berechnen ist.</param>
        /// <returns>Hitbox für die 2D Grafik</returns>
        private static ModelHitsphere computeBigTextureHitsphere(Texture2D graphic)
        {
            //Mittelpunkt der Grafik
            Point center = graphic.Bounds.Center;

            //Obere linke Ecke der Grafik, welche die Position bestimmt
            Point location = graphic.Bounds.Location;
            double maxRadius = Math.Sqrt(Math.Pow(center.X - location.X, 2.0) + Math.Pow(center.Y - location.Y, 2.0));

            return new ModelHitsphere((int)maxRadius, new List<ModelHitsphere>());
        }
    }
}
