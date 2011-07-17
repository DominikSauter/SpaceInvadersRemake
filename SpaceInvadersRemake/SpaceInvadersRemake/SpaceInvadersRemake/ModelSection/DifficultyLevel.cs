using Microsoft.Xna.Framework;

// Implementiert von D. Sauter

namespace SpaceInvadersRemake.ModelSection
{
    /// <summary>
    /// Enthält Parameter, die den Schwierigkeitsgrad festlegen.
    /// </summary>
    /// <remarks>
    /// Die Parameter <c>ShootingFrequency</c> und <c>VelocityIncrease</c> sind für den Controller relevant.
    /// </remarks>
    public class DifficultyLevel
    {
        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <remarks></remarks>
        /// <param name="hitpointsMultiplier">Lebenspunkte-Multiplikator der Gegner</param>
        /// <param name="velocityMultiplier">Startgeschwindigkeits-Multiplikator der Gegner</param>
        /// <param name="shootingFrequency">Schussfrequenz der Gegner</param>
        /// <param name="velocityIncrease">Geschwindigkeitserhöhung der Gegner</param>
        /// <param name="damageMultiplier">Schadens-Multiplikator der Gegner</param>
        /// <param name="scoreGainMultiplier">Punktzahl-Multiplikator für die Punkte, die die Gegner bei Abschuss geben</param>
        public DifficultyLevel(float hitpointsMultiplier, Vector2 velocityMultiplier, float shootingFrequency, Vector2 velocityIncrease, float damageMultiplier, float scoreGainMultiplier)
        {
            this.HitpointsMultiplier = hitpointsMultiplier;
            this.VelocityMultiplier = velocityMultiplier;
            this.ShootingFrequency = shootingFrequency;
            this.VelocityIncrease = velocityIncrease;
            this.DamageMultiplier = damageMultiplier;
            this.ScoreGainMultiplier = scoreGainMultiplier;
        }

        /// <summary>
        /// Schwierigkeitsspezifische multiplikative Modifikation der Lebenspunkte der Aliens.
        /// </summary>
        public float HitpointsMultiplier { get; private set; }

        /// <summary>
        /// Schwierigkeitsspezifische multiplikative Modifikation der Geschwindigkeit der Aliens.
        /// </summary>
        public Vector2 VelocityMultiplier { get; private set; }
      
        /// <summary>
        /// Schwierigkeitsspezifische Schussfrequenz der Aliens in Schussanzahl pro Sekunde.
        /// </summary>
        public float ShootingFrequency { get; private set; }
      
        /// <summary>
        /// Schwierigkeitsspezifische Geschwindigkeitserhöhung der Aliens in Erhöhungswert pro Sekunde.
        /// </summary>
        public Vector2 VelocityIncrease { get; private set; }

        /// <summary>
        /// Konfiguration der Parameter für die 1. Schwierigkeitsstufe ("leicht").
        /// </summary>
        public static DifficultyLevel EasyDifficulty
        {
            get
            {
                return new DifficultyLevel(1.0f, new Vector2(1.0f, 1.0f), GameItemConstants.AlienShootingFrequency, GameItemConstants.AlienVelocityIncrease, 1.0f, 1.0f);
            }
        }

        /// <summary>
        /// Konfiguration der Parameter für die 2. Schwierigkeitsstufe ("mittel").
        /// </summary>
        public static DifficultyLevel MediumDifficulty
        {
            get
            {
                Vector2 velocityIncrease;
                velocityIncrease.X = 1.5f * GameItemConstants.AlienVelocityIncrease.X;
                velocityIncrease.Y = 1.5f * GameItemConstants.AlienVelocityIncrease.Y;
                return new DifficultyLevel(2.0f, new Vector2(1.5f, 1.5f), 2.0f * GameItemConstants.AlienShootingFrequency, velocityIncrease, 2.0f, 2.0f);
            }
        }

        /// <summary>
        /// Konfiguration der Parameter für die 3. Schwierigkeitsstufe ("schwer").
        /// </summary>
        public static DifficultyLevel HardDifficulty
        {
            get
            {
                Vector2 velocityIncrease;
                velocityIncrease.X = 2.0f * GameItemConstants.AlienVelocityIncrease.X;
                velocityIncrease.Y = 2.0f * GameItemConstants.AlienVelocityIncrease.Y;
                return new DifficultyLevel(3.0f, new Vector2(2.0f, 2.0f), 3.0f * GameItemConstants.AlienShootingFrequency, velocityIncrease, 3.0f, 3.0f);
            }
        }

        /// <summary>
        /// Schwierigkeitsspezifische multiplikative Modifikation des Kollisionsschadens der Aliens.
        /// </summary>
        public float DamageMultiplier { get; private set; }

        /// <summary>
        /// Schwierigkeitsspezifische multiplikative Modifikation der Punktzahl, die der Spieler durch das Zerstören der Aliens erhält.
        /// </summary>
        public float ScoreGainMultiplier { get; private set; }

    }
}
