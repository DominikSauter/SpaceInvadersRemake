using Microsoft.Xna.Framework;
using System.Collections.Generic;

// Implementiert von Tobias

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
        /// Die aktuelle Position
        /// </summary>
        public Vector2 Position
        {
            get;
            set;
        }

        /// <summary>
        /// Die maximale Geschwindigkeit
        /// </summary>
        /// <remarks>
        /// Da diese Eigenschaft die maximale Geschwindigkeit angibt, müssen die x- und y-Werte nichtnegativ sein.
        /// </remarks>
        public Vector2 Velocity
        {
            get;
            set;
        }

        private int hitpoints;

        /// <summary>
        /// Die Lebenspunkte des Objekts
        /// </summary>
        public int Hitpoints
        {
            get
            {
                return hitpoints;
            }
            set
            {
                hitpoints = value;
                if (hitpoints <= 0)
                    Destroy();
            }
        }

        /// <summary>
        /// Der Schaden, die einem anderen GameItem zugefügt wird
        /// </summary>
        public int Damage
        {
            get;
            set;
        }

        /// <summary>
        /// Zeigt an ob das Objekt gelöscht werden kann.
        /// </summary>
        public bool IsAlive
        {
            get;
            set;
        }

        /// <summary>
        /// Bewegt das Objekt in die gewünschte Richtung, dabei werden die x- und die y-Komponente mit denen der maximalen Geschwindigkeit multipliziert.
        /// </summary>
        /// <remarks>
        /// Der übergebene Richtungsvektor wird vor der Multiplikation normalisiert.
        /// </remarks>
        /// <param name="direction">Bewegungsrichtung</param>
        /// <returns>Boole'scher Wert, der angibt ob die Bewegung ohne Probleme durchgeführt werden konnte. <c>true</c>: erfolg; <c>false</c>: es gab Probleme</returns>
        public virtual bool Move(Vector2 direction)
        {
            // Standardmäßig Rückgabe von false, um bei Klassen, die nicht von einem Controller bewegt werden können Schreibarbeit zu sparen
            return false;
        }

        /// <summary>
        /// Diese Methode wird bei einer Kollision mit einem anderen Objekt aufgerufen. 
        /// Innerhalb der Methode wird der Schaden am übergebenen Objekt berechnet,
        /// oder PowerUps angewendet. Außerdem wird das <c>Hit</c>-Event ausgelöst.
        /// </summary>
        /// <remarks>
        /// Bei der Kollisionsprüfung wird nur verhindert, dass zwei gleichartige Objekte kollidieren. 
        /// Deshalb muss in dieser Methode geprüft werden, ob eine Kollision mit dem übergebenen Objekt überhaupt sinnvoll ist.
        /// </remarks>
        /// <param name="collisionPartner">Das GameItem mit dem die Kollision stattfand.</param>
        public abstract void IsCollidedWith(IGameItem collisionPartner);

        /// <summary>
        /// In dieser Methode werden alle Werte aktualisiert, die nicht durch einen Controller beeinflusst werden können.
        /// </summary>
        /// <param name="gameTime">Spielzeit</param>
        public virtual void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            // Leerer Methodenrumpf, um bei Klassen, die sich nicht selbst aktualisieren müssen Schreibarbeit zu sparen
        }

        /// <summary>
        /// Teilt dem Objekt mit, dass es versuchen soll zu schießen.
        /// </summary>
        /// <remarks>
        /// Wenn das Objekt nicht schießen kann, dann geschieht nichts.
        /// </remarks>
        /// <param name="gameTime">Spielzeit</param>
        public virtual void Shoot(GameTime gameTime)
        {
            // Leerer Methodenrumpf, um bei Klassen, die nicht von einem Controller kontrolliert werden können Schreibarbeit zu sparen
        }

        /// <summary>
        /// Überladung der <c>Shoot</c>-Methode, für den Fall, dass in eine bestimmte Richtung gechossen werden soll
        /// </summary>
        /// <param name="gameTime">Spielzeit</param>
        /// <param name="direction">gewünschte Schussrichtung</param>
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
        /// Das begrenzende Volumen (Kugel) des Objekts für die Kollisionsberechnung
        /// </summary>
        public IBoundingVolume BoundingVolume
        {
            get;
            set;
        }

        /// <summary>
        /// Konstruktor in der Basisklasse um redundanten Code zu vermeiden.
        /// </summary>
        /// <remarks>
        /// Setzt alle Grundeigenschaften des GameItems (außer BoundingVolume; wird von View gesetzt)
        /// und fügt es der GameItemList hinzu.
        /// </remarks>
        /// <param name="position">StartPosition</param>
        /// <param name="velocity">Maximale Geschwindigkeit</param>
        /// <param name="hitpoints">Lebenspunkte</param>
        /// <param name="damage">Schaden der anderen zugefügt wird</param>
        public GameItem(Vector2 position, Vector2 velocity, int hitpoints, int damage)
        {
            this.Position = position;
            this.Velocity = velocity;
            this.Hitpoints = Hitpoints;
            this.Damage = damage;
            this.IsAlive = true;

            GameItem.GameItemList.AddLast(this);
        }
    }
}
