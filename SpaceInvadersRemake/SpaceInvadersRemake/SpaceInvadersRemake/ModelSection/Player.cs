﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

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
            Hitpoints = 1;
            Weapon = new PlayerNormalWeapon();
            ActivePowerUps.Clear();
            Velocity = baseVelocity;
            Position = startPosition;
        }

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

        public override bool Move(Vector2 direction)
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

        public override void IsCollidedWith(IGameItem collisionPartner)
        {
            throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
            //TODO: PowerUp-System im Wahlteil hinzufügen
        }

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
        /// <param name="powerUpIcons">Das neue PowerUps</param>
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
        /// <param name="lives">Anzahl Leben</param>
        /// <param name="weapon">Startwaffe</param>
        public Player(Vector2 position, Vector2 velocity, int hitpoints, Weapon weapon, int lives)
            : base(position, velocity, hitpoints, weapon)
        {
            this.startPosition = position;
            this.baseVelocity = velocity;
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
        /// <param name="enemy">Gegner der das Event ausgelöst hat</param>
        /// <param name="e">EventArgs werden nich verwendet</param>
        public void AddScore(Object sender, EventArgs e)
        {
            Enemy enemy = (Enemy)sender;

            Score += enemy.ScoreGain;
        }
    }
}
