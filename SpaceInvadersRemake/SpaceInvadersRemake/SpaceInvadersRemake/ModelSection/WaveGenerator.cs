using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using SpaceInvadersRemake.Controller;

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
        /// <returns>Eine Liste von Gegnern, die sie aktuelle Welle darstellen</returns>
        public static LinkedList<IGameItem> CreateWave(BehaviourEnum AI, Vector2[] formation, DifficultyLevel difficultyLevel)
        {
            throw new System.NotImplementedException();
            //SwitchCase über "Bestellung" 
            //Private Methoden für konkrete Creatings um swichcase übersichtlich zu halten
        }
    }
}
