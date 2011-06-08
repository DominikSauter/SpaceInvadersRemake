using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace SpaceInvadersRemake.View
{
    /// <summary>
    /// Diese Klasse verwaltet alle für den aktuellen Spielzustand benötigten View Objekte.
    /// Die Ezeugung der Objekte wird durch Events gesteuert. Sobald die <c>draw()</c> Methode in der State Machine aufgerufen
    /// wird, wird die Liste mit den View Objekten durchgegangen und bei jedem Objekt die <c>draw()</c> Methode aufgerufen.
    /// </summary>
    class ViewManager : SpaceInvadersRemake.StateMachine.IView
    {
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
        public void CreatePlayer()
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
        public void CreateAlien()
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
        public void CreateMothership()
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
        public void CreateMiniboss()
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
        public void CreateShield()
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
        public void CreateProjectile()
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
        public void CreatePowerUp()
        {
            throw new System.NotImplementedException();
        }
    }
}
