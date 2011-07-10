//Implementiert von Dodo
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using SpaceInvadersRemake.ModelSection;

namespace SpaceInvadersRemake.View
{
    /// <summary>
    /// Diese Klasse verwaltet alle für den aktuellen Spielzustand benötigten View Objekte.
    /// Die Erzeugung der Objekte wird durch Events gesteuert. Sobald die <c>Draw()</c> Methode in der State Machine aufgerufen
    /// wird, wird die Liste mit den View Objekten durchgegangen und bei jedem Objekt die <c>Draw()</c> Methode aufgerufen.
    /// </summary>
    /// <remarks>
    /// Der <c>ViewManager</c> registriert sich beim Instanziieren bei allen <c>Create</c>-Events um diese später
    /// behandeln zu können.
    /// 
    /// Er registriert auch immer gleichzeitig die passenden View-Methoden an den Model-Objekten (z.B. für Soundeffekte)
    /// </remarks>
    public class ViewManager : SpaceInvadersRemake.StateMachine.IView
    {
        private GraphicsDeviceManager graphics;
        private Random random;
        private BasicEffect effect;

        /// <summary>
        /// Erzeugt abhängig vom aktuellen Zustand in der <c>StateMachine</c> das passende
        /// ViewManager-Objekt
        /// </summary>
        /// 
        /// <param name="currentState">Aktueller Zustand der <c>StateMachine</c> anhand dessen die passende
        /// UI erstellt wird.</param>
        /// <param name="graphics"></param>
        /// 
        /// <remarks>
        /// Die <c>ViewItemList</c> wird initialisiert und das passende UI Objekt hinzugefügt (GameUI, HighscoreUI, MenuUI).
        /// </remarks>
        public ViewManager(StateMachine.State currentState, GraphicsDeviceManager graphics)
        {
            this.ViewItemList = new List<IView>();
            this.graphics = graphics;
            this.effect = new BasicEffect(graphics.GraphicsDevice);


            //abhängig vom State wird hier die UI geladen.
            if (currentState is StateMachine.InGameState)
            {
                //erzeugen einer neuen GameUI. powerUpIcons werden auf null gesetzt da Wahl.
                this.ViewItemList.Add(CreateGameUI(currentState, graphics));

                //initialisieren mit einem SoundEffects-Objekt um Sounds abspielen zu können.
                EffectPlayer = new SoundEffects();

                //initialisieren eines Randomgenerators um den Aliens zufällige Texturen zuweisen zu können.
                this.random = new Random();

                //View und Projection Matrizen für die Sicht auf das Spiel
                GameItemRepresentation.Camera = Matrix.CreateLookAt(new Vector3(0.0f, 800.0f, 500.0f), new Vector3(0.0f, 0.0f, 80.0f), Vector3.Up);
                GameItemRepresentation.Projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(60),
                    graphics.PreferredBackBufferWidth / graphics.PreferredBackBufferHeight, 0.1f, 5000.0f);
                
                //registrieren an den events
                //created
                Player.Created += CreatePlayer;
                Alien.Created += CreateAlien;
                Mothership.Created += CreateMothership;
                Shield.Created += CreateShield;
                Projectile.Created += CreateProjectile;
                PowerUp.Created += CreatePowerUp;
                
                //hit
                Shield.Hit += HitSFX;
                Player.Hit += HitSFX;
                Alien.Hit += HitSFX;
                Mothership.Hit += HitSFX;

                //weaponFired
                PlayerNormalWeapon.WeaponFired += ShootSFX;
                EnemyNormalWeapon.WeaponFired += ShootSFX;

                //TODO weitere Waffensounds
                /* <WAHL>
                 * (created)
                 * Miniboss.Created += CreateMiniboss;
                 * 
                 * (weaponFired)
                 * PiercingShotWeapon.WeaponFired += ShootSFX;
                 * RapidfireWeapon.WeaponFired += ShootSFX;
                 * MultiShotWeapon.WeaponFired += ShootSFX;
                 * */


                //TODO Eventuell noch Explosionssounds
                /* <WAHL>
                 * destroyed
                 * Alien.Destroyed += ExplosionFX;
                 * Mothership.Destroyed += ExplosionFX;
                 * Shield.Destroyed += ExplosionFX;
                 * */

                
            }
            else if (currentState is StateMachine.IntroState)
            {
                //da nur das Video abgespielt wird, benötigt man keine wirkliche Oberfläche.
                EffectPlayer = new Intro(this.graphics, (StateMachine.IntroState)currentState);
                this.ViewItemList.Add((Intro)EffectPlayer);
            }
            else if (currentState is StateMachine.HighscoreState)
            {
                //erzeugen einer HighscoreUI
                this.ViewItemList.Add(CreateHighscoreUI(currentState, graphics));
            }
            else if (currentState is StateMachine.CreditsState)
            {
                //erzeugen einer CreditsUI
                this.ViewItemList.Add(CreateCreditsUI(graphics));
            }
            else if (currentState is StateMachine.AudioOptionsState || currentState is StateMachine.BreakState || currentState is StateMachine.MainMenuState
                    || currentState is StateMachine.OptionsState || currentState is StateMachine.VideoOptionsState)
            {
                //erzeugen einer MenuUI
                this.ViewItemList.Add(CreateMenuUI(currentState, graphics));
            }
        }
        /// <summary>
        /// Liste mit den View Objekten
        /// </summary>
        /// <remarks>
        /// Zum einen werden die dargestellten Model-Representations in die Liste gefügt, zum anderen auch
        /// die GameUI, HighscoreUI und MenuUI.
        /// </remarks>
        public List<IView> ViewItemList
        {
            get;
            private set;
        }

