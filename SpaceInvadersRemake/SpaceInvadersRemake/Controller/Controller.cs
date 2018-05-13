using Microsoft.Xna.Framework;
using SpaceInvadersRemake.ModelSection;
using SpaceInvadersRemake.StateMachine;

//Implemntiert von Christian (ck)
namespace SpaceInvadersRemake.Controller
{

    /// <summary>
    /// Die abstrakte Controller Klasse ist dafür zuständig die verschiedenen <c>GameItem</c> zu kontrollieren.
    /// </summary>
    /// <remarks> 
    /// Sie abstrahiert von den Controller-Verhaltensweisen Benutzer und Künstliche Intelligenz im GameState
    /// Um dies zutun benutzt sie das GameItem Interface.
    /// Von dieser Klasse ist nicht zu erben, sondern von ihren Unterklassen.
    /// <see cref="PlayerController"/>
    /// <see cref="AIController"/>
    /// </remarks>
    public abstract class Controller : ICommander
    {
        // ADDED (by STST): 2.7.2011
        protected readonly ControllerManager controllerManager;

        
        /// <summary>
        /// Erstellt eine neue Instanz eines allgemeinen Controllers.
        /// </summary>
        /// <remarks>
        /// Da dies eine Abstrakte Klasse ist, wird dieser innerhalb des Konstruktors der konkreten Klasse aufgerufen.
        /// </remarks>
        /// <param name="controllerManager">Verweis auf Verwaltungsklasse</param>
        /// <param name="controllee">Controllee des Controllers</param>
        protected Controller(ControllerManager controllerManager, IGameItem controllee)
        {
            this.Controllee = controllee;
            this.controllerManager = controllerManager;
        }
  

    
       /// <summary>
       /// Eigenschaft Controllees (kontrolliertes Objekt)
       /// </summary>
       /// <remarks>Eigenschaft in der das kontrollierte GameItem gespeichert ist.
       /// <c>get</c>
       /// <c>set</c>setzt ein IGameItem als kontrolliertes GameItem ein.</remarks>
        protected virtual IGameItem Controllee { get; set; }




        /// <summary>
        /// Kümmert sich um die Bewegung der GameItem
        /// </summary>
        /// <param name="game">Referenz des Games aus dem XNA Framework.</param>
        /// <param name="gameTime">Bietet die aktuelle Spielzeit an.</param>
        protected abstract void Movement(Game game,GameTime gameTime);

        /// <summary>
        /// Kümmert sich um das Schießen der GameItem
        /// </summary>
        /// <param name="game">Referenz des Games aus dem XNA Framework.</param>
        /// <param name="gameTime">Bietet die aktuelle Spielzeit an.</param>
        protected abstract void Shooting(Game game, GameTime gameTime);

        /// <summary>
        /// Erlaubt die Ausführung der Steuerung.
        /// </summary>
        /// <param name="game">Referenz des Games aus dem XNA Framework.</param>
        /// <param name="gameTime">Bietet die aktuelle Spielzeit an.</param>
        /// <param name="state">Gibt den aktuellen State an von dem diese Funktion aufgerufen wurde.</param>
        public virtual void Update(Game game,GameTime gameTime, State state)
        {
          
            
            //Richtungsanweisung an das Controllee (ermittelt durch konkreten Controller)
            this.Movement(game,gameTime);


            this.Shooting(game, gameTime);
          
            
        }
    }
}
