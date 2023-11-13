using Nameless.Libraries.Rukia.ProjectEuler.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.Test.ProjectEuler
{
    [TestClass]
    public class FactorialDigitSumTest
    {
        [TestMethod]
        public void Factorial100()
        {
            FactorialDigitSum action = new FactorialDigitSum(100);
            Assert.AreEqual(648, action.Result);
        }
    }
}
