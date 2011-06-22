using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace SpaceInvadersRemake.ModelSection
{
    /// <summary>
    /// Ist für den Spielablauf zuständig und bestimmt u.a. die Abfolge der Wellen und besonderer Ereignisse
    /// während einer Welle, etwa das Auftauchen eines Mutterschiffs.
    /// </summary>
    /// <remarks>Zählt außerdem die Wellen mit.</remarks>
    public class GameCourse
    {
        /// <summary>
        /// Enthält die GameTime zum Zeitpunkt der Erstellung der letzten Welle.
        /// </summary>
        private GameTime waveStartingTime;

        /// <summary>
        /// Objekt um Zufallselemente einzubauen, z.B. zufällige Formationen oder das zufällige Auftauchen eines Mutterschiffs.
        /// </summary>
        private Random random;

        /// <summary>
        /// Konstruktor
        /// </summary>
        public GameCourse()
        {
            random = new Random();
            InitializeGame();
        }

        /// <summary>
        /// Zählt die Wellen mit.
        /// </summary>
        public int WaveCounter
        {
            get
            {
                return WaveCounter;
            }
            private set
            {
                WaveCounter = value;
            }
        }

        /// <summary>
        /// Referenz auf das Spielerschiff-Objekt.
        /// </summary>
        public Player Player
        {
            get
            {
                return Player;
            }
            private set
            {
                Player = value;
            }
        }

        /// <summary>
        /// Erzeugt eine neue Welle, d.h. eine Liste von Aliens, die durch einen Controller gesteuert werden.
        /// Die Abfolge der Wellen ist hier anhand des WaveCounters festgelegt. Die Methode setzt außerdem 
        /// bei jedem Aufruf die <c>waveStartingTime</c> auf die aktuelle <c>gameTime</c>.
        /// </summary>
        /// <param name="gameTime">Spielzeit</param>
        public LinkedList<IGameItem> NextWave(GameTime gameTime)
        {
            waveStartingTime = gameTime;

            if (WaveCounter == 0)
            {
                WaveGenerator.CreateWave(BehaviourEnum.BlockMovement, FormationGenerator.SkullFormation, DifficultyLevel.EasyDifficulty);
            }
            else if (WaveCounter == 1)
            {
                WaveGenerator.CreateWave(BehaviourEnum.BlockMovement, FormationGenerator.BlockFormation, DifficultyLevel.EasyDifficulty);
            }
            else if (WaveCounter == 2)
            {
                WaveGenerator.CreateWave(BehaviourEnum.BlockMovement, FormationGenerator.CircleFormation, DifficultyLevel.EasyDifficulty);
            }
            else if (WaveCounter == 3)
            {
                WaveGenerator.CreateWave(BehaviourEnum.BlockMovement, FormationGenerator.TriangleFormation, DifficultyLevel.MediumDifficulty);
            }
            else if (WaveCounter == 4)
            {
                WaveGenerator.CreateWave(BehaviourEnum.BlockMovement, FormationGenerator.SkullFormation, DifficultyLevel.MediumDifficulty);
            }
            else if (WaveCounter == 5)
            {
                WaveGenerator.CreateWave(BehaviourEnum.BlockMovement, FormationGenerator.BlockFormation, DifficultyLevel.MediumDifficulty);
            }
            else if (WaveCounter == 6)
            {
                WaveGenerator.CreateWave(BehaviourEnum.BlockMovement, FormationGenerator.CircleFormation, DifficultyLevel.HardDifficulty);
            }
            else if (WaveCounter == 7)
            {
                WaveGenerator.CreateWave(BehaviourEnum.BlockMovement, FormationGenerator.TriangleFormation, DifficultyLevel.HardDifficulty);
            }
            else if (WaveCounter == 8)
            {
                WaveGenerator.CreateWave(BehaviourEnum.BlockMovement, FormationGenerator.SkullFormation, DifficultyLevel.HardDifficulty);
            }
            else
            {
                int rnd = random.Next(4);
                if (rnd == 0)
                {
                    Vector2[] formation = FormationGenerator.SkullFormation;
                } else if (rnd == 1)
                {
                    Vector2[] formation = FormationGenerator.BlockFormation;
                } else if (rnd == 2)
                {
                    Vector2[] formation = FormationGenerator.CircleFormation;
                } else
                {
                    Vector2[] formation = FormationGenerator.TriangleFormation;
                }
                WaveGenerator.CreateWave(BehaviourEnum.BlockMovement, FormationGenerator.BlockFormation, DifficultyLevel.HardDifficulty);
            }
        }

        /// <summary>
        /// Dient zur Erstellung besonderer Ereignisse während einer Welle, z.B. das Auftauchen eines Mutterschiffs.
        /// </summary>
        /// <remarks>
        /// Hierfür wird die <c>waveStartingTime</c> benötigt, um Ereignisse zu bestimmten Wellen timen zu können.
        /// </remarks>
        /// <param name="gameTime">Spielzeit</param>
        public void SpecialEvent(GameTime gameTime)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Wird vom Konstruktor aufgerufen, um das Spiel zu initialisieren.
        /// </summary>
        /// <remarks>Konkret werden das Spielerschiff, sowie die statischen Schilde erzeugt.</remarks>
        private void InitializeGame()
        {
            throw new System.NotImplementedException();
        }
    }
}
