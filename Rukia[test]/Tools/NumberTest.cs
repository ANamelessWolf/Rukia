using Nameless.Libraries.Rukia.ProjectEuler.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.Test.Tools
{
    [TestClass]
    public class NumberTest
    {
        [TestMethod]
        public void NumberFactors()
        {
            long[] numbers = { 4573800, 1, 3, 10, 28, 36, 76576500 };
            long[] total = { 288, 1, 2, 4, 6, 9, 576 };
            PrimeTester tester = new PrimeTester();
            for (int i = 0; i < numbers.Length; i++)
            {
                var n = numbers[i];
                var factors = n.GetFactors(tester);
                var fCount = n.CountFactors(tester);
                Assert.AreEqual(fCount, factors.Count);
                Assert.AreEqual( total[i], fCount);

            }
        }
    }
}
