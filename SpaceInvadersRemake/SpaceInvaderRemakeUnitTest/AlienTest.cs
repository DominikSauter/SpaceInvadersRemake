using SpaceInvadersRemake.ModelSection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.Xna.Framework;

namespace SpaceInvaderRemakeUnitTest
{
    
    
    /// <summary>
    ///Dies ist eine Testklasse für "AlienTest" und soll
    ///alle AlienTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class AlienTest
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

            // AlienObjekt für Test initialisieren
            Vector2 position = Vector2.Zero; // Position
            Vector2 velocity = GameItemConstants.AlienVelocity; // Geschwindigkeit
            int hitpoints = GameItemConstants.AlienHitpoints; // Lebenspunkte
            int damage = GameItemConstants.AlienDamage; // Schaden
            Weapon weapon = GameItemConstants.AlienWeapon; // Waffe
            int scoreGain = GameItemConstants.AlienScoreGain; // Punktzahl
            Alien target = new Alien(position, velocity, hitpoints, damage, weapon, scoreGain); // Alien erstellen

            // Als Kollisionspartner ein normales Spielerprojektil erstellen
            IGameItem collisionPartner = new Projectile(Vector2.Zero, Vector2.Zero, ProjectileTypeEnum.PlayerNormalProjectile, GameItemConstants.PlayerNormalProjectileHitpoints, Vector2.Zero, GameItemConstants.PlayerNormalProjectileDamage); // TODO: Passenden Wert initialisieren

            target.IsCollidedWith(collisionPartner);

            int expected = GameItemConstants.AlienHitpoints - GameItemConstants.PlayerNormalProjectileDamage;

            // Für Testerfolg muss überprüft werden, ob dem Alien der korrekte Schadenswert abgezogen wurde
            Assert.AreEqual(target.Hitpoints, expected);

            // GameItem-Liste wieder zurücksetzen
            GameItem.GameItemList = null;
        }
    }
}
