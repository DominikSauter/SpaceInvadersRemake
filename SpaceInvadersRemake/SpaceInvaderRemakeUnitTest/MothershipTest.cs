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
            // GameItem-Liste initialisieren
            GameItem.GameItemList = new System.Collections.Generic.LinkedList<IGameItem>();

            // Mutterschiff initialisieren
            Vector2 position = GameItemConstants.MothershipPosition; // Position
            Vector2 velocity = GameItemConstants.MothershipVelocity; // Geschwindigkeit
            int hitpoints = GameItemConstants.MothershipHitpoints; // Lebenspunkte
            int damage = GameItemConstants.MothershipDamage; // Schaden
            Weapon weapon = null; // Waffe
            int scoreGain = GameItemConstants.MothershipScoreGain; // Punktzahl
            Mothership target = new Mothership(position, velocity, hitpoints, damage, weapon, scoreGain); // Mutterschiff erzeugen
            
            // Als Kollisionspartner ein normales Spielerprojektil erzeugen
            IGameItem collisionPartner = new Projectile(GameItemConstants.MothershipPosition, Vector2.Zero, ProjectileTypeEnum.PlayerNormalProjectile, GameItemConstants.PlayerNormalProjectileHitpoints, Vector2.Zero, GameItemConstants.PlayerNormalProjectileDamage); // TODO: Passenden Wert initialisieren
            
            target.IsCollidedWith(collisionPartner);

            int expected = GameItemConstants.MothershipHitpoints - GameItemConstants.PlayerNormalProjectileDamage;

            Assert.AreEqual(target.Hitpoints, expected);

            // GameItem-Liste zurücksetzen
            GameItem.GameItemList = null;
        }
    }
}
