using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace SpaceInvadersRemake.View
{
    /// <summary>
    /// Diese Klasse verwaltet alle für den aktuellen Spielzustand benötigten View Objekte.
    /// Die Erzeugung der Objekte wird durch Events gesteuert. Sobald die <c>draw()</c> Methode in der State Machine aufgerufen
    /// wird, wird die Liste mit den View Objekten durchgegangen und bei jedem Objekt die <c>draw()</c> Methode aufgerufen.
    /// </summary>
    /// <remarks>
    /// Der <code>ViewManager</code> registriert sich beim Instanziieren bei allen <code>CreateHighscoreUI</code>-Events um diese später
    /// behandeln zu können.
    /// 
    /// Er registriert auch immer gleichzeitig die passenden View-Methoden an den Model-Objekten (z.B. für Soundeffekte)
    /// </remarks>
    class ViewManager : SpaceInvadersRemake.StateMachine.IView
    {
        //Random Generator um zufällige AlienRepresentations zu erstellen.
        private Random random;

        /// <summary>
        /// Erzeugt abhängig vom aktuellen Zustand in der <code>StateMachine</code> das passende
        /// ViewManager-Objekt
        /// </summary>
        /// 
        /// <param name="currentState">Aktueller Zustand der <code>StateMachine</code> anhand dessen die passende
        /// UI erstellt wird.</param>
        /// 
        /// <remarks>
        /// Die <code>ViewItemList</code> wird initialisiert und das passende UI Objekt hinzugefügt (GameUI, HighscoreUI, MenuUI).
        /// </remarks>
        public ViewManager(StateMachine.State currentState)
        {
            throw new System.NotImplementedException();
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
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        /// <summary>
        /// Audioplayer um die Soundeffekte wiederzugeben.
        /// </summary>
        public SoundEffects EffectPlayer
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
        /// Iteriert über die gesamte Liste <code>ViewItemList</code> und ruft die <code>Update() bzw. Draw() Methoden auf</code>.
        /// </summary>
        /// <param name="game">siehe Microsoft-Doc</param>
        /// <param name="gameTime">siehe Microsoft-Doc</param>
        /// <param name="state">aktueller Zustand in dem sich die StateMachine befindet.</param>
        public void Update(Game game, GameTime gameTime, StateMachine.State state)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Soundeffekt für das Abfeuern der Spielerwaffe.
        /// </summary>
        public void ShootSFX()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Soundeffekt für das Erscheinen des Mutterschiffs.
        /// </summary>
        /// <remarks>
        /// Eventuell über die komplette Dauer, während das Mutterschiff im Bild ist.
        /// </remarks>
        public void MothershipSFX()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Soundeffekt sowie Anstosspunkt für die Explosions-PartikelEngine, wenn eine Representation zerstört wird.
        /// </summary>
        public void ExplosionFX()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Soundeffekt wenn ein "Kamikaze"-Alien sein Spezialmanöver startet.
        /// </summary>
        public void KamikazeSFX()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Behandelt ein Created-Event aus Model. Eine <code>PlayerRepresentation</code> wird erstellt,
        /// und in die Liste eingefügt.
        /// </summary>
        /// <remarks>
        /// Beim Erstellen der Representation muss im Model die passendende <code>ModelHitsphere</code> gespeichert werden.
        /// </remarks>
        public PlayerRepresentation CreatePlayer()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Behandelt ein Created-Event aus Model. Eine <code>AlienRepresentation</code> wird erstellt,
        /// und in die Liste eingefügt.
        /// </summary>
        /// <remarks>
        /// Beim Erstellen der Representation muss im Model die passendende <code>ModelHitsphere</code> gespeichert werden.
        /// </remarks>
        public AlienRepresentation CreateAlien()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Behandelt ein Created-Event aus Model. Eine <code>MothershipRepresentation</code> wird erstellt,
        /// und in die Liste eingefügt.
        /// </summary>
        /// <remarks>
        /// Beim Erstellen der Representation muss im Model die passendende <code>ModelHitsphere</code> gespeichert werden.
        /// </remarks>
        public MothershipRepresentation CreateMothership()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Behandelt ein Created-Event aus Model. Eine <code>MinibossRepresentation</code> wird erstellt,
        /// und in die Liste eingefügt.
        /// </summary>
        /// <remarks>
        /// Beim Erstellen der Representation muss im Model die passendende <code>ModelHitsphere</code> gespeichert werden.
        /// </remarks>
        public MinibossRepresentation CreateMiniboss()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Behandelt ein Created-Event aus Model. Eine <code>ShieldRepresentation</code> wird erstellt,
        /// und in die Liste eingefügt.
        /// </summary>
        /// <remarks>
        /// Beim Erstellen der Representation muss im Model die passendende <code>ModelHitsphere</code> gespeichert werden.
        /// </remarks>
        public ShieldRepresentation CreateShield()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Behandelt ein Created-Event aus Model. Eine <code>projectileRepresentation</code> wird erstellt,
        /// und in die Liste eingefügt.
        /// </summary>
        /// <remarks>
        /// Beim Erstellen der Representation muss im Model die passendende <code>ModelHitsphere</code> gespeichert werden.
        /// </remarks>
        public ProjectileRepresentation CreateProjectile()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Behandelt ein Created-Event aus Model. Eine <code>PowerUpRepresentation</code> wird erstellt,
        /// und in die Liste eingefügt.
        /// </summary>
        /// <remarks>
        /// Beim Erstellen der Representation muss im Model die passendende <code>ModelHitsphere</code> gespeichert werden.
        /// </remarks>
        public PowerUpRepresentation CreatePowerUp()
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
    }
}
