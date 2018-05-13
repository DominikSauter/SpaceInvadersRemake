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
        /// Objekt um Zufallselemente einzubauen, z.B. zufällige Formationen oder das zufällige Auftauchen eines Mutterschiffs.
        /// </summary>
        private Random random;

        /// <summary>
        /// Gibt die Mindestzeit in Milisekunden bis zum Auftauchen des nächsten Mutterschiffs an, die seit dem Beginn einer Welle oder dem Auftauchen des letzten Mutterschiffs vergehen muss.
        /// </summary>
        /// <remarks>
        /// Muss kleiner gleich <c>mothershipCooldownMaximum</c> sein.
        /// </remarks>
        private int mothershipCooldownMinimum;

        /// <summary>
        /// Gibt die Maximalzeit in Milisekunden bis zum Auftauchen des nächsten Mutterschiffs an, die seit dem Beginn einer Welle oder dem Auftauchen des letzten Mutterschiffs vergehen darf.
        /// </summary>
        /// <remarks>
        /// Muss größer gleich <c>mothershipCooldownMinimum</c> sein.
        /// </remarks>
        private int mothershipCooldownMaximum;

        /// <summary>
        /// Gibt die Wahrscheinlichkeit in Prozent an, mit der ein Mutterschiff erscheint.
        /// </summary>
        /// <remarks>
        /// Muss größer gleich 0 und kleiner gleich 100 sein.
        /// </remarks>
        private int mothershipProbability;

        /// <summary>
        /// Gibt die Anzahl potenzieller Mutterschiffe pro Welle an.
        /// </summary>
        private int mothershipsPerWave;

        /// <summary>
        /// Speichert die Anzahl verbleibender potenzieller Mutterschiffe für die aktuelle Welle.
        /// </summary>
        private int mothershipsPerWaveRemaining;

        /// <summary>
        /// Speichert die verbleibende Zeit in Milisekunden bis zum Auftauchen des nächsten Mutterschiffs.
        /// </summary>
        private double mothershipCooldownRemaining;

        /// <summary>
        /// Gibt an, ob der Mutterschiff-Cooldown gerade aktiv ist oder nicht.
        /// </summary>
        private bool mothershipCooldownActive;

        /// <summary>
        /// Speichert die Wellennummer, bei der sich die Mutterschiff-Berechnung gerade befindet.
        /// </summary>
        private int mothershipWaveCounter;

        /// <summary>
        /// Konstruktor
        /// </summary>
        public GameCourse()
        {
            // Änderbare Werte
            mothershipCooldownMinimum = 10000;
            mothershipCooldownMaximum = 60000;
            mothershipProbability = 25;
            mothershipsPerWave = 2;

            // Feste Werte
            mothershipsPerWaveRemaining = mothershipsPerWave;
            mothershipCooldownRemaining = 0;
            mothershipCooldownActive = false;
            mothershipWaveCounter = 1;
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
        /// Die Abfolge der Wellen ist hier anhand des WaveCounters festgelegt.
        /// </summary>
        /// <param name="gameTime">Spielzeit</param>
        public LinkedList<IGameItem> NextWave(GameTime gameTime)
        {
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
        /// <param name="gameTime">Spielzeit</param>
        public void SpecialEvent(GameTime gameTime)
        {
            // Verringere Cooldown-Zeit
            if (mothershipCooldownRemaining > 0)
            {
                mothershipCooldownRemaining = mothershipCooldownRemaining - gameTime.ElapsedGameTime.TotalMilliseconds;
            }


            // Kein Cooldown muss abgewartet werden und es wurden noch nicht alle potenziellen Mutterschiffe berechnet
            if ((mothershipCooldownRemaining <= 0) && (mothershipWaveCounter <= WaveCounter))
            {

                // Kein abgelaufener Mutterschiff-Cooldown; berechne ob und wann das nächste Mutterschiff auftaucht
                if (!mothershipCooldownActive)
                {
                    mothershipsPerWaveRemaining--;
                    // Mutterschiff wird erscheinen; Cooldown wird gesetzt
                    if (random.Next(101) <= mothershipProbability)
                    {
                        mothershipCooldownRemaining = mothershipCooldownMinimum + random.Next(mothershipCooldownMaximum - mothershipCooldownMinimum + 1);
                        mothershipCooldownActive = true;
                    }
                    // Kein Mutterschiff wird erscheinen; sofern alle Mutterschiffe dieser Welle berechnet wurden, wird der Mutterschiff-Wellenzähler erhöht
                    else
                    {
                        if (mothershipsPerWaveRemaining <= 0)
                        {
                            mothershipWaveCounter++;
                            mothershipsPerWaveRemaining = mothershipsPerWave;
                        }
                    }
                }

                // Abgelaufener Mutterschiff-Cooldown; erzeuge Mutterschiff
                else
                {
                    Vector2[] formation = { GameItemConstants.MothershipPosition };
                    WaveGenerator.CreateWave(BehaviourEnum.MothershipMovement, formation, DifficultyLevel.EasyDifficulty);
                    mothershipCooldownActive = false;

                    // Sofern alle Mutterschiffe dieser Welle berechnet wurden, wird der Mutterschiff-Wellenzähler erhöht
                    if (mothershipsPerWaveRemaining <= 0)
                    {
                        mothershipWaveCounter++;
                        mothershipsPerWaveRemaining = mothershipsPerWave;
                    }
                }
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
