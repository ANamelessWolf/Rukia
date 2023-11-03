using Nameless.Libraries.Rukia.ProjectEuler.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler.Utils
{
    public static class NumberUtils
    {
        /// <summary>
        /// Test if a number is even
        /// </summary>
        /// <param name="number">The number to be tested</param>
        /// <returns>True if the number is even</returns>
        public static Boolean IsEven(this int number)
        {
            return number % 2 == 0;
        }

        /// <summary>
        /// Test if a number is Odd
        /// </summary>
        /// <param name="number">The number to be tested</param>
        /// <returns>True if the number is Odd</returns>
        public static Boolean IsOdd(this int number)
        {
            return number % 2 == 0;
        }


        public static bool IsPalindrome(this int number, int divSize)
        {
            int left, right = 0, num = number;
            while (divSize > 10)
            {
                left = number / divSize;
                right = right * 10 + num % 10;
                num /= 10;
                divSize /= 10;
                if (left != right)
                    return false;
            }
            return true;
        }

        public static int Inverse(this int number)
        {
            int reverse = 0, remainder;
            while (number != 0)
            {
                remainder = number % 10;
                reverse = reverse * 10 + remainder;
                number /= 10;
            }
            return reverse;
        }

        public static long GetTriangleNumber(this long index)
        {
            return (index * (index + 1)) / 2;
        }

        public static long GetTriangleNumber(this int index)
            => NumberUtils.GetTriangleNumber((long)index);


        public static List<long> GetFactors(this long number, PrimeTester tester)
        {
            List<long> factors = new List<long>();
            long testDivisor = 2;
            //All numbers have at least one factor
            factors.Add(1);
            if (number > 1)
                factors.Add(number / 1);
            while (number > 1 && testDivisor < number && testDivisor < number / testDivisor)
            {
                if (number % testDivisor == 0)
                {
                    factors.Add(testDivisor);
                    factors.Add(number / testDivisor);
                }
                testDivisor++;
            };
            if (testDivisor == number / testDivisor && number % testDivisor == 0)
                factors.Add(testDivisor);
            return factors;
        }

        public static int CountFactors(this long number, PrimeTester tester)
        {
            int fCount = 1;
            long testDivisor = 2;
            //All numbers have at least one factor
            if (number > 1)
                fCount++;
            while (number > 1 && testDivisor < number && testDivisor < number / testDivisor)
            {
                if (number % testDivisor == 0)
                    fCount += 2;
                testDivisor++;
            };
            if (testDivisor == number / testDivisor && number % testDivisor == 0)
                fCount++;
            return fCount;
        }

        public static long NextCollatzSequence(this long number)
        {
            if ((number % 2) == 0)
                return number / 2;
            else
                return 3 * number + 1;
        }
        public static int NextCollatzSequence(this int number)
        => (int)NextCollatzSequence((long)number);


        public static string ToEnglish(this long number)
        {
            StringNumber num = new StringNumber(number);
            return num.EnglishName;
        }
        public static string ToEnglish(this int number)
        => ToEnglish((long)number);

    }
}
