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
    class XBoxController : PlayerController
    {

                /// <summary>
        /// Generiert eine neue Instanz der <see cref="KeyboardController"/> Klasse.
        /// </summary>
        public XBoxController(ControllerManager controllerManager, IGameItem controllee)
            : base(controllerManager,controllee)
        {
            this.XBox = XBoxControllerConfig.Default;

           //Suche angeschlossenen XBox Controller. Wenn mehrere vorhanden wird kleinster genommen
            //TODO Schönere Lösung ?
            if (GamePad.GetState(PlayerIndex.One).IsConnected)
            {
                myPad = PlayerIndex.One;
                GamePadConnected = true;

            }
            else if (GamePad.GetState(PlayerIndex.Two).IsConnected) 
            {
                myPad = PlayerIndex.Two;
                GamePadConnected = true;
            }
            else if (GamePad.GetState(PlayerIndex.Three).IsConnected) 
            {
                myPad = PlayerIndex.Three;
                GamePadConnected = true;
            }
            else if (GamePad.GetState(PlayerIndex.Four).IsConnected)
            {
                myPad = PlayerIndex.Four;
                GamePadConnected = true;
            }
            else 
            {
                //Hack Benötige Kein Controller verbunden State oder ähnliches
                throw new System.Exception("No XBox Controller found");
            }
            
            
            
            if (this.Controllee is Player)
            {
                myPlayer = (Player)Controllee;
            }



        }

        //Private Felder
        //Status des GamePads
        private GamePadState PState;
        private readonly Player myPlayer;
        
        //Gibt an welches GamePad verwended wird
        private PlayerIndex myPad;
        private bool GamePadConnected = false;


        /// <summary>
        /// Getter/Setter der XBox Controller Konfiguration
        /// </summary>
        /// <value>
        /// Die KBconfig.
        /// </value>
        public Settings.XBoxControllerConfig XBox { get; set; }

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
            
            
            PState = GamePad.GetState(myPad);
            
            //Teste ob Controller angeschlossen ist. 
            if(!PState.IsConnected)
            {
                GamePadConnected = false;
            }
          

            
            
 
            //Pausemenüaufruf
            if (GamePadConnected && PState.IsButtonDown(XBox.Back) || MenuController.KeyPressed(Keys.Escape))
            {
                if (state is InGameState)
                {
                    ((InGameState)state).Break();
                }


            }

            //Ruft Movement und Shooting auf
            if (GamePadConnected) 
            {
                base.Update(game, gameTime, state);

            } //TODO GamePad Disconnected Hinweis oder ähnliches
            
        }


        /// <summary>
        /// Kümmert sich um die Bewegung der GameItem
        /// </summary>
        /// <param name="game">Referenz des Games aus dem XNA Framework.</param>
        /// <param name="gameTime">Bietet die aktuelle Spielzeit an.</param>
        protected override void Movement(Microsoft.Xna.Framework.Game game, Microsoft.Xna.Framework.GameTime gameTime)
        {

            Vector2 direction = Vector2.Zero;


            if (PState.IsButtonDown(XBox.Left))
            {
                direction += CoordinateConstants.Left;
            }

            if (PState.IsButtonDown(XBox.Right))
            {
                direction += CoordinateConstants.Right;
            }




            this.Controllee.Move(direction, gameTime);

        }

        /// <summary>
        /// Kümmert sich um das Schießen der GameItem
        /// </summary>
        /// <param name="game">Referenz des Games aus dem XNA Framework.</param>
        /// <param name="gameTime">Bietet die aktuelle Spielzeit an.</param>
        protected override void Shooting(Microsoft.Xna.Framework.Game game, Microsoft.Xna.Framework.GameTime gameTime)
        {

            //Für Normale Waffen hierbei muss Feuertaste losgelassen werden
            if (PState.IsButtonDown(XBox.Fire))
            {
                this.Controllee.Shoot(gameTime);

            }

            //Für schnellfeuer Waffen Feuertaste kann gedrückt bleiben
            else if (myPlayer.Weapon is RapidfireWeapon && this.PState.IsButtonDown(XBox.Fire))
            {
                this.myPlayer.Shoot(gameTime);
            }
        }
    }
}
