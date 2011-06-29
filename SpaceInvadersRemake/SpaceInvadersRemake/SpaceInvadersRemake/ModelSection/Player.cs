using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

// Implementiert von Tobias

namespace SpaceInvadersRemake.ModelSection
{
    /// <summary>
    /// Diese Klasse stellt ein Spielerraumschiff dar, das von einem Benutzer kontrolliert werden soll.
    /// </summary>
    public class Player : Ship
    {

        /// <summary>
        /// Feld zum Speichern der Grundgeschwindigkeit des Spielers
        /// </summary>
        private Vector2 baseVelocity;

        /// <summary>
        /// Feld zum Speichern der Startposition des Spielers
        /// </summary>
        private Vector2 startPosition;

        /// <summary>
        /// Feld zum Speichern der Grundlebenspunkte des Spielers
        /// </summary>
        private int baseHitpoints;

        /// <summary>
        /// Die aktuelle Punktzahl des Spielers
        /// </summary>
        public int Score
        {
            get;
            private set;
        }

        /// <summary>
        /// Die verbleibenden Leben (Versuche) des Spielers. Wenn der Wert 0 erreicht wird, wird <c>IsAlive</c> 
        /// auf <c>false</c> gesetzt.
        /// </summary>
        public int Lives
        {
            get;
            private set;
        }

        /// <summary>
        /// Setzt den Spieler zurück, wenn er ein Leben verloren hat.
        /// </summary>
        public void Reset()
        {
            Hitpoints = baseHitpoints;
            Weapon = new PlayerNormalWeapon();
            //ActivePowerUps.Clear();
            Velocity = baseVelocity;
            Position = startPosition;
        }

        /// <summary>
        /// Diese Methode wird aufgerufen, wenn die Lebenspunkte auf den Wert 0 oder darunter sinken.
        /// Sie sorgt dafür, dass das <c>Destroyed</c>-Event ausgelöst wird.
        /// </summary>
        protected override void Destroy()
        {
            Lives--;

            if (Lives <= 0)
            {
                IsAlive = false;

                Alien.ScoreGained -= AddScore;
                Mothership.ScoreGained -= AddScore;
                Miniboss.ScoreGained -= AddScore;
            }
            else
            {
                Reset();
            }

            if (Player.Destroyed != null)
                Player.Destroyed(this, EventArgs.Empty);
        }

        /// <summary>
        /// Dieses Event wird ausgelöst, wenn ein Objekt der Klasse mit einem anderen Objekt kollidiert ist.
        /// </summary>
        public static event EventHandler Hit;

        /// <summary>
        /// Dieses Event wird ausgelöst, wenn ein Objekt der Klasse zerstört wurde, d.h. dessen Lebenspunkte auf 0 gesunken sind.
        /// </summary>
        public static event EventHandler Destroyed;

