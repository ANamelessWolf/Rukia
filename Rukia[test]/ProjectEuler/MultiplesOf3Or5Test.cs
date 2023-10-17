using Nameless.Libraries.Rukia.ProjectEuler.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.Test.ProjectEuler
{
    [TestClass]
    public class MultiplesOf3Or5Test
    {

        [TestMethod]
        public void TestLimit10()
        {
            MultiplesOf3Or5 task = new MultiplesOf3Or5(10);
            Assert.AreEqual(task.Result, 23);        
        }

        [TestMethod]
        public void TestLimit1000()
        {
            MultiplesOf3Or5 task = new MultiplesOf3Or5(1000);
            Assert.AreEqual(task.Result, 233168);
        }

    }
}
