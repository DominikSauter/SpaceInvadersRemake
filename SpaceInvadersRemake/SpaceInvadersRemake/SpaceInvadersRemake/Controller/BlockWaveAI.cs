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
        // ADDED (by STST): 29.06.2011
        // Grund: ich kann mit dem gegebenen Entwurf nicht arbeiten und will mit dieser Klassen-Namenskonflikten ausweichen.
        private class STSTHelpers
        {
            BlockWaveAI outerClass;

            public STSTHelpers(BlockWaveAI outerClass)
            {
                this.outerClass = outerClass;
            }

            public void Shooting(Game game, GameTime gameTime)
            {
                const int POINT_SHIFTING = 1000;

                float alienFreq = GetAlienShootingFrequency(game);
                if (alienFreq > 1)
                    throw new Exception("Frequenz ist zu hoch um mit dem Algorithmus klar zu kommen.");

                // zu der Wahrscheinlichkeit soll jetzt jedes Alien was schießen kann, schießen:
                Random rnd = new Random();
                foreach (LinkedList<IGameItem> col in outerClass.AlienMatrix)
                {
                    int iAlienFreq = (int)(alienFreq * POINT_SHIFTING);
                    int iRnd = rnd.Next(POINT_SHIFTING);
                    if (iRnd <= iAlienFreq)
                        if (col.Last != null)
                            col.Last.Value.Shoot(gameTime);
                }
            }
            
            private float GetAlienShootingFrequency(Game game)
            {
                return outerClass.ShootingFrequency / outerClass.AlienMatrix.Count / (float)game.TargetElapsedTime.TotalSeconds;
            }
        }

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
                    if (item.IsAlive)
                    {
                        item.Move(CoordinateConstants.Down, gameTime);

                        //GameItem werden schneller
                        item.Velocity += this.VelocityIncrease;
                    }
                    else 
                    {
                        //Entferne Tote GameItems
                        this.Controllees.Remove(item);
                        // <STST>
                        // Alien aus AlienMatrix
                        foreach (var col in this.AlienMatrix)
                        {
                            if (col.Contains(item))
                            {
                                col.Remove(item);
                                break;
                            }
                        }
                        // </STST>
                    }
                }
                moveDown = false;
            }
            else //Bewegung in Richtung aktuelle Richtung.
            {
                foreach (IGameItem item in Controllees)
                {
                    if (item.IsAlive)
                    {
                        if (!item.Move(currentDirection, gameTime))
                        {
                            moveDown = true;
                        }
                    }
                    else //Entferne Tote GameItems
                    {
                        this.Controllees.Remove(item);
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
                    if (item.IsAlive)
                    {
                        item.Move(currentDirection, gameTime);
                    }
                    else //Totes Item
                    {
                        this.Controllees.Remove(item);
                    }
                }
            }

            // <STST>
            new STSTHelpers(this).Shooting(game, gameTime);
            // </STST>
          }

        /// <summary>
        /// Eigenschaft Controllees Liste (kontrollierte Objekte)
        /// </summary>
        // DESIGN (by STST): 29.06.2011
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


    }
}
