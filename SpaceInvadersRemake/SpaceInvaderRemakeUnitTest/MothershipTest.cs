using SpaceInvadersRemake.ModelSection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.Xna.Framework;

namespace SpaceInvaderRemakeUnitTest
{
    
    
    /// <summary>
    ///Dies ist eine Testklasse für "MothershipTest" und soll
    ///alle MothershipTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class MothershipTest
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

            Vector2 position = GameItemConstants.MothershipPosition; // TODO: Passenden Wert initialisieren
            Vector2 velocity = GameItemConstants.MothershipVelocity; // TODO: Passenden Wert initialisieren
            int hitpoints = GameItemConstants.MothershipHitpoints; // TODO: Passenden Wert initialisieren
            int damage = GameItemConstants.MothershipDamage; // TODO: Passenden Wert initialisieren
            Weapon weapon = null; // TODO: Passenden Wert initialisieren
            int scoreGain = GameItemConstants.MothershipScoreGain; // TODO: Passenden Wert initialisieren
            Mothership target = new Mothership(position, velocity, hitpoints, damage, weapon, scoreGain); // TODO: Passenden Wert initialisieren
            
            
            IGameItem collisionPartner = new Projectile(GameItemConstants.MothershipPosition, Vector2.Zero, ProjectileTypeEnum.PlayerNormalProjectile, GameItemConstants.PlayerNormalProjectileHitpoints, Vector2.Zero, GameItemConstants.PlayerNormalProjectileDamage); // TODO: Passenden Wert initialisieren
            target.IsCollidedWith(collisionPartner);

            Assert.AreEqual(target.IsAlive, false);

            //Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");

            GameItem.GameItemList.Clear();
        }
    }
}
