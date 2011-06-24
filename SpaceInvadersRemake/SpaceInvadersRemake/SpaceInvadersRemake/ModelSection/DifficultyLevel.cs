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
    /// Die vier Parameter <c>Hitpoints</c>, <c>Velocity</c> (für <c>FormationGenerator</c> relevant), 
    /// sowie <c>ShootingFrequency</c> und <c>VelocityIncrease</c> (für Controller relevant) bestimmen den Schwierigkeitsgrad.
    /// </remarks>
    public class DifficultyLevel
    {
        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <remarks>Private deklariert.</remarks>
        /// <param name="hitpoints">Lebenspunkte der Gegner</param>
        /// <param name="shootingFrequency">Schussfrequenz der Gegner</param>
        /// <param name="velocityIncrease">Rate der Geschwindigkeitszunahme</param>
        /// <param name="damage">Schaden der Gegner</param>
        /// <param name="scoreGain">Punktzahl, die die Gegner bei Abschuss geben</param>
        /// <param name="velocity">Startgeschwindigkeit der Gegner</param>
        public DifficultyLevel(float hitpoints, Vector2 velocity, float shootingFrequency, Vector2 velocityIncrease, float damage, float scoreGain)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Schwierigkeitsspezifische Modifikation der Lebenspunkte der Aliens.
        /// </summary>
        public float Hitpoints
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
        public Vector2 Velocity
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
        public float ShootingFrequency
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
        public Vector2 VelocityIncrease
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
        public float Damage
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
        public float ScoreGain
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
