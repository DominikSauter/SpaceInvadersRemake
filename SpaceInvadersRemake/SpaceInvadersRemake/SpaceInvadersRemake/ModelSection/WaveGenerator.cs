using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using SpaceInvadersRemake.Controller;

namespace SpaceInvadersRemake.ModelSection
{
    /// <summary>
    /// Erzeugt neue Wellen anhand der drei Parameter AI, Formation und Schwierigkeitsgrad.
    /// </summary>
    public static class WaveGenerator
    {
        
        //UNDONE Klasse überprüfen wegen  Änderung nötig ! da struct als eventarg nicht funktioniert -CK
 

        /// <summary>
        /// Übergibt die benötigten Parameter an den Controllers über die "ControllerEventArgs".
        /// </summary>
        /// <remarks>Parameter sind: Gewünschte AI als Enum, Liste der Gegner-Objekte und Schwierigkeitsgrad-Objekt.</remarks>
        public static event EventHandler<ControllerEventArgs> WaveGenerated;

        /// <summary>
        /// Erzeugt eine neue Welle mit den Parametern AI, Formation und Schwierigkeitsgrad, und ruft danach das Event "WaveGenerated" auf, um dem Controllers die gewünschten Controllers-Eigenschaften mitzuteilen.
        /// </summary>
        /// <remarks>Dem Event "WaveGenerated" werden die gewünschte Controllers-AI, die erstellte Liste an Gegnern und das  Schwierigkeitsgrad-Objekt übergeben.</remarks>
        public static List<IGameItem> CreateWave(BehaviourEnum AI, Vector2[] formation, DifficultyLevel difficultyLevel)
        {
            throw new System.NotImplementedException();
            //SwitchCase über "Bestellung" 
            //Private Methoden für konkrete Creatings um swichcase übersichtlich zu halten
        }
    }
}
