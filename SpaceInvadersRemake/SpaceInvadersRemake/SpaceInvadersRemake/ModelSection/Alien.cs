using System;
using Microsoft.Xna.Framework;

// Implementiert von Tobias

namespace SpaceInvadersRemake.ModelSection
{
    /// <summary>
    /// Diese Klasse stellt ein einfaches gegnerisches Raumschiff (Alien) dar.
    /// </summary>
    public class Alien : Enemy
    {

        /// <summary>
        /// Dieses Event wird ausgelöst, wenn ein Objekt der Klasse mit einem anderen Objekt kollidiert ist.
        /// </summary>
        public static event EventHandler Hit;

        /// <summary>
        /// Dieses Event wird ausgelöst, wenn ein Objekt der Klasse zerstört wurde, d.h. dessen Lebenspunkte auf 0 gesunken sind.
        /// </summary>
        public static event EventHandler Destroyed;

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
            // Aliens können mit dem Spieler, Spielerprojektilen und Schilden kollidieren

            if (!(collisionPartner is Player)
                && !(collisionPartner is Projectile)
                && !(collisionPartner is Shield))
                return;

            if (collisionPartner is Projectile)
            {
                Projectile projectile = (Projectile)collisionPartner;

                if (!(projectile.ProjectileType == ProjectileTypeEnum.PlayerNormalProjectile)
                    && !(projectile.ProjectileType == ProjectileTypeEnum.PiercingProjectile))
                    return;
            }

            // Wenn der Programmfluss hier ankommt, gibt es eine Kollision.

            if (Alien.Hit != null)
                Alien.Hit(this, EventArgs.Empty);
            Hitpoints -= collisionPartner.Damage;

            if (Hitpoints <= 0)
            {
                if (Alien.ScoreGained != null)
                    Alien.ScoreGained(this, EventArgs.Empty);

                PowerUpGenerator.GeneratePowerUp(PowerUpEnum.Random, Position);
            }
        }

        /// <summary>
        /// Dieses Event wird ausgelöst, wenn ein neues Objekt dieser Klasse erzeugt wurde.
        /// </summary>
        public static event EventHandler Created;

        /// <summary>
        /// Erzeugt ein Alien
        /// </summary>
        /// <param name="position">Startposition</param>
        /// <param name="velocity">maximale Geschwindigkeit</param>
        /// <param name="hitpoints">Lebenspunkte</param>
        /// <param name="damage">Schaden, der anderen zugefügt wird</param>
        /// <param name="weapon">Waffe</param>
        /// <param name="scoreGain">Punktwert des Aliens</param>
        public Alien(Vector2 position, Vector2 velocity, int hitpoints, int damage, Weapon weapon, int scoreGain)
            : base(position, velocity, hitpoints, damage, weapon, scoreGain)
        {
            if (Alien.Created != null)
                Alien.Created(this, EventArgs.Empty);
        }

        /// <summary>
        /// Dieses Event wird ausgelöst, wenn es für einen Abschuss Punkte gibt
        /// </summary>
        public static event EventHandler ScoreGained;

        /// <summary>
        /// Diese Methode wird aufgerufen, wenn die Lebenspunkte auf den Wert 0 oder darunter sinken.
        /// Sie sorgt dafür, dass das <c>Destroyed</c>-Event ausgelöst wird.
        /// </summary>
        protected override void Destroy()
        {
            IsAlive = false;

            if (Alien.Destroyed != null)
                Alien.Destroyed(this, EventArgs.Empty);
        }
    }
}
