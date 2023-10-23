using Nameless.Libraries.Rukia.ProjectEuler.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.Test.ProjectEuler
{
    [TestClass]
    public class SpecialPythagoreanTripletTest
    {
        [TestMethod]
        public void TestPerimeter12()
        {
            SpecialPythagoreanTriplet action = new SpecialPythagoreanTriplet(12);
            Assert.AreEqual(60, action.Product);
        }

        [TestMethod]
        public void TestPerimeter1000()
        {
            SpecialPythagoreanTriplet action = new SpecialPythagoreanTriplet(1000);
            Assert.AreEqual(31875000, action.Product);
        }
    }
}
