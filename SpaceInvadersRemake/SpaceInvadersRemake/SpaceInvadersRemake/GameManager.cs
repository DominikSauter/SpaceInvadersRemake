using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpaceInvadersRemake.Resources;
using SpaceInvadersRemake.StateMachine;


namespace SpaceInvadersRemake
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class GameManager : Microsoft.Xna.Framework.Game
    {
        public GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;

        public GameManager()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            // <STST><ck>
            //Beim Ersten Spielstart wird Sprache vom System gelesen und in Gameconfig eingetragen. 
            //Auch in der GameConfig.Language einstellbar: Englisch = en-US Deutsch = de-DE
            if (Settings.GameConfig.Default.FirstRun)
            {
                Settings.GameConfig.Default.Language = System.Threading.Thread.CurrentThread.CurrentCulture;
                Settings.GameConfig.Default.FirstRun = false;
                Settings.GameConfig.Default.Save();

            }

            //Zuweisen der Sprache aus der Gameconfig
            Resource.Culture = Settings.GameConfig.Default.Language;
            // </STST></CK>
        }

        /// <summary>
        /// Hält eine Instanz zur StateMachine
        /// </summary>
        public SpaceInvadersRemake.StateMachine.StateManager StateManager
        {
            get;
            set;
        }

        /// <summary>
        /// Der Musikplayer für die Hintergrundmusik
        /// </summary>
        public static SpaceInvadersRemake.View.BackgroundMusic MusicPlayer
        {
            get;
            set;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();

            graphics.PreferredBackBufferWidth = Settings.GameConfig.Default.graphicsWidth;
            graphics.PreferredBackBufferHeight = Settings.GameConfig.Default.graphicsHeight;
            graphics.IsFullScreen = Settings.GameConfig.Default.Fullscreen;
            graphics.ApplyChanges();

            //[VIEW]
     
            
            View.ViewContent.ComputeHitspheres();
            MusicPlayer = new View.BackgroundMusic();

            //[Model]
            ModelSection.PowerUpGenerator.InitializePowerUpSystem();

            // <STST>
            this.StateManager = new StateManager(this);
            // </STST>
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw texture.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //[VIEW]
            View.ViewContent.LoadContent(this.Content);

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {

            // <STST>
            this.StateManager.ModelUpdate(gameTime);
            this.StateManager.ControllerUpdate(gameTime);
            // </STST>

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);


            // <STST>
            this.StateManager.ViewUpdate(gameTime);
            // </STST>

            base.Draw(gameTime);

            // Wenn die Screenshot-Taste gedrückt wird (F12) dann mache einen Screenshot
            if (Controller.MenuController.KeyPressed(Keys.F12))
            {
                TakeScreenshot();
            }
        }

        /// <summary>
        /// Speichert einen Screenshot. Dateiname wird aus aktueller Zeit ermittelt.
        /// </summary>
        private void TakeScreenshot()
        {
            int w = graphics.GraphicsDevice.PresentationParameters.BackBufferWidth;
            int h = graphics.GraphicsDevice.PresentationParameters.BackBufferHeight;

            System.IO.Directory.CreateDirectory("screenshots");
            
            // Erstelle Datei für Screenshot
            System.DateTime time = System.DateTime.Now;
            string path = "screenshots\\screenshot_"
                        + time.Year.ToString() + "-" + time.Month.ToString() + "-" + time.Day.ToString() + "_"
                        + time.Hour.ToString() + "-" + time.Minute.ToString() + "-" + time.Second.ToString() + ".png";

            System.IO.Stream output = System.IO.File.Open(path, System.IO.FileMode.Create);

            // Erstelle Array zum Kopieren des Backbuffers und eine Ausgabetextur
            Color[] backbufferData = new Color[w * h];
            Texture2D screenshotTexture = new Texture2D(graphics.GraphicsDevice, w, h, false, SurfaceFormat.Color);

            // Kopiere Backbuffer in die Ausgabetextur
            graphics.GraphicsDevice.GetBackBufferData<Color>(backbufferData);
            screenshotTexture.SetData<Color>(backbufferData);

            // Speichere Textur
            screenshotTexture.SaveAsPng(output, w, h);

            // Schließe Datei
            output.Close();
        }
    }
}