        /// <summary>
        /// Audioplayer um die Soundeffekte wiederzugeben.
        /// </summary>
        public static IMediaplayer EffectPlayer
        {
            get;
            private set;
        }

        /// <summary>
        /// Soundeffekt für das Abfeuern der Spielerwaffe.
        /// </summary>
        /// <param name="weapon">Ereignissender</param>
        /// <param name="e">Ereignis Argumente</param>
        public void ShootSFX(object weapon, EventArgs e)
        {
            if (weapon is PlayerNormalWeapon)
            {
                EffectPlayer.Play(ViewContent.EffectContent.WeaponPlayer);
            }
            else if (weapon is PiercingShotWeapon)
            {
                EffectPlayer.Play(ViewContent.EffectContent.WeaponPiercingshot);
            }
            else if (weapon is MultiShotWeapon)
            {
                EffectPlayer.Play(ViewContent.EffectContent.WeaponMultishot);
            }
            else if (weapon is RapidfireWeapon)
            {
                EffectPlayer.Play(ViewContent.EffectContent.WeaponRapidFire);
            }
            else if (weapon is EnemyNormalWeapon)
            {
                EffectPlayer.Play(ViewContent.EffectContent.WeaponEnemy);
            }
        }

        /// <summary>
        /// Soundeffekt für das Erscheinen des Mutterschiffs.
        /// </summary>
        /// <param name="mothership">Ereignissender</param>
        /// <param name="e">Ereignis Argumente</param>
        /// <remarks>
        /// Eventuell über die komplette Dauer, während das Mutterschiff im Bild ist.
        /// Private Methode, da sie aufgerufen werden kann wenn ein Mutterschiff erstellt wird.
        /// </remarks>
        private void MothershipSFX(object mothership, EventArgs e)
        {
            EffectPlayer.Play(ViewContent.EffectContent.MothershipSound);
        }

        /// <summary>
        /// Soundeffekt sowie Anstosspunkt für die Explosions-PartikelEngine, wenn eine Representation zerstört wird.
        /// </summary>
        /// <param name="gameItem">Ereignissender</param>
        /// <param name="e">Ereignis Argumente</param>
        public void ExplosionFX(object gameItem, EventArgs e)
        {
            /*
             * Solang keine Soundeffekte vorhanden sind, bewirkt diese Methode nichts.
             * EffectPlayer.Play(ViewContent.EffectContent.ExplosionSound);
             * */
            //TODO Anbindung der PartikelEngine
        }

        /// <summary>
        /// Spielt über den EffectPlayer einen Soundeffekt für getroffene Objekte ab
        /// </summary>
        /// <param name="gameItem">Ereignissender</param>
        /// <param name="e">Ereignis Argumente</param>
        public void HitSFX(object gameItem, EventArgs e)
        {
            if (gameItem is Shield)
            {
                EffectPlayer.Play(ViewContent.EffectContent.ShieldHit);
            }
            else if (gameItem is Player)
            {
                EffectPlayer.Play(ViewContent.EffectContent.PlayerHit);
            }
            else
            {
                EffectPlayer.Play(ViewContent.EffectContent.EnemyHit);
            }
        }

