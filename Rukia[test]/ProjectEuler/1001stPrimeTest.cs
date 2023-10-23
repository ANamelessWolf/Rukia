using Nameless.Libraries.Rukia.ProjectEuler.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.Test.ProjectEuler
{
    [TestClass]
    public class ThousandFirstPrimeTest
    {
        [TestMethod]
        public void Test6ThPrime()
        {
            ThousandFirstPrime action = new ThousandFirstPrime(6);
            Assert.AreEqual(13, action.Result);
        }

        [TestMethod]
        public void Test1001StPrime()
        {
            ThousandFirstPrime action = new ThousandFirstPrime(1001);
            Assert.AreEqual(7927, action.Result);
        }

        [TestMethod]
        public void Test10001StPrime()
        {
            ThousandFirstPrime action = new ThousandFirstPrime(10001);
            Assert.AreEqual(104743, action.Result);
        }
    }
}
