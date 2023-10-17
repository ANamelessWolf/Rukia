using Nameless.Libraries.Rukia.ProjectEuler.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.Test.ProjectEuler
{
    [TestClass]
    public class LargestPrimeFactorTest
    {
        [TestMethod]
        public void Test13195()
        {
            LargestPrimeFactor task = new LargestPrimeFactor(13195);
            Assert.AreEqual(task.Result, 29);
        }

        [TestMethod]
        public void TestLongNumber()
        {
            LargestPrimeFactor task = new LargestPrimeFactor(600851475143);
            Assert.AreEqual(task.Result, 6857);
        }
    }
}