        /// <summary>
        /// Behandelt ein Created-Event aus Model. Eine <c>PlayerRepresentation</c> wird erstellt,
        /// und in die Liste eingefügt.
        /// </summary>
        /// <param name="player">Ereignissender</param>
        /// <param name="e">Ereignis Argumente</param>
        /// <remarks>
        /// Beim Erstellen der Representation muss im Model die passendende <c>ModelHitsphere</c> gespeichert werden.
        /// </remarks>
        public void CreatePlayer(object player, EventArgs e)
        {
            PlayerRepresentation playerRepresentation = new PlayerRepresentation((Player)player, this.graphics);
            this.ViewItemList.Add(playerRepresentation);
            ((Player)player).BoundingVolume = new ModelHitsphere(ViewContent.RepresentationContent.PlayerHitsphere);
            ((ModelHitsphere)((Player)player).BoundingVolume).World = playerRepresentation.World;
        }

        /// <summary>
        /// Behandelt ein Created-Event aus Model. Eine <c>AlienRepresentation</c> wird erstellt,
        /// und in die Liste eingefügt.
        /// </summary>
        /// <param name="alien">Ereignissender</param>
        /// <param name="e">Ereignis Argumente</param>
        /// <remarks>
        /// Beim Erstellen der Representation muss im Model die passendende <c>ModelHitsphere</c> gespeichert werden.
        /// </remarks>
        public void CreateAlien(object alien, EventArgs e)
        {
            int randomTexture = this.random.Next(ViewContent.RepresentationContent.AlienTextures.Count);

            AlienRepresentation alienRepresentation = new AlienRepresentation((Alien)alien, randomTexture, this.graphics);
            this.ViewItemList.Add(alienRepresentation);
            ((Alien)alien).BoundingVolume = new ModelHitsphere(ViewContent.RepresentationContent.AlienHitsphere);
            ((ModelHitsphere)((Alien)alien).BoundingVolume).World = alienRepresentation.World;
        }

        /// <summary>
        /// Behandelt ein Created-Event aus Model. Eine <c>MothershipRepresentation</c> wird erstellt,
        /// und in die Liste eingefügt.
        /// </summary>
        /// <param name="mothership">Ereignissender</param>
        /// <param name="e">Ereignis Argumente</param>
        /// <remarks>
        /// Beim Erstellen der Representation muss im Model die passendende <c>ModelHitsphere</c> gespeichert werden.
        /// </remarks>
        public void CreateMothership(object mothership, EventArgs e)
        {
            MothershipRepresentation motherShiprepresentation = new MothershipRepresentation((Mothership)mothership, this.graphics);
            this.ViewItemList.Add(motherShiprepresentation);
            ((Mothership)mothership).BoundingVolume = new ModelHitsphere(ViewContent.RepresentationContent.MothershipHitsphere);
            ((ModelHitsphere)((Mothership)mothership).BoundingVolume).World = motherShiprepresentation.World;

            EffectPlayer.Play(ViewContent.EffectContent.MothershipSound);
        }

        /*
         * <WAHL>
         * 
         * Wird benötigt wenn eine Boss-Gegner implementiert wird.
         * 
        /// <summary>
        /// Behandelt ein Created-Event aus Model. Eine <c>MinibossRepresentation</c> wird erstellt,
        /// und in die Liste eingefügt.
        /// </summary>
        /// <param name="miniboss">Ereignissender</param>
        /// <param name="e">Ereignis Argumente</param>
        /// <remarks>
        /// Beim Erstellen der Representation muss im Model die passendende <c>ModelHitsphere</c> gespeichert werden.
        /// </remarks>
        public void CreateMiniboss(Object miniboss, EventArgs e)
        {
            this.ViewItemList.Add(new MinibossRepresentation());
            ((Miniboss)miniboss).BoundingVolume = ViewContent.RepresentationContent.BossHitsphere;
        }
         * */

        /// <summary>
        /// Behandelt ein Created-Event aus Model. Eine <c>ShieldRepresentation</c> wird erstellt,
        /// und in die Liste eingefügt.
        /// </summary>
        /// <param name="shield">Ereignissender</param>
        /// <param name="e">Ereignis Argumente</param>
        /// <remarks>
        /// Beim Erstellen der Representation muss im Model die passendende <c>ModelHitsphere</c> gespeichert werden.
        /// </remarks>
        public void CreateShield(object shield, EventArgs e)
        {
            //[Anji] Weiterreichen der gameTime  für die Schildanimation
            ShieldRepresentation shieldRepresentation = new ShieldRepresentation((Shield)shield, graphics);
            this.ViewItemList.Add(shieldRepresentation);
            ((Shield)shield).BoundingVolume = new ModelHitsphere(ViewContent.RepresentationContent.ShieldHitsphere);
            ((ModelHitsphere)((Shield)shield).BoundingVolume).World = shieldRepresentation.World;
        }

