
using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Galaxy.Test
{
    [TestClass]
    public class GeometricTest
    {
        [TestMethod]
        public void TestGeometrics()
        {
            var testGalaxy = new Galaxy.Core.Models.Galaxy(new GeometricTestSetup());
            Assert.IsTrue(testGalaxy.GeometricIncludeCenter());
        }
    }
}
