using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

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
        /// <remarks>Private deklariert.</remarks>
        /// <param name="hitpointsMultiplier">Lebenspunkte der Gegner</param>
        /// <param name="shootingFrequencyMultiplier">Schussfrequenz der Gegner</param>
        /// <param name="velocityIncrease">Rate der Geschwindigkeitszunahme</param>
        /// <param name="damageMultiplier">Schaden der Gegner</param>
        /// <param name="scoreGainMultiplier">Punktzahl, die die Gegner bei Abschuss geben</param>
        /// <param name="velocityMultiplier">Startgeschwindigkeit der Gegner</param>
        public DifficultyLevel(float hitpointsMultiplier, Vector2 velocityMultiplier, float shootingFrequencyMultiplier, Vector2 velocityIncreaseMultiplier, float damageMultiplier, float scoreGainMultiplier)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Schwierigkeitsspezifische Modifikation der Lebenspunkte der Aliens.
        /// </summary>
        public float HitpointsMultiplier
        {
            get
            {
                throw new System.NotImplementedException();
}
            set { }
        }

        /// <summary>
        /// Schwierigkeitsspezifische Modifikation der Geschwindigkeit der Aliens.
        /// </summary>
        public Vector2 VelocityMultiplier
        {
            get
            {
                throw new System.NotImplementedException();
}
            set { }
        }

        /// <summary>
        /// Schwierigkeitsspezifische Modifikation der Schussfrequenz der Aliens.
        /// </summary>
        public float ShootingFrequencyMultiplier
        {
            get
            {
                throw new System.NotImplementedException();
}
            set { }
        }

        /// <summary>
        /// Schwierigkeitsspezifische Modifikation der Geschwindigkeitserhöhung der Aliens.
        /// </summary>
        public Vector2 VelocityIncreaseMultiplier
        {
            get
            {
                throw new System.NotImplementedException();
}
            set { }
        }

        /// <summary>
        /// Konfiguration der Parameter für die 1. Schwierigkeitsstufe ("leicht").
        /// </summary>
        public static DifficultyLevel EasyDifficulty
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
        /// Konfiguration der Parameter für die 2. Schwierigkeitsstufe ("mittel").
        /// </summary>
        public static DifficultyLevel MediumDifficulty
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
        /// Konfiguration der Parameter für die 3. Schwierigkeitsstufe ("schwer").
        /// </summary>
        public static DifficultyLevel HardDifficulty
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
        /// Schwierigkeitsspezifische Modifikation des Schadens der Aliens.
        /// </summary>
        public float DamageMultiplier
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
        /// Schwierigkeitsspezifische Modifikation der Punktzahl, die der Spieler durch das Zerstören der Aliens erhält.
        /// </summary>
        public float ScoreGainMultiplier
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    }
}
