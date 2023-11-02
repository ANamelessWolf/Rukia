using Nameless.Libraries.Rukia.ProjectEuler.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.Test.ProjectEuler
{
    [TestClass]
    public class LongestCollatzSequenceTest
    {
        [TestMethod]
        public void Test13()
        {
            LongestCollatzSequence seq = new LongestCollatzSequence(13);
            Assert.AreEqual(9, seq.Result);
        }

        [TestMethod]
        public void Test1000000()
        {
            LongestCollatzSequence seq = new LongestCollatzSequence(1000000);
            Assert.AreEqual(837799, seq.Result);
        }
    }
}
