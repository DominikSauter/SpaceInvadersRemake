using SpaceInvadersRemake.ModelSection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SpaceInvaderRemakeUnitTest
{
    
    
    /// <summary>
    ///Dies ist eine Testklasse für "HighscoreManagerTest" und soll
    ///alle HighscoreManagerTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class HighscoreManagerTest
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
        ///Ein Test für "Save"
        ///</summary>
        [TestMethod()]
        public void SaveTest()
        {
            // Hinweis: Sollte dieser Test fehlschlegen, kann es sein, dass der neue Eintrag nicht mehr 
            // in die Highscore-Liste passt. Dies muss evtl. überprüft werden.        

            // Neuen Highscore-Manager erzeugen, bei dem ein neuer Eintrag erzeugt werden soll
            HighscoreManager target = new HighscoreManager(1000); 
            target.NewEntry.Name = "TEST"; // Namen eintragen

            bool expected = true; 
            bool actual;

            actual = target.Save();

            Assert.AreEqual(expected, actual);

        }
    }
}
