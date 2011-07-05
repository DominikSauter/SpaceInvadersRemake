﻿//Implementiert von Dodo
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
            RepresentationContent.AlienTextures = new List<Texture2D>();
            

            //Laden des UI Contents
            UIContent.Font = Content.Load<SpriteFont>("Fonts/testfont");
            UIContent.GameBackgroundImage = Content.Load<Texture2D>("Images/InGame_Hintergrund");
            UIContent.MenuBackgroundImage = Content.Load<Texture2D>("Images/Menü_Hintergrund");
            UIContent.HUDBackground = Content.Load<Texture2D>("Graphics/hud_32x50");
            UIContent.LiveIcon = Content.Load<Texture2D>("Graphics/LebensIcon");
            UIContent.MenuButton = Content.Load<Texture2D>("Menu/button");
            UIContent.SettingsBackground = Content.Load<Texture2D>("Menu/einstellungsfenster");
            UIContent.SettingsButton = Content.Load<Texture2D>("Menu/auswahl_pfeile");
            UIContent.GameTitle = Content.Load<Texture2D>("Menu/GameTitle"); //[Anji]

            //Laden des Representation Contents
            RepresentationContent.ProjectileNormal = Content.Load<Texture2D>("Graphics/Projektil");
            RepresentationContent.ShieldTexture = Content.Load<Texture2D>("Graphics/Schild_TextureAtlas");
            RepresentationContent.AlienModel = Content.Load<Model>("3D Models/Alienschiff");
            RepresentationContent.PlayerModel = Content.Load<Model>("3D Models/Spielerschiff");
            RepresentationContent.MothershipModel = Content.Load<Model>("3D Models/Mutterschiff");
            RepresentationContent.PlayerTexture = Content.Load<Texture2D>("3D Model Textures/Spieler");
            RepresentationContent.MothershipTexture = Content.Load<Texture2D>("3D Model Textures/Mutterschiff");
            RepresentationContent.PowerUp = Content.Load<Model>("3D Models/PowerUp");
            RepresentationContent.PowerUpTextureWeapon = Content.Load<Texture2D>("3D Model Textures/BoxTexturWeapon");
            RepresentationContent.PowerUpTextureUtility = Content.Load<Texture2D>("3D Model Textures/BoxTexturUtility");
            /*
             * Schleife zum Laden der Alientexturen. Diese sind/müssen mit "AlienTextur#" benannt sein
             * wobei # die Nummer der Textur ist.
             * */
            for (int texCount = 1; texCount <= 6; texCount++)
            {
                string path = "3D Model Textures/AlienTextur" + texCount.ToString();
                RepresentationContent.AlienTextures.Add(Content.Load<Texture2D>(path));
            }
            //<WAHL>
            //RepresentationContent.BossModel = Content.Load<Model>("3D Models/Minibossschiff");
            //</WAHL>

            //Laden des EffectContents
            EffectContent.MenuSong = Content.Load<Song>("Music/Menü");
            EffectContent.GameSong = Content.Load<Song>("Music/Spiel1");
            EffectContent.WeaponPlayer = Content.Load<SoundEffect>("Soundeffects/Laser_Spieler_Normal");
            EffectContent.WeaponEnemy = Content.Load<SoundEffect>("Soundeffects/Laser_Alien_Normal");
        }

        /// <summary>
        /// Berechnet die Hitspheres der 3D Modelle
        /// </summary>
        public static void ComputeHitspheres()
        {
            //Berechnen der Hitboxen / Laden des Representation Contents
            RepresentationContent.PlayerHitsphere = computeBigModelHitsphere(RepresentationContent.PlayerModel);
            RepresentationContent.AlienHitsphere = computeBigModelHitsphere(RepresentationContent.AlienModel);
            RepresentationContent.MothershipHitsphere = computeBigModelHitsphere(RepresentationContent.MothershipModel);
            RepresentationContent.ShieldHitsphere = computeBigTextureHitsphere(RepresentationContent.ShieldTexture);
            RepresentationContent.ProjectileNormalHitsphere = computeBigTextureHitsphere(RepresentationContent.ProjectileNormal);
            RepresentationContent.PowerUpHitsphere = computeBigModelHitsphere(RepresentationContent.PowerUp);
            
            //<WAHL>
            //RepresentationContent.BossHitsphere = computeBigModelHitsphere(RepresentationContent.BossModel);
            //RepresentationContent.ProjectilePiercingHitsphere = computeBigTextureHitsphere(RepresentationContent.ProjectilePiercing);
            //RepresentationContent.ProjectileBossHitsphere = computeBigTextureHitsphere(RepresentationContent.ProjectileBoss);
            //</WAHL>

        }

        /// <summary>
        /// Erstellt anhand eines 3D Models eine Hitsphere, die das komplette Model umgibt.
        /// </summary>
        /// <param name="model3D">Model von dem die Hitsphere zu berechnen ist.</param>
        /// <returns>Hitsphere für das 3D Model</returns>
        private static ModelHitsphere computeBigModelHitsphere(Model model3D)
        {
            //Hitsphere, welche das gesamte Model umgibt
            BoundingSphere finalSphere = new BoundingSphere(Vector3.Zero, 0.0f);
            BoundingSphere tmpSphere;

            //Es werden die BoundingSphere's alle Meshes zusammengeführt um am Ende die finale Hitsphere zu bekommen.
            foreach (ModelMesh mesh in model3D.Meshes)
            {
                tmpSphere = mesh.BoundingSphere;
                finalSphere = BoundingSphere.CreateMerged(finalSphere, tmpSphere);
            }

            return new ModelHitsphere(finalSphere);
        }

        /// <summary>
        ///  Erstellt anhand einer 2D Grafik eine Hitsphere, welche die komplette Grafik umgibt.
        /// </summary>
        /// <param name="graphic">Grafik von der die Hitsphere zu berechnen ist.</param>
        /// <returns>Hitsphere für die 2D Grafik</returns>
        private static ModelHitsphere computeBigTextureHitsphere(Texture2D graphic)
        {
            //Mittelpunkt der Grafik
           /* Point center = graphic.Bounds.Center;

            //Obere linke Ecke der Grafik, welche die Position bestimmt
            Point location = graphic.Bounds.Location;
            float maxRadius = (float)Math.Sqrt((center.X - location.X) * (center.X - location.X) + (center.Y - location.Y)*(center.Y - location.Y));
            return new ModelHitsphere(new BoundingSphere(Vector3.Zero, maxRadius));*/

            Vector2 corner2 = new Vector2(graphic.Width/2.0f, graphic.Height/2.0f);
            Vector3 corner3 = PlaneProjector.Convert2DTo3D(corner2);

            float radius = corner3.Length();

            return new ModelHitsphere(new BoundingSphere(Vector3.Zero, radius));
        }
    }
}
