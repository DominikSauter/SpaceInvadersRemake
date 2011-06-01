using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace SpaceInvadersRemake
{
    /// <summary>
    /// Die Klasse dient dazu sich Gegner (<c>GameItem</c>) generieren zu lassen
    /// </summary>
    /// <remarks>Abstrakte Fabrik</remarks>
    public abstract class FormationGenerator
    {

       /// <summary>
        /// Generiert eine FormationEnum von Gegnern 
       /// </summary>
       /// <returns></returns>
        protected abstract List<IGameItem> CreateFormation(int hitpoints, Vector2 velocity);
 
    }

    public static class WaveGenerator
    {
        public static Controller CreateWave(DifficultyLevel difficulty, FormationEnum formation, ControllerEnum AI)
        {
            throw new System.NotImplementedException();
            //SwitchCase über "Bestellung" 
            //Private Methoden für konkrete Creatings um swichcase übersichtlich zu halten
        }
    }
}
