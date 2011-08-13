using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xna.Framework;
using SpaceInvadersRemake.ModelSection;

namespace SpaceInvaderRemakeUnitTest
{
    
    
    /// <summary>
    ///Dies ist eine Testklasse für "GameCourseManagerTest" und soll
    ///alle GameCourseManagerTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class GameCourseManagerTest
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
        ///Ein Test für "UpdateGameItemList"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("SpaceInvadersRemake.exe")]
        public void UpdateGameItemListTest()
        {
            GameCourseManager_Accessor target = new GameCourseManager_Accessor();


            GameItem.GameItemList = new System.Collections.Generic.LinkedList<IGameItem>();

            // Alien befindet sich in Kollision mit Spieler-Projektil
            GameItem.GameItemList.AddLast(new Alien(new Vector2(100f, 100f), GameItemConstants.AlienVelocity, GameItemConstants.AlienHitpoints, GameItemConstants.AlienDamage, GameItemConstants.AlienWeapon, GameItemConstants.AlienScoreGain));
            GameItem.GameItemList.AddLast(new Projectile(new Vector2(100f, 100f), CoordinateConstants.Up, ProjectileTypeEnum.PlayerNormalProjectile, GameItemConstants.PlayerNormalProjectileHitpoints, GameItemConstants.PlayerNormalProjectileVelocity, GameItemConstants.PlayerNormalProjectileDamage));

            // Alien ohne Kollision
            GameItem.GameItemList.AddLast(new Alien(new Vector2(10f, 10f), GameItemConstants.AlienVelocity, GameItemConstants.AlienHitpoints, GameItemConstants.AlienDamage, GameItemConstants.AlienWeapon, GameItemConstants.AlienScoreGain));

            // Nach Ausführung der Methode in der GameItem.GameItemList verbleibendes Alien
            IGameItem remainingAlien = GameItem.GameItemList.Last.Value;


            GameTime gameTime = new GameTime(new TimeSpan(0, 0, 42), new TimeSpan(0, 0, 1));
            target.UpdateGameItemList(gameTime);

            Assert.AreSame(remainingAlien, GameItem.GameItemList.First.Value);

            GameItem.GameItemList = null;
        }
    }
}
