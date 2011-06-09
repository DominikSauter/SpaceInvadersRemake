using System;
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
        /// Die aktuelle Punktzahl des Spielers
        /// </summary>
        public int Score
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
        /// Die verbleibenden Leben (Versuche) des Spielers. Wenn der Wert 0 erreicht wird, wird "IsAlive" auf "false" gesetzt.
        /// </summary>
        public int Lives
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
        /// Setzt den Spieler zurück, wenn er ein Leben verloren hat.
        /// </summary>
        public void Reset()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Diese Methode wird aufgerufen, wenn die Lebenspunkte auf den Wert 0 oder darunter sinken.
        /// </summary>
        protected override void Destroy()
        {
            throw new NotImplementedException();
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
        /// Bewegt das Objekt in die gewünschte Richtung
        /// </summary>
        /// <param name="direction">Bewegungsrichtung</param>
        public override void Move(Vector2 direction)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Diese Methode wird bei einer Kollision mit einem anderen Objekt aufgerufen.
        /// </summary>
        /// <param name="collisionPartner">Das GameItem mit die Kollision stattfand.</param>
        public override void IsCollidedWith(IGameItem collisionPartner)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// In dieser Methode wird alles geupdatet, was nicht durch einen Controllers beeinflusst werden kann.
        /// </summary>
        /// <param name="gameTime">Spielzeit</param>
        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Teilt dem Objekt mit, dass es versuchen soll zu schießen
        /// </summary>
        public override void Shoot()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Dieses Event wird ausgelöst, wenn ein neues Objekt dieser Klasse erzeugt wurde.
        /// </summary>
        public static event EventHandler Created;

        /// <summary>
        /// Fügt der Liste der aktiven PowerUps ein neues PowerUp hinzu
        /// </summary>
        /// <remarks>Unbedingt die Kommentare zur PowerUp-Liste "ActivePowerUps" beachten</remarks>
        /// <param name="powerUpIcons">Das neue PowerUp</param>
        public void AddPowerUp(ActivePowerUp powerUp)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Eine Liste der derzeit aktiven PowerUps des Spielers
        /// </summary>
        /// <remarks>Wird der Liste ein PowerUp hinzugefügt, wird dessen "Apply"-Delegate aufgerufen. Beim Entfernen aus der Liste wird das "Remove"-Delegate aufgerufen. Ausname ist, wenn ein weiteres Waffen-PowerUp hinzugefügt wird. In diesem Fall wird das vorher aktive Waffen-PowerUp entfernt ohne "Remove" aufzurufen.</remarks>
        public List<ActivePowerUp> ActivePowerUps
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
        /// Erzeugt einen Spieler
        /// </summary>
        /// <param name="position">Startposition</param>
        /// <param name="velocity">Geschwindigkeit</param>
        /// <param name="lives">Anzahl Leben</param>
        /// <param name="weapon">Startwaffe</param>
        public Player(Vector2 position, Vector2 velocity, int lives, Weapon weapon)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Fügt der Punktzahl des Spielers Punkte hinzu. Wird verwendet um sich am "ScoreGained"-Event der Gegner anzumelden.
        /// </summary>
        /// <param name="enemy">Gegner der das Event ausgelöst hat</param>
        /// <param name="e">EventArgs werden nich verwendet</param>
        public void AddScore(Object enemy, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}
