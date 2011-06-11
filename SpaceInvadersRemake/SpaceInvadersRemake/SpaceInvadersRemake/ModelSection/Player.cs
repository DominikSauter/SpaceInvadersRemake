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
        /// Die verbleibenden Leben (Versuche) des Spielers. Wenn der Wert 0 erreicht wird, wird <c>IsAlive</c> 
        /// auf <c>false</c> gesetzt.
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

        public override void Move(Vector2 direction)
        {
            throw new NotImplementedException();
        }

        public override void IsCollidedWith(IGameItem collisionPartner)
        {
            throw new NotImplementedException();
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        public override void Shoot()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Dieses Event wird ausgelöst, wenn ein neues Objekt dieser Klasse erzeugt wurde.
        /// </summary>
        public static event EventHandler Created;

        /// <summary>
        /// Fügt der Liste der aktiven PowerUps ein neues PowerUp hinzu. Dabei wird das <c>Apply</c>-Delegate des übegebenen <c>ActivePowerUp</c>s ausgelöst.
        /// </summary>
        /// <remarks>
        /// Wenn bereits ein gleiches <c>ActivePowerUp</c> in der Liste ist, wird dieses gelöscht ohne das <c>Remove-</c>Delegate auszulösen.
        /// Für weitere Informationen sollten unbedingt die Hinweise zur PowerUp-Liste <c>ActivePowerUps</c> beachtet werden.
        /// </remarks>
        /// <param name="powerUpIcons">Das neue PowerUp</param>
        public void AddPowerUp(ActivePowerUp powerUp)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Eine Liste der derzeit aktiven PowerUps des Spielers. Ihr werden in der <c>AddPowerUp</c>-Methode Elemente hinzugefügt.
        /// In der <c>Update</c>-Methode wird bei allen aktiven PowerUps die Restzeit aktualisiert und diese gegebenenfalls entfernt, 
        /// wenn die Restzeit auf null oder darunter gefallen ist.
        /// </summary>
        /// <remarks>Wird der Liste ein PowerUp hinzugefügt, wird dessen <c>Apply</c>-Delegate aufgerufen (in der <c>AddPowerUp</c>-Methode).
        /// Beim Entfernen aus der Liste wird das <c>Remove</c>-Delegate aufgerufen (in der <c>Update</c>-Methode). Ausnahme ist, 
        /// wenn ein weiteres Waffen-PowerUp hinzugefügt wird oder ein PowerUp, das bereits aktiv ist. 
        /// In diesem Fall wird das vorher aktive Waffen-PowerUp entfernt ohne <c>Remove</c> aufzurufen.
        /// </remarks>
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
        /// <param name="velocity">maximale Geschwindigkeit</param>
        /// <param name="lives">Anzahl Leben</param>
        /// <param name="weapon">Startwaffe</param>
        public Player(Vector2 position, Vector2 velocity, int lives, Weapon weapon)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Fügt der Punktzahl des Spielers Punkte hinzu. Wird verwendet um sich am <c>ScoreGained</c>-Event der Gegner-Klassen anzumelden.
        /// </summary>
        /// <param name="enemy">Gegner der das Event ausgelöst hat</param>
        /// <param name="e">EventArgs werden nich verwendet</param>
        public void AddScore(Object enemy, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}
