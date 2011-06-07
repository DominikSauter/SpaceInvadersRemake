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
    /// <remarks>Die vier Parameter "Hitpoints", "Velocity" (für FormationGenerator relevant), sowie "ShootingFrequency" und "VelocityIncrease" (für Controller relevant) bestimmen den Schwierigkeitsgrad.</remarks>
    public class DifficultyLevel
    {
        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <remarks>Private deklariert.</remarks>
        private DifficultyLevel(int hitpoints, Vector2 velocity, int shootingFrequency, Vector2 velocityIncrease)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Schwierigkeitsspezifische Lebenspunkte der Aliens.
        /// </summary>
        public int Hitpoints
        {
            get
            {
                throw new System.NotImplementedException();
}
            set { }
        }

        /// <summary>
        /// Schwierigkeitsspezifische Geschwindigkeit der Aliens.
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
        /// Schwierigkeitsspezifische Schussfrequenz der Aliens.
        /// </summary>
        public int ShootingFrequency
        {
            get
            {
                throw new System.NotImplementedException();
}
            set { }
        }

        /// <summary>
        /// Schwierigkeitsspezifische Geschwindigkeitserhöhung der Aliens.
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
    }
}
