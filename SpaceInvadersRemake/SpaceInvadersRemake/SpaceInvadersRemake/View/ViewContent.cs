//Implementiert von Dodo
using System.Collections.Generic;

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
        /// Utilityobjekt für alle Models, Texturen, etc., die zum Darstellen der Spielobjekte benötigt werden.
        /// </summary>
        public static RepresentationContent RepresentationContent
        {
            get;
            set;
        }

        /// <summary>
        /// Utilityobjekt für alle Grafiken und Texturen, die zum Darstellen der Spieloberflächen benötigt werden.
        /// </summary>
        public static UIContent UIContent
        {
            get;
            set;
        }

        /// <summary>
        /// Utilityobjekt für alle Grafiken und Texturen, die zum Darstellen von Grafik- und Soundeffekten benötigt werden.
        /// </summary>
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
            //Schriften
            UIContent.Font = Content.Load<SpriteFont>("Fonts/FontText");
            UIContent.FontScore = Content.Load<SpriteFont>("Fonts/FontScore");
            UIContent.FontSelect = Content.Load<SpriteFont>("Fonts/FontSelect");
            //Hintergrundbilder
            UIContent.GameBackgroundImage = Content.Load<Texture2D>("Images/InGame_Hintergrund");
            UIContent.MenuBackgroundImage = Content.Load<Texture2D>("Images/Menü_Hintergrund");
            UIContent.StarAnimation = Content.Load<Texture2D>("Images/Sterne");
            //UI Grafiken
            UIContent.HUDBackground = Content.Load<Texture2D>("Graphics/hud_32x50");
            UIContent.LiveIcon = Content.Load<Texture2D>("Graphics/LebensIcon");
            UIContent.MenuButton = Content.Load<Texture2D>("Menu/button");
            UIContent.SettingsBackground = Content.Load<Texture2D>("Menu/einstellungsfenster");
            UIContent.SettingsButton = Content.Load<Texture2D>("Menu/auswahl_pfeile");
            //Titelgrafik
            UIContent.GameTitle = Content.Load<Texture2D>("Menu/GameTitle"); //[Anji]
            //UI PowerUp Icons
            UIContent.SpeedUpIcon = Content.Load<Texture2D>("Graphics/SpeedUp");
            UIContent.SlowMotionIcon = Content.Load<Texture2D>("Graphics/SlowMotion");
            UIContent.MultishotIcon = Content.Load<Texture2D>("Graphics/MultiShot");
            UIContent.PiercingShotIcon = Content.Load<Texture2D>("Graphics/PiercingShot");
            UIContent.RapidFireIcon = Content.Load<Texture2D>("Graphics/RapidFire");

            //Laden des Representation Contents
            //2D Grafiken
            RepresentationContent.ProjectileNormal = Content.Load<Texture2D>("Graphics/Projektil");
            RepresentationContent.ProjectilePiercing = Content.Load<Texture2D>("Graphics/Projektil_Piercing");
            RepresentationContent.ShieldTexture = Content.Load<Texture2D>("Graphics/Schild_TextureAtlas");
            //3D Models
            RepresentationContent.AlienModel = Content.Load<Model>("3D Models/Alienschiff");
            RepresentationContent.PlayerModel = Content.Load<Model>("3D Models/Spielerschiff");
            RepresentationContent.MothershipModel = Content.Load<Model>("3D Models/Mutterschiff");
            //3D Model Texturen
            RepresentationContent.PlayerTexture = Content.Load<Texture2D>("3D Model Textures/Spieler");
            RepresentationContent.MothershipTexture = Content.Load<Texture2D>("3D Model Textures/Mutterschiff");
            RepresentationContent.PowerUpTextureWeapon = Content.Load<Texture2D>("3D Model Textures/BoxTexturWeapon");
            RepresentationContent.PowerUpTextureUtility = Content.Load<Texture2D>("3D Model Textures/BoxTexturUtility");
            RepresentationContent.PowerUp = Content.Load<Model>("3D Models/PowerUp");
            //Projektilfarben
            RepresentationContent.PlayerProjektileColor = new Vector3(0, 255, 0);
            RepresentationContent.AlienProjektileColor = new Vector3(255, 0, 0);
            RepresentationContent.PlayerPiercingShotProjektileColor = new Vector3(0, 234, 255);

            /*
             * <WAHL>
             * [Dodo] wollte es nicht löschen
            RepresentationContent.MothershipProjektileColor = new Vector3(255, 0, 3);
            RepresentationContent.BossProjektileColor = new Vector3(255, 0, 0);
             * */

            /*
             * Schleife zum Laden der Alientexturen. Diese sind/müssen mit "AlienTextur#" benannt sein
             * wobei # die Nummer der Textur ist.
             * */
            for (int texCount = 1; texCount <= 6; texCount++)
            {
                string path = "3D Model Textures/AlienTextur" + texCount.ToString();
                RepresentationContent.AlienTextures.Add(Content.Load<Texture2D>(path));
            }
            
            /*
             * <WAHL>
             * Wird benötigt wenn ein Boss-Gegner implementiert wird.
             * 
             * RepresentationContent.BossModel = Content.Load<Model>("3D Models/Minibossschiff");
             * */

            //Laden des EffectContents
            //Video
            EffectContent.IntroVideo = Content.Load<Video>("Videos/Intro");
            //Hintergrundmusik
            EffectContent.MenuSong = Content.Load<Song>("Music/Menü");
            EffectContent.GameSong = Content.Load<Song>("Music/Spiel1");
            //Soundeffekte
            EffectContent.WeaponPlayer = Content.Load<SoundEffect>("Soundeffects/Laser_Spieler_Normal");
            EffectContent.WeaponEnemy = Content.Load<SoundEffect>("Soundeffects/Laser_Alien_Normal");
            EffectContent.MothershipSound = Content.Load<SoundEffect>("Soundeffects/Mutterschiff");
            EffectContent.ShieldHit = Content.Load<SoundEffect>("Soundeffects/SchildTreffer1");
            EffectContent.EnemyHit = Content.Load<SoundEffect>("Soundeffects/Treffer1");
            EffectContent.PlayerHit = Content.Load<SoundEffect>("Soundeffects/Treffer2");
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
            RepresentationContent.ProjectilePiercingHitsphere = computeBigTextureHitsphere(RepresentationContent.ProjectilePiercing);
            RepresentationContent.PowerUpHitsphere = computeBigModelHitsphere(RepresentationContent.PowerUp);
            
            /*
             * <WAHL>
             * Wird benötigt wenn ein Boss-Gegner implementiert wird.
             * 
             * RepresentationContent.BossHitsphere = computeBigModelHitsphere(RepresentationContent.BossModel);
             * RepresentationContent.ProjectileBossHitsphere = computeBigTextureHitsphere(RepresentationContent.ProjectileBoss);
             * */

        }

        /// <summary>
        /// Erstellt anhand eines 3D Models eine Hitsphere, die das komplette Model umgibt.
        /// </summary>
        /// <param name="model3D">Model von dem die Hitsphere zu berechnen ist.</param>
        /// <returns>Hitsphere für das 3D Model</returns>
        private static ModelHitsphere computeBigModelHitsphere(Model model3D)
        {
            System.Diagnostics.Debug.Assert(model3D != null, "Die Referenz auf das 3D Model ist nicht vorhanden!");
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
            System.Diagnostics.Debug.Assert(graphic != null, "Die Referenz auf die 2D Textur ist nicht vorhanden!");
            //Berechnen einer halben Diagonalen der Textur
            Vector2 corner = new Vector2(graphic.Width/2.0f, graphic.Height/2.0f);
            //Konvertierung von 2D in 3D
            Vector3 corner2 = PlaneProjector.Convert2DTo3D(corner);
            //Vektornorm bilden um den Radius der Hitsphere zu bestimmen
            float radius = corner2.Length();

            return new ModelHitsphere(new BoundingSphere(Vector3.Zero, radius));
        }
    }
}