        /// <summary>
        /// Behandelt ein Created-Event aus Model. Eine <c>projectileRepresentation</c> wird erstellt,
        /// und in die Liste eingefügt.
        /// </summary>
        /// <param name="projectile">Ereignissender</param>
        /// <param name="e">Ereignis Argumente</param>
        /// <remarks>
        /// Beim Erstellen der Representation muss im Model die passendende <c>ModelHitsphere</c> gespeichert werden.
        /// </remarks>
        public void CreateProjectile(object projectile, EventArgs e)
        {
            Vector3 color = new Vector3(255, 255, 255);
            Projectile currentProjectile = (Projectile)projectile;
            Texture2D texture = ViewContent.RepresentationContent.ProjectileNormal;

            switch (currentProjectile.ProjectileType)
            {
                case ProjectileTypeEnum.PlayerNormalProjectile: currentProjectile.BoundingVolume = new ModelHitsphere(ViewContent.RepresentationContent.ProjectileNormalHitsphere);
                    texture = ViewContent.RepresentationContent.ProjectileNormal;
                    color = ViewContent.RepresentationContent.PlayerProjektileColor;
                    break;
                case ProjectileTypeEnum.EnemyNormalProjectile: currentProjectile.BoundingVolume = new ModelHitsphere(ViewContent.RepresentationContent.ProjectileNormalHitsphere);
                    texture = ViewContent.RepresentationContent.ProjectileNormal;
                    color = ViewContent.RepresentationContent.AlienProjektileColor;
                    break;
                case ProjectileTypeEnum.PiercingProjectile: currentProjectile.BoundingVolume = new ModelHitsphere(ViewContent.RepresentationContent.ProjectileNormalHitsphere);
                    texture = ViewContent.RepresentationContent.ProjectileNormal;
                    color = ViewContent.RepresentationContent.PlayerPiercingShotProjektileColor;
                    break;
                /*
                 * <WAHL>
                 * 
                 * Wird benötigt wenn eine Mutterschiffwaffe implementiert wird.
                 * 
                case ProjectileTypeEnum.MothershipProjectile: currentProjectile.BoundingVolume = new ModelHitsphere(ViewContent.RepresentationContent.ProjectileMothershipHitsphere);
                    texture = ViewContent.RepresentationContent.ProjectileMothership;
                    color = ViewContent.RepresentationContent.MothershipProjektileColor;
                    break;
                 * */
                /*
                 * <WAHL>
                 * 
                 * Wird benötigt wenn ein Boss-Gegner implementiert wird.
                 * 
                case ProjectileTypeEnum.MinibossProjectile: currentProjectile.BoundingVolume = new ModelHitsphere(ViewContent.RepresentationContent.ProjectileBossHitsphere);
                    texture = ViewContent.RepresentationContent.ProjectileBoss;
                    color = ViewContent.RepresentationContent.BossProjektileColor;
                    break;
                 * */
            }

            ProjectileRepresentation projectileRepresentation = new ProjectileRepresentation(currentProjectile, texture, graphics, effect, color);
            this.ViewItemList.Add(projectileRepresentation);
            ((ModelHitsphere)(currentProjectile).BoundingVolume).World = projectileRepresentation.World;
        }

        /// <summary>
        /// Behandelt ein Created-Event aus Model. Eine <c>PowerUpRepresentation</c> wird erstellt,
        /// und in die Liste eingefügt.
        /// </summary>
        /// <param name="powerUp">Ereignissender</param>
        /// <param name="e">Ereignis Argumente</param>
        /// <remarks>
        /// Beim Erstellen der Representation muss im Model die passendende <c>ModelHitsphere</c> gespeichert werden.
        /// </remarks>
        public void CreatePowerUp(object powerUp, EventArgs e)
        {
            Texture2D texture;
            PowerUp PowerUpItem = (PowerUp)powerUp;

            if (powerUp is PiercingShot || powerUp is Rapidfire || powerUp is MultiShot)
            {
                texture = ViewContent.RepresentationContent.PowerUpTextureWeapon;
            }
            else //if (powerUp is Speedboost || powerUp is Deflector || powerUp is SlowMotion)
            {
                texture = ViewContent.RepresentationContent.PowerUpTextureUtility;
            }

            PowerUpRepresentation powerUpRepresentation = new PowerUpRepresentation(PowerUpItem, texture, graphics);
            PowerUpItem.BoundingVolume = new ModelHitsphere(ViewContent.RepresentationContent.PowerUpHitsphere);
            this.ViewItemList.Add(powerUpRepresentation);
            ((ModelHitsphere)(PowerUpItem).BoundingVolume).World = powerUpRepresentation.World;
        }

