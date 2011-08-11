using SpaceInvadersRemake.ModelSection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.Xna.Framework;

namespace SpaceInvaderRemakeUnitTest
{
    
    
    /// <summary>
    ///Dies ist eine Testklasse für "ShieldTest" und soll
    ///alle ShieldTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class ShieldTest
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
        ///Ein Test für "IsCollidedWith"
        ///</summary>
        [TestMethod()]
        public void IsCollidedWithTest()
        {
            GameItem.GameItemList = new System.Collections.Generic.LinkedList<IGameItem>();

            Vector2 position = Vector2.Zero; // TODO: Passenden Wert initialisieren
            int hitpoints = GameItemConstants.ShieldHitpoints; // TODO: Passenden Wert initialisieren
            int damage = GameItemConstants.ShieldDamage; // TODO: Passenden Wert initialisieren
            Shield target = new Shield(position, hitpoints, damage); // TODO: Passenden Wert initialisieren

            IGameItem collisionPartner = new Alien(Vector2.Zero, GameItemConstants.AlienVelocity, GameItemConstants.AlienHitpoints, GameItemConstants.AlienDamage, GameItemConstants.AlienWeapon, GameItemConstants.AlienScoreGain); // TODO: Passenden Wert initialisieren

            target.IsCollidedWith(collisionPartner);

            Assert.AreEqual(target.Hitpoints, GameItemConstants.ShieldHitpoints - GameItemConstants.AlienDamage);
            //Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");

            GameItem.GameItemList.Clear();
        }
    }
}
