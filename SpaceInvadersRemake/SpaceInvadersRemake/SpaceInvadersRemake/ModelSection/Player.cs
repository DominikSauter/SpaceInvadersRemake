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
        /// Gibt an wie lange der Spieler noch unverwundbar ist
        /// </summary>
        private float invincibleTime;

        /// <summary>
        /// Gibt an ob der Spieler unverwundbar ist
        /// </summary>
        public bool IsInvincible
        {
            get
            {
                return (invincibleTime > 0.0f);
            }
        }

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
            //Spielerwerte zurücksetzen
            Hitpoints = GameItemConstants.PlayerHitpoints;
            Weapon = GameItemConstants.PlayerWeapon;
            Velocity = GameItemConstants.PlayerVelocity;
            Position = GameItemConstants.PlayerPosition;

            //PowerUpList leeren
            ActivePowerUps.Clear();

            // Spieler für kurze Zeit unverwundbar machen
            invincibleTime = GameItemConstants.PlayerInvincibleTime;
        }

        /// <summary>
        /// Diese Methode wird aufgerufen, wenn die Lebenspunkte auf den Wert 0 oder darunter sinken.
        /// Sie sorgt dafür, dass das <c>Destroyed</c>-Event ausgelöst wird.
        /// </summary>
        protected override void Destroy()
        {
            // Ein Leben abziehen
            Lives--;

            if (Lives <= 0) // Falls Spieler keine Leben mehr hat
            {
                // Spieler zum Löschen markieren
                IsAlive = false;

                // Registrierung am ScoreGained-Event wieder Rückgängig machen, damit der Spieler keine Punkte mehr bekommt
                Alien.ScoreGained -= AddScore;
                Mothership.ScoreGained -= AddScore;
                Miniboss.ScoreGained -= AddScore;
            }
            else // Falls der Spieler noh Leben zur Verfügung hat
            {
                // Spieler zurücksetzen
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
            // Bewegungsrichtung normalisieren, wenn sie nicht 0 ist
            if (direction != Vector2.Zero)
            {
                direction.Normalize();
            }
            

            // Spieler mit seiner Geschwindigkeit in die angegebene Richtung bewegen. TimeFactor ermöglicht Zeitlupeneffekt
            Position += Velocity * direction * (float)gameTime.ElapsedGameTime.TotalSeconds * GameItem.TimeFactor;

            // Verhindern, dass der Spieler das Spielfeld nach rechts/links verlässt
            if (Position.X < CoordinateConstants.LeftBorder)
            {
                Position = new Vector2(CoordinateConstants.LeftBorder, GameItemConstants.PlayerPosition.Y);
            }

            if (Position.X > CoordinateConstants.RightBorder)
            {
                Position = new Vector2(CoordinateConstants.RightBorder, GameItemConstants.PlayerPosition.Y);
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
            // Wenn der Spieler unverwundbar ist, kann hier schon abgebrochen werden
            if (IsInvincible)
                return;

            // Spieler können mit gegnerischen Projektilen und Schiffen kollidieren
            // Außerdem auch mit PowerUps, aber die müssen hier nicht behandelt werden, sondern nur in deren IsCollidedWith-Methode
            if (!(collisionPartner is Enemy) && !(collisionPartner is Projectile))
                return;

            if (collisionPartner is Projectile) 
            {
                // Spieler kann nicht mit seinen eigenen Projektilen kollidieren
                Projectile projectile = (Projectile)collisionPartner;
                if ((projectile.ProjectileType == ProjectileTypeEnum.PlayerNormalProjectile)
                    || (projectile.ProjectileType == ProjectileTypeEnum.PiercingProjectile))
                    return;
            }

            // Wenn der Programmfluss hier ankommt gibt es eine Kollision
            if (Player.Hit != null)
                Player.Hit(this, EventArgs.Empty);
            Hitpoints -= collisionPartner.Damage;
        }


        /// <summary>
        /// In dieser Methode werden alle Werte aktualisiert, die nicht durch einen Controller beeinflusst werden können.
        /// </summary>
        /// <param name="gameTime">Spielzeit</param>
        public override void Update(GameTime gameTime)
        {
            // Update den Unerwundbarkeits-Timer wenn nötig
            if (IsInvincible)
            {
                invincibleTime -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            // Update alle aktiven PowerUps
            foreach (ActivePowerUp powerUp in ActivePowerUps)
            {
                powerUp.Update(gameTime);
            }
            // Werfe alle abgelaufenen PowerUps aus der Liste und führe dabei das Remove-Delegate aus
            ActivePowerUps.RemoveAll(delegate(ActivePowerUp powerUp)
                                        {
                                            bool timeOver = (powerUp.TimeLeft <= 0.0f);
                                            if (timeOver)
                                            {
                                                if (powerUp.Remove != null)
                                                    powerUp.Remove(this);
                                            }
                                            return timeOver;
                                        });
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
        /// Fügt der Liste der aktiven PowerUps ein neues PowerUp hinzu. Dabei wird das <c>Apply</c>-Delegate des übegebenen <c>ActivePowerUp</c>s ausgelöst.
        /// </summary>
        /// <remarks>
        /// Wenn bereits ein gleiches <c>ActivePowerUp</c> in der Liste ist, wird dieses gelöscht ohne das <c>Remove-</c>Delegate auszulösen.
        /// Für weitere Informationen sollten unbedingt die Hinweise zur PowerUps-Liste <c>ActivePowerUps</c> beachtet werden.
        /// </remarks>
        /// <param name="powerUp">Das neue PowerUp</param>
        public void AddPowerUp(ActivePowerUp powerUp)
        {
            // Wenn ein gleiches PowerUp in der Liste ist, wird dieses gelöscht
            PowerUpEnum newType = powerUp.Type;
            ActivePowerUps.RemoveAll(delegate(ActivePowerUp p)
                                     {
                                         return (p.Type == newType);
                                     });

            // Wenn das PowerUp ein Waffen-PowerUp ist, dann müssen alle anderen Waffen-PowerUps 
            // aus der Liste entfernt werden, damit immer nur ein Waffen-PowerUp aktiv ist.
            if ((powerUp.Type == PowerUpEnum.MultiShot)
                    || (powerUp.Type == PowerUpEnum.PiercingShot)
                    || (powerUp.Type == PowerUpEnum.Rapidfire))
            {
                ActivePowerUps.RemoveAll(delegate(ActivePowerUp p)
                                         {
                                             if ((p.Type == PowerUpEnum.MultiShot)
                                                    || (p.Type == PowerUpEnum.PiercingShot)
                                                    || (p.Type == PowerUpEnum.Rapidfire))
                                             {
                                                 return true;
                                             }
                                             else
                                             {
                                                 return false;
                                             }
                                         });
            }

            // Das neue PowerUp wird hinzugefügt und dessen Apply-Delegate ausgeführt
            ActivePowerUps.Add(powerUp);
            if (powerUp.Apply != null)
                powerUp.Apply(this);
        }

        /// <summary>
        /// Eine Liste der derzeit aktiven PowerUps des Spielers. Ihr werden in der <c>AddPowerUp</c>-Methode Elemente hinzugefügt.
        /// In der <c>Update</c>-Methode wird bei allen aktiven PowerUps die Restzeit aktualisiert und diese gegebenenfalls entfernt, 
        /// wenn die Restzeit auf null oder darunter gefallen ist.
        /// </summary>
        /// <remarks>Wird der Liste ein PowerUp hinzugefügt, wird dessen <c>Apply</c>-Delegate aufgerufen (in der <c>AddPowerUp</c>-Methode).
        /// Beim Entfernen aus der Liste wird das <c>Remove</c>-Delegate aufgerufen (in der <c>Update</c>-Methode). Ausnahme ist, 
        /// wenn ein weiteres Waffen-PowerUps hinzugefügt wird oder ein PowerUp, das bereits aktiv ist. 
        /// In diesem Fall wird das vorher aktive (Waffen-)PowerUp entfernt ohne <c>Remove</c> aufzurufen.
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
            this.Lives = lives;

            // Spieler für kurze Zeit unverwundbar machen
            this.invincibleTime = GameItemConstants.PlayerInvincibleTime;

            //PowerUp-Liste initialisieren
            ActivePowerUps = new List<ActivePowerUp>();

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
