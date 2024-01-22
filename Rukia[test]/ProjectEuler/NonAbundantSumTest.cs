using Nameless.Libraries.Rukia.ProjectEuler.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.Test.ProjectEuler
{
    [TestClass]
    public class NonAbundantSumTest
    {
        [TestMethod]
        public void NonAbundantSum28123()
        {
            NonAbundantSum action = new NonAbundantSum();
            Assert.AreEqual(4179871, action.Result);
        }
    }
}
