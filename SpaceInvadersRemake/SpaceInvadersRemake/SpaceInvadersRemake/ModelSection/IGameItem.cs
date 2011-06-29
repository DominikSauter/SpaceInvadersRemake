using Microsoft.Xna.Framework;

// Implementiert von Tobias

namespace SpaceInvadersRemake.ModelSection
{
    /// <summary>
    /// Dieses Interface muss von allen spielrelevanten Klassen implementiert werden.
    /// </summary>
    public interface IGameItem
    {

        /// <summary>
        /// Die aktuelle Position
        /// </summary>
        Vector2 Position
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
        /// Der Schaden, die einem anderen GameItem zugefügt wird
        /// </summary>
        int Damage
        {
            get;
            set;
        }

        /// <summary>
        /// Zeigt an ob das Objekt gelöscht werden kann.
        /// </summary>
        bool IsAlive
        {
            get;
            set;
        }

        /// <summary>
        /// Das begrenzende Volumen (Kugel) des Objekts für die Kollisionsberechnung
        /// </summary>
        IBoundingVolume BoundingVolume
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
        /// <param name="gameTime">Spielzeit</param>
        /// <returns>Boole'scher Wert, der angibt ob die Bewegung ohne Probleme durchgeführt werden konnte. <c>true</c>: erfolg; <c>false</c>: es gab Probleme</returns>
        bool Move(Vector2 direction, GameTime gameTime);

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
        void IsCollidedWith(IGameItem collisionPartner);

        /// <summary>
        /// In dieser Methode werden alle Werte aktualisiert, die nicht durch einen Controller beeinflusst werden können.
        /// </summary>
        /// <param name="gameTime">Spielzeit</param>
        void Update(GameTime gameTime);

        /// <summary>
        /// Teilt dem Objekt mit, dass es versuchen soll zu schießen.
        /// </summary>
        /// <remarks>
        /// Wenn das Objekt nicht schießen kann, dann geschieht nichts.
        /// </remarks>
        /// <param name="gameTime">Spielzeit</param>
        void Shoot(GameTime gameTime);

        /// <summary>
        /// Überladung der <c>Shoot</c>-Methode, für den Fall, dass in eine bestimmte Richtung gechossen werden soll
        /// </summary>
        /// <param name="gameTime">Spielzeit</param>
        /// <param name="direction">gewünschte Schussrichtung</param>
        void Shoot(GameTime gameTime, Vector2 direction);
    }
}
