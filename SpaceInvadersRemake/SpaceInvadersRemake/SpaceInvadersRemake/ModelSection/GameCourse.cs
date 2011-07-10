using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

// Implementiert von D. Sauter

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
        /// Speichert den Zeitpunkt, ab dem das Mutterschiff das nächste Mal auftauchen darf in Milisekunden seit Spielstart.
        /// </summary>
        private double nextMothershipTime;

        /// <summary>
        /// Die Zeit, die zwischen dem Auftauchen und dem erneuten Auftauchen des Mutterschiffs vergehen muss in Milisekunden.
        /// </summary>
        private int mothershipCooldown;

        /// <summary>
        /// Gibt an, ob der Mutterschiff-Cooldown gerade aktiv ist oder nicht.
        /// </summary>
        private bool mothershipCooldownActive;

        /// <summary>
        /// Konstruktor
        /// </summary>
        public GameCourse()
        {
            mothershipCooldown = 30000;
            nextMothershipTime = 0;
            mothershipCooldownActive = false;
            random = new Random();
            WaveCounter = 0;
            InitializeGame();
        }

        /// <summary>
        /// Zählt die Wellen mit.
        /// </summary>
        public int WaveCounter { get; private set; }

        /// <summary>
        /// Referenz auf das Spielerschiff-Objekt.
        /// </summary>
        public Player Player { get; private set; }
 
        /// <summary>
        /// Erzeugt eine neue Welle, d.h. eine Liste von Aliens, die durch einen Controller gesteuert werden.
        /// Die Abfolge der Wellen ist hier anhand des WaveCounters festgelegt. Die Methode setzt außerdem 
        /// bei jedem Aufruf die <c>waveStartingTime</c> auf die aktuelle <c>gameTime</c>.
        /// </summary>
        /// <param name="gameTime">Spielzeit</param>
        public LinkedList<IGameItem> NextWave(GameTime gameTime)
        {
            waveStartingTime = gameTime;

            LinkedList<IGameItem> wave = null;
            if (WaveCounter == 0)
            {
                wave = WaveGenerator.CreateWave(BehaviourEnum.BlockMovement, FormationGenerator.SkullFormation, DifficultyLevel.EasyDifficulty);
            }
            else if (WaveCounter == 1)
            {
                wave = WaveGenerator.CreateWave(BehaviourEnum.BlockMovement, FormationGenerator.BlockFormation, DifficultyLevel.EasyDifficulty);
            }
            else if (WaveCounter == 2)
            {
                wave = WaveGenerator.CreateWave(BehaviourEnum.BlockMovement, FormationGenerator.ArrowFormation, DifficultyLevel.EasyDifficulty);
            }
            else if (WaveCounter == 3)
            {
                wave = WaveGenerator.CreateWave(BehaviourEnum.BlockMovement, FormationGenerator.InfinityFormation, DifficultyLevel.MediumDifficulty);
            }
            else if (WaveCounter == 4)
            {
                wave = WaveGenerator.CreateWave(BehaviourEnum.BlockMovement, FormationGenerator.TriangleFormation, DifficultyLevel.MediumDifficulty);
            }
            else if (WaveCounter == 5)
            {
                wave = WaveGenerator.CreateWave(BehaviourEnum.BlockMovement, FormationGenerator.CircleFormation, DifficultyLevel.MediumDifficulty);
            }
            else if (WaveCounter == 6)
            {
                wave = WaveGenerator.CreateWave(BehaviourEnum.BlockMovement, FormationGenerator.SkullFormation, DifficultyLevel.HardDifficulty);
            }
            else if (WaveCounter == 7)
            {
                wave = WaveGenerator.CreateWave(BehaviourEnum.BlockMovement, FormationGenerator.BlockFormation, DifficultyLevel.HardDifficulty);
            }
            else if (WaveCounter == 8)
            {
                wave = WaveGenerator.CreateWave(BehaviourEnum.BlockMovement, FormationGenerator.ArrowFormation, DifficultyLevel.HardDifficulty);
            }
            else
            {
                int rnd = random.Next(6);
                Vector2[] formation;
                if (rnd == 0)
                {
                    formation = FormationGenerator.SkullFormation;
                }
                else if (rnd == 1)
                {
                    formation = FormationGenerator.BlockFormation;
                }
                else if (rnd == 2)
                {
                    formation = FormationGenerator.CircleFormation;
                }
                else if (rnd == 3)
                {
                    formation = FormationGenerator.TriangleFormation;
                }
                else if (rnd == 4)
                {
                    formation = FormationGenerator.ArrowFormation;
                }
                else
                {
                    formation = FormationGenerator.InfinityFormation;
                }
                wave = WaveGenerator.CreateWave(BehaviourEnum.BlockMovement, formation, DifficultyLevel.HardDifficulty);
            }
            WaveCounter++;
            return wave;
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
            // Bestimme Zeitpunkt des nächsten Mutterschiff-Auftauchens
            if (!mothershipCooldownActive)
            {
                nextMothershipTime = gameTime.TotalGameTime.TotalMilliseconds + (mothershipCooldown + random.Next(mothershipCooldown + 1)); // Mutterschiff erscheint in zufälligen Abständen aus dem Intervall [mothershipCooldown, (mothershipCooldown * 2)]
                mothershipCooldownActive = true;
            }

            // Erzeuge Mutterschiff, sobald der vorher bestimmte Zeitpunkt dafür gekommen ist
            if (gameTime.TotalGameTime.TotalMilliseconds >= nextMothershipTime)
            {
                Vector2[] formation = { GameItemConstants.MothershipPosition };
                WaveGenerator.CreateWave(BehaviourEnum.MothershipMovement, formation, DifficultyLevel.EasyDifficulty);

                mothershipCooldownActive = false;
            }
        }

        /// <summary>
        /// Wird vom Konstruktor aufgerufen, um das Spiel zu initialisieren.
        /// </summary>
        /// <remarks>Konkret werden das Spielerschiff, sowie die statischen Schilde erzeugt.</remarks>
        private void InitializeGame()
        {
            for (int i = 0; i < GameItemConstants.ShieldPositions.Length; i++)
            {
                new Shield(GameItemConstants.ShieldPositions[i], GameItemConstants.ShieldHitpoints, GameItemConstants.ShieldDamage);
            }
            Player = new Player(GameItemConstants.PlayerPosition, GameItemConstants.PlayerVelocity, GameItemConstants.PlayerHitpoints, GameItemConstants.PlayerDamage, GameItemConstants.PlayerWeapon, GameItemConstants.PlayerLives);
        }
    }
}
