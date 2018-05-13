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
                return 1.0f;
            }
        }

        /// <summary>
        /// Die standardmäßige Geschwindigkeitserhöhung der Aliens in Erhöhungswert pro Sekunde.
        /// </summary>
        public static Vector2 AlienVelocityIncrease
        {
            get
            {
                return new Vector2(0.2f, 0.2f);
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
                return new Vector2(60.0f, 60.0f);
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
                Vector2[] positions = {new Vector2(-50.0f, -60.0f), new Vector2(0.0f, -60.0f), new Vector2(50.0f, -60.0f)};
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
                return new Vector2(0.0f, CoordinateConstants.BottomBorder);
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
                return 400;
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
                return new Vector2(30.0f, 30.0f);
            }
        }

        /// <summary>
        /// Der standardmäßige Kollisionsschaden der Aliens.
        /// </summary>
        public static int AlienDamage
        {
            get
            {
                return 30;
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

        /// <summary>
        /// Der standardmäßige (Kollisions-)Schaden der PlayerNormalProjectiles.
        /// </summary>
        public static int PlayerNormalProjectileDamage
        {
            get
            {
                return 10;
            }
        }

        /// <summary>
        /// Die standardmäßigen Lebenspunkte der PlayerNormalProjectiles.
        /// </summary>
        public static int PlayerNormalProjectileHitpoints
        {
            get
            {
                return 10;
            }
        }

        /// <summary>
        /// Die standardmäßige Geschwindigkeit der PlayerNormalProjectiles in Distanz pro Sekunde.
        /// </summary>
        public static Vector2 PlayerNormalProjectileVelocity
        {
            get
            {
                return new Vector2(100.0f, 100.0f);
            }
        }

        /// <summary>
        /// Der standardmäßige (Kollisions-)Schaden der EnemyNormalProjectiles.
        /// </summary>
        public static int EnemyNormalProjectileDamage
        {
            get
            {
                return 10;
            }
        }

        /// <summary>
        /// Die standardmäßigen Lebenspunkte der EnemyNormalProjectiles.
        /// </summary>
        public static int EnemyNormalProjectileHitpoints
        {
            get
            {
                return 10;
            }
        }

        /// <summary>
        /// Die standardmäßige Geschwindigkeit der EnemyNormalProjectiles in Distanz pro Sekunde.
        /// </summary>
        public static Vector2 EnemyNormalProjectileVelocity
        {
            get
            {
                return new Vector2(100.0f, 100.0f);
            }
        }

        /// <summary>
        /// Die Startposition des Mutterschiffs.
        /// </summary>
        public static Vector2 MothershipPosition
        {
            get
            {
                return new Vector2(-200.0f, CoordinateConstants.TopBorder);
            }
        }

        /// <summary>
        /// Die standardmäßige Geschwindigkeit des Mutterschiffs in Distanz pro Sekunde.
        /// </summary>
        public static Vector2 MothershipVelocity
        {
            get
            {
                return new Vector2(45.0f, 45.0f);
            }
        }

        /// <summary>
        /// Die standardmäßigen Lebenspunkte des Mutterschiffs.
        /// </summary>
        public static int MothershipHitpoints
        {
            get
            {
                return 10;
            }
        }

        /// <summary>
        /// Der standardmäßige (Kollisions-)Schaden des Mutterschiffs.
        /// </summary>
        public static int MothershipDamage
        {
            get
            {
                return 10;
            }
        }

        /// <summary>
        /// Die standardmäßige Punktzahl, die der Spieler durch das Zerstören des Mutterschiffs bekommt.
        /// </summary>
        public static int MothershipScoreGain
        {
            get
            {
                return 100;
            }
        }

        /// <summary>
        /// Die Standard-Waffe des Mutterschiffs.
        /// </summary>
        public static Weapon MothershipWeapon
        {
            get
            {
                return new MothershipWeapon();
            }
        }

        /// <summary>
        /// Der standardmäßige Cooldown der PlayerNormalWeapon in Milisekunden.
        /// </summary>
        public static int PlayerNormalWeaponCooldown
        {
            get
            {
                return 1000;
            }
        }

        /// <summary>
        /// Der standardmäßige (Kollisions-)Schaden der PiercingProjectiles.
        /// </summary>
        public static int PiercingProjectileDamage
        {
            get
            {
                return (int)(AlienHitpoints * DifficultyLevel.HardDifficulty.HitpointsMultiplier + 1); // Ein Alien soll bei Kollision sterben
            }
        }

        /// <summary>
        /// Die standardmäßigen Lebenspunkte der PiercingProjectiles.
        /// </summary>
        public static int PiercingProjectileHitpoints
        {
            get
            {
                return 180;
            }
        }

        /// <summary>
        /// Die standardmäßige Geschwindigkeit der PiercingProjectiles in Distanz pro Sekunde.
        /// </summary>
        public static Vector2 PiercingProjectileVelocity
        {
            get
            {
                return new Vector2(80.0f, 80.0f);
            }
        }

        /// <summary>
        /// Wirkungsdauer eines MultiShot-PowerUps
        /// </summary>
        public static float MultiShotDuration
        {
            get
            {
                return 15.0f;
            }
        }

        /// <summary>
        /// Wirkungsdauer eines PiercingShot-PowerUps
        /// </summary>
        public static float PiercingShotDuration
        {
            get
            {
                return 15.0f;
            }
        }

        /// <summary>
        /// Zeitspanne, in der der Spieler, nach einem Treffer und nach Spielstart, unverwundbar ist
        /// </summary>
        public static float PlayerInvincibleTime
        {
            get
            {
                return 3.0f;
            }
        }

        /// <summary>
        /// Geschwindigkeit der PowerUps
        /// </summary>
        public static Vector2 PowerUpVelocity
        {
            get
            {
                return new Vector2(40.0f, 40.0f);
            }
        }

        /// <summary>
        /// Wahrscheinlichkeit, dass ein PowerUp von einem Zerstörten Alien fallengelassen wird
        /// </summary>
        public static double PowerUpProbability
        {
            get
            {
                return 0.1;
            }
        }

        /// <summary>
        /// Wirkungsdauer eines Rapidfire-PowerUps
        /// </summary>
        public static float RapidfireDuration
        {
            get
            {
                return 15.0f;
            }
        }

        /// <summary>
        /// Wirkungsdauer eines SlowMotion-PowerUps
        /// </summary>
        public static float SlowMotionDuration
        {
            get
            {
                return 5.0f;
            }
        }

        /// <summary>
        /// Wirkungsdauer eines Speedboost-PowerUps
        /// </summary>
        public static float SpeedboostDuration
        {
            get
            {
                return 15.0f;
            }
        }

        /// <summary>
        /// Der Faktor, mit dem die Spielergeschwindigkeit beim Speedboost multipliziert wird
        /// </summary>
        public static float SpeedboostFactor
        {
            get
            {
                return 1.5f;
            }
        }

        /// <summary>
        /// Gibt den Faktor der Zeitlupe an
        /// </summary>
        public static float SlowMotionFactor
        {
            get
            {
                return 0.5f;
            }
        }

        /// <summary>
        /// Gibt die Häufigkeit des Deflector-PowerUps an
        /// </summary>
        public static int DeflectorFrequency
        {
            get
            {
                return 1000;
            }
        }

        /// <summary>
        /// Gibt die Häufigkeit des MultiShot-PowerUps an
        /// </summary>
        public static int MultiShotFrequency
        {
            get
            {
                return 1000;
            }
        }

        /// <summary>
        /// Gibt die Häufigkeit des PiercingShot-PowerUps an
        /// </summary>
        public static int PiercingShotFrequency
        {
            get
            {
                return 1000;
            }
        }

        /// <summary>
        /// Gibt die Häufigkeit des Rapidfire-PowerUps an
        /// </summary>
        public static int RapidfireFrequency
        {
            get
            {
                return 1000;
            }
        }

        /// <summary>
        /// Gibt die Häufigkeit des SlowMotion-PowerUps an
        /// </summary>
        public static int SlowMotionFrequency
        {
            get
            {
                return 1000;
            }
        }

        /// <summary>
        /// Gibt die Häufigkeit des Speedboost-PowerUps an
        /// </summary>
        public static int SpeedboostFrequency
        {
            get
            {
                return 1000;
            }
        }
    }
}
