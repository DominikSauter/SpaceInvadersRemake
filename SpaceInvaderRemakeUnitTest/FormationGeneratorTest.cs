using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xna.Framework;
using SpaceInvadersRemake.ModelSection;

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
            GameItem.GameItemList = new LinkedList<IGameItem>();

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


            LinkedListNode<IGameItem> item2 = expected.First;
            for (LinkedListNode<IGameItem> item1 = actual.First; item1 != null; item1 = item1.Next)
            {
                    Assert.AreEqual(item2.Value.BoundingVolume, item1.Value.BoundingVolume);
                    Assert.AreEqual(item2.Value.Damage, item1.Value.Damage);
                    Assert.AreEqual(item2.Value.Hitpoints, item1.Value.Hitpoints);
                    Assert.AreEqual(item2.Value.IsAlive, item1.Value.IsAlive);
                    Assert.AreEqual(item2.Value.Position, item1.Value.Position);
                    Assert.AreEqual(item2.Value.Velocity, item1.Value.Velocity);
                    Enemy item2Enemy = (Enemy)item2.Value;
                    Enemy item1Enemy = (Enemy)item1.Value;
                    Assert.AreEqual(item2Enemy.ScoreGain, item1Enemy.ScoreGain);
                    Assert.ReferenceEquals(item2Enemy.Weapon, item1Enemy.Weapon);
                    item2 = item2.Next;
            }

            GameItem.GameItemList = null;
        }
    }
}
