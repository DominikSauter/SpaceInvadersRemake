using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

// Implementiert von D. Sauter

namespace SpaceInvadersRemake.ModelSection
{
    /// <summary>
    /// Enthält Parameter, die den Schwierigkeitsgrad festlegen.
    /// </summary>
    /// <remarks>
    /// Die vier Parameter <c>HitpointsMultiplier</c>, <c>VelocityMultiplier</c> (für <c>FormationGenerator</c> relevant), 
    /// sowie <c>ShootingFrequencyMultiplier</c> und <c>VelocityIncreaseMultiplier</c> (für Controller relevant) bestimmen den Schwierigkeitsgrad.
    /// </remarks>
    public class DifficultyLevel
    {
        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <remarks></remarks>
        /// <param name="hitpointsMultiplier">Lebenspunkte der Gegner</param>
        /// <param name="shootingFrequencyMultiplier">Schussfrequenz der Gegner</param>
        /// <param name="velocityIncreaseMultiplier">Geschwindigkeitserhöhung der Gegner</param>
        /// <param name="velocityIncrease">Rate der Geschwindigkeitszunahme</param>
        /// <param name="damageMultiplier">Schaden der Gegner</param>
        /// <param name="scoreGainMultiplier">Punktzahl, die die Gegner bei Abschuss geben</param>
        /// <param name="velocityMultiplier">Startgeschwindigkeit der Gegner</param>
        public DifficultyLevel(float hitpointsMultiplier, Vector2 velocityMultiplier, float shootingFrequencyMultiplier, Vector2 velocityIncreaseMultiplier, float damageMultiplier, float scoreGainMultiplier)
        {
            this.HitpointsMultiplier = hitpointsMultiplier;
            this.VelocityMultiplier = velocityMultiplier;
            this.ShootingFrequencyMultiplier = shootingFrequencyMultiplier;
            this.VelocityIncreaseMultiplier = velocityIncreaseMultiplier;
            this.DamageMultiplier = damageMultiplier;
            this.ScoreGainMultiplier = scoreGainMultiplier;
        }

        /// <summary>
        /// Schwierigkeitsspezifische Modifikation der Lebenspunkte der Aliens.
        /// </summary>
        public float HitpointsMultiplier
        {
            get
            {
                return HitpointsMultiplier;
            }
            private set
            {
                HitpointsMultiplier = value;
            }
        }

        /// <summary>
        /// Schwierigkeitsspezifische Modifikation der Geschwindigkeit der Aliens.
        /// </summary>
        public Vector2 VelocityMultiplier
        {
            get
            {
                return VelocityMultiplier;
            }
            private set
            {
                VelocityMultiplier = value;
            }
        }

        /// <summary>
        /// Schwierigkeitsspezifische Modifikation der Schussfrequenz der Aliens.
        /// </summary>
        public float ShootingFrequencyMultiplier
        {
            get
            {
                return ShootingFrequencyMultiplier;
            }
            private set
            {
                ShootingFrequencyMultiplier = value;
            }
        }

        /// <summary>
        /// Schwierigkeitsspezifische Modifikation der Geschwindigkeitserhöhung der Aliens.
        /// </summary>
        public Vector2 VelocityIncreaseMultiplier
        {
            get
            {
                return VelocityIncreaseMultiplier;
            }
            private set
            {
                VelocityIncreaseMultiplier = value;
            }
        }

        /// <summary>
        /// Konfiguration der Parameter für die 1. Schwierigkeitsstufe ("leicht").
        /// </summary>
        public static DifficultyLevel EasyDifficulty
        {
            get
            {
                return new DifficultyLevel(1.0f, new Vector2(1.0f, 1.0f), 1.0f, new Vector2(1.0f, 1.0f), 1.0f, 1.0f);
            }
        }

        /// <summary>
        /// Konfiguration der Parameter für die 2. Schwierigkeitsstufe ("mittel").
        /// </summary>
        public static DifficultyLevel MediumDifficulty
        {
            get
            {
                return new DifficultyLevel(2.0f, new Vector2(1.5f, 1.5f), 2.0f, new Vector2(1.5f, 1.5f), 2.0f, 2.0f);
            }
        }

        /// <summary>
        /// Konfiguration der Parameter für die 3. Schwierigkeitsstufe ("schwer").
        /// </summary>
        public static DifficultyLevel HardDifficulty
        {
            get
            {
                return new DifficultyLevel(3.0f, new Vector2(2.0f, 2.0f), 3.0f, new Vector2(2.0f, 2.0f), 3.0f, 3.0f);
            }
        }

        /// <summary>
        /// Schwierigkeitsspezifische Modifikation des Kollisionsschadens der Aliens.
        /// </summary>
        public float DamageMultiplier
        {
            get
            {
                return DamageMultiplier;
            }
            private set
            {
                DamageMultiplier = value;
            }
        }

        /// <summary>
        /// Schwierigkeitsspezifische Modifikation der Punktzahl, die der Spieler durch das Zerstören der Aliens erhält.
        /// </summary>
        public float ScoreGainMultiplier
        {
            get
            {
                return ScoreGainMultiplier;
            }
            private set
            {
                ScoreGainMultiplier = value;
            }
        }
    }
}
