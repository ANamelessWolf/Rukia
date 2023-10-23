using Nameless.Libraries.Rukia.ProjectEuler.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.Test.ProjectEuler
{
    [TestClass]
    public class LargestProductInASeriesTest
    {
        [TestMethod]
        public void Test4Digits()
        {
            LargestProductInASeries action = new LargestProductInASeries(4);
            Assert.AreEqual(5832, action.Product);
        }

        [TestMethod]
        public void Test13Digits()
        {
            LargestProductInASeries action = new LargestProductInASeries(13);
            Assert.AreEqual(23514624000, action.Product);
        }

    }
}
