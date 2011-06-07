using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace SpaceInvadersRemake.ModelSection
{
    /// <summary>
    /// Dieses Interface muss von allen spielrelevanten Klassen implementiert werden.
    /// </summary>
    public interface IGameItem
    {

        /// <summary>
        /// Die aktuelle position
        /// </summary>
        Vector2 Position
        {
            get;
            set;
        }

        /// <summary>
        /// Die aktuelle Geschwindigkeit
        /// </summary>
        Vector2 Velocity
        {
            get;
            set;
        }

        /// <summary>
        /// Die Lebenspunkte des Objekts
        /// </summary>
        int Hitpoints
        {
            get;
            set;
        }

        /// <summary>
        /// Zeigt an ob das Objekt noch nicht zerstört ist oder ob es gelöscht werden kann.
        /// </summary>
        bool IsAlive
        {
            get;
            set;
        }

        /// <summary>
        /// Das begrenzende Volumen (Kugel) des Objekts
        /// </summary>
        ModelHitsphere ModelHitsphere
        {
            get;
            set;
        }

        /// <summary>
        /// Bewegt das Objekt in die gewünschte Richtung
        /// </summary>
        /// <param name="direction">Bewegungsrichtung</param>
        void Move(Vector2 direction);

        /// <summary>
        /// Diese Methode wird bei einer Kollision mit einem anderen Objekt aufgerufen.
        /// </summary>
        /// <param name="collisionPartner">Das GameItem mit die Kollision stattfand.</param>
        void IsCollidedWith(IGameItem collisionPartner);

        /// <summary>
        /// In dieser Methode wird alles geupdatet, was nicht durch einen Controller beeinflusst werden kann.
        /// </summary>
        /// <param name="gameTime">Spielzeit</param>
        void Update(GameTime gameTime);

        /// <summary>
        /// Teilt dem Objekt mit, dass es versuchen soll zu schießen
        /// </summary>
        void Shoot();
    }
}
