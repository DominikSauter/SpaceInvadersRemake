using SpaceInvadersRemake.ModelSection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.Xna.Framework;

namespace SpaceInvaderRemakeUnitTest
{
    
    
    /// <summary>
    ///Dies ist eine Testklasse für "PlayerTest" und soll
    ///alle PlayerTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class PlayerTest
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
        ///Ein Test für "Move"
        ///</summary>
        [TestMethod()]
        public void MoveTest()
        {
            // GameItem-Liste initialisieren
            GameItem.GameItemList = new System.Collections.Generic.LinkedList<IGameItem>();

            Vector2 position = GameItemConstants.PlayerPosition; // TODO: Passenden Wert initialisieren
            Vector2 velocity = GameItemConstants.PlayerVelocity; // TODO: Passenden Wert initialisieren
            int hitpoints = 10; // TODO: Passenden Wert initialisieren
            int damage = 10; // TODO: Passenden Wert initialisieren
            Weapon weapon = GameItemConstants.PlayerWeapon; // TODO: Passenden Wert initialisieren
            int lives = 3; // TODO: Passenden Wert initialisieren
            Player target = new Player(position, velocity, hitpoints, damage, weapon, lives); // TODO: Passenden Wert initialisieren
            Vector2 direction = CoordinateConstants.Left; // TODO: Passenden Wert initialisieren
            GameTime gameTime = new GameTime(new TimeSpan(0, 42, 42), new TimeSpan(166667)); // TODO: Passenden Wert initialisieren
            bool expected = true; // TODO: Passenden Wert initialisieren
            bool actual;
            actual = target.Move(direction, gameTime);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");

            // GameItem-Liste leeren
            GameItem.GameItemList.Clear();
        }

        /// <summary>
        ///Ein Test für "Reset"
        ///</summary>
        [TestMethod()]
        public void ResetTest()
        {

            // GameItem-Liste initialisieren
            GameItem.GameItemList = new System.Collections.Generic.LinkedList<IGameItem>();

            Vector2 position = GameItemConstants.PlayerPosition + new Vector2(50.0f, 0.0f); // TODO: Passenden Wert initialisieren
            Vector2 velocity = GameItemConstants.PlayerVelocity * 1.5f; // TODO: Passenden Wert initialisieren
            int hitpoints = 20; // TODO: Passenden Wert initialisieren
            int damage = 10; // TODO: Passenden Wert initialisieren
            Weapon weapon = new RapidfireWeapon(); // TODO: Passenden Wert initialisieren
            int lives = 2; // TODO: Passenden Wert initialisieren
            Player target = new Player(position, velocity, hitpoints, damage, weapon, lives); // TODO: Passenden Wert initialisieren
            Rapidfire rapidfire = new Rapidfire(Vector2.Zero, Vector2.Zero);
            target.ActivePowerUps.Add(new ActivePowerUp(12.0f, PowerUpEnum.Rapidfire, rapidfire.Apply, rapidfire.Remove));

            target.Reset();

            Assert.AreEqual(target.Position, GameItemConstants.PlayerPosition);
            Assert.AreEqual(target.Velocity, GameItemConstants.PlayerVelocity);
            Assert.AreEqual((target.Weapon is PlayerNormalWeapon), true);
            Assert.AreEqual(target.Hitpoints, GameItemConstants.PlayerHitpoints);
            Assert.AreEqual(target.IsInvincible, true);
            Assert.AreEqual(target.ActivePowerUps.Count, 0);
            
            //Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");

            // GameItem-Liste leeren
            GameItem.GameItemList.Clear();
        }

