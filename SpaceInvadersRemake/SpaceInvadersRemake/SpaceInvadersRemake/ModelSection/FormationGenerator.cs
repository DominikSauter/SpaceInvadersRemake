using System.Collections.Generic;
using Microsoft.Xna.Framework;

// Implementiert von D. Sauter

namespace SpaceInvadersRemake.ModelSection
{
    /// <summary>
    /// Generiert eine Liste von Gegner-Objekten aus einem Positions-Array.
    /// </summary>
    /// <remarks>
    /// Vorgefertigte Arrays für bestimmte Formationen sind in der Klasse bereits verfügbar.
    /// </remarks>
    public static class FormationGenerator
    {
        /// <summary>
        /// Positionsangaben für eine Block-Formation.
        /// </summary>
        /// <remarks>Die Positionen sind zeilenweise "von links nach rechts" (aufsteigende X-Werte) und die Zeilen nacheinander "von unten nach oben" (aufsteigende Y-Werte) angeordnet.</remarks>
        public static Vector2[] BlockFormation
        {
            get
            {
                Vector2[] formation = {new Vector2(-40f, 10f), new Vector2(-20f, 10f), new Vector2(0f, 10f), new Vector2(20f, 10f), new Vector2(40f, 10f),
                                          new Vector2(-30f, 20f), new Vector2(-10f, 20f), new Vector2(10f, 20f), new Vector2(30f, 20f),
                                          new Vector2(-40f, 30f), new Vector2(-20f, 30f), new Vector2(0f, 30f), new Vector2(20f, 30f), new Vector2(40f, 30f),
                                          new Vector2(-30f, 40f), new Vector2(-10f, 40f), new Vector2(10f, 40f), new Vector2(30f, 40f),
                                          new Vector2(-40f, 50f), new Vector2(-20f, 50f), new Vector2(0f, 50f), new Vector2(20f, 50f), new Vector2(40f, 50f)};
                return formation;
            }
        }

        /// <summary>
        /// Positionsangaben für eine Totenkopf-Formation.
        /// </summary>
        /// <remarks>Die Positionen sind zeilenweise "von links nach rechts" (aufsteigende X-Werte) und die Zeilen nacheinander "von unten nach oben" (aufsteigende Y-Werte) angeordnet.</remarks>
        public static Vector2[] SkullFormation
        {
            get
            {
                Vector2[] formation = {new Vector2(-20f, 10f), new Vector2(0f, 10f), new Vector2(20f, 10f),
                                          new Vector2(-20f, 20f), new Vector2(-10f, 20f), new Vector2(0f, 20f), new Vector2(10f, 20f), new Vector2(20f, 20f),
                                          new Vector2(-30f, 30f), new Vector2(-20f, 30f), new Vector2(-10f, 30f), new Vector2(0f, 30f), new Vector2(10f, 30f), new Vector2(20f, 30f), new Vector2(30f, 30f),
                                          new Vector2(-30f, 40f), new Vector2(0f, 40f), new Vector2(30f, 40f),
                                          new Vector2(-20f, 50f), new Vector2(-10f, 50f), new Vector2(0f, 50f), new Vector2(10f, 50f), new Vector2(20f, 50f)};
                return formation;
            }
        }

        /// <summary>
        /// Positionsangaben für eine Dreieck-Formation.
        /// </summary>
        /// <remarks>Die Positionen sind zeilenweise "von links nach rechts" (aufsteigende X-Werte) und die Zeilen nacheinander "von unten nach oben" (aufsteigende Y-Werte) angeordnet.</remarks>
        public static Vector2[] TriangleFormation
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        /// <summary>
        /// Positionsangaben für eine Kreis-Formation.
        /// </summary>
        /// <remarks>Die Positionen sind zeilenweise "von links nach rechts" (aufsteigende X-Werte) und die Zeilen nacheinander "von unten nach oben" (aufsteigende Y-Werte) angeordnet.</remarks>
        public static Vector2[] CircleFormation
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        /// <summary>
        /// Positionsangaben für eine Pfeil-Formation.
        /// </summary>
        /// <remarks>Die Positionen sind zeilenweise "von links nach rechts" (aufsteigende X-Werte) und die Zeilen nacheinander "von unten nach oben" (aufsteigende Y-Werte) angeordnet.</remarks>
        public static Vector2[] ArrowFormation
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        /// <summary>
        /// Positionsangaben für eine "Unendlich"-Formation.
        /// </summary>
        /// <remarks>Die Positionen sind zeilenweise "von links nach rechts" (aufsteigende X-Werte) und die Zeilen nacheinander "von unten nach oben" (aufsteigende Y-Werte) angeordnet.</remarks>
        public static Vector2[] InfinityFormation
        {
            get
            {
                throw new System.NotImplementedException();
            }
        }

        /// <summary>
        /// Erzeugt eine Liste von Gegner-Objekten aus einem Vector2-Array.
        /// </summary>
        /// <param name="hitpointsMultiplier">Lebenspunkte der Gegner</param>
        /// <param name="velocityMultiplier">maximale Geschwindigkeit der Gegner</param>
        /// <param name="hitpoints">Lebenspunkte</param>
        /// <param name="velocity">Geschwindigkeit</param>
        /// <param name="formation">Formation der Welle</param>
        /// <param name="damage">Kollisionsschaden</param>
        /// <param name="scoreGain">Abschusspunktzahl</param>
        /// <returns>Die generierte Liste von Gegnern</returns>
        public static LinkedList<IGameItem> CreateFormation(int hitpoints, Vector2 velocity, Vector2[] formation, int damage, int scoreGain)
        {
            LinkedList<IGameItem> wave = new LinkedList<IGameItem>();
            for (int i = 0; i < formation.Length; i++)
            {
                wave.AddLast(new Alien(formation[i], velocity, hitpoints, damage, GameItemConstants.AlienWeapon, scoreGain));
            }
            return wave;
        }
    }
}
