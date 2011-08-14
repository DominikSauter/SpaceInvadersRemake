using SpaceInvadersRemake.View;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.Xna.Framework;
using SpaceInvadersRemake.ModelSection;

namespace SpaceInvaderRemakeUnitTest
{
    
    
    /// <summary>
    ///Dies ist eine Testklasse für "ModelHitsphereTest" und soll
    ///alle ModelHitsphereTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class ModelHitsphereTest
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
        ///Ein Test für "Intersects"
        ///</summary>
        [TestMethod()]
        public void IntersectsTest()
        {
            //äußere Hitsphere, die ein gesamtes Objekt umgibt
            BoundingSphere outerSphere = new BoundingSphere(new Vector3(0, 0, 0), 10.0f);
            //mit der 'outerSphere' wird eine ModelHitsphere erstellt
            ModelHitsphere target = new ModelHitsphere(outerSphere);
            //eine weitere ModelHitsphere zum Testen der Kollision wird erstellt
            IBoundingVolume other = new ModelHitsphere(new BoundingSphere(new Vector3(0, 0, 9), 10.0f));
            bool expected = true;
            bool actual;
            actual = target.Intersects(other);
            Assert.AreEqual(expected, actual);
        }
    }
}
