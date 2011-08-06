using System;
using Microsoft.Xna.Framework;
using SpaceInvadersRemake.ModelSection;

//Implemntiert von Christian (ck)
namespace SpaceInvadersRemake.Controller
{
    /// <summary>
    /// Diese Klasse stellt die KI des Mutterschiffes da.
    /// </summary>
    public class MothershipAI : AIController
    {
        // MODIFIED (by STST): 2.7.2011
        /// <summary>
        /// Generiert eine neue Instanz der MothershipAI Controllers.
        /// </summary>
        public MothershipAI(ControllerManager controllerManager, float shootingFrequency, IGameItem controllee, Vector2 velocityIncrease)
            : base(controllerManager, shootingFrequency, controllee, velocityIncrease)
        {
            Mothership.Destroyed += new EventHandler(Mothership_Destroyed);
        }


        //MothershipController aus Liste von ControllerManager austragen 
       private void Mothership_Destroyed(object sender, EventArgs e)
        {
            //verhindert das bei mehr als einem Mutterschiffen das eine Anhält wenn das andere Zerstört wird
            if (sender == this.Controllee) 
           
            {
                this.controllerManager.Controllers.Remove(this);
            }
        }


        /// <summary>
        /// Entscheidet in welche Richtung sich das Controllee bewegen soll
        /// </summary>
        /// <returns>
        /// 2D Richtungsvektor
        /// </returns>
        protected override void Movement(Game game,GameTime gameTime)
        {
            this.Controllee.Move(CoordinateConstants.Right,gameTime);
        }


        /// <summary>
        /// Kümmert sich um das Schießen der GameItem
        /// </summary>
        /// <param name="game">Referenz des Games aus dem XNA Framework.</param>
        /// <param name="gameTime">Bietet die aktuelle Spielzeit an.</param>
        protected override void Shooting(Game game, GameTime gameTime)
        {
            //TODO für /FA11000W/ (Mutterschiff schießt) - ck

        }
    }
}
