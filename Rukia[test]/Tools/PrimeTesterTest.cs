using Nameless.Libraries.Rukia.ProjectEuler.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.Test.Tools
{
    [TestClass]
    public class PrimeTesterTest
    {
        [TestMethod]
        public void Int32PrimalityTest()
        {
            PrimeTester tester = new PrimeTester();
            int[] testNo = { 4759, 7789, 6211, 6857 };
            foreach (int n in testNo) {
                Assert.AreEqual(true, tester.IsPrime(n)); 
            }
        }
    }
}
