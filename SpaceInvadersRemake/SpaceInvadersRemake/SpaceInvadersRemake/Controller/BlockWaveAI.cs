using System;
using System.Collections.Generic;
using SpaceInvadersRemake.ModelSection;
using Microsoft.Xna.Framework;
using SpaceInvadersRemake.StateMachine;
using System.Linq;


//Implementiert von Chris
namespace SpaceInvadersRemake.Controller
{
    /// <summary>
    /// KI die eine Welle kontrolliert in Block Formation.
    /// </summary>
    /// <remarks>
    /// Verhalten einer Block Formation:
    /// 
    /// </remarks>
    public class BlockWaveAI : WaveAI
    {
        //Private Felder
        private bool moveDown = false;
        private Vector2 currentDirection = CoordinateConstants.Right;

        // by STST
        /// <summary>
        /// Generiert eine neue BlockWaveAI Klasse.
        /// </summary>
        /// <param name="shootingFrequency">Die Schussfrequenz.</param>
        /// <param name="controllees">Die GameItem, die der Controller kontrollieren soll.</param>
        /// <param name="velocityIncrease">Geschwindigkeitserhöhung</param>
        public BlockWaveAI(float shootingFrequency, ICollection<IGameItem> controllees, Vector2 velocityIncrease)
            : base(shootingFrequency, controllees, velocityIncrease)
        {
        }



        /// <summary>
        /// Eigenschaft Controllees Liste (kontrollierte Objekte)
        /// </summary>
        // DESIGN (by STST): 29.06.2011
        //Hack: Wieso override mit identischer implementierung ?
        protected override ICollection<IGameItem> Controllees { get; set; }

        //Private Methoden

        /// <summary>
        /// Ändert die Richtung.
        /// </summary>
        /// <param name="currentDirection">Die aktuelle Richtung.</param>
        /// <returns>Die Gegengesetzte Richtung</returns>
        private static Vector2 changeDirection(Vector2 currentDirection)
        {

            if (currentDirection == CoordinateConstants.Left)
            {
                return CoordinateConstants.Right;
            }
            else
            {
                return CoordinateConstants.Left;
            }
        }

        /// <summary>
        /// Kümmert sich um die Bewegung der GameItem
        /// </summary>
        /// <param name="game">Referenz des Games aus dem XNA Framework.</param>
        /// <param name="gameTime">Bietet die aktuelle Spielzeit an.</param>
        protected override void Movement(Game game, GameTime gameTime)
        {
            //Ausführung des Runter Kommandos aus vorigem Frame.
            if (moveDown)
            {
                //Navigiert alle GameItem nach unten.
                foreach (IGameItem item in Controllees)
                {
                    
                        item.Move(CoordinateConstants.Down, gameTime);

                        //GameItem werden schneller
                        item.Velocity += this.VelocityIncrease;


                }
                moveDown = false;
            }
            else //Bewegung in Richtung aktuelle Richtung.
            {
                foreach (IGameItem item in Controllees)
                {
                    
                        if (!(item.Move(currentDirection, gameTime)))
                        {
                            moveDown = true;

                        }

                }
            }

            /*
             * Ändert die aktuelle Richtung sofern ein GameItem am Rand ist, 
             * damit nachdem runtergerückt wurde in die andere Richtung sich bewegt wird.
            */
            if (moveDown)
            {


                currentDirection = BlockWaveAI.changeDirection(currentDirection);

                //Alle mann zurück!
                foreach (IGameItem item in Controllees)
                {
 
                        item.Move(currentDirection, gameTime);
                    
                }
            }
        }

        /// <summary>
        /// Kümmert sich um das Schießen der GameItem
        /// </summary>
        /// <param name="game">Referenz des Games aus dem XNA Framework.</param>
        /// <param name="gameTime">Bietet die aktuelle Spielzeit an.</param>
        protected override void Shooting(Game game, GameTime gameTime)
        {
            const int POINT_SHIFTING = 1000; // TODO: reicht der aus?

            float alienFreqInHz = this.ShootingFrequency / this.AlienMatrix.Count;
            float alienFreqInFrame = alienFreqInHz * (float)game.TargetElapsedTime.TotalSeconds;
            if (alienFreqInFrame > 1)
                throw new Exception("Frequenz ist zu hoch um mit dem Algorithmus klar zu kommen.");

            // zu der Wahrscheinlichkeit soll jetzt jedes Alien was schießen kann, schießen:
            Random rnd = new Random();
            foreach (LinkedList<IGameItem> col in this.AlienMatrix)
            {
                int iAlienFreq = (int)(alienFreqInFrame * POINT_SHIFTING);
                int iRnd = rnd.Next(POINT_SHIFTING);
                if (iRnd <= iAlienFreq)
                    if (col.Last != null)
                        col.Last.Value.Shoot(gameTime);
            }
        }
    }
}




