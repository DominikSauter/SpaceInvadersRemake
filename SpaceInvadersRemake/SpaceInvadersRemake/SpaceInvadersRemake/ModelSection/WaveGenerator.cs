using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using SpaceInvadersRemake.Controller;

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
            int hitpoints = (int)(GameItemConstants.AlienHitpoints * difficultyLevel.HitpointsMultiplier);
            Vector2 velocity;
            velocity.X = GameItemConstants.AlienVelocity.X * difficultyLevel.VelocityMultiplier.X;
            velocity.Y = GameItemConstants.AlienVelocity.Y * difficultyLevel.VelocityMultiplier.Y;

            LinkedList<IGameItem> wave = FormationGenerator.CreateFormation(hitpoints, velocity, formation);

            WaveGenerated(null, new ControllerEventArgs(AI, wave, difficultyLevel));

            return wave;
        }
    }
}
