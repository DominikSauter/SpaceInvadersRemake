using System;
using System.Collections.Generic;
using SpaceInvadersRemake.ModelSection;
using Microsoft.Xna.Framework;
using SpaceInvadersRemake.StateMachine;


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
        
        
        /// <summary>
        /// Generiert eine neue BlockWaveAI Klasse.
        /// </summary>
        /// <param name="shootingFrequency">Die Schussfrequenz.</param>
        /// <param name="controllees">Die GameItem, die der Controller kontrollieren soll.</param>
        public BlockWaveAI(int shootingFrequency, ICollection<IGameItem> controllees) :base (shootingFrequency, controllees)
        {
            
        }

            
        /// <summary>
        /// Entscheidet in welche Richtung sich das Controllees bewegen soll
        /// </summary>
        /// <returns>
        /// 2D Richtungsvektor
        /// </returns>
        
        //Nicht brauchbar in dieser Klasse.
        protected override Microsoft.Xna.Framework.Vector2 Movement()
        {
            
            return Vector2.Zero;
        }

        /// <summary>
        /// Entscheidet ob Controllees schießen soll
        /// </summary>
        /// <returns></returns>
        /// <c>true</c>
        ///  = schießen andererseits 
        /// <c>false</c>
        protected override bool Shooting()
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Erlaubt die Ausführung der Steuerung.
        /// </summary>
        /// <param name="game">Referenz des Games aus dem XNA Framework.</param>
        /// <param name="gameTime">Bietet die aktuelle Spielzeit an.</param>
        /// <param name="state">Gibt den aktuellen State an von dem diese Funktion aufgerufen wurde.</param>
        public override void Update(Game game, GameTime gameTime, State state)
        {

            //Ausführung des Runter Kommandos aus vorigem Frame.
            if (moveDown)
            {
                //Navigiert alle GameItem nach unten.
                foreach (IGameItem item in Controllees)
                {
                    item.Move(CoordinateConstants.Down);
                }
                moveDown = false;
            }
            else //Bewegung in Richtung aktuelle Richtung.
            {
                foreach (IGameItem item in Controllees)
                {
                    if (!item.Move(currentDirection))
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

                //Hack für Performance 
                //sofern Left * -1 = Right ist, kann current *(-1) stehen für gleichen Effekt.
                currentDirection = BlockWaveAI.changeDirection(currentDirection);
                
                //Alle mann zurück!
                foreach (IGameItem item in Controllees)
                {
                    item.Move(currentDirection);
                }
            }

            //TODO Implement Shooting

          }

        /// <summary>
        /// Eigenschaft Controllees Liste (kontrollierte Objekte)
        /// </summary>
        protected override ICollection<IGameItem> Controllees
        {
            get;
 
            set;

        }

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

        //TODO löschen demnächst
        //private void movingBack()
        //{
        //    moveDown = true;
        //}

    }
}
