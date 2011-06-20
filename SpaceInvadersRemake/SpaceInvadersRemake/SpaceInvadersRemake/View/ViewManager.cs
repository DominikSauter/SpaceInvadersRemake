using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

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
        //Random Generator um zufällige AlienRepresentations zu erstellen.
        private Random random;

        /// <summary>
        /// Erzeugt abhängig vom aktuellen Zustand in der <c>StateMachine</c> das passende
        /// ViewManager-Objekt
        /// </summary>
        /// 
        /// <param name="currentState">Aktueller Zustand der <c>StateMachine</c> anhand dessen die passende
        /// UI erstellt wird.</param>
        /// 
        /// <remarks>
        /// Die <c>ViewItemList</c> wird initialisiert und das passende UI Objekt hinzugefügt (GameUI, HighscoreUI, MenuUI).
        /// </remarks>
        public ViewManager(StateMachine.State currentState)
        {
            this.ViewItemList = new List<IView>();

            //abhängig vom State wird hier die UI geladen.
            if (currentState is StateMachine.InGameState)
            {
                //erzeugen einer neuen GameUI. PowerUpIcons werden auf null gesetzt da Wahl.
                this.ViewItemList.Add(new GameUI(ViewContent.UIContent.Font, ViewContent.UIContent.GameBackgroundImage,
                                                ViewContent.UIContent.HUDBackground, null));
                this.EffectPlayer = new SoundEffects(ViewContent.EffectContent.PowerUpSound, ViewContent.EffectContent.ExplosionSound,
                                                    ViewContent.EffectContent.WeaponPlayer, ViewContent.EffectContent.WeaponPiercingshot,
                                                    ViewContent.EffectContent.WeaponMultishot, ViewContent.EffectContent.MothershipSound);
            }
            else if (currentState is StateMachine.IntroState)
            {
            }
            else if (currentState is StateMachine.HighscoreState)
            {
            }
            else
            {
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
        
        //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
        //GEHT DAS MIT DEM TYP?? -> GIBT JEDENFALLS KEINEN COMPILEFEHLER!
        //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
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
            throw new System.NotImplementedException();
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
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Soundeffekt sowie Anstosspunkt für die Explosions-PartikelEngine, wenn eine Representation zerstört wird.
        /// </summary>
        /// <param name="gameItem">Ereignissender</param>
        /// <param name="e">Ereignis Argumente</param>
        public void ExplosionFX(object gameItem, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Soundeffekt wenn ein "Kamikaze"-Alien sein Spezialmanöver startet.
        /// </summary>
        /// <param name="alien">Ereignissender</param>
        /// <param name="e">Ereignis Argumente</param>
        public void KamikazeSFX(object alien, EventArgs e)
        {
            throw new System.NotImplementedException();
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
        public PlayerRepresentation CreatePlayer(object player, EventArgs e)
        {
            throw new System.NotImplementedException();
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
        public AlienRepresentation CreateAlien(Object alien, EventArgs e)
        {
            throw new System.NotImplementedException();
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
        public MothershipRepresentation CreateMothership(object mothership, EventArgs e)
        {
            throw new System.NotImplementedException();
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
        public MinibossRepresentation CreateMiniboss(Object miniboss, EventArgs e)
        {
            throw new System.NotImplementedException();
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
        public ShieldRepresentation CreateShield(object shield, EventArgs e)
        {
            throw new System.NotImplementedException();
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
        public ProjectileRepresentation CreateProjectile(object projectile, EventArgs e)
        {
            throw new System.NotImplementedException();
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
        public PowerUpRepresentation CreatePowerUp(object powerUp, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Erstellt eine GameUI-Objekt und fügt dieses in die ViewItemList ein.
        /// </summary>
        /// <returns>GameUI-Objekt, welches die Spieleroberfläche darstellt.</returns>
        public GameUI CreateGameUI()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Erstellt eine HighscoreUI-Objekt und fügt dieses in die ViewItemList ein.
        /// </summary>
        /// <returns>HighscoreUI-Objekt, welches die Highscoreansicht darstellt.</returns>
        public HighscoreUI CreateHighscoreUI()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Erstellt eine MenuUI-Objekt und fügt dieses in die ViewItemList ein.
        /// </summary>
        /// <returns>MenuUI-Objekt, welches das Menu darstellt.</returns>
        public MenuUI CreateMenuUI()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Iteriert über die gesamte Liste <c>ViewItemList</c> und ruft die <c>Update()</c> bzw. <c>Draw()</c> Methoden auf.
        /// </summary>
        /// <param name="game">XNA Game Klasse</param>
        /// <param name="gameTime">Spielzeit</param>
        /// <param name="state">aktueller Zustand in dem sich die StateMachine befindet.</param>
        public void Update(Game game, GameTime gameTime, StateMachine.State state)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Erledigt Aufräumarbeiten, wenn der aktuelle State endgültig beendet wird.
        /// </summary>
        /// <remarks>
        /// Löschen von Objekten aus der ViewItemList um den Bildschirm zu "säubern".
        /// </remarks>
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
