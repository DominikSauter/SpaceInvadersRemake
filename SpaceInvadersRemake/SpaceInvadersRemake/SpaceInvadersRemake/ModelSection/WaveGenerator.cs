using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using SpaceInvadersRemake.Controller;

namespace SpaceInvadersRemake.ModelSection
{
    /// <summary>
    /// Generiert eine Liste von Gegner-Objekten aus einem Positions-Array.
    /// </summary>
    /// <remarks>Vorgefertigte Arrays für bestimmte Formationen sind in der Klasse bereits verfügbar.</remarks>
    public static class FormationGenerator
    {
        /// <summary>
        /// Positionsangaben für eine Block-Formation.
        /// </summary>
        public static Vector2[] BlockFormation
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
        /// Positionsangaben für eine Totenkopf-Formation.
        /// </summary>
        public static Microsoft.Xna.Framework.Vector2[] SkullFormation
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
        /// Positionsangaben für eine Dreieck-Formation.
        /// </summary>
        public static Vector2[] TriangleFormation
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
        /// Positionsangaben für eine Kreis-Formation.
        /// </summary>
        public static Vector2[] CircleFormation
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
        /// Erzeugt eine Liste von Gegner-Objekten aus einem Vector2-Array.
        /// </summary>
        /// <returns></returns>
        public static List<IGameItem> CreateFormation(int hitpoints, Vector2 velocity, Vector2[] formation)
        {
            throw new System.NotImplementedException();
}
 
    }

    /// <summary>
    /// Erzeugt neue Wellen anhand der drei Parameter AI, Formation und Schwierigkeitsgrad.
    /// </summary>
    public static class WaveGenerator
    {
        /// <summary>
        /// Übergibt die benötigten Parameter an den Controller über die Struct "ControllerParameters".
        /// </summary>
        /// <remarks>Parameter sind: Gewünschte AI als Enum, Liste der Gegner-Objekte und Schwierigkeitsgrad-Objekt.</remarks>
        public static event EventHandler WaveGenerated;

        /// <summary>
        /// Erzeugt eine neue Welle mit den Parametern AI, Formation und Schwierigkeitsgrad, und ruft danach das Event "WaveGenerated" auf, um dem Controller die gewünschten Controller-Eigenschaften mitzuteilen.
        /// </summary>
        /// <remarks>Dem Event "WaveGenerated" werden die gewünschte Controller-AI, die erstellte Liste an Gegnern und das  Schwierigkeitsgrad-Objekt übergeben.</remarks>
        public static List<IGameItem> CreateWave(ControllerEnum AI, Vector2[] formation, DifficultyLevel difficultyLevel)
        {
            throw new System.NotImplementedException();
            //SwitchCase über "Bestellung" 
            //Private Methoden für konkrete Creatings um swichcase übersichtlich zu halten
        }
    }
}
