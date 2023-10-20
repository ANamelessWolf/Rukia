using Nameless.Libraries.Rukia.ProjectEuler.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.Test.ProjectEuler
{
    [TestClass]
    public class SmallestMultipleTest
    {
        [TestMethod]
        public void Test10()
        {
            SmallestMultiple task = new SmallestMultiple(10);
            Assert.AreEqual(task.Result, 2520);
        }

        [TestMethod]
        public void Test20()
        {
            SmallestMultiple task = new SmallestMultiple(20);
            Assert.AreEqual(task.Result, 232792560);
        }
    }
}
