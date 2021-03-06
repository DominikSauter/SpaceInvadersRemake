﻿using Microsoft.Xna.Framework;

// Implementiert von Tobias

namespace SpaceInvadersRemake.ModelSection
{
    /// <summary>
    /// Die abstrakte Oberklasse aller gegnerischen Raumschiffe im Spiel.
    /// </summary>
    public abstract class Enemy : Ship
    {
        /// <summary>
        /// Die Punktzahl die dem Spieler bei Zertörung des Schiffs gutgeschrieben wird
        /// </summary>
        public int ScoreGain
        {
            get;
            protected set;
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
        public override bool Move(Vector2 direction, GameTime gameTime)
        {
            bool result = true;

            // Normalisiere Vektor, fall er nicht 0 ist
            if (direction != Vector2.Zero)
            {
                direction.Normalize();
            }

            // Bewege das Schiff mir seiner Geschwindigkeit in die angegebene Richtung. TimeFactor ermöglicht Zeitlupeneffekt
            Position += Velocity * direction * (float)gameTime.ElapsedGameTime.TotalSeconds * GameItem.TimeFactor;

            // Rückmeldung, falls Schiff das Spielfeld verlässt
            if ((Position.X < CoordinateConstants.LeftBorder) || (Position.X > CoordinateConstants.RightBorder)
                || (Position.Y < CoordinateConstants.BottomBorder) || (Position.Y > CoordinateConstants.TopBorder))
            {
                result = false;
            }

            // Wenn der Gegner nach unten aus dem Spielfeld fliegt, wird er zum Löschen markiert
            if (Position.Y < 1.25f * CoordinateConstants.BottomBorder)
            {
                IsAlive = false;
            }

            return result;
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
            Weapon.Fire(Position, CoordinateConstants.Down, gameTime);
        }

        /// <summary>
        /// Konstruktor, um redundanten Code zu vermeiden
        /// </summary>
        /// <param name="position">Startposition</param>
        /// <param name="velocity">Maximale Geschwindigkeit</param>
        /// <param name="hitpoints">Lebenspunkte</param>
        /// <param name="damage">Schaden, der anderen zugefügt wird</param>
        /// <param name="weapon">Waffe</param>
        /// <param name="scoreGain">Punktzahl, die dem Spieler bei Zerstörung gutgeschrieben wird</param>
        public Enemy(Vector2 position, Vector2 velocity, int hitpoints, int damage, Weapon weapon, int scoreGain)
            : base(position, velocity, hitpoints, damage, weapon)
        {
            this.ScoreGain = scoreGain;
        }
    }
}
