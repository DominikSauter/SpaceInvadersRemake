using System;
using Microsoft.Xna.Framework;

// Implementiert von Tobias

namespace SpaceInvadersRemake.ModelSection
{
    /// <summary>
    /// Diese Klasse dient zur Erstellung sich selbst bewegender Projektile.
    /// </summary>
    public class Projectile : GameItem
    {

        /// <summary>
        /// Gibt die Flugrichtung des Projektils an, d.h. die Verschiebung in X- und Y-Richtung.
        /// </summary>
        public Vector2 FlightDirection
        {
            get;
            set;
        }

        /// <summary>
        /// Gibt die Art des Projektils für die Darstellung in der View an.
        /// </summary>
        public ProjectileTypeEnum ProjectileType
        {
            get;
            private set;
        }

        /// <summary>
        /// Wird geworfen, wenn ein neues Projektil erstellt wird.
        /// </summary>
        public static event EventHandler Created;

        /// <summary>
        /// Wird geworfen, wenn ein Projektil zerstört wird.
        /// </summary>
        public static event EventHandler Destroyed;

        /// <summary>
        /// Wird geworfen, wenn ein Projektil mit einem anderen Spielobjekt kollidiert.
        /// </summary>
        public static event EventHandler Hit;

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
        public override void IsCollidedWith(IGameItem collisionPartner)
        {
            // Projektile können mit Schilden und, je nachdem was für ein Projektiltyp es ist, mit bestimmten Schiffen kollidieren

            if ((collisionPartner is Shield)
                // Wenn der Kollisionspartner ein Gegner ist, muss es sich um ein Spielerprojektil handeln
                || ((collisionPartner is Enemy) && ((ProjectileType == ProjectileTypeEnum.PlayerNormalProjectile) || (ProjectileType == ProjectileTypeEnum.PiercingProjectile)))
                // Wenn der Kollisionspartner ein Spieler ist, muss es sich um ein gegnerisches Projektil handel
                || ((collisionPartner is Player) && ((ProjectileType == ProjectileTypeEnum.EnemyNormalProjectile) || (ProjectileType == ProjectileTypeEnum.MothershipProjectile) || (ProjectileType == ProjectileTypeEnum.MinibossProjectile))))
            {
                if (Projectile.Hit != null)
                    Projectile.Hit(this, EventArgs.Empty);
                Hitpoints -= collisionPartner.Damage;
            }
        }

        /// <summary>
        /// Bewirkt das Bewegen des Projektils in Richtung "FlightDirection" in Abhängigkeit von "VelocityMultiplier".
        /// </summary>
        /// <remarks>"VelocityMultiplier" ist eine Modifikation für "FlightDirection", welche auf "Position" addiert wird, um die Bewegung zu simulieren.</remarks>
        public override void Update(GameTime gameTime)
        {
            // Normalisieren der Flugrichtung
            FlightDirection.Normalize();

            // Bewegt das Projektil mit seiner Geschwindigkeit in die gewünschte Richtung. TimeFactor bewirkt Zeitlupeneffekt
            Position += FlightDirection * Velocity * (float)gameTime.ElapsedGameTime.TotalSeconds * GameItem.TimeFactor;

            // Wenn das Projektil das Spielfeld verlässt (mit Puffer, damit es besser aussieht), dann wird es zerstört.
            if ((Position.X < 2.0f * CoordinateConstants.LeftBorder) || (Position.X > 2.0f * CoordinateConstants.RightBorder)
                || (Position.Y < 2.0f * CoordinateConstants.BottomBorder) || (Position.Y > 2.0f * CoordinateConstants.TopBorder))
            {
                // Das Destroyed-Event soll dabei nicht ausgelöst werden. Deshalb wird IsAlive direkt auf false gesetzt.
                IsAlive = false;
            }
        }

        /// <summary>
        /// Erstellt ein Projektil
        /// </summary>
        /// <param name="position">Position</param>
        /// <param name="flightDirection">Flugrichtung</param>
        /// <param name="projectileType">Art des Projektils</param>
        /// <param name="hitpoints">Lebenspunkte</param>
        /// <param name="velocity">maximale Geschwindigkeit</param>
        /// <param name="damage">Schaden, der anderen zugefügt wird</param>
        public Projectile(Vector2 position, Vector2 flightDirection, ProjectileTypeEnum projectileType, int hitpoints, Vector2 velocity, int damage)
            : base(position, velocity, hitpoints, damage)
        {
            this.ProjectileType = projectileType;
            this.FlightDirection = flightDirection;
            this.FlightDirection.Normalize();

            if (Projectile.Created != null)
                Projectile.Created(this, EventArgs.Empty);
        }

        /// <summary>
        /// Diese Methode wird aufgerufen, wenn die Lebenspunkte auf den Wert 0 oder darunter sinken.
        /// Sie sorgt dafür, dass das <c>Destroyed</c>-Event ausgelöst wird.
        /// </summary>
        protected override void Destroy()
        {
            IsAlive = false;

            if (Projectile.Destroyed != null)
                Projectile.Destroyed(this, EventArgs.Empty);
        }
    }
}
