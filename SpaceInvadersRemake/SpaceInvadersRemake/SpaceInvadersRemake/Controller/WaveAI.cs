using System.Collections.Generic;
using SpaceInvadersRemake.ModelSection;
using Microsoft.Xna.Framework;

//Implementiert von Chris
namespace SpaceInvadersRemake.Controller
{
    /// <summary>
    /// Diese Klasse abstrahiert von den verschiedenen KIs zur Steurerung einer Welle von Gegnern
    /// </summary>
    /// <remarks>
    /// Von dieser Klasse ist für die Implementierung einer Wellen KI zu erben.
    /// </remarks>
    public abstract class WaveAI : AIController
    {


        /// <summary>
        /// Erstellt eine neue Instanz eines allgemeinen WaveAI Controllers.
        /// </summary>
        /// <remarks>
        /// Da dies eine Abstrakte Klasse ist, wird dieser innerhalb des Konstruktors der konkreten Klasse aufgerufen.
        /// </remarks>
        /// <param name="shootingFrequencyMultiplier">Die Schussfrequenz.</param>
        /// <param name="controllees">Die GameItem, die der Controller kontrollieren soll.</param>
      protected  WaveAI(int shootingFrequency, ICollection<IGameItem> controllees,Vector2 velocityIncrease)
            : base(shootingFrequency, null, velocityIncrease) //null wird das single controllee gesetzt 
        {
            
            this.Controllees = controllees;
        }

        /// <summary>
        /// Eigenschaft Controllees Liste (kontrollierte Objekt)
        /// </summary>
        protected abstract System.Collections.Generic.ICollection<IGameItem> Controllees
        {
            get;

           set; 

        }
    }
}
