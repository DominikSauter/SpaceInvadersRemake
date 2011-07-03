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


                //AUSKOMMENTIERT ZUM AUSFÜHREN!
                //this.EffectPlayer = new SoundEffects();


                this.random = new Random();

                /* Vorläufige Matrizen.
                * Wir müssen noch besprechen wie groß unsre 3D Ebene wird (dementsprechend müssen wir Camera und Projection initialisieren)
                * */
                GameItemRepresentation.Camera = Matrix.CreateLookAt(new Vector3(0.0f, 800.0f, 500.0f), new Vector3(0.0f, 0.0f, 0.0f), Vector3.Up);
                GameItemRepresentation.Projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(60),
                    graphics.PreferredBackBufferWidth / graphics.PreferredBackBufferHeight, 0.1f, 2000.0f);
                
                //registrieren an den events [PFLICHT]
                //created
                Player.Created += CreatePlayer;
                Alien.Created += CreateAlien;
                Mothership.Created += CreateMothership;
                Shield.Created += CreateShield;
                Projectile.Created += CreateProjectile;

                /* [WAHL]
                 * (created)
                 * Miniboss.Created += CreateMiniboss;
                 * PowerUp... += CreatePowerUp;
                 * 
                 * (weaponFired)
                 * PiercingShotWeapon.WeaponFired += ShootSFX;
                 * RapidfireWeapon.WeaponFired += ShootSFX;
                 * MultiShotWeapon.WeaponFired += ShootSFX;
                 * */


                //AUSKOMMENTIERT ZUM AUSFÜHREN!
                //destroyed
                /*Player.Destroyed += ExplosionFX;
                Alien.Destroyed += ExplosionFX;
                Mothership.Destroyed += ExplosionFX;
                Shield.Destroyed += ExplosionFX;

                //weaponFired
                PlayerNormalWeapon.WeaponFired += ShootSFX;
                 * */

            }
            else if (currentState is StateMachine.IntroState)
            {
                //da nur das Video abgespielt wird, benötigt man keine wirkliche Oberfläche.
                this.EffectPlayer = new Intro();
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
        public IMediaplayer EffectPlayer
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
            EffectPlayer.Play(ViewContent.EffectContent.ExplosionSound);
            //TODO Anbindung der PartikelEngine
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
            this.ViewItemList.Add(new PlayerRepresentation((Player)player));
            ((Player)player).BoundingVolume = ViewContent.RepresentationContent.PlayerHitsphere;
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

            this.ViewItemList.Add(new AlienRepresentation((Alien)alien, randomTexture));
            ((Alien)alien).BoundingVolume = ViewContent.RepresentationContent.AlienHitsphere;
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
            this.ViewItemList.Add(new MothershipRepresentation((Mothership)mothership));
            ((Mothership)mothership).BoundingVolume = ViewContent.RepresentationContent.MothershipHitsphere;
        }

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
            this.ViewItemList.Add(new ShieldRepresentation((Shield) shield, graphics));
            ((Shield)shield).BoundingVolume = ViewContent.RepresentationContent.ShieldHitsphere;
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
            bool player = false;
            Projectile currentProjectile = (Projectile)projectile;
            Texture2D texture = ViewContent.RepresentationContent.ProjectileNormal;

            switch (currentProjectile.ProjectileType)
            {
                case ProjectileTypeEnum.PlayerNormalProjectile: currentProjectile.BoundingVolume = ViewContent.RepresentationContent.ProjectileNormalHitsphere;
                    texture = ViewContent.RepresentationContent.ProjectileNormal;
                    player = true;
                    break;
                case ProjectileTypeEnum.EnemyNormalProjectile: currentProjectile.BoundingVolume = ViewContent.RepresentationContent.ProjectileNormalHitsphere;
                    texture = ViewContent.RepresentationContent.ProjectileNormal;
                    break;
                case ProjectileTypeEnum.PiercingProjectile: currentProjectile.BoundingVolume = ViewContent.RepresentationContent.ProjectilePiercingHitsphere;
                    texture = ViewContent.RepresentationContent.ProjectilePiercing;
                    break;
                case ProjectileTypeEnum.MothershipProjectile: currentProjectile.BoundingVolume = ViewContent.RepresentationContent.ProjectileMothershipHitsphere;
                    texture = ViewContent.RepresentationContent.ProjectileMothership;
                    break;
                case ProjectileTypeEnum.MinibossProjectile: currentProjectile.BoundingVolume = ViewContent.RepresentationContent.ProjectileBossHitsphere;
                    texture = ViewContent.RepresentationContent.ProjectileBoss;
                    break;
            }

            this.ViewItemList.Add(new ProjectileRepresentation((Projectile)projectile, texture, graphics , effect, player));
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
            throw new System.NotImplementedException();
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
            /*
             * Diese Schleife funktioniert auf jedenfall
            for (int listCount = ViewItemList.Count; listCount > 0; listCount--)
            {
                IView item = ViewItemList[listCount - 1];
                if (item is GameItemRepresentation)
                {
                    if (!((GameItemRepresentation)item).GameItem.IsAlive)
                    {
                        this.ViewItemList.Remove(item);
                    }
                }
            }*/

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
                item.Draw(((GameManager)game).spriteBatch);
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
            //abmelden der methoden
            //created
            Player.Created -= CreatePlayer;
            Alien.Created -= CreateAlien;
            Mothership.Created -= CreateMothership;
            Shield.Created -= CreateShield;
            Projectile.Created -= CreateProjectile;

            //destroyed
            Player.Destroyed -= ExplosionFX;
            Alien.Destroyed -= ExplosionFX;
            Mothership.Destroyed -= ExplosionFX;
            Shield.Destroyed -= ExplosionFX;

            //weaponFired
            PlayerNormalWeapon.WeaponFired -= ShootSFX;
            PiercingShotWeapon.WeaponFired -= ShootSFX;
            RapidfireWeapon.WeaponFired -= ShootSFX;
            MultiShotWeapon.WeaponFired -= ShootSFX;

            this.ViewItemList = null;
        }
    }
}
