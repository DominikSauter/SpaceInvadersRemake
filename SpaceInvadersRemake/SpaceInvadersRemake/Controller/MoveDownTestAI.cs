using System.Collections.Generic;
using Microsoft.Xna.Framework;
using SpaceInvadersRemake.ModelSection;

//Implemntiert von Christian (ck)
namespace SpaceInvadersRemake.Controller

{
    /// <summary>
    /// TEST AI 
    /// </summary>
    /// <remarks>
    /// Eine AI die alle Aliens nach unten fliegen lässt. Zu Testzwecken verwenden.
    /// </remarks>
    class MoveDownTestAI : WaveAI
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="MoveDownTestAI"/> class.
        /// </summary>
        /// <param name="controllerManager">Verweis auf Verwaltungsklasse</param>
        /// <param name="shootingFrequency">Die Schussfrequenz.</param>
        /// <param name="controllees">Die GameItem, die der Controller kontrollieren soll.</param>
        /// <param name="velocityIncrease">Geschwindigkeitserhöhung</param>
        public MoveDownTestAI(ControllerManager controllerManager, float shootingFrequency, ICollection<IGameItem> controllees, Vector2 velocityIncrease)
            : base(controllerManager, shootingFrequency, controllees, velocityIncrease)
        {
           

        }


        /// <summary>
        /// Kümmert sich um die Bewegung der GameItem
        /// </summary>
        /// <param name="game">Referenz des Games aus dem XNA Framework.</param>
        /// <param name="gameTime">Bietet die aktuelle Spielzeit an.</param>
        protected override void Movement(Microsoft.Xna.Framework.Game game, Microsoft.Xna.Framework.GameTime gameTime)
        {
            foreach (var item in Controllees)
            {
                item.Move(SpaceInvadersRemake.ModelSection.CoordinateConstants.Down, gameTime);
            }
        }

        /// <summary>
        /// Kümmert sich um das Schießen der GameItem
        /// </summary>
        /// <param name="game">Referenz des Games aus dem XNA Framework.</param>
        /// <param name="gameTime">Bietet die aktuelle Spielzeit an.</param>
        protected override void Shooting(Microsoft.Xna.Framework.Game game, Microsoft.Xna.Framework.GameTime gameTime)
        {
            
        }
    }
}
