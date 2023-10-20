using Nameless.Libraries.Rukia.ProjectEuler.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.Test.ProjectEuler
{
    [TestClass]
    public class SumSquareDifferenceTest
    {
        [TestMethod]
        public void TestLimit10()
        {
            SumSquareDifference task = new SumSquareDifference(10);
            Assert.AreEqual(task.Result, 2640);
        }

        [TestMethod]
        public void TestLimit100()
        {
            SumSquareDifference task = new SumSquareDifference(100);
            Assert.AreEqual(task.Result, 25164150);
        }
    }
}
