using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public void Update(Microsoft.Xna.Framework.Game game, Microsoft.Xna.Framework.GameTime gameTime, StateMachine.State state)
        {
            throw new NotImplementedException();
        }

        public void ShootFX()
        {
            throw new System.NotImplementedException();
        }

        public void MothershipFX()
        {
            throw new System.NotImplementedException();
        }

        public void ExplosionFX()
        {
            throw new System.NotImplementedException();
        }

        public void KamikazeFX()
        {
            throw new System.NotImplementedException();
        }

        public void CreatePlayer()
        {
            throw new System.NotImplementedException();
        }

        public void CreateAlien()
        {
            throw new System.NotImplementedException();
        }

        public void CreateMothership()
        {
            throw new System.NotImplementedException();
        }

        public void CreateMiniboss()
        {
            throw new System.NotImplementedException();
        }

        public void CreateShield()
        {
            throw new System.NotImplementedException();
        }

        public void CreateProjectile()
        {
            throw new System.NotImplementedException();
        }

        public void CreatePowerUp()
        {
            throw new System.NotImplementedException();
        }
    }
}
