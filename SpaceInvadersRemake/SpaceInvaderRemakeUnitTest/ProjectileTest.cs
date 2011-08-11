using SpaceInvadersRemake.ModelSection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.Xna.Framework;

namespace SpaceInvaderRemakeUnitTest
{
    
    
    /// <summary>
    ///Dies ist eine Testklasse für "ProjectileTest" und soll
    ///alle ProjectileTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class ProjectileTest
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
        ///Ein Test für "Update"
        ///</summary>
        [TestMethod()]
        public void UpdateTest()
        {
            GameItem.GameItemList = new System.Collections.Generic.LinkedList<IGameItem>();

            Vector2 position = new Vector2(0.0f, CoordinateConstants.TopBorder * 2.0f - 1.0f); // TODO: Passenden Wert initialisieren
            Vector2 flightDirection = CoordinateConstants.Up; // TODO: Passenden Wert initialisieren
            ProjectileTypeEnum projectileType = ProjectileTypeEnum.PlayerNormalProjectile; // TODO: Passenden Wert initialisieren
            int hitpoints = GameItemConstants.PlayerNormalProjectileHitpoints; // TODO: Passenden Wert initialisieren
            Vector2 velocity = GameItemConstants.PlayerNormalProjectileVelocity; // TODO: Passenden Wert initialisieren
            int damage = GameItemConstants.PlayerNormalProjectileDamage; // TODO: Passenden Wert initialisieren
            Projectile target = new Projectile(position, flightDirection, projectileType, hitpoints, velocity, damage); // TODO: Passenden Wert initialisieren

            GameTime gameTime = new GameTime(new TimeSpan(0, 42, 42), new TimeSpan(0, 0, 1)); // TODO: Passenden Wert initialisieren
            
            target.Update(gameTime);

            Assert.AreEqual(target.IsAlive, false);
            //Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");

            GameItem.GameItemList.Clear();
        }

        /// <summary>
        ///Ein Test für "IsCollidedWith"
        ///</summary>
        [TestMethod()]
        public void IsCollidedWithTest()
        {
            GameItem.GameItemList = new System.Collections.Generic.LinkedList<IGameItem>();

            Vector2 position = new Vector2(0.0f, CoordinateConstants.TopBorder * 2.0f - 1.0f); // TODO: Passenden Wert initialisieren
            Vector2 flightDirection = CoordinateConstants.Up; // TODO: Passenden Wert initialisieren
            ProjectileTypeEnum projectileType = ProjectileTypeEnum.PlayerNormalProjectile; // TODO: Passenden Wert initialisieren
            int hitpoints = GameItemConstants.PlayerNormalProjectileHitpoints; // TODO: Passenden Wert initialisieren
            Vector2 velocity = GameItemConstants.PlayerNormalProjectileVelocity; // TODO: Passenden Wert initialisieren
            int damage = GameItemConstants.PlayerNormalProjectileDamage; // TODO: Passenden Wert initialisieren
            Projectile target = new Projectile(position, flightDirection, projectileType, hitpoints, velocity, damage); // TODO: Passenden Wert initialisieren
            
            IGameItem collisionPartner = new Shield(Vector2.Zero, GameItemConstants.ShieldHitpoints, GameItemConstants.ShieldDamage); // TODO: Passenden Wert initialisieren

            target.IsCollidedWith(collisionPartner);

            Assert.AreEqual(target.IsAlive, false);
            //Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");

            GameItem.GameItemList.Clear();
        }
    }
}
