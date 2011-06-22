//Implementiert von Dodo
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
        public static RepresentationContent RepresentationContent
        {
            get;
            set;
        }

        public static UIContent UIContent
        {
            get;
            set;
        }

        public static EffectContent EffectContent
        {
            get;
            set;
        }

        /// <summary>
        /// Lädt den Content aus der GameManager Klasse in die ViewContent Klasse
        /// </summary>
        public static void LoadContent(ContentManager Content)
        {
            //instanziieren der Content "Behälter"
            UIContent = new UIContent();
            EffectContent = new EffectContent();
            RepresentationContent = new RepresentationContent();

            //Laden des UI Contents
            UIContent.Font = Content.Load<SpriteFont>("Fonts/testfont");
            UIContent.GameBackgroundImage = Content.Load<Texture2D>("Images/InGame_Hintergrund");
            UIContent.MenuBackgroundImage = Content.Load<Texture2D>("Images/Menü_Hintergrund");
            UIContent.HUDBackground = Content.Load<Texture2D>("Graphics/hud_32x60");
            UIContent.LiveIcon = Content.Load<Texture2D>("Graphics/LebensIcon");
            UIContent.MenuButton = Content.Load<Texture2D>("Menu/button");
            UIContent.SettingsBackground = Content.Load<Texture2D>("Menu/einstellungsfenster");
            UIContent.SettingsButton = Content.Load<Texture2D>("Menu/auswahl");
            UIContent.SettingsArrowLeft = Content.Load<Texture2D>("Menu/pfeil_links");
            UIContent.SettingsArrowLeftEnd = Content.Load<Texture2D>("Menu/pfeil_links_ende");
            UIContent.SettingsArrowRight = Content.Load<Texture2D>("Menu/pfeil_rechts");
            UIContent.SettingsArrowRightEnd = Content.Load<Texture2D>("Menu/pfeil_rechts_ende");

            //Laden des Representation Contents
            RepresentationContent.ProjectileNormal = Content.Load<Texture2D>("Graphics/Projektil");
            RepresentationContent.ShieldTexture = Content.Load<Texture2D>("Graphics/Schild_TextureAtlas");

            //Laden des EffectContents
        }

        /// <summary>
        /// Berechnet die kugelförmigen Hitboxen der 3D Modelle
        /// </summary>
        public static void ComputeHitspheres()
        {
            //Berechnen der Hitboxen / Laden des Representation Contents
             RepresentationContent.PlayerHitsphere = computeBigModelHitsphere(RepresentationContent.PlayerModel);
             RepresentationContent.AlienHitsphere = computeBigModelHitsphere(RepresentationContent.AlienModel);
             RepresentationContent.MothershipHitsphere = computeBigModelHitsphere(RepresentationContent.MothershipModel);
             RepresentationContent.ShieldHitsphere = computeBigTextureHitsphere(RepresentationContent.ShieldTexture);
             RepresentationContent.ProjectileNormalHitsphere = computeBigTextureHitsphere(RepresentationContent.ProjectileNormal);
            //<WAHL>
            //RepresentationContent.BossHitsphere = computeBigModelHitsphere(RepresentationContent.BossModel);
            //RepresentationContent.ProjectilePiercingHitsphere = computeBigTextureHitsphere(RepresentationContent.ProjectilePiercing);
            //RepresentationContent.ProjectileBossHitsphere = computeBigTextureHitsphere(RepresentationContent.ProjectileBoss);
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
            BoundingSphere finalSphere = new BoundingSphere(Vector3.Zero, 0.0f);
            BoundingSphere tmpSphere;
            foreach (ModelMesh mesh in model3D.Meshes)
            {
                tmpSphere = mesh.BoundingSphere;
                finalSphere = BoundingSphere.CreateMerged(finalSphere, tmpSphere);
            }

            return new ModelHitsphere(finalSphere);
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
            float maxRadius = (float)Math.Sqrt((center.X - location.X) * (center.X - location.X) + (center.Y - location.Y)*(center.Y - location.Y));
            return new ModelHitsphere(new BoundingSphere(Vector3.Zero, maxRadius));
        }
    }
}
