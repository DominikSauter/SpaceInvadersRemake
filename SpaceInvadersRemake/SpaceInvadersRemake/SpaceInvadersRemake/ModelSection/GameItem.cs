
using Microsoft.Xna.Framework;
using System.Collections.Generic;
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
        protected abstract void Destroy();

        /// <summary>
        /// </summary>
        public Vector2 Position
        {
            get;
            set;
        }

        /// <summary>
        /// </summary>
        public Vector2 Velocity
        {
            get;
            set;
        }

        /// <summary>
        /// </summary>
        public int Hitpoints
        {
            get;
            set;
        }

        /// <summary>
        /// </summary>
        public bool IsAlive
        {
            get;
            set;
        }

        /// <summary>
        /// </summary>
        /// <param name="direction"></param>
        public virtual bool Move(Vector2 direction)
        {
            // Standardmäßig Rückgabe von false, um bei Klassen, die nicht von einem Controller bewegt werden können Schreibarbeit zu sparen
            return false;
        }

        /// <summary>
        /// </summary>
        /// <param name="collisionPartner"></param>
        public abstract void IsCollidedWith(IGameItem collisionPartner);

        /// <summary>
        /// </summary>
        /// <param name="gameTime"></param>
        public virtual void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            // Leerer Methodenrumpf, um bei Klassen, die sich nicht selbst aktualisieren müssen Schreibarbeit zu sparen
        }

        /// <summary>
        /// </summary>
        public virtual void Shoot(GameTime gameTime)
        {
            // Leerer Methodenrumpf, um bei Klassen, die nicht von einem Controller kontrolliert werden können Schreibarbeit zu sparen
        }

        public virtual void Shoot(GameTime gameTime, Vector2 direction)
        {
            // Leerer Methodenrumpf, um bei Klassen, die nicht von einem Controller kontrolliert werden können Schreibarbeit zu sparen
        }

        /// <summary>
        /// In dieser Liste werden alle Spielobjekte verwaltet. Jedes Spielobjekt fügt sich selbst in seinem Konstruktor zu dieser Liste hinzu.
        /// </summary>
        /// <remarks>
        /// Muss am Anfang eines Spiels neu erzeugt und am Ende gelöscht werden
        /// </remarks>
        public static LinkedList<IGameItem> GameItemList
        {
            get;
            set;
        }

        /// <summary>
        /// </summary>
        public IBoundingVolume BoundingVolume
        {
            get;
            set;
        }

    }
}
