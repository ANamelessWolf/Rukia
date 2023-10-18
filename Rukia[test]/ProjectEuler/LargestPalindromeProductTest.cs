using Nameless.Libraries.Rukia.ProjectEuler.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.Test.ProjectEuler
{
    [TestClass]
    public class LargestPalindromeProductTest
    {
        [TestMethod]
        public void Test2Digits()
        {
            LargestPalindromeProduct task = new LargestPalindromeProduct(2);
            Assert.AreEqual(task.Result, 9009);
        }

        [TestMethod]
        public void Test3Digits()
        {
            LargestPalindromeProduct task = new LargestPalindromeProduct(3);
            Assert.AreEqual(task.Result, 906609);
        }

        [TestMethod]
        public void Test4Digits()
        {
            LargestPalindromeProduct task = new LargestPalindromeProduct(4);
            Assert.AreEqual(task.Result, 99000099);
        }

    }
}
