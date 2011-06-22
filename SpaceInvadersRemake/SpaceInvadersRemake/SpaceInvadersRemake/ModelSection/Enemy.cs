using Microsoft.Xna.Framework;

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

        public override bool Move(Vector2 direction)
        {
            bool result = true;

            direction.Normalize();

            Position += Velocity * direction;

            if ((Position.X < CoordinateConstants.LeftBorder) || (Position.X > CoordinateConstants.RightBorder)
                || (Position.Y < CoordinateConstants.BottomBorder) || (Position.Y > CoordinateConstants.TopBorder))
            {
                result = false;
            }

            return result;
        }

        public override void Shoot(GameTime gameTime)
        {
            Weapon.Fire(Position, CoordinateConstants.Down, gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            // leer, da Gegner nich geupdated werden müssen
        }

        /// <summary>
        /// Konstruktor, um redundanten Code zu vermeiden
        /// </summary>
        /// <param name="position">Startposition</param>
        /// <param name="velocity">Maximale Geschwindigkeit</param>
        /// <param name="hitpoints">Lebenspunkte</param>
        /// <param name="weapon">Waffe</param>
        /// <param name="scoreGain">Punktzahl, die dem Spieler bei Zerstörung gutgeschrieben wird</param>
        public Enemy(Vector2 position, Vector2 velocity, int hitpoints, Weapon weapon, int scoreGain)
            : base(position, velocity, hitpoints, weapon)
        {
            this.ScoreGain = scoreGain;
        }
    }
}
