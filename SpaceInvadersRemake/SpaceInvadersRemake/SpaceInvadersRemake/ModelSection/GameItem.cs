using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvadersRemake.ModelSection
{
    /// <summary>
    /// Diese abstrakte Klasse ist die Überklasse von allen spielrelevanten Objekten.
    /// </summary>
    public abstract class GameItem : IGameItem
    {

        /// <summary>
        /// Diese Methode wird aufgerufen, wenn die Lebenspunkte auf den Wert 0 oder darunter sinken.
        /// </summary>
        protected void Destroy()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Die aktuelle position
        /// </summary>
        public Microsoft.Xna.Framework.Vector2 Position
        {
            get
            {
                throw new System.NotImplementedException();
}

            set { }
          }

        /// <summary>
        /// Die aktuelle Geschwindigkeit
        /// </summary>
        public Microsoft.Xna.Framework.Vector2 Velocity
        {
            get
            {
                throw new System.NotImplementedException();
}

            set { }
        }

        /// <summary>
        /// Die Lebenspunkte des Objekts
        /// </summary>
        public int Hitpoints
        {
            get
            {
                throw new System.NotImplementedException();
}

            set { }

        }

        /// <summary>
        /// Zeigt an ob das Objekt noch nicht zerstört ist oder ob es gelöscht werden kann.
        /// </summary>
        public bool IsAlive
        {
            get
            {
                throw new System.NotImplementedException();
}

            set { }
        }

        /// <summary>
        /// Bewegt das Objekt in die gewünschte Richtung
        /// </summary>
        /// <param name="direction">Bewegungsrichtung</param>
        public abstract void Move(Microsoft.Xna.Framework.Vector2 direction);

        /// <summary>
        /// Diese Methode wird bei einer Kollision mit einem anderen Objekt aufgerufen.
        /// </summary>
        /// <param name="collisionPartner">Das GameItem mit die Kollision stattfand.</param>
        public abstract void IsCollidedWith(IGameItem collisionPartner);

        /// <summary>
        /// In dieser Methode wird alles geupdatet, was nicht durch einen Controllers beeinflusst werden kann.
        /// </summary>
        /// <param name="gameTime">Spielzeit</param>
        public abstract void Update(Microsoft.Xna.Framework.GameTime gameTime);

        /// <summary>
        /// Teilt dem Objekt mit, dass es versuchen soll zu schießen
        /// </summary>
        public virtual void Shoot()
        {
            throw new System.NotImplementedException();
}

        /// <summary>
        /// In dieser Liste werden alle Spielobjekte verwaltet.
        /// </summary>
        /// <remarks>Muss am Anfang eines Spiels neu erzeugt und am Ende gelöscht werden</remarks>
        public static List<IGameItem> GameItemList
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
        /// Das begrenzende Volumen (Kugel) des Objekts
        /// </summary>
        public ModelHitsphere ModelHitsphere
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

    }
}
