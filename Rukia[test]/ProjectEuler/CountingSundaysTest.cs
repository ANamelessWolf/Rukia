using Nameless.Libraries.Rukia.ProjectEuler.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.Test.ProjectEuler
{
    [TestClass]
    public class CountingSundaysTest
    {
        [TestMethod]
        public void Test20thCentury()
        {
            CountingSundays action = new CountingSundays(new DateTime(1901, 1, 1), new DateTime(2000, 12, 31));
            Assert.AreEqual(171, action.Sundays);
        }
    }
}
