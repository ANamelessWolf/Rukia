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
    /// We shall say that an n-digit number is pandigital if it makes use of all the digits 1 to n exactly once; for example, the 5-digit number, 15234, is 1 through 5 pandigital.
    /// The product 7254 is unusual, as the identity, 39 × 186 = 7254, containing multiplicand, multiplier, and product is 1 through 9 pandigital.
    /// Find the sum of all products whose multiplicand/multiplier/product identity can be written as a 1 through 9 pandigital.
    /// HINT: Some products can be obtained in more than one way so be sure to only include it once in your sum.
    /// </summary>
    public class PandigitalProducts
    {
        /// <summary>
        /// The Distinct power members
        /// </summary>
        public List<String> Members;
        /// <summary>
        /// The number Limit
        /// </summary>
        public int Limit;
        /// <summary>
        /// The result
        /// </summary>
        public long Result { get { return Solve(); } }
        /// <summary>
        /// Get the sum of all spiral members
        /// </summary>
        /// <param name="limit">The matrix spiral order</param>
        public PandigitalProducts(int limit = 1000)
        {
            this.Limit = limit;
        }
        /// <summary>
        /// Solve the problem
        /// </summary>
        /// <returns>The sum result</returns>
        private long Solve()
        {
            long sum = 0;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            PandigitalProductNumber num;
            Members = new List<string>();
            for (int a = 1; a <= this.Limit; a++)
                for (int b = a; b <= this.Limit*2; b++)
                {
                    if (a % 10 == 0)
                        a++;
                    if (b % 10 == 0)
                        b++;
                    num = new PandigitalProductNumber(a, b);

                    if (num.IsPandigitalProduct)
                        if (!Members.Contains(num.Result.ToString()))
                        {
                            Members.Add(num.Result.ToString());
                            sum += num.Result;
                        }
                }
            sw.Stop();
            Console.WriteLine("Elapsed: {0}s, {1}ms", sw.Elapsed.Seconds, sw.Elapsed.Milliseconds);
            return sum;
        }
        /// <summary>
        /// Print the result
        /// </summary>
        /// <returns>The result</returns>
        public override string ToString()
        {
            return String.Format("The sum of all products whose multiplicand/multiplier/product identity can be written as a 1 through 9 pandigital is {0}", this.Result);
        }
    }
}
