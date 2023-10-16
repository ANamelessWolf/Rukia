using Nameless.Libraries.Rukia.ProjectEuler.Utility;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler
{
    /// <summary>
    /// Take the number 192 and multiply it by each of 1, 2, and 3:
    /// 192 × 1 = 192
    /// 192 × 2 = 384
    /// 192 × 3 = 576
    /// By concatenating each product we get the 1 to 9 pandigital, 192384576. We will call 192384576 the concatenated product of 192 and (1,2,3)
    /// The same can be achieved by starting with 9 and multiplying by 1, 2, 3, 4, and 5, giving the pandigital, 918273645, 
    /// which is the concatenated product of 9 and (1,2,3,4,5).
    /// What is the largest 1 to 9 pandigital 9-digit number that can be formed as the concatenated product of an integer 
    /// with (1,2, ... , n) where n > 1?
    /// </summary>
    public class PandigitalMultiples : ISolution<long>
    {
        /// <summary>
        /// The result
        /// </summary>
        public long Result { get { return Solve(); } }
        /// <summary>
        /// Get the sum of all spiral members
        /// </summary>
        /// <param name="limit">The matrix spiral order</param>
        public PandigitalMultiples()
        {

        }
        /// <summary>
        /// Solve the problem
        /// </summary>
        /// <returns>The sum result</returns>
        public long Solve()
        {
            long num = 2, largest = 2, last = 0;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            String nStr = (num * 1).ToString();
            while (MinProduct(num).Length < 10)
            {
                if (IsLargerPandigital(nStr, ref last, num))
                    largest = num;
                num++;
            }

            sw.Stop();
            Console.WriteLine("Elapsed: {0}s, {1}ms", sw.Elapsed.Seconds, sw.Elapsed.Milliseconds);
            return last;
        }

        private bool IsLargerPandigital(String nStr, ref long last, long num)
        {
            long index = 1;
            long product = 0;
            Char[] ch;
            Boolean isPandigital = false;
            nStr = String.Empty;
            while (nStr.Length != 9)
            {
                product = num * index;
                if ((nStr + product.ToString()).Length == 9)
                {
                    nStr += product.ToString();
                    ch = nStr.ToCharArray();
                    Array.Sort<char>(ch);
                    isPandigital = new String(ch) == "123456789" ? true : false;
                }
                else if ((nStr + product.ToString()).Length < 9)
                    nStr += product.ToString();
                else
                    break;
                index++;
            }
            product = long.Parse(nStr);
            if (isPandigital && product > last)
            {
                last = product;
                return true;
            }
            else
                return false;
        }

        private string MinProduct(long num)
        {
            String digit = string.Empty;
            for (int n = 1; n <= 2; n++)
                digit += (num * n).ToString();
            return digit;
        }
        /// <summary>
        /// Print the result
        /// </summary>
        /// <returns>The result</returns>
        public override string ToString()
        {
            return String.Format("The largest 1 to 9 pandigital 9-digit number that can be formed as the concatenated product of an integer with (1,2, ... , n) where n > 1is {0}", this.Result);
        }
    }

}
