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
    }
}
