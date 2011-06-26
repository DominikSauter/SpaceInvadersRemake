using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

// Implementiert von D. Sauter

namespace SpaceInvadersRemake.ModelSection
{
    /// <summary>
    /// Diese Klasse enthält Standardwerte der GameItems.
    /// </summary>
    public static class GameItemConstants
    {
        /// <summary>
        /// Die standardmäßige Schussfrequenz der Aliens in Schussanzahl pro Sekunde.
        /// </summary>
        public static float AlienShootingFrequency
        {
            get
            {
                return 3.0f;
            }
        }

        /// <summary>
        /// Die standardmäßige Geschwindigkeitserhöhung der Aliens in Erhöhungswert pro Sekunde.
        /// </summary>
        public static Vector2 AlienVelocityIncrease
        {
            get
            {
                return new Vector2(0.5f, 0.5f);
            }
        }

        /// <summary>
        /// Die standardmäßigen Lebenspunkte des Spielers.
        /// </summary>
        public static int PlayerHitpoints
        {
            get
            {
                return 10;
            }
        }

        /// <summary>
        /// Die standardmäßige Geschwindigkeit des Spielers in Distanz pro Sekunde.
        /// </summary>
        public static Vector2 PlayerVelocity
        {
            get
            {
                return new Vector2(20.0f, 0.0f);
            }
        }

        /// <summary>
        /// Der standardmäßige Kollisionsschaden des Spielers.
        /// </summary>
        public static int PlayerDamage
        {
            get
            {
                return (int)(AlienHitpoints * DifficultyLevel.HardDifficulty.HitpointsMultiplier + 1); // Ein Alien soll bei Kollision sterben
            }
        }

        /// <summary>
        /// Die standardmäßigen Leben des Spielers.
        /// </summary>
        public static int PlayerLives
        {
            get
            {
                return 3;
            }
        }

        /// <summary>
        /// Die Positionsangaben der Schilde.
        /// </summary>
        public static Vector2[] ShieldPositions
        {
            get
            {
                Vector2[] positions = {new Vector2(-50.0f, -40.0f), new Vector2(0.0f, -40.0f), new Vector2(50.0f, -40.0f)};
                return positions;
            }
        }

        /// <summary>
        /// Die Startposition des Spielers.
        /// </summary>
        public static Vector2 PlayerPosition
        {
            get
            {
                return new Vector2(0.0f, -60.0f);
            }
        }

        /// <summary>
        /// Die Standard-Waffe des Spielers.
        /// </summary>
        public static Weapon PlayerWeapon
        {
            get
            {
                return new PlayerNormalWeapon();
            }
        }

        /// <summary>
        /// Die standardmäßigen Lebenspunkte der Schilde.
        /// </summary>
        public static int ShieldHitpoints
        {
            get
            {
                return 100;
            }
        }

        /// <summary>
        /// Der standardmäßige Kollisionsschaden der Schilde.
        /// </summary>
        public static int ShieldDamage
        {
            get
            {
                return (int)(AlienHitpoints * DifficultyLevel.HardDifficulty.HitpointsMultiplier + 1); // Ein Alien soll bei Kollision sterben
            }
        }

        /// <summary>
        /// Die standardmäßigen Lebenspunkte der Aliens.
        /// </summary>
        public static int AlienHitpoints
        {
            get
            {
                return 10;
            }
        }

        /// <summary>
        /// Die standardmäßige Geschwindigkeit der Aliens in Distanz pro Sekunde.
        /// </summary>
        public static Vector2 AlienVelocity
        {
            get
            {
                return new Vector2(10.0f, 10.0f);
            }
        }

        /// <summary>
        /// Der standardmäßige Kollisionsschaden der Aliens.
        /// </summary>
        public static int AlienDamage
        {
            get
            {
                return 10;
            }
        }

        /// <summary>
        /// Die Standard-Waffe der Aliens.
        /// </summary>
        public static Weapon AlienWeapon
        {
            get
            {
                return new EnemyNormalWeapon();
            }
        }

        /// <summary>
        /// Die standardmäßige Punktzahl, die der Spieler durch das Zerstören der Aliens bekommt.
        /// </summary>
        public static int AlienScoreGain
        {
            get
            {
                return 10;
            }
        }
    }
}
