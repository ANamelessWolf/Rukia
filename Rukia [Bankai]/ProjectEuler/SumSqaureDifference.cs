using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler
{
    /// <summary>
    /// The sum of the squares of the first ten natural numbers is,
    /// 12 + 22 + ... + 102 = 385
    /// The square of the sum of the first ten natural numbers is,
    /// (1 + 2 + ... + 10)2 = 552 = 3025
    /// Hence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is 3025 − 385 = 2640.
    /// Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.
    /// </summary>
    public class SumSqaureDifference
    {
        /// <summary>
        /// The sum limit
        /// </summary>
        public long Number;
        /// <summary>
        /// The multple sum result
        /// </summary>
        public long Result { get { return Solve(); } }
        /// <summary>
        /// Get the largest prime factor for the given number
        /// </summary>
        /// <param name="number">The number to extract it prime factor</param>
        public SumSqaureDifference(long number = 100)
        {
            this.Number = number;
        }
        /// <summary>
        /// Solve the problem
        /// </summary>
        /// <returns>The sum result</returns>
        private long Solve()
        {
            long sqNumSum = 0, sum = 0, sum2, res;
            for (int i = 1; i <= this.Number; i++)
            {
                sqNumSum += i * i;
                sum += i;
            }
            sum2 = sum * sum;
            res = sum2 - sqNumSum;
            return res;
        }
        /// <summary>
        /// Print the result
        /// </summary>
        /// <returns>The result</returns>
        public override string ToString()
        {
            return String.Format("The difference between the sum of the squares of the first {0} natural numbers and the square of the sum is {1}", this.Number, this.Result);
        }
    }
}
