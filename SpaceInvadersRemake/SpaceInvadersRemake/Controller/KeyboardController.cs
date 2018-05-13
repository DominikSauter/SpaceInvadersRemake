using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SpaceInvadersRemake.ModelSection;
using SpaceInvadersRemake.Settings;
using SpaceInvadersRemake.StateMachine;

//Implemntiert von Christian (ck)
namespace SpaceInvadersRemake.Controller
{

    /// <summary>
    /// Diese Klasse stellt die konkrete Benutzereingabe mithilfe der Tastatur.
    /// </summary>
    /// <remarks>In dieser Klasse wird das Verhalten des Controllers vom einem menschlichen Benutzer
    /// mithilfe der Tastatur bestimmt</remarks>
    public class KeyboardController : PlayerController
    {
        // MODIFIED (by STST): 2.7.2011
        /// <summary>
        /// Generiert eine neue Instanz der <see cref="KeyboardController"/> Klasse.
        /// </summary>
        public KeyboardController(ControllerManager controllerManager, IGameItem controllee)
            : base(controllerManager,controllee)
        {
            this.KBconfig = KeyboardConfig.Default;

            if (this.Controllee is Player)
            {
                myPlayer = (Player)Controllee;
            }

        }

        //Private Felder
        private KeyboardState kState;
        private readonly Player myPlayer;


        /// <summary>
        /// Getter/Setter der Tastatur Konfiguration
        /// </summary>
        /// <value>
        /// Die KBconfig.
        /// </value>
        public Settings.KeyboardConfig KBconfig { get; set; }

        /// <summary>
        /// Erlaubt die Ausführung der Steuerung.
        /// </summary>
        /// <remarks>
        /// Fügt der Base.Update die Erneuerung des Keyboardstates und den Pausemenüaufruf hinzu
        /// </remarks>
        /// <param name="game">Referenz des Games aus dem XNA Framework.</param>
        /// <param name="gameTime">Bietet die aktuelle Spielzeit an.</param>
        /// <param name="state">Gibt den aktuellen State an von dem diese Funktion aufgerufen wurde.</param>
        public override void Update(Game game, GameTime gameTime, StateMachine.State state)
        {

            kState = StateManager.newState;

            //Pausemenüaufruf
            if (MenuController.KeyPressed(KBconfig.Back) || MenuController.KeyPressed(Keys.Escape))
            {
                if (state is InGameState)
                {
                    ((InGameState)state).Break();
                }


            }

            //Ruft Movement und Shooting auf
            base.Update(game, gameTime, state);
        }


        /// <summary>
        /// Kümmert sich um die Bewegung der GameItem
        /// </summary>
        /// <param name="game">Referenz des Games aus dem XNA Framework.</param>
        /// <param name="gameTime">Bietet die aktuelle Spielzeit an.</param>
        protected override void Movement(Game game, GameTime gameTime)
        {

            Vector2 direction = Vector2.Zero;


            if (kState.IsKeyDown(KBconfig.Left))
            {
                direction += CoordinateConstants.Left;
            }

            if (kState.IsKeyDown(KBconfig.Right))
            {
                direction += CoordinateConstants.Right;
            }

            


            this.Controllee.Move(direction, gameTime);


        }

        /// <summary>
        /// Entscheidet ob Controllee schießen soll
        /// </summary>
        /// <remarks>Dies geschieht indem der Benutzer die Taste für schießen drückt.
        /// Welche Taste dies ist, ist in der Eigenschaft <c>KBconfig</c> hinterlegt
        /// </remarks>
        /// <returns>
        ///   <c>true</c> = schießen andererseits <c>false</c>
        /// </returns>
        protected override void Shooting(Game game, GameTime gameTime)
        {
            
            //Für Normale Waffen hierbei muss Feuertaste losgelassen werden
            if (MenuController.KeyPressed(KBconfig.Fire))
            {
                this.Controllee.Shoot(gameTime);

            }

            //Für schnellfeuer Waffen Feuertaste kann gedrückt bleiben
            else if (myPlayer.Weapon is RapidfireWeapon && this.kState.IsKeyDown(KBconfig.Fire))
            {
                this.myPlayer.Shoot(gameTime);
            }
        }
    }
}
