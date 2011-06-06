using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using SpaceInvadersRemake.Controller;

namespace SpaceInvadersRemake.ModelSection
{
    /// <summary>
    /// Die Klasse dient dazu sich Gegner (<c>GameItem</c>) generieren zu lassen
    /// </summary>
    /// <remarks>Abstrakte Fabrik</remarks>
    public static class FormationGenerator
    {
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
        /// Generiert eine FormationEnum von Gegnern 
       /// </summary>
       /// <returns></returns>
        public static List<IGameItem> CreateFormation(int hitpoints, Vector2 velocity, Array formation)
        {
            throw new System.NotImplementedException();
}
 
    }

    public static class WaveGenerator
    {
        public static event EventHandler WaveGenerated;

        public static List<IGameItem> CreateWave(ControllerEnum AI, Vector2[] formation, DifficultyLevel difficultyLevel)
        {
            throw new System.NotImplementedException();
            //SwitchCase über "Bestellung" 
            //Private Methoden für konkrete Creatings um swichcase übersichtlich zu halten
        }
    }
}
