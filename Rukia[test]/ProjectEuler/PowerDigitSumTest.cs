using Nameless.Libraries.Rukia.ProjectEuler.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.Test.ProjectEuler
{
    [TestClass]
    public class PowerDigitSumTest
    {
        [TestMethod]
        public void TestPow2_15()
        {
            PowerDigitSum test = new PowerDigitSum(2, 15);
            Assert.AreEqual(26, test.Result);
        }

        [TestMethod]
        public void TestPow2_1000()
        {
            PowerDigitSum test = new PowerDigitSum(2, 1000);
            Assert.AreEqual(1366, test.Result);
        }
    }
}
