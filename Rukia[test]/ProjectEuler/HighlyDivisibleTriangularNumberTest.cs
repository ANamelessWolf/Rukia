using Nameless.Libraries.Rukia.ProjectEuler.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.Test.ProjectEuler
{
    [TestClass]
    public class HighlyDivisibleTriangularNumberTest
    {
        [TestMethod]
        public void Test5divisors()
        {
            HighlyDivisibleTriangularNumber task = new HighlyDivisibleTriangularNumber(5);
            Assert.AreEqual(task.Number, 28);
        }
        [TestMethod]
        public void Test500divisors()
        {
            HighlyDivisibleTriangularNumber task = new HighlyDivisibleTriangularNumber(500);
            Assert.IsTrue(task.Number > 0);
        }
    }
}
