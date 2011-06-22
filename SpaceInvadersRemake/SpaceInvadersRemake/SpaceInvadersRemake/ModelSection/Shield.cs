using System;
using Microsoft.Xna.Framework;

namespace SpaceInvadersRemake.ModelSection
{
    /// <summary>
    /// Diese Klasse stellt ein Schild dar, das den Spieler vor feindlichem Beschuss schützt, 
    /// aber auch seine eigenen Projektile aufhält.
    /// </summary>
    public class Shield : GameItem
    {

        /// <summary>
        /// Dieses Event wird ausgelöst, wenn ein Objekt der Klasse mit einem anderen Objekt kollidiert ist.
        /// </summary>
        public static event EventHandler Hit;

        /// <summary>
        /// Dieses Event wird ausgelöst, wenn ein Objekt der Klasse zerstört wurde, d.h. dessen Lebenspunkte auf 0 gesunken sind.
        /// </summary>
        public static event EventHandler Destroyed;

        public override void IsCollidedWith(IGameItem collisionPartner)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Dieses Event wird ausgelöst, wenn ein neues Objekt dieser Klasse erzeugt wurde.
        /// </summary>
        public static event EventHandler Created;

        /// <summary>
        /// Erzeugt ein Schild
        /// </summary>
        /// <param name="position">Position</param>
        /// <param name="hitpoints">Lebenspunkte</param>
        public Shield(Vector2 position, int hitpoints)
            : base(position, Vector2.Zero, hitpoints)
        {
            if (Shield.Created != null)
                Shield.Created(this, EventArgs.Empty);
        }

        protected override void Destroy()
        {
            IsAlive = false;

            if (Shield.Destroyed != null)
                Shield.Destroyed(this, EventArgs.Empty);
        }
    }
}
