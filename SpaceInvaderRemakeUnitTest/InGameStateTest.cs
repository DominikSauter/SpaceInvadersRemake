using SpaceInvadersRemake.StateMachine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SpaceInvadersRemake;

namespace SpaceInvaderRemakeUnitTest
{
    
    
    /// <summary>
    ///Dies ist eine Testklasse für "InGameStateTest" und soll
    ///alle InGameStateTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class InGameStateTest
    {
        private StateManager sMngr;
        private GameManager gMngr;

        private TestContext testContextInstance;

        /// <summary>
        ///Ruft den Testkontext auf, der Informationen
        ///über und Funktionalität für den aktuellen Testlauf bietet, oder legt diesen fest.
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

        #region Zusätzliche Testattribute
        // 
        //Sie können beim Verfassen Ihrer Tests die folgenden zusätzlichen Attribute verwenden:
        //
        //Mit ClassInitialize führen Sie Code aus, bevor Sie den ersten Test in der Klasse ausführen.
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Mit ClassCleanup führen Sie Code aus, nachdem alle Tests in einer Klasse ausgeführt wurden.
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        

        //Mit TestInitialize können Sie vor jedem einzelnen Test Code ausführen.
        [TestInitialize()]
        public void MyTestInitialize()
        {
            this.gMngr = new GameManager();
            this.sMngr = new StateManager(this.gMngr);
        }

        //Mit TestCleanup können Sie nach jedem einzelnen Test Code ausführen.
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///Ein Test für "Break"
        ///</summary>
        [TestMethod()]
        public void BreakTest()
        {
            StateManager stateManager = this.sMngr; // TODO: Passenden Wert initialisieren
            GameManager gameManager = this.gMngr; // TODO: Passenden Wert initialisieren
            InGameState target = new InGameState(stateManager, gameManager); // TODO: Passenden Wert initialisieren
            stateManager.State = target;
            target.Break();
            Assert.IsTrue(stateManager.State != target, "Der Sprung vom Pausemenü ins Spiel funktioniert nicht!");
        }


        /// <summary>
        ///Ein Test für "Exit"
        ///</summary>
        [TestMethod()]
        public void ExitTest()
        {
            StateManager stateManager = null; // TODO: Passenden Wert initialisieren
            GameManager gameManager = null; // TODO: Passenden Wert initialisieren
            InGameState target = new InGameState(stateManager, gameManager); // TODO: Passenden Wert initialisieren
            int score = 0; // TODO: Passenden Wert initialisieren
            target.Exit(score);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }
    }
}
