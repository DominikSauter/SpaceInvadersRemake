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
        /// Sie sorgt dafür, dass das <c>Destroyed</c>-Event ausgelöst wird.
        /// </summary>
        protected virtual void Destroy()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
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
        /// </summary>
        /// <param name="direction"></param>
        public virtual void Move(Microsoft.Xna.Framework.Vector2 direction)
        {
            throw new System.NotImplementedException();
}

        /// <summary>
        /// </summary>
        /// <param name="collisionPartner"></param>
        public abstract void IsCollidedWith(IGameItem collisionPartner);

        /// <summary>
        /// </summary>
        /// <param name="gameTime"></param>
        public abstract void Update(Microsoft.Xna.Framework.GameTime gameTime);

        /// <summary>
        /// </summary>
        public virtual void Shoot()
        {
            throw new System.NotImplementedException();
}

        /// <summary>
        /// In dieser Liste werden alle Spielobjekte verwaltet. Jedes Spielobjekt fügt sich selbst in seinem Konstruktor zu dieser Liste hinzu.
        /// </summary>
        /// <remarks>
        /// Muss am Anfang eines Spiels neu erzeugt und am Ende gelöscht werden
        /// </remarks>
        public static System.Collections.Generic.LinkedList<SpaceInvadersRemake.ModelSection.IGameItem> GameItemList
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
