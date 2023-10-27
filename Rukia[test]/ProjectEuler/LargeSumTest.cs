using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.Test.ProjectEuler
{
    [TestClass]
    public class LargeSumTest
    {
        [TestMethod]
        public void TestSum()
        {
            LargeSum sum = new LargeSum();
            Assert.AreEqual("5537376230", sum.Result);
        }
    }
}