        /// <summary>
        ///Ein Test für "AddPowerUp"
        ///</summary>
        [TestMethod()]
        public void AddPowerUpTest()
        {
            // GameItem-Liste initialisieren
            GameItem.GameItemList = new System.Collections.Generic.LinkedList<IGameItem>();

            Vector2 position = GameItemConstants.PlayerPosition; // TODO: Passenden Wert initialisieren
            Vector2 velocity = GameItemConstants.PlayerVelocity; // TODO: Passenden Wert initialisieren
            int hitpoints = 10; // TODO: Passenden Wert initialisieren
            int damage = 10; // TODO: Passenden Wert initialisieren
            Weapon weapon = GameItemConstants.PlayerWeapon; // TODO: Passenden Wert initialisieren
            int lives = 3; // TODO: Passenden Wert initialisieren
            Player target = new Player(position, velocity, hitpoints, damage, weapon, lives); // TODO: Passenden Wert initialisieren
         
            MultiShot multiShot = new MultiShot(Vector2.Zero, Vector2.Zero);

            ActivePowerUp powerUp = new ActivePowerUp(15.0f, PowerUpEnum.MultiShot, multiShot.Apply, multiShot.Remove); // TODO: Passenden Wert initialisieren
           

            target.AddPowerUp(powerUp);

            Assert.AreEqual(target.ActivePowerUps.Count, 1);
            //Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");

            // GameItem-Liste leeren
            GameItem.GameItemList.Clear();
        }

        /// <summary>
        ///Ein Test für "Update"
        ///</summary>
        [TestMethod()]
        public void UpdateTest()
        {
            // GameItem-Liste initialisieren
            GameItem.GameItemList = new System.Collections.Generic.LinkedList<IGameItem>();

            Vector2 position = GameItemConstants.PlayerPosition; // TODO: Passenden Wert initialisieren
            Vector2 velocity = GameItemConstants.PlayerVelocity; // TODO: Passenden Wert initialisieren
            int hitpoints = 10; // TODO: Passenden Wert initialisieren
            int damage = 10; // TODO: Passenden Wert initialisieren
            Weapon weapon = GameItemConstants.PlayerWeapon; // TODO: Passenden Wert initialisieren
            int lives = 3; // TODO: Passenden Wert initialisieren
            Player_Accessor target = new Player_Accessor(position, velocity, hitpoints, damage, weapon, lives); // TODO: Passenden Wert initialisieren

            target.invincibleTime = 0.5f;

            Speedboost speedboost = new Speedboost(Vector2.Zero, Vector2.Zero);

            target.AddPowerUp(new ActivePowerUp(0.5f, PowerUpEnum.Speedboost, speedboost.Apply, speedboost.Remove));

            GameTime gameTime = new GameTime(new TimeSpan(0, 42, 42), new TimeSpan(0, 0, 1)); // TODO: Passenden Wert initialisieren
            
            target.Update(gameTime);
            

            Assert.AreEqual(target.IsInvincible, false);
            Assert.AreEqual(target.ActivePowerUps.Count, 0);

            //Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");

            // GameItem-Liste leeren
            GameItem.GameItemList.Clear();
        }

        /// <summary>
        ///Ein Test für "IsCollidedWith"
        ///</summary>
        [TestMethod()]
        public void IsCollidedWithTest()
        {
            GameItem.GameItemList = new System.Collections.Generic.LinkedList<IGameItem>();

            Vector2 position = GameItemConstants.PlayerPosition; // TODO: Passenden Wert initialisieren
            Vector2 velocity = GameItemConstants.PlayerVelocity; // TODO: Passenden Wert initialisieren
            int hitpoints = 10; // TODO: Passenden Wert initialisieren
            int damage = 10; // TODO: Passenden Wert initialisieren
            Weapon weapon = GameItemConstants.PlayerWeapon; // TODO: Passenden Wert initialisieren
            int lives = 3; // TODO: Passenden Wert initialisieren
            Player_Accessor target = new Player_Accessor(position, velocity, hitpoints, damage, weapon, lives); // TODO: Passenden Wert initialisieren
            target.invincibleTime = 0.0f;

            IGameItem collisionPartner = new Alien(Vector2.Zero, GameItemConstants.AlienVelocity, GameItemConstants.AlienHitpoints, GameItemConstants.AlienDamage, GameItemConstants.AlienWeapon, GameItemConstants.AlienScoreGain); // TODO: Passenden Wert initialisieren
            
            target.IsCollidedWith(collisionPartner);


            Assert.AreEqual(target.Lives, 2);
            Assert.AreEqual(target.IsInvincible, true);
            //Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");

            GameItem.GameItemList.Clear();
        }
    }
}
