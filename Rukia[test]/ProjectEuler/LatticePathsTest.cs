using Nameless.Libraries.Rukia.ProjectEuler.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.Test.ProjectEuler
{
    [TestClass]
    public class LatticePathsTest
    {
        [TestMethod]
        public void Test2()
        {
            LatticePaths test = new LatticePaths(2);
            Assert.AreEqual(6, test.Routes);
        }

        [TestMethod]
        public void Test20()
        {
            LatticePaths test = new LatticePaths(20);
            Assert.AreEqual(137846528820, test.Routes);
        }
    }
}