        /// <summary>
        /// Bewegt das Objekt in die gewünschte Richtung, dabei werden die x- und die y-Komponente mit denen der maximalen Geschwindigkeit multipliziert.
        /// </summary>
        /// <remarks>
        /// Der übergebene Richtungsvektor wird vor der Multiplikation normalisiert.
        /// </remarks>
        /// <param name="direction">Bewegungsrichtung</param>
        /// <param name="gameTime">Spielzeit</param>
        /// <returns>Boole'scher Wert, der angibt ob die Bewegung ohne Probleme durchgeführt werden konnte. <c>true</c>: erfolg; <c>false</c>: es gab Probleme</returns>
        public override bool Move(Vector2 direction, GameTime gameTime)
        {
            direction.Normalize();

            Position += Velocity * direction;

            if (Position.X < CoordinateConstants.LeftBorder)
            {
                Position = new Vector2(CoordinateConstants.LeftBorder, startPosition.Y);
            }

            if (Position.X > CoordinateConstants.RightBorder)
            {
                Position = new Vector2(CoordinateConstants.RightBorder, startPosition.Y);
            }

            return true;
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
        public override void IsCollidedWith(IGameItem collisionPartner)
        {
            // Spieler können mit gegnerischen Projektilen und Schiffen kollidieren
            // Außerdem auch mit PowerUps, ab das kommt erst im Wahlteil

            if (!(collisionPartner is Enemy) && !(collisionPartner is Projectile))
                return;

            if (collisionPartner is Projectile)
            {
                Projectile projectile = (Projectile)collisionPartner;
                if ((projectile.ProjectileType == ProjectileTypeEnum.PlayerNormalProjectile)
                    || (projectile.ProjectileType == ProjectileTypeEnum.PiercingProjectile))
                    return;
            }

            // Wenn der Programmfluss hier ankommt gibt es eine Kollision
            if (Player.Hit != null)
                Player.Hit(this, EventArgs.Empty);
            Hitpoints -= collisionPartner.Damage;

            //TODO: Kollision mit PowerUps ermöglichen
        }


        /// <summary>
        /// In dieser Methode werden alle Werte aktualisiert, die nicht durch einen Controller beeinflusst werden können.
        /// </summary>
        /// <param name="gameTime">Spielzeit</param>
        public override void Update(GameTime gameTime)
        {
            //TODO: PowerUp-System im Wahlteil hinzufügen
        }

        /// <summary>
        /// Teilt dem Objekt mit, dass es versuchen soll zu schießen.
        /// </summary>
        /// <remarks>
        /// Wenn das Objekt nicht schießen kann, dann geschieht nichts.
        /// </remarks>
        /// <param name="gameTime">Spielzeit</param>
        public override void Shoot(GameTime gameTime)
        {
            Weapon.Fire(Position, CoordinateConstants.Up, gameTime);
        }

        /// <summary>
        /// Dieses Event wird ausgelöst, wenn ein neues Objekt dieser Klasse erzeugt wurde.
        /// </summary>
        public static event EventHandler Created;

        /// <summary>
        /// Fügt der Liste der aktiven PowerUps ein neues PowerUps hinzu. Dabei wird das <c>Apply</c>-Delegate des übegebenen <c>ActivePowerUp</c>s ausgelöst.
        /// </summary>
        /// <remarks>
        /// Wenn bereits ein gleiches <c>ActivePowerUp</c> in der Liste ist, wird dieses gelöscht ohne das <c>Remove-</c>Delegate auszulösen.
        /// Für weitere Informationen sollten unbedingt die Hinweise zur PowerUps-Liste <c>ActivePowerUps</c> beachtet werden.
        /// </remarks>
        /// <param name="powerUp">Das neue PowerUps</param>
        public void AddPowerUp(ActivePowerUp powerUp)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Eine Liste der derzeit aktiven PowerUps des Spielers. Ihr werden in der <c>AddPowerUp</c>-Methode Elemente hinzugefügt.
        /// In der <c>Update</c>-Methode wird bei allen aktiven PowerUps die Restzeit aktualisiert und diese gegebenenfalls entfernt, 
        /// wenn die Restzeit auf null oder darunter gefallen ist.
        /// </summary>
        /// <remarks>Wird der Liste ein PowerUps hinzugefügt, wird dessen <c>Apply</c>-Delegate aufgerufen (in der <c>AddPowerUp</c>-Methode).
        /// Beim Entfernen aus der Liste wird das <c>Remove</c>-Delegate aufgerufen (in der <c>Update</c>-Methode). Ausnahme ist, 
        /// wenn ein weiteres Waffen-PowerUps hinzugefügt wird oder ein PowerUps, das bereits aktiv ist. 
        /// In diesem Fall wird das vorher aktive Waffen-PowerUps entfernt ohne <c>Remove</c> aufzurufen.
        /// </remarks>
        public List<ActivePowerUp> ActivePowerUps
        {
            get;
            private set;
        }

        /// <summary>
        /// Erzeugt einen Spieler
        /// </summary>
        /// <param name="position">Startposition</param>
        /// <param name="velocity">maximale Geschwindigkeit</param>
        /// <param name="hitpoints">Lebenspunkte</param>
        /// <param name="damage">Schaden, der anderen zugefügt wird</param>
        /// <param name="lives">Anzahl Leben</param>
        /// <param name="weapon">Startwaffe</param>
        public Player(Vector2 position, Vector2 velocity, int hitpoints, int damage, Weapon weapon, int lives)
            : base(position, velocity, hitpoints, damage, weapon)
        {
            this.startPosition = position;
            this.baseVelocity = velocity;
            this.baseHitpoints = hitpoints;
            this.Lives = lives;

            ActivePowerUps = null; //TODO: PowerUps-Liste initialisieren

            Alien.ScoreGained += AddScore;
            Mothership.ScoreGained += AddScore;
            Miniboss.ScoreGained += AddScore;

            if (Player.Created != null)
                Player.Created(this, EventArgs.Empty);
        }

        /// <summary>
        /// Fügt der Punktzahl des Spielers Punkte hinzu. Wird verwendet um sich am <c>ScoreGained</c>-Event der Gegner-Klassen anzumelden.
        /// </summary>
        /// <param name="sender">Gegner der das Event ausgelöst hat</param>
        /// <param name="e">EventArgs werden nich verwendet</param>
        public void AddScore(Object sender, EventArgs e)
        {
            Enemy enemy = (Enemy)sender;

            Score += enemy.ScoreGain;
        }
    }
}
