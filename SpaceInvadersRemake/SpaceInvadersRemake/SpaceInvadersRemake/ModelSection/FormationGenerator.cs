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
        /// Gibt den Abstand zwischen zwei direkt benachbarten Aliens in einer Formation an und damit die Größe/Skalierung der Formation.
        /// </summary>
        private static float alienDistance = 15.0f;

        /// <summary>
        /// Gibt den Fußpunkt einer Formation an, d.h. den mittigen X-Wert und den kleinsten Y-Wert der Formation.
        /// </summary>
        private static Vector2 basePoint = new Vector2(0.0f, 0.0f);

        /// <summary>
        /// Positionsangaben für eine Block-Formation.
        /// </summary>
        /// <remarks>Die Positionen sind zeilenweise "von links nach rechts" (aufsteigende X-Werte) und die Zeilen nacheinander "von unten nach oben" (aufsteigende Y-Werte) angeordnet.</remarks>
        public static Vector2[] BlockFormation
        {
            get
            {
                float ad = alienDistance;
                Vector2 bp = basePoint;
                Vector2[] formation = {new Vector2(bp.X - (4 * ad), bp.Y), new Vector2(bp.X - (2 * ad), bp.Y), new Vector2(bp.X, bp.Y), new Vector2(bp.X + (2 * ad), bp.Y), new Vector2(bp.X + (4 * ad), bp.Y),
                                          new Vector2(bp.X - (3 * ad), bp.Y + ad), new Vector2(bp.X - ad, bp.Y + ad), new Vector2(bp.X + ad, bp.Y + ad), new Vector2(bp.X + (3 * ad), bp.Y + ad),
                                          new Vector2(bp.X - (4 * ad), bp.Y + (2 * ad)), new Vector2(bp.X - (2 * ad), bp.Y + (2 * ad)), new Vector2(bp.X, bp.Y + (2 * ad)), new Vector2(bp.X + (2 * ad), bp.Y + (2 * ad)), new Vector2(bp.X + (4 * ad), bp.Y + (2 * ad)),
                                          new Vector2(bp.X - (3 * ad), bp.Y + (3 * ad)), new Vector2(bp.X - ad, bp.Y + (3 * ad)), new Vector2(bp.X + ad, bp.Y + (3 * ad)), new Vector2(bp.X + (3 * ad), bp.Y + (3 * ad)),
                                          new Vector2(bp.X - (4 * ad), bp.Y + (4 * ad)), new Vector2(bp.X - (2 * ad), bp.Y + (4 * ad)), new Vector2(bp.X, bp.Y + (4 * ad)), new Vector2(bp.X + (2 * ad), bp.Y + (4 * ad)), new Vector2(bp.X + (4 * ad), bp.Y + (4 * ad))};
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
                float ad = alienDistance;
                Vector2 bp = basePoint;
                Vector2[] formation = {new Vector2(bp.X - (2 * ad), bp.Y), new Vector2(bp.X, bp.Y), new Vector2(bp.X + (2 * ad), bp.Y),
                                          new Vector2(bp.X - (2 * ad), bp.Y + ad), new Vector2(bp.X - ad, bp.Y + ad), new Vector2(bp.X, bp.Y + ad), new Vector2(bp.X + ad, bp.Y + ad), new Vector2(bp.X + (2 * ad), bp.Y + ad),
                                          new Vector2(bp.X - (3 * ad), bp.Y + (2 * ad)), new Vector2(bp.X - (2 * ad), bp.Y + (2 * ad)), new Vector2(bp.X - ad, bp.Y + (2 * ad)), new Vector2(bp.X, bp.Y + (2 * ad)), new Vector2(bp.X + ad, bp.Y + (2 * ad)), new Vector2(bp.X + (2 * ad), bp.Y + (2 * ad)), new Vector2(bp.X + (3 * ad), bp.Y + (2 * ad)),
                                          new Vector2(bp.X - (3 * ad), bp.Y + (3 * ad)), new Vector2(bp.X, bp.Y + (3 * ad)), new Vector2(bp.X + (3 * ad), bp.Y + (3 * ad)),
                                          new Vector2(bp.X - (2 * ad), bp.Y + (4 * ad)), new Vector2(bp.X - ad, bp.Y + (4 * ad)), new Vector2(bp.X, bp.Y + (4 * ad)), new Vector2(bp.X + ad, bp.Y + (4 * ad)), new Vector2(bp.X + (2 * ad), bp.Y + (4 * ad))};
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
                float ad = alienDistance;
                Vector2 bp = basePoint;
                Vector2[] formation = {new Vector2(bp.X, bp.Y),
                                          new Vector2(bp.X - ad, bp.Y + ad), new Vector2(bp.X, bp.Y + ad), new Vector2(bp.X + ad, bp.Y + ad),
                                          new Vector2(bp.X - (2 * ad), bp.Y + (2 * ad)), new Vector2(bp.X - ad, bp.Y + (2 * ad)), new Vector2(bp.X, bp.Y + (2 * ad)), new Vector2(bp.X + ad, bp.Y + (2 * ad)), new Vector2(bp.X + (2 * ad), bp.Y + (2 * ad)),
                                          new Vector2(bp.X - (3 * ad), bp.Y + (3 * ad)), new Vector2(bp.X - (2 * ad), bp.Y + (3 * ad)), new Vector2(bp.X - ad, bp.Y + (3 * ad)), new Vector2(bp.X + ad, bp.Y + (3 * ad)), new Vector2(bp.X + (2 * ad), bp.Y + (3 * ad)), new Vector2(bp.X + (3 * ad), bp.Y + (3 * ad)),
                                          new Vector2(bp.X - (4 * ad), bp.Y + (4 * ad)), new Vector2(bp.X - (3 * ad), bp.Y + (4 * ad)), new Vector2(bp.X - (2 * ad), bp.Y + (4 * ad)), new Vector2(bp.X, bp.Y + (4 * ad)), new Vector2(bp.X + (2 * ad), bp.Y + (4 * ad)), new Vector2(bp.X + (3 * ad), bp.Y + (4 * ad)), new Vector2(bp.X + (4 * ad), bp.Y + (4 * ad))};
                return formation;
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
                Vector2[] formation = {new Vector2(-40f, 10f), new Vector2(-10f, 10f), new Vector2(0f, 10f), new Vector2(10f, 10f), new Vector2(40f, 10f),
                                          new Vector2(-20f, 20f), new Vector2(-10f, 20f), new Vector2(10f, 20f), new Vector2(20f, 20f),
                                          new Vector2(-30f, 30f), new Vector2(-20f, 30f), new Vector2(0f, 30f), new Vector2(20f, 30f), new Vector2(30f, 30f),
                                          new Vector2(-20f, 40f), new Vector2(-10f, 40f), new Vector2(10f, 40f), new Vector2(20f, 40f),
                                          new Vector2(-40f, 50f), new Vector2(-10f, 50f), new Vector2(0f, 50f), new Vector2(10f, 50f), new Vector2(40f, 50f)};
                return formation;
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
                float ad = alienDistance;
                Vector2 bp = basePoint;
                Vector2[] formation = {new Vector2(bp.X - (3 * ad), bp.Y), new Vector2(bp.X + (3 * ad), bp.Y),
                                          new Vector2(bp.X - (4 * ad), bp.Y + ad), new Vector2(bp.X - (3 * ad), bp.Y + ad), new Vector2(bp.X - (2 * ad), bp.Y + ad), new Vector2(bp.X + (2 * ad), bp.Y + ad), new Vector2(bp.X + (3 * ad), bp.Y + ad), new Vector2(bp.X + (4 * ad), bp.Y + ad),
                                          new Vector2(bp.X - (5 * ad), bp.Y + (2 * ad)), new Vector2(bp.X - (3 * ad), bp.Y + (2 * ad)), new Vector2(bp.X - ad, bp.Y + (2 * ad)), new Vector2(bp.X + ad, bp.Y + (2 * ad)), new Vector2(bp.X + (3 * ad), bp.Y + (2 * ad)), new Vector2(bp.X + (5 * ad), bp.Y + (2 * ad)),
                                          new Vector2(bp.X - (3 * ad), bp.Y + (3 * ad)), new Vector2(bp.X + (3 * ad), bp.Y + (3 * ad)),
                                          new Vector2(bp.X - (3 * ad), bp.Y + (4 * ad)), new Vector2(bp.X + (3 * ad), bp.Y + (4 * ad))};
                return formation;
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
                float ad = alienDistance;
                Vector2 bp = basePoint;
                Vector2[] formation = {new Vector2(bp.X - (3 * ad), bp.Y), new Vector2(bp.X - (2 * ad), bp.Y), new Vector2(bp.X + (2 * ad), bp.Y), new Vector2(bp.X + (3 * ad), bp.Y),
                                          new Vector2(bp.X - (4 * ad), bp.Y + ad), new Vector2(bp.X - ad, bp.Y + ad), new Vector2(bp.X + ad, bp.Y + ad), new Vector2(bp.X + (4 * ad), bp.Y + ad),
                                          new Vector2(bp.X - (5 * ad), bp.Y + (2 * ad)), new Vector2(bp.X, bp.Y + (2 * ad)), new Vector2(bp.X + (5 * ad), bp.Y + (2 * ad)),
                                          new Vector2(bp.X - (4 * ad), bp.Y + (3 * ad)), new Vector2(bp.X - ad, bp.Y + (3 * ad)), new Vector2(bp.X + ad, bp.Y + (3 * ad)), new Vector2(bp.X + (4 * ad), bp.Y + (3 * ad)),
                                          new Vector2(bp.X - (3 * ad), bp.Y + (4 * ad)), new Vector2(bp.X - (2 * ad), bp.Y + (4 * ad)), new Vector2(bp.X + (2 * ad), bp.Y + (4 * ad)), new Vector2(bp.X + (3 * ad), bp.Y + (4 * ad))};
                return formation;
            }
        }

        /// <summary>
        /// Erzeugt eine Liste von Gegner-Objekten aus einem Vector2-Array.
        /// </summary>
        /// <param name="AI">Art der Welle</param>
        /// <param name="hitpoints">Lebenspunkte</param>
        /// <param name="velocity">Geschwindigkeit</param>
        /// <param name="formation">Formation der Welle</param>
        /// <param name="damage">Kollisionsschaden</param>
        /// <param name="scoreGain">Abschusspunktzahl</param>
        /// <returns>Die generierte Liste von Gegnern</returns>
        public static LinkedList<IGameItem> CreateFormation(BehaviourEnum AI, int hitpoints, Vector2 velocity, Vector2[] formation, int damage, int scoreGain)
        {
            LinkedList<IGameItem> wave = new LinkedList<IGameItem>();
            if (AI.Equals(BehaviourEnum.MothershipMovement))
            {
                for (int i = 0; i < formation.Length; i++)
                {
                    wave.AddLast(new Mothership(formation[i], velocity, hitpoints, damage, GameItemConstants.MothershipWeapon, scoreGain));
                }
            }
            else
            {
                for (int i = 0; i < formation.Length; i++)
                {
                    wave.AddLast(new Alien(formation[i], velocity, hitpoints, damage, GameItemConstants.AlienWeapon, scoreGain));
                }
            }

            return wave;
        }
    }
}
