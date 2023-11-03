using Nameless.Libraries.Rukia.ProjectEuler.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.Test.ProjectEuler
{
    [TestClass]
    public class MaximumPathSumTest
    {
        [TestMethod]
        public void TestTiny()
        {
            MaximumPathSum test = new MaximumPathSum(PyramidSize.Tiny);
            Assert.AreEqual(23, test.Total);
        }

        [TestMethod]
        public void TestNormal()
        {
            MaximumPathSum test = new MaximumPathSum(PyramidSize.Normal);
            Assert.AreEqual(1074, test.Total);
        }
    }
}
