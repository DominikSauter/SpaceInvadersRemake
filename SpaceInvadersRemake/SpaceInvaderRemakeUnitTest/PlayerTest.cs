using SpaceInvadersRemake.ModelSection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.Xna.Framework;

namespace SpaceInvaderRemakeUnitTest
{
    
    
    /// <summary>
    ///Dies ist eine Testklasse für "PlayerTest" und soll
    ///alle PlayerTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class PlayerTest
    {


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
        //
        //Mit TestInitialize können Sie vor jedem einzelnen Test Code ausführen.
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Mit TestCleanup können Sie nach jedem einzelnen Test Code ausführen.
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///Ein Test für "Move"
        ///</summary>
        [TestMethod()]
        public void MoveTest()
        {
            // GameItem-Liste initialisieren
            GameItem.GameItemList = new System.Collections.Generic.LinkedList<IGameItem>();

            Vector2 position = GameItemConstants.PlayerPosition; // TODO: Passenden Wert initialisieren
            Vector2 velocity = GameItemConstants.PlayerVelocity; // TODO: Passenden Wert initialisieren
            int hitpoints = 10; // TODO: Passenden Wert initialisieren
            int damage = 10; // TODO: Passenden Wert initialisieren
            Weapon weapon = GameItemConstants.PlayerWeapon; // TODO: Passenden Wert initialisieren
            int lives = 3; // TODO: Passenden Wert initialisieren
            Player target = new Player(position, velocity, hitpoints, damage, weapon, lives); // TODO: Passenden Wert initialisieren
            Vector2 direction = CoordinateConstants.Left; // TODO: Passenden Wert initialisieren
            GameTime gameTime = new GameTime(new TimeSpan(0, 42, 42), new TimeSpan(166667)); // TODO: Passenden Wert initialisieren
            bool expected = true; // TODO: Passenden Wert initialisieren
            bool actual;
            actual = target.Move(direction, gameTime);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");

            // GameItem-Liste leeren
            GameItem.GameItemList.Clear();
        }
    }
}
