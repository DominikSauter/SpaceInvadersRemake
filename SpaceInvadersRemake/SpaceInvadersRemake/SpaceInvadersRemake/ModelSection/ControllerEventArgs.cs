using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceInvadersRemake.Controller;

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
        /// <param name="difficultyLevel">Schwirigkeitsgrad der Gegner</param>
        public ControllerEventArgs(BehaviourEnum behaviour, List<IGameItem> controllees, DifficultyLevel difficultyLevel)
        {
            throw new System.NotImplementedException();
        }
        /// <summary>
        /// Die gewünschte Controller-AI.
        /// </summary>
        public BehaviourEnum Behaviour 
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
        /// Die Liste der zu kontrollierenden Aliens.
        /// </summary>
        public List<IGameItem> Controllees
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
        /// Objekt, das Parameter enthält, die den Schwierigkeitsgrad festlegen.
        /// </summary>
        /// <remarks>
        /// <c>ShootingFrequencyMultiplier</c> und <c>VelocityIncreaseMultiplier</c> sind für den Controller relevant.
        /// </remarks>
        public DifficultyLevel DifficultyLevel
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
