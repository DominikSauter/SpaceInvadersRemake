using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceInvadersRemake.Controller;

namespace SpaceInvadersRemake.ModelSection
{
    /// <summary>
    /// Diese Klasse dient der Parameterübergabe über das Event "WaveGenerated" der Klasse WaveGenerator.
    /// Sie enthält die gewünschte Controllers-AI, eine Liste der zu kontrollierenden Aliens und das Schwierigkeitsgrad-Objekt.
    /// </summary>
    /// <remarks>Das Objekt für den Schwierigkeitsgrad enthält die zwei Parameter "ShootingFrequency" und "VelocityIncrease", die für den Controllers bestimmt sind.</remarks>
    public class ControllerEventArgs: System.EventArgs
    {
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
        public System.Collections.Generic.ICollection<SpaceInvadersRemake.ModelSection.IGameItem> Controllees
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
        /// <remarks>"ShootingFrequency" und "VelocityIncrease" sind für den Controllers relevant.</remarks>
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
