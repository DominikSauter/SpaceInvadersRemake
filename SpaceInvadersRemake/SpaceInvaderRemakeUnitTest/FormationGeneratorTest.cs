using SpaceInvadersRemake.ModelSection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace SpaceInvaderRemakeUnitTest
{
    
    
    /// <summary>
    ///Dies ist eine Testklasse für "FormationGeneratorTest" und soll
    ///alle FormationGeneratorTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class FormationGeneratorTest
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
        ///Ein Test für "CreateFormation"
        ///</summary>
        [TestMethod()]
        public void CreateFormationTest()
        {
            BehaviourEnum AI = BehaviourEnum.BlockMovement;
            int hitpoints = 10;
            Vector2 velocity = new Vector2(40.0f, 40.0f);
            Vector2[] formation = FormationGenerator.ArrowFormation;
            int damage = 10;
            int scoreGain = 10;

            LinkedList<IGameItem> wave = new LinkedList<IGameItem>();
            for (int i = 0; i < formation.Length; i++)
            {
                wave.AddLast(new Alien(formation[i], velocity, hitpoints, damage, GameItemConstants.AlienWeapon, scoreGain));
            }

            LinkedList<IGameItem> expected = wave;
            LinkedList<IGameItem> actual;
            actual = FormationGenerator.CreateFormation(AI, hitpoints, velocity, formation, damage, scoreGain);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }
    }
}
