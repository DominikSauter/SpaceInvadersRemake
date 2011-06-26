using System.Collections.Generic;

// Implementiert von D. Sauter

namespace SpaceInvadersRemake.ModelSection
{
    /// <summary>
    /// Diese Klasse dient der Parameterübergabe über das Event <c>WaveGenerated</c> der Klasse <c>WaveGenerator</c>.
    /// Sie enthält die gewünschte Controller-AI, eine Liste der zu kontrollierenden Aliens und das Schwierigkeitsgrad-Objekt.
    /// </summary>
    /// <remarks>
    /// Das Objekt für den Schwierigkeitsgrad enthält die zwei Parameter <c>ShootingFrequencyMultiplier</c> und <c>VelocityIncreaseMultiplier</c>, die für den Controller bestimmt sind.
    /// </remarks>
    public class ControllerEventArgs: System.EventArgs
    {
        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="behaviour">gewünschtes Verhalten des Controllers</param>
        /// <param name="controllees">Liste der zu kontrollierenden Gegner</param>
        /// <param name="difficultyLevel">Schwierigkeitsgrad der Gegner</param>
        public ControllerEventArgs(BehaviourEnum behaviour, LinkedList<IGameItem> controllees, DifficultyLevel difficultyLevel)
        {
            this.Behaviour = behaviour;
            this.Controllees = controllees;
            this.DifficultyLevel = difficultyLevel;
        }

        /// <summary>
        /// Die gewünschte Controller-AI.
        /// </summary>
        public BehaviourEnum Behaviour 
        {
            get
            {
                return Behaviour;
            }
            private set
            {
                Behaviour = value;
            }
        }

        /// <summary>
        /// Die Liste der zu kontrollierenden Aliens.
        /// </summary>
        public LinkedList<IGameItem> Controllees
        {
            get
            {
                return Controllees;
            }
            private set
            {
                Controllees = value;
            }
        }

        /// <summary>
        /// Objekt, das Parameter enthält, die den Schwierigkeitsgrad festlegen.
        /// </summary>
        /// <remarks>
        /// <c>ShootingFrequencyMultiplier</c> und <c>VelocityIncreaseMultiplier</c> sind für den Controller relevant.
        /// </remarks>
        public DifficultyLevel DifficultyLevel
        {
            get
            {
                return DifficultyLevel;
            }
            private set
            {
                DifficultyLevel = value;
            }
        }
    }
}
