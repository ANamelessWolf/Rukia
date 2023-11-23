using Nameless.Libraries.Rukia.ProjectEuler.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.Test.ProjectEuler
{
    [TestClass]
    public class AmicableNumbersTest
    {
        [TestMethod]
        public void TestUnder10000()
        {
            AmicableNumbers action = new AmicableNumbers(10000);
            Assert.AreEqual(31626, action.Result);
        }
    }
}