        /// <summary>
        /// Erstellt eine GameUI-Objekt und fügt dieses in die ViewItemList ein.
        /// </summary>
        /// <returns>GameUI-Objekt, welches die Spieleroberfläche darstellt.</returns>
        private GameUI CreateGameUI(StateMachine.State currentState, GraphicsDeviceManager graphics)
        {
            return new GameUI((StateMachine.InGameState)currentState, graphics);
        }

        /// <summary>
        /// Erstellt eine HighscoreUI-Objekt und fügt dieses in die ViewItemList ein.
        /// </summary>
        /// <returns>HighscoreUI-Objekt, welches die Highscoreansicht darstellt.</returns>
        private HighscoreUI CreateHighscoreUI(StateMachine.State currentState, GraphicsDeviceManager graphics)
        {
            return new HighscoreUI(((HighscoreManager)(currentState.Model)), graphics);
        }

        /// <summary>
        /// Erstellt eine MenuUI-Objekt und fügt dieses in die ViewItemList ein.
        /// </summary>
        /// <returns>MenuUI-Objekt, welches das Menu darstellt.</returns>
        private MenuUI CreateMenuUI(StateMachine.State currentState, GraphicsDeviceManager graphics)
        {
            //[Anji] Weiterreichen des currentstates an die MenuUI
            return new MenuUI(((Menu)currentState.Model).Controls, graphics, currentState); 
        }

        /// <summary>
        /// Erstellt ein CreditsUI Objekt und fügt dieses in die ViewItemList ein.
        /// </summary>
        /// <param name="graphics">Handlingobjekt für Grafikeinstellungen</param>
        /// <returns>CreditsUI-Objekt, welches die Credits Oberfläche darstellt.</returns>
        private CreditsUI CreateCreditsUI(GraphicsDeviceManager graphics)
        {
            return new CreditsUI(graphics);
        }

        /// <summary>
        /// Iteriert über die gesamte Liste <c>ViewItemList</c> und ruft die <c>Update()</c> bzw. <c>Draw()</c> Methoden auf.
        /// </summary>
        /// <param name="game">XNA Game Klasse</param>
        /// <param name="gameTime">Spielzeit</param>
        /// <param name="state">aktueller Zustand in dem sich die StateMachine befindet.</param>
        public void Update(Game game, GameTime gameTime, StateMachine.State state)
        {
            GameManager gameMngr = (GameManager)game;
            
            /*
             * RemoveAll entfernt alle Element die die Bedingung im Delegate erfüllen.
             * Dazu wird ein anonymes Deleaget erstellt welches die Bedingungen beinhaltet.
             * */
            this.ViewItemList.RemoveAll(delegate(IView item)
            {
                if (item is GameItemRepresentation)
                {
                    return !((GameItemRepresentation)item).GameItem.IsAlive;
                }
                else
                {
                    return false;
                }
            });

            foreach (IView item in this.ViewItemList)
            {
                if (item is Intro)
                {
                    ((Intro)item).Play(ViewContent.EffectContent.IntroVideo);
                }
                item.Draw(gameMngr.spriteBatch);
            }
        }

        /// <summary>
        /// Erledigt Aufräumarbeiten, wenn der aktuelle State endgültig beendet wird.
        /// </summary>
        /// <remarks>
        /// Löschen von Objekten aus der ViewItemList um den Bildschirm zu "säubern".
        /// </remarks>
        public void Dispose()
        {
            //beenden des EffectPlayers
            EffectPlayer.Stop();

            //abmelden der methoden
            Player.Created -= CreatePlayer;
            Alien.Created -= CreateAlien;
            Mothership.Created -= CreateMothership;
            Shield.Created -= CreateShield;
            Projectile.Created -= CreateProjectile;
            PowerUp.Created -= CreatePowerUp;

            //hit
            Shield.Hit -= HitSFX;
            Player.Hit -= HitSFX;
            Alien.Hit -= HitSFX;
            Mothership.Hit -= HitSFX;

            //weaponFired
            PlayerNormalWeapon.WeaponFired -= ShootSFX;
            EnemyNormalWeapon.WeaponFired -= ShootSFX;

            this.ViewItemList = null;
        }
    }
}
