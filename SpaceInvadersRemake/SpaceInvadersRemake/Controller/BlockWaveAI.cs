using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using SpaceInvadersRemake.ModelSection;
using System.Diagnostics;


//Implemntiert von Christian (ck)
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
        private Random rnd;

        // by STST
        // MODIFIED (by STST): 2.7.2011
        /// <summary>
        /// Generiert eine neue BlockWaveAI Klasse.
        /// </summary>
        /// <param name="shootingFrequency">Die Schussfrequenz.</param>
        /// <param name="controllees">Die GameItem, die der Controller kontrollieren soll.</param>
        /// <param name="velocityIncrease">Geschwindigkeitserhöhung</param>
        /// <param name="controllerManager">Verweis auf Verwaltungsklasse</param>
        public BlockWaveAI(ControllerManager controllerManager, float shootingFrequency, ICollection<IGameItem> controllees, Vector2 velocityIncrease)
            : base(controllerManager, shootingFrequency, controllees, velocityIncrease)
        {
            rnd = new Random();
        }

        //Private Felder
        private Vector2 VelocityIncreasePerFrame;

        #region Private Methoden
        /// <summary>
        /// Ändert die Richtung.
        /// </summary>
        /// <param name="currentDirection">Die aktuelle Richtung.</param>
        /// <returns>Die Gegengesetzte Richtung</returns>
        private static Vector2 changeDirection(Vector2 currentDirection)
        {

           Debug.Assert(currentDirection.Equals(CoordinateConstants.Left) || currentDirection.Equals(CoordinateConstants.Right));
            
            if (currentDirection == CoordinateConstants.Left)
            {
                return CoordinateConstants.Right;
            }
            else
            {
                return CoordinateConstants.Left;
            }
        } 
        #endregion

        /// <summary>
        /// Kümmert sich um die Bewegung der GameItem
        /// </summary>
        /// <param name="game">Referenz des Games aus dem XNA Framework.</param>
        /// <param name="gameTime">Bietet die aktuelle Spielzeit an.</param>
        protected override void Movement(Game game, GameTime gameTime)
        {

            //Umrechnung von V/s in V/frame
            VelocityIncreasePerFrame = (this.VelocityIncrease * (float)game.TargetElapsedTime.TotalSeconds);

            
            //Ausführung des Runter Kommandos aus vorigem Frame.
            if (moveDown)
            {
                //Navigiert alle GameItem nach unten.
                foreach (IGameItem item in Controllees)
                {
                    // Geschwindigkeitserhöhung
                    item.Velocity += VelocityIncreasePerFrame;
    
                    //Befehl an GameItem
                    item.Move(CoordinateConstants.Down, gameTime);
                }
                
                //MoveDown ausgeführt !
                moveDown = false;
            }
            else //Bewegung in Richtung aktuelle Richtung.
            {
                foreach (IGameItem item in Controllees)
                {

                    // Geschwindigkeitserhöhung
                    item.Velocity += VelocityIncreasePerFrame;
    
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
                        
            const int POINT_SHIFTING = 1000; // HACK: reicht der aus?

            float alienFreqInHz = this.ShootingFrequency / this.AlienMatrix.Count;
            float alienFreqInFrame = alienFreqInHz * (float)game.TargetElapsedTime.TotalSeconds;

            if (!game.IsFixedTimeStep)
                throw new ArgumentException("Game.isFixedTimeStep = true, sonst funktioniert der Algorithmus nicht richtig.");
            if (alienFreqInFrame > 1)
                throw new ArgumentException("Frequenz ist zu hoch um mit dem Algorithmus klar zu kommen.");

            // zu der Wahrscheinlichkeit soll jetzt jedes Alien was schießen kann, schießen:
           
            //new Random-Erzeugung in Konstruktor verlagert um Performance zu sparen -CK

            foreach (LinkedList<IGameItem> col in this.AlienMatrix)
            {
                int iAlienFreq = (int)(alienFreqInFrame * POINT_SHIFTING);
                int iRnd = rnd.Next(POINT_SHIFTING);
                if (iRnd <= iAlienFreq)
                    if (col.First != null)
                        col.First.Value.Shoot(gameTime);
            }
            
        }
    }
}




