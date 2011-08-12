using SpaceInvadersRemake.ModelSection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.Xna.Framework;

namespace SpaceInvaderRemakeUnitTest
{
    
    
    /// <summary>
    ///Dies ist eine Testklasse für "PowerUpTest" und soll
    ///alle PowerUpTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class PowerUpTest
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


        internal virtual PowerUp CreatePowerUp()
        {
            // Stellvertretend für PowerUps ein Speedboost-PowerUp erzeugen, dass knapp über der unteren Grenze ist
            PowerUp target = new Speedboost(new Vector2(0.0f, CoordinateConstants.BottomBorder * 1.25f + 1.0f), GameItemConstants.PowerUpVelocity);
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

            // PowerUp erzeugen
            PowerUp target = CreatePowerUp();

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

            // PowerUp erzeugen
            PowerUp target = CreatePowerUp();

            // Als Kollisionspartner einen Spieler erzeugen
            IGameItem collisionPartner = new Player(GameItemConstants.PlayerPosition, GameItemConstants.PlayerVelocity, GameItemConstants.PlayerHitpoints, GameItemConstants.PlayerDamage, GameItemConstants.PlayerWeapon, GameItemConstants.PlayerLives); // TODO: Passenden Wert initialisieren
            
            target.IsCollidedWith(collisionPartner);

            Assert.AreEqual(target.IsAlive, false);
            Assert.AreEqual(((Player)collisionPartner).ActivePowerUps.Count, 1);

            //Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");

            // GameItem-Liste zurücksetzen
            GameItem.GameItemList = null;
        }
    }
}
