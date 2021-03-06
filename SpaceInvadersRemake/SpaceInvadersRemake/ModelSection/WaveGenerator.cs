﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

// Implementiert von D. Sauter

namespace SpaceInvadersRemake.ModelSection
{
    /// <summary>
    /// Erzeugt neue Wellen anhand der drei Parameter AI, Formation und Schwierigkeitsgrad.
    /// </summary>
    /// <remarks>Die Bezeichnung "Controller" bezieht sich im Folgenden auf den Controller-Bereich aus MVC.</remarks>
    public static class WaveGenerator
    {
        /// <summary>
        /// Übergibt die benötigten Parameter an den Controller über die "ControllerEventArgs".
        /// </summary>
        /// <remarks>Parameter sind: Gewünschte AI als Enum, Liste der Gegner-Objekte und Schwierigkeitsgrad-Objekt.</remarks>
        public static event EventHandler<ControllerEventArgs> WaveGenerated;

        /// <summary>
        /// Erzeugt eine neue Welle und ruft danach das Event "WaveGenerated" auf, um dem Controller die gewünschten Controller-Eigenschaften mitzuteilen.
        /// </summary>
        /// <remarks>Dem Event "WaveGenerated" werden die gewünschte Controller-AI, die erstellte Liste an Gegnern und das Schwierigkeitsgrad-Objekt übergeben.</remarks>
        /// <param name="AI">gewünschtes Verhalten des Controllers</param>
        /// <param name="formation">gewünschte Formation der Welle</param>
        /// <param name="difficultyLevel">gewünschter Schwierigkeitsgrad</param>
        /// <returns>Eine Liste von Gegnern, die die aktuelle Welle darstellen</returns>
        public static LinkedList<IGameItem> CreateWave(BehaviourEnum AI, Vector2[] formation, DifficultyLevel difficultyLevel)
        {
            int hitpoints;
            Vector2 velocity;
            int damage;
            int scoreGain;
            LinkedList<IGameItem> wave = null;
            if (AI.Equals(BehaviourEnum.MothershipMovement))
            {
                hitpoints = (int)(GameItemConstants.MothershipHitpoints * difficultyLevel.HitpointsMultiplier);
                velocity.X = GameItemConstants.MothershipVelocity.X * difficultyLevel.VelocityMultiplier.X;
                velocity.Y = GameItemConstants.MothershipVelocity.Y * difficultyLevel.VelocityMultiplier.Y;
                damage = (int)(GameItemConstants.MothershipDamage * difficultyLevel.DamageMultiplier);
                scoreGain = (int)(GameItemConstants.MothershipScoreGain * difficultyLevel.ScoreGainMultiplier);

                wave = FormationGenerator.CreateFormation(BehaviourEnum.MothershipMovement, hitpoints, velocity, formation, damage, scoreGain);
            }
            else
            {
                hitpoints = (int)(GameItemConstants.AlienHitpoints * difficultyLevel.HitpointsMultiplier);
                velocity.X = GameItemConstants.AlienVelocity.X * difficultyLevel.VelocityMultiplier.X;
                velocity.Y = GameItemConstants.AlienVelocity.Y * difficultyLevel.VelocityMultiplier.Y;
                damage = (int)(GameItemConstants.AlienDamage * difficultyLevel.DamageMultiplier);
                scoreGain = (int)(GameItemConstants.AlienScoreGain * difficultyLevel.ScoreGainMultiplier);

                wave = FormationGenerator.CreateFormation(BehaviourEnum.BlockMovement, hitpoints, velocity, formation, damage, scoreGain);
            }

            if (WaveGenerated != null)
            {
                WaveGenerated(null, new ControllerEventArgs(AI, wave, difficultyLevel));
            }

            return wave;
        }
    }
}
