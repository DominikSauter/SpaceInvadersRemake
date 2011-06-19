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
        public static SpaceInvadersRemake.RepresentationContent RepresentationContent
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public static SpaceInvadersRemake.UIContent UIContent
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public static SpaceInvadersRemake.EffectContent EffectContent
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
            //instanziieren der Content "Behälter"
            UIContent = new UIContent();
            EffectContent = new EffectContent();
            RepresentationContent = new RepresentationContent();

            //Laden des UI Contents
            UIContent.GameBackgroundImage = Content.Load<Texture2D>("Images/InGame_Hintergrund");
            UIContent.MenuBackgroundImage = Content.Load<Texture2D>("Images/Menü_Hintergrund");
            UIContent.HUDBackground = Content.Load<Texture2D>("Graphics/hud_32x60");
            UIContent.MenuButton = Content.Load<Texture2D>("Menu/button");
            UIContent.SettingsBackground = Content.Load<Texture2D>("Menu/einstellungsfenster");
            UIContent.SettingsButton = Content.Load<Texture2D>("Menu/auswahl");
            UIContent.SettingsArrowLeft = Content.Load<Texture2D>("Menu/pfeil_links");
            UIContent.SettingsArrowLeftEnd = Content.Load<Texture2D>("Menu/pfeil_links_ende");
            UIContent.SettingsArrowRight = Content.Load<Texture2D>("Menu/pfeil_rechts");
            UIContent.SettingsArrowRightEnd = Content.Load<Texture2D>("Menu/pfeil_rechts_ende");

            //Laden des Representation Contents
            RepresentationContent.ProjectileNormal = Content.Load<Texture2D>("Graphics/Projektil");
            RepresentationContent.ShieldTexture = Content.Load<Texture2D>("Graphics/Schild");

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
