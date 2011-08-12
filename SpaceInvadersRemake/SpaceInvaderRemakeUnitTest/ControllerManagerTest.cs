using SpaceInvadersRemake.Controller;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SpaceInvadersRemake.ModelSection;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace SpaceInvaderRemakeUnitTest
{
    
    
    /// <summary>
    ///This is a test class for ControllerManagerTest and is intended
    ///to contain all ControllerManagerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ControllerManagerTest
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
        //
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
        ///Tested ob ein neuer Controller erzeugt wird im Falle einer AlienWave
        ///</summary>
        [TestMethod()]
        public void CreateControllerTest_InputAlienWave()
        {
            //Erzeugung Testumgebung

            ControllerManager target = new ControllerManager(); 
            //Nicht benötigt
            object sender = null; 


            BehaviourEnum behaviour = BehaviourEnum.BlockMovement;
            LinkedList<IGameItem> controllees = new LinkedList<IGameItem>();
            controllees.AddFirst(new Alien(Vector2.Zero,new Vector2(5,5),1,1,new PlayerNormalWeapon(),7));

            DifficultyLevel difficultyLevel = DifficultyLevel.EasyDifficulty;



            ControllerEventArgs desiredController = new ControllerEventArgs(behaviour,controllees,difficultyLevel); // TODO: Initialize to an appropriate value
            
            
            //Test start
            target.CreateController(sender, desiredController);


            //Testergebnis
            Assert.AreEqual(target.Controllers.Count,1);

 
           
            
        }

        /// <summary>
        ///Tested ob ein neuer Controller erzeugt wird im Falle eines Mutterschiffes
        ///</summary>
        [TestMethod()]
        public void CreateControllerTest_InputMothership()
        {
            //Erzeugung Testumgebung

            ControllerManager target = new ControllerManager();
            //Nicht benötigt
            object sender = null;


            BehaviourEnum behaviour = BehaviourEnum.MothershipMovement;
            LinkedList<IGameItem> controllees = new LinkedList<IGameItem>();
            controllees.AddFirst(new Alien(Vector2.Zero, new Vector2(5, 5), 1, 1, new PlayerNormalWeapon(), 7));

            DifficultyLevel difficultyLevel = DifficultyLevel.EasyDifficulty;



            ControllerEventArgs desiredController = new ControllerEventArgs(behaviour, controllees, difficultyLevel); // TODO: Initialize to an appropriate value


            //Test start
            target.CreateController(sender, desiredController);


            //Testergebnis
            Assert.AreEqual(target.Controllers.Count, 1);




        }
    }
}
