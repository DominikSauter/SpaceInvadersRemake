using SpaceInvadersRemake.ModelSection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace SpaceInvaderRemakeUnitTest
{
    
    
    /// <summary>
    ///Dies ist eine Testklasse für "MenuTest" und soll
    ///alle MenuTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class MenuTest
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

        private Menu_Accessor CreateTestMenu()
        {
            // Erstellt ein neues Menü mit fünf Einträgen, wovon einer zufällig ausgewählt wird

            List<MenuControl> controls = new List<MenuControl>();

            controls.Add(new Button("Testbutton1", null));
            controls.Add(new Button("Testbutton2", null));
            controls.Add(new Button("Testbutton3", null));
            controls.Add(new Button("Testbutton4", null));
            controls.Add(new Button("Testbutton5", null));

            Random random = new Random();

            Menu_Accessor menu = new Menu_Accessor(controls);

            menu.ActiveControl = menu.controls[random.Next(menu.controls.Count)];

            return menu;

        }

        /// <summary>
        ///Ein Test für "Down"
        ///</summary>
        [TestMethod()]
        public void DownTest()
        {
            // Neues Menü erstellen
            Menu_Accessor target = CreateTestMenu();

            // Den Index vor der Ausführung speichern
            int index_before = target.controls.IndexOf(target.ActiveControl);

            target.Down();

            // Den Index nach der Ausführung speichern
            int index_after = target.controls.IndexOf(target.ActiveControl);

            int expected = (index_before + 1) % target.controls.Count;

            Assert.AreEqual(index_after, expected);
        }

        /// <summary>
        ///Ein Test für "Up"
        ///</summary>
        [TestMethod()]
        public void UpTest()
        {
            // Neues Menü erstellen
            Menu_Accessor target = CreateTestMenu();

            // Den Index vor der Ausführung speichern
            int index_before = target.controls.IndexOf(target.ActiveControl);

            target.Up();

            // Den Index nach der Ausführung speichern
            int index_after = target.controls.IndexOf(target.ActiveControl);

            int expected = (index_before - 1 + target.controls.Count) % target.controls.Count;

            Assert.AreEqual(index_after, expected);
        }
    }
}
