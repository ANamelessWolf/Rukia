using Nameless.Libraries.Rukia.ProjectEuler.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.Test.ProjectEuler
{
    [TestClass]
    public class SummationOfPrimesTest
    {

        [TestMethod]
        public void TestBelow10()
        {
            SummationOfPrimes action = new SummationOfPrimes(10);
            Assert.AreEqual(17, action.Sum);
        }

        [TestMethod]
        public void TestBelow2M()
        {
            SummationOfPrimes action = new SummationOfPrimes(2000000);
            Assert.AreEqual(142913828922, action.Sum);
        }

    }
}
