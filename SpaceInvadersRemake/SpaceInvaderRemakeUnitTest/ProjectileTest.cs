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


        private Projectile CreateProjectile()
        {
            Vector2 position = new Vector2(0.0f, CoordinateConstants.TopBorder * 2.0f - 1.0f); // Position knapp unter der oberen Grenze
            Vector2 flightDirection = CoordinateConstants.Up; // Bewegungsrichtung
            ProjectileTypeEnum projectileType = ProjectileTypeEnum.PlayerNormalProjectile; // Projektiltyp
            int hitpoints = GameItemConstants.PlayerNormalProjectileHitpoints; // Lebenspunkte
            Vector2 velocity = GameItemConstants.PlayerNormalProjectileVelocity; // Geschwindigkeit
            int damage = GameItemConstants.PlayerNormalProjectileDamage; // Schaden
            // Prijektil erzeugen
            Projectile target = new Projectile(position, flightDirection, projectileType, hitpoints, velocity, damage);
            return target;
        }

        /// <summary>
        ///Ein Test für "Update"
        ///</summary>
        [TestMethod()]
        public void UpdateTest()
        {
            // GameItem-Liste initialisieren
            GameItem.GameItemList = new System.Collections.Generic.LinkedList<IGameItem>();

            // Projektil erzeugen
            Projectile target = CreateProjectile();

            // Passende Parameter initialisieren
            GameTime gameTime = new GameTime(new TimeSpan(0, 42, 42), new TimeSpan(0, 0, 1)); 
            
            target.Update(gameTime);

            Assert.AreEqual(target.IsAlive, false);

            // GameItem-Liste zurücksetzen
            GameItem.GameItemList = null;
        }

        /// <summary>
        ///Ein Test für "IsCollidedWith"
        ///</summary>
        [TestMethod()]
        public void IsCollidedWithTest()
        {
            // GameItem-Liste initialisieren
            GameItem.GameItemList = new System.Collections.Generic.LinkedList<IGameItem>();

            // Projektil erstellen
            Projectile target = CreateProjectile();
            
            // Als Kollisionspartner ein Schild erstellen
            IGameItem collisionPartner = new Shield(Vector2.Zero, GameItemConstants.ShieldHitpoints, GameItemConstants.ShieldDamage); // TODO: Passenden Wert initialisieren

            target.IsCollidedWith(collisionPartner);

            Assert.AreEqual(target.IsAlive, false);

            // GameItem-Liste zurücksetzen
            GameItem.GameItemList = null;
        }
    }
}
