using SpaceInvadersRemake.Controller;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.Xna.Framework;
using SpaceInvadersRemake.ModelSection;
using Microsoft.Xna.Framework.Input;
using SpaceInvadersRemake.StateMachine;
using System.Collections.Generic;

namespace SpaceInvaderRemakeUnitTest
{
    
    
    /// <summary>
    ///This is a test class for KeyboardControllerTest and is intended
    ///to contain all KeyboardControllerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class KeyboardControllerTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
            




        //}
        ////
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///Hier wird die Movement Methode getested mit dem Fall das die Taste für Links gedrückt wird (Default Config)
        ///</summary>
        [TestMethod()]
        [DeploymentItem("SpaceInvadersRemake.exe")]
        public void MovementTest_InputLeftpressedKey()
        {
             //Erstelle Start Objekt für Tests
            ControllerManager myTestManager = new ControllerManager();

            //Init GameItemListe
            GameItem.GameItemList = new LinkedList<IGameItem>();

            Player myTestPlayer = new Player(Vector2.Zero,new Vector2(1,1),1,1,new PlayerNormalWeapon(),3);
            
            //registriere Player im Manager
            //myTestManager.CreatePlayerController(myTestPlayer,new EventArgs());
            
            Game game = new Game();
            //gameTime.ElapsedGameTime.TotalSeconds = 1
            GameTime gameTime = new GameTime(new TimeSpan(),new TimeSpan(0,0,1));

            

            //Left Key pressed
          
            Keys[] keys = { SpaceInvadersRemake.Settings.KeyboardConfig.Default.Left }; 
            KeyboardState myTestKBState = new KeyboardState(keys);



            KeyboardController_Accessor target = new KeyboardController_Accessor(myTestManager, myTestPlayer); // TODO: Initialize to an appropriate value
            //Nötig zur KeyboardController Erzeugung
            KeyboardController target2 = new KeyboardController(myTestManager, myTestPlayer);
            
            myTestManager.Controllers.Add(target2);

            target.kState = myTestKBState;

            //Test start
            target.Movement(game, gameTime);
            
            //Referenz zum Vergleich
            Vector2 expected = new Vector2(1,1) * CoordinateConstants.Left;
            
            Assert.AreEqual(expected, target.Controllee.Position);
        }

        /// <summary>
        ///Hier wird die Movement Methode getested mit dem Fall das die Taste für Rechts gedrückt wird (Default Config)
        ///</summary>
        [TestMethod()]
        [DeploymentItem("SpaceInvadersRemake.exe")]
        public void MovementTest_InputRightpressedKey()
        {
            //Erstelle Start Objekt für Tests
            ControllerManager myTestManager = new ControllerManager();

            //Init GameItemListe
            GameItem.GameItemList = new LinkedList<IGameItem>();

            Player myTestPlayer = new Player(Vector2.Zero, new Vector2(1, 1), 1, 1, new PlayerNormalWeapon(), 3);

            //registriere Player im Manager
            //myTestManager.CreatePlayerController(myTestPlayer,new EventArgs());

            Game game = new Game();
            //gameTime.ElapsedGameTime.TotalSeconds = 1
            GameTime gameTime = new GameTime(new TimeSpan(), new TimeSpan(0, 0, 1));



            //Left Key pressed

            Keys[] keys = { SpaceInvadersRemake.Settings.KeyboardConfig.Default.Right };
            KeyboardState myTestKBState = new KeyboardState(keys);



            KeyboardController_Accessor target = new KeyboardController_Accessor(myTestManager, myTestPlayer); // TODO: Initialize to an appropriate value
            KeyboardController target2 = new KeyboardController(myTestManager, myTestPlayer);

            myTestManager.Controllers.Add(target2);

            target.kState = myTestKBState;

            //Test start
            target.Movement(game, gameTime);

            //Referenz zum Vergleich
            Vector2 expected = new Vector2(1, 1) * CoordinateConstants.Right;

            Assert.AreEqual(expected, target.Controllee.Position);
        }



    }
}
