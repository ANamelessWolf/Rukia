using Nameless.Libraries.Rukia.ProjectEuler.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.Test.ProjectEuler
{
    [TestClass]
    public class NumberLetterCountsTest
    {
        [TestMethod]
        public void CountTo5()
        {
            NumberLetterCounts test = new NumberLetterCounts(5);
            Assert.AreEqual(19, test.Count);
        }

        [TestMethod]
        public void CountTo1000()
        {
            NumberLetterCounts test = new NumberLetterCounts(1000);
            Assert.AreEqual(21124, test.Count);
        }

        [TestMethod]
        public void CountNumberChars()
        {
            NumberLetterCounts test = new NumberLetterCounts(1);
            Assert.AreEqual(23, test.CountLetters(342));
            Assert.AreEqual(20, test.CountLetters(115));
        }
    }
}
