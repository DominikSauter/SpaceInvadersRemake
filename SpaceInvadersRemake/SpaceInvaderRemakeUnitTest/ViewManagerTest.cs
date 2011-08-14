using SpaceInvadersRemake.View;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using SpaceInvadersRemake.StateMachine;
using Microsoft.Xna.Framework;
using SpaceInvadersRemake;

namespace SpaceInvaderRemakeUnitTest
{
    
    
    /// <summary>
    ///Dies ist eine Testklasse für "ViewManagerTest" und soll
    ///alle ViewManagerTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class ViewManagerTest
    {
        private GameManager gMngr;
        private StateManager sMngr;
        private State currentState;
        private GraphicsDeviceManager graphics;


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
        [TestInitialize()]
        public void MyTestInitialize()
        {
            this.gMngr = new GameManager();
            this.sMngr = new StateManager(gMngr);
            this.sMngr.State = new InGameState(sMngr, gMngr);
            this.graphics = new GraphicsDeviceManager(gMngr);
            this.gMngr.graphics = this.graphics;
            this.currentState = sMngr.State;
        }

        //Mit TestCleanup können Sie nach jedem einzelnen Test Code ausführen.
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///Ein Test für "EffectPlayer"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("SpaceInvadersRemake.exe")]
        public void EffectPlayerTest()
        {
            IMediaplayer expected = null; // TODO: Passenden Wert initialisieren
            IMediaplayer actual;
            ViewManager_Accessor.EffectPlayer = expected;
            actual = ViewManager_Accessor.EffectPlayer;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "ViewItemList"
        ///</summary>
        [TestMethod()]
        [DeploymentItem("SpaceInvadersRemake.exe")]
        public void ViewItemListTest()
        {
            PrivateObject param0 = null; // TODO: Passenden Wert initialisieren
            ViewManager_Accessor target = new ViewManager_Accessor(param0); // TODO: Passenden Wert initialisieren
            List<SpaceInvadersRemake.View.IView> expected = null; // TODO: Passenden Wert initialisieren
            List<SpaceInvadersRemake.View.IView> actual;
            target.ViewItemList = expected;
            actual = target.ViewItemList;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Überprüfen Sie die Richtigkeit dieser Testmethode.");
        }

        /// <summary>
        ///Ein Test für "CreatePlayer"
        ///</summary>
        [TestMethod()]
        public void CreatePlayerTest()
        {
            State currentState = this.currentState;
            GraphicsDeviceManager graphics = this.graphics;
            ViewManager target = new ViewManager(currentState, graphics);
            SpaceInvadersRemake.ModelSection.Player player = new SpaceInvadersRemake.ModelSection.Player(
                new Vector2(0,0), new Vector2(1,0), 1, 1, new SpaceInvadersRemake.ModelSection.PlayerNormalWeapon(), 1);
            EventArgs e = new EventArgs();
            target.CreatePlayer(player, e);
            Assert.IsTrue(target.ViewItemList.Count == 1, "Es ist kein Element oder zu Viele in der Liste vorhanden!");
        }

        /// <summary>
        ///Ein Test für "CreateMothership"
        ///</summary>
        [TestMethod()]
        public void CreateMothershipTest()
        {
            State currentState = null; // TODO: Passenden Wert initialisieren
            GraphicsDeviceManager graphics = null; // TODO: Passenden Wert initialisieren
            ViewManager target = new ViewManager(currentState, graphics); // TODO: Passenden Wert initialisieren
            object mothership = null; // TODO: Passenden Wert initialisieren
            EventArgs e = null; // TODO: Passenden Wert initialisieren
            target.CreateMothership(mothership, e);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "CreateAlien"
        ///</summary>
        [TestMethod()]
        public void CreateAlienTest()
        {
            State currentState = null; // TODO: Passenden Wert initialisieren
            GraphicsDeviceManager graphics = null; // TODO: Passenden Wert initialisieren
            ViewManager target = new ViewManager(currentState, graphics); // TODO: Passenden Wert initialisieren
            object alien = null; // TODO: Passenden Wert initialisieren
            EventArgs e = null; // TODO: Passenden Wert initialisieren
            target.CreateAlien(alien, e);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "CreateProjectile"
        ///</summary>
        [TestMethod()]
        public void CreateProjectileTest()
        {
            State currentState = null; // TODO: Passenden Wert initialisieren
            GraphicsDeviceManager graphics = null; // TODO: Passenden Wert initialisieren
            ViewManager target = new ViewManager(currentState, graphics); // TODO: Passenden Wert initialisieren
            object projectile = null; // TODO: Passenden Wert initialisieren
            EventArgs e = null; // TODO: Passenden Wert initialisieren
            target.CreateProjectile(projectile, e);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");

            //[Anji] Der eigentliche test, der jedoch wegen einem, bis jetzt noch nicht behobenem, Fehler nicht ausführbar ist
            //GameManager gameMan = new GameManager();
            ////GraphicsDevice gd = new GraphicsDevice(GraphicsAdapter.DefaultAdapter, GraphicsProfile.HiDef, new PresentationParameters());
            //StateManager stateManager = new StateManager(gameMan);
            //State currentState = new InGameState(stateManager, gameMan);
            //ViewManager target = new ViewManager(currentState, gameMan.graphics);
            //object projectile = new Projectile(new Vector2(0, 0), new Vector2(0, 1), ProjectileTypeEnum.PlayerNormalProjectile, 10, new Vector2(0, 1), 10);
            //EventArgs e = new EventArgs();
            //target.CreateProjectile(projectile, e);
            ////Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "CreatePowerUp"
        ///</summary>
        [TestMethod()]
        public void CreatePowerUpTest()
        {
            State currentState = null; // TODO: Passenden Wert initialisieren
            GraphicsDeviceManager graphics = null; // TODO: Passenden Wert initialisieren
            ViewManager target = new ViewManager(currentState, graphics); // TODO: Passenden Wert initialisieren
            object powerUp = null; // TODO: Passenden Wert initialisieren
            EventArgs e = null; // TODO: Passenden Wert initialisieren
            target.CreatePowerUp(powerUp, e);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");

            //[Anji] Der eigentliche test, der jedoch wegen einem, bis jetzt noch nicht behobenem, Fehler nicht ausführbar ist
            //GameManager gameMan = new GameManager();
            ////GraphicsDevice gd = new GraphicsDevice(GraphicsAdapter.DefaultAdapter, GraphicsProfile.HiDef, new PresentationParameters());
            //StateManager stateManager = new StateManager(gameMan);
            //State currentState = new InGameState(stateManager, gameMan);
            //ViewManager target = new ViewManager(currentState, gameMan.graphics);
            //Vector2 position = new Vector2(0f, 0f);
            //Vector2 velocity = new Vector2(1f, 0f);
            //object powerUp = new PiercingShot(position, velocity);
            //EventArgs e = new EventArgs();
            //target.CreatePowerUp(powerUp, e);
            ////Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "CreateShield"
        ///</summary>
        [TestMethod()]
        public void CreateShieldTest()
        {
            State currentState = null; // TODO: Passenden Wert initialisieren
            GraphicsDeviceManager graphics = null; // TODO: Passenden Wert initialisieren
            ViewManager target = new ViewManager(currentState, graphics); // TODO: Passenden Wert initialisieren
            object shield = null; // TODO: Passenden Wert initialisieren
            EventArgs e = null; // TODO: Passenden Wert initialisieren
            target.CreateShield(shield, e);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");

            //[Anji] Der eigentliche test, der jedoch wegen einem, bis jetzt noch nicht behobenem, Fehler nicht ausführbar ist
            //GameManager gameMan = new GameManager();
            ////GraphicsDevice gd = new GraphicsDevice(GraphicsAdapter.DefaultAdapter, GraphicsProfile.HiDef, new PresentationParameters());
            //StateManager stateManager = new StateManager(gameMan);
            //State currentState = new InGameState(stateManager, gameMan);
            //ViewManager target = new ViewManager(currentState, gameMan.graphics);
            //object shield = new Shield(new Vector2(0, 0), 100, 100);
            //EventArgs e = new EventArgs();
            //target.CreateShield(shield, e);
            ////Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "HitSFX"
        ///</summary>
        [TestMethod()]
        public void HitSFXTest()
        {
            State currentState = null; // TODO: Passenden Wert initialisieren
            GraphicsDeviceManager graphics = null; // TODO: Passenden Wert initialisieren
            ViewManager target = new ViewManager(currentState, graphics); // TODO: Passenden Wert initialisieren
            object gameItem = null; // TODO: Passenden Wert initialisieren
            EventArgs e = null; // TODO: Passenden Wert initialisieren
            target.HitSFX(gameItem, e);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");

            //[Anji] Der eigentliche test, der jedoch wegen einem, bis jetzt noch nicht behobenem, Fehler nicht ausführbar ist
            //GameManager gameMan = new GameManager();
            ////GraphicsDevice gd = new GraphicsDevice(GraphicsAdapter.DefaultAdapter, GraphicsProfile.HiDef, new PresentationParameters());
            //StateManager stateManager = new StateManager(gameMan);
            //State currentState = new InGameState(stateManager, gameMan);
            //ViewManager target = new ViewManager(currentState, gameMan.graphics);
            //object gameItem = new Shield(new Vector2(0, 0), 100, 100);
            //EventArgs e = new EventArgs();
            //target.HitSFX(gameItem, e);
            ////Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
        }

        /// <summary>
        ///Ein Test für "ShootSFX"
        ///</summary>
        [TestMethod()]
        public void ShootSFXTest()
        {
            State currentState = null; // TODO: Passenden Wert initialisieren
            GraphicsDeviceManager graphics = null; // TODO: Passenden Wert initialisieren
            ViewManager target = new ViewManager(currentState, graphics); // TODO: Passenden Wert initialisieren
            object weapon = null; // TODO: Passenden Wert initialisieren
            EventArgs e = null; // TODO: Passenden Wert initialisieren
            target.ShootSFX(weapon, e);
            Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");

            //[Anji] Der eigentliche test, der jedoch wegen einem, bis jetzt noch nicht behobenem, Fehler nicht ausführbar ist
            //GameManager gameMan = new GameManager();
            ////GraphicsDevice gd = new GraphicsDevice(GraphicsAdapter.DefaultAdapter, GraphicsProfile.HiDef, new PresentationParameters());
            //StateManager stateManager = new StateManager(gameMan);
            //State currentState = new InGameState(stateManager, gameMan);
            //ViewManager target = new ViewManager(currentState, gameMan.graphics); 
            //object weapon = new PlayerNormalWeapon(); 
            //EventArgs e = new EventArgs(); 
            //target.ShootSFX(weapon, e);
            ////Assert.Inconclusive("Eine Methode, die keinen Wert zurückgibt, kann nicht überprüft werden.");
            
        }
    }
}
