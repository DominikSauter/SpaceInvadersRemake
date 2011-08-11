using SpaceInvadersRemake.ModelSection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.Xna.Framework;

namespace SpaceInvaderRemakeUnitTest
{
    
    
    /// <summary>
    ///Dies ist eine Testklasse für "EnemyTest" und soll
    ///alle EnemyTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class EnemyTest
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


        internal virtual Enemy CreateEnemy()
        {
            // TODO: Geeignete konkrete Klasse instanziieren
            Enemy target = new Alien(Vector2.Zero, GameItemConstants.AlienVelocity, 10, 10, GameItemConstants.AlienWeapon, 10);
            return target;
        }

        /// <summary>
        ///Ein Test für "Move", bei dem ein Alien nicht über den Rand kommt
        ///</summary>
        [TestMethod()]
        public void MoveTestNotOverBorder()
        {
            // GameItem-Liste initialisieren
            GameItem.GameItemList = new System.Collections.Generic.LinkedList<IGameItem>();

            Enemy target = CreateEnemy(); // TODO: Passenden Wert initialisieren
            Vector2 direction = CoordinateConstants.Right; // TODO: Passenden Wert initialisieren
            GameTime gameTime = new GameTime(new TimeSpan(0, 42, 42), new TimeSpan(166667)); // TODO: Passenden Wert initialisieren
            bool expected = true; // TODO: Passenden Wert initialisieren
            bool actual;
            actual = target.Move(direction, gameTime);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");

            // GameItem-Liste leeren
            GameItem.GameItemList.Clear();
        }

        /// <summary>
        ///Ein Test für "Move", bei dem ein Alien über den Rand kommt
        ///</summary>
        [TestMethod()]
        public void MoveTestOverBorder()
        {
            // GameItem-Liste initialisieren
            GameItem.GameItemList = new System.Collections.Generic.LinkedList<IGameItem>();

            Enemy target = CreateEnemy(); // TODO: Passenden Wert initialisieren
            target.Position = new Vector2(CoordinateConstants.RightBorder, 0.0f);
            Vector2 direction = CoordinateConstants.Right; // TODO: Passenden Wert initialisieren
            GameTime gameTime = new GameTime(new TimeSpan(0, 42, 42), new TimeSpan(166667)); // TODO: Passenden Wert initialisieren
            bool expected = false; // TODO: Passenden Wert initialisieren
            bool actual;
            actual = target.Move(direction, gameTime);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");

            // GameItem-Liste leeren
            GameItem.GameItemList.Clear();
        }
    }
}
