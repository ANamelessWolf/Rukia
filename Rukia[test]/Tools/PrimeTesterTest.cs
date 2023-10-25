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
            int[] arePrime = { 104743, 4759, 7789, 6211, 6857 };
            foreach (int n in arePrime)
            {
                Assert.AreEqual(true, tester.IsPrime(n));
            }

            int[] notPrime = { 99 };
            foreach (int n in notPrime)
            {
                Assert.AreEqual(false, tester.IsPrime(n));
            }
        }

        //[TestMethod]
        public void CreatPrimesFile()
        {
            PrimeGenerator generator = new PrimeGenerator();
            generator.Create(5000000);
        }
        [TestMethod]
        public void GetPrimesRange()
        {
            PrimeGenerator generator = new PrimeGenerator();
            var primes = generator.getPrimes(500, 2500);
            Assert.IsNotNull(primes);
            Assert.IsTrue(primes.Count > 0);
            Assert.AreEqual(503, primes.First());
            Assert.AreEqual(2477, primes.Last());

        }

    }
}
