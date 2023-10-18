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

    }
}
