using SpaceInvadersRemake.Controller;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.Xna.Framework;

namespace SpaceInvaderRemakeUnitTest
{
    
    
    /// <summary>
    ///This is a test class for BlockWaveAITest and is intended
    ///to contain all BlockWaveAITest Unit Tests
    ///</summary>
    [TestClass()]
    public class BlockWaveAITest
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
        ///A test for changeDirection
        ///</summary>
        [TestMethod()]
        [DeploymentItem("SpaceInvadersRemake.exe")]
        public void changeDirectionTest()
        {
            Vector2 currentDirection = SpaceInvadersRemake.ModelSection.CoordinateConstants.Left;
            Vector2 expected = SpaceInvadersRemake.ModelSection.CoordinateConstants.Right; 
            Vector2 actual;
            actual = BlockWaveAI_Accessor.changeDirection(currentDirection);
            
            Assert.AreEqual(expected, actual);
           
        }


    }
}
