using Nameless.Libraries.Rukia.ProjectEuler.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.Test.Tools
{
    [TestClass]
    public class NumberTest
    {
        [TestMethod]
        public void NumberFactors()
        {
            long[] numbers = { 4573800, 1, 3, 10, 28, 36, 76576500 };
            long[] total = { 288, 1, 2, 4, 6, 9, 576 };
            PrimeTester tester = new PrimeTester();
            for (int i = 0; i < numbers.Length; i++)
            {
                var n = numbers[i];
                var factors = n.GetFactors(tester);
                var fCount = n.CountFactors(tester);
                Assert.AreEqual(fCount, factors.Count);
                Assert.AreEqual( total[i], fCount);

            }
        }

        [TestMethod]
        public void ToEnglishNumber()
        {
            long[] numbers = { 
                1000,
                7000,
                1020693, 
                26300805,  
                999999999999, 
                121, 
                5, 
                19, 
                700125,
                300403001,
                100600,
                4202881,
                56018,
                7916,
            };
            string[] engNames = {
                "one thousand",
                "seven thousand",
                "one million, twenty thousand, six hundred and ninety-three",
                "twenty six million, three hundred thousand, eight hundred and five",
                "nine hundred and ninety nine billion, nine hundred and ninety nine million, nine hundred and ninety nine thousand, nine hundred and ninety-nine",
                "one hundred and twenty-one", 
                "five",
                "nineteen",
                "seven hundred thousand, one hundred and twenty-five",
                "three hundred million, four hundred and three thousand and one",
                "one hundred thousand, six hundred",
                "four million, two hundred and two thousand, eight hundred and eighty-one",
                "fifty-six thousand and eighteen",
                "seven thousand, nine hundred and sixteen"
            };
            for (int i = 0; i < numbers.Length; i++)
            {
                var n = numbers[i];
                var name = n.ToEnglish();
                Assert.AreEqual(name, engNames[i]);
            }
        }
    }
}
