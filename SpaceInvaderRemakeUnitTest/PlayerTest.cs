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

        private Player CreatePlayer()
        {
            // Neuen Spieler erzeugen und zurückgeben
            return new Player(GameItemConstants.PlayerPosition, GameItemConstants.PlayerVelocity, GameItemConstants.PlayerHitpoints, GameItemConstants.PlayerDamage, GameItemConstants.PlayerWeapon, GameItemConstants.PlayerLives);
        }

        private Player_Accessor CreatePlayer_Accessor()
        {
            // Neuen Spieler erzeugen und zurückgeben
            return new Player_Accessor(GameItemConstants.PlayerPosition, GameItemConstants.PlayerVelocity, GameItemConstants.PlayerHitpoints, GameItemConstants.PlayerDamage, GameItemConstants.PlayerWeapon, GameItemConstants.PlayerLives);
        }

        /// <summary>
        ///Ein Test für "Move"
        ///</summary>
        [TestMethod()]
        public void MoveTest()
        {
            // GameItem-Liste initialisieren
            GameItem.GameItemList = new System.Collections.Generic.LinkedList<IGameItem>();

            // Neuen Spieler erzeugen
            Player target = CreatePlayer();

            // Passende Parameter erzeugen
            Vector2 direction = CoordinateConstants.Left; 
            GameTime gameTime = new GameTime(new TimeSpan(0, 42, 42), new TimeSpan(166667)); 

            bool expected = true;
            bool actual;

            actual = target.Move(direction, gameTime);

            Assert.AreEqual(expected, actual);

            // GameItem-Liste zurücksetzen
            GameItem.GameItemList = null;
        }

        /// <summary>
        ///Ein Test für "Reset"
        ///</summary>
        [TestMethod()]
        public void ResetTest()
        {

            // GameItem-Liste initialisieren
            GameItem.GameItemList = new System.Collections.Generic.LinkedList<IGameItem>();

            // Neuen Spieler erzeugen
            Player target = CreatePlayer();
            // Die Werte des Spielers etwas verändern
            target.Weapon = new RapidfireWeapon();
            target.Hitpoints = 20;
            target.Velocity *= 1.5f;
            // PowerUp erzeugen und in die PowerUp-Liste eintragen
            Rapidfire rapidfire = new Rapidfire(Vector2.Zero, Vector2.Zero);
            target.ActivePowerUps.Add(new ActivePowerUp(12.0f, PowerUpEnum.Rapidfire, rapidfire.Apply, rapidfire.Remove));

            target.Reset();

            // Überprüfen, ob der Spieler korrekt zurückgesetzt wurde
            Assert.AreEqual(target.Position, GameItemConstants.PlayerPosition);
            Assert.AreEqual(target.Velocity, GameItemConstants.PlayerVelocity);
            Assert.AreEqual((target.Weapon is PlayerNormalWeapon), true);
            Assert.AreEqual(target.Hitpoints, GameItemConstants.PlayerHitpoints);
            Assert.AreEqual(target.IsInvincible, true);
            Assert.AreEqual(target.ActivePowerUps.Count, 0);

            // GameItem-Liste zurücksetzen
            GameItem.GameItemList = null;
        }

        /// <summary>
        ///Ein Test für "AddPowerUp"
        ///</summary>
        [TestMethod()]
        public void AddPowerUpTest()
        {
            // GameItem-Liste initialisieren
            GameItem.GameItemList = new System.Collections.Generic.LinkedList<IGameItem>();
            
            // Neuen Spieler erzeugen
            Player target = CreatePlayer();

            // Neues PowerUp und ActivePowerUp erzeugen
            MultiShot multiShot = new MultiShot(Vector2.Zero, Vector2.Zero);
            ActivePowerUp powerUp = new ActivePowerUp(15.0f, PowerUpEnum.MultiShot, multiShot.Apply, multiShot.Remove); // TODO: Passenden Wert initialisieren
           

            target.AddPowerUp(powerUp);

            Assert.AreEqual(target.ActivePowerUps.Count, 1);

            // GameItem-Liste zurüksetzen
            GameItem.GameItemList = null;
        }

        /// <summary>
        ///Ein Test für "Update"
        ///</summary>
        [TestMethod()]
        public void UpdateTest()
        {
            // GameItem-Liste initialisieren
            GameItem.GameItemList = new System.Collections.Generic.LinkedList<IGameItem>();

            // Neuen Spieler erzeugen (Accessor, das private Felder manipuliert werden müssen)
            Player_Accessor target = CreatePlayer_Accessor();

            // Unverwundbarkeits-Timer setzen
            target.invincibleTime = 0.5f;

            // PowerUp hinzufügen
            Speedboost speedboost = new Speedboost(Vector2.Zero, Vector2.Zero);
            target.AddPowerUp(new ActivePowerUp(0.5f, PowerUpEnum.Speedboost, speedboost.Apply, speedboost.Remove));

            // GameTime so anlegen, dass nach Update keine Unverwundbarkeit mehr aktiv sein sollte und das PowerUp ausgelaufen ist
            GameTime gameTime = new GameTime(new TimeSpan(0, 42, 42), new TimeSpan(0, 0, 1));
            
            target.Update(gameTime);
            

            Assert.AreEqual(target.IsInvincible, false);
            Assert.AreEqual(target.ActivePowerUps.Count, 0);

            // GameItem-Liste zurücksetzen
            GameItem.GameItemList = null;
        }

        /// <summary>
        ///Ein Test für "IsCollidedWith"
        ///</summary>
        [TestMethod()]
        public void IsCollidedWithTest()
        {
            GameItem.GameItemList = new System.Collections.Generic.LinkedList<IGameItem>();

            // Neuen Spieler erzeugen (Accessor, das private Felder manipuliert werden müssen)
            Player_Accessor target = CreatePlayer_Accessor(); 
            // Anfängliche Unverwundbarkeit ausschalten
            target.invincibleTime = 0.0f;

            // Als Kollisionspartner ein Alien erstellen
            IGameItem collisionPartner = new Alien(Vector2.Zero, GameItemConstants.AlienVelocity, GameItemConstants.AlienHitpoints, GameItemConstants.AlienDamage, GameItemConstants.AlienWeapon, GameItemConstants.AlienScoreGain); // TODO: Passenden Wert initialisieren
            
            target.IsCollidedWith(collisionPartner);


            Assert.AreEqual(target.Lives, GameItemConstants.PlayerLives - 1);
            Assert.AreEqual(target.IsInvincible, true);

            // GameItem-Liste zurücksetzen
            GameItem.GameItemList = null;
        }
    }
}
