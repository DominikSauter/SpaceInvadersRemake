using SpaceInvadersRemake.ModelSection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.Xna.Framework;

namespace SpaceInvaderRemakeUnitTest
{
    
    
    /// <summary>
    ///Dies ist eine Testklasse für "PowerUpGeneratorTest" und soll
    ///alle PowerUpGeneratorTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class PowerUpGeneratorTest
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
        ///Ein Test für "GeneratePowerUp"
        ///</summary>
        [TestMethod()]
        public void GeneratePowerUpTest()
        {
            // GameItem-Liste initialisieren
            GameItem.GameItemList = new System.Collections.Generic.LinkedList<IGameItem>();

            // Speedboost PowerUp in die Liste eintragen
            int frequency = 1000; 
            CreatePowerUp create = delegate(Vector2 pos, Vector2 vel)
            {
                new Speedboost(pos, vel);
            }; 
            PowerUpGenerator.AddAvailablePowerUp(PowerUpEnum.Speedboost, frequency, create);

            // Passende Parameter initialisieren
            PowerUpEnum type = PowerUpEnum.Speedboost; 
            Vector2 position = Vector2.Zero; 

            PowerUpGenerator.GeneratePowerUp(type, position);

            // Überprüfen, ob tatsächlich das gewünschte PowerUp erstellt wurde
            Assert.AreEqual(GameItem.GameItemList.Count, 1);
            Assert.AreEqual(GameItem.GameItemList.First.Value is Speedboost, true);

            // GameItem-Liste zurücksetzen
            GameItem.GameItemList = null;
        }
    }
}
