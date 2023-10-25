using Nameless.Libraries.Rukia.ProjectEuler.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.Test.ProjectEuler
{
    [TestClass]
    public class LargestProductOnAGridTest
    {
        [TestMethod]
        public void Test4Adjacents()
        {
            LargestProductOnAGrid action = new LargestProductOnAGrid(4);
            Assert.AreEqual(70600674, action.Product);
        }

    }
}
