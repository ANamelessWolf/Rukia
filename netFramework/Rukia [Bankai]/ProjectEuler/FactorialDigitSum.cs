using Nameless.Libraries.Rukia.ProjectEuler.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler
{
    /// <summary>
    /// n! means n × (n − 1) × ... × 3 × 2 × 1
    /// For example, 10! = 10 × 9 × ... × 3 × 2 × 1 = 3628800,
    /// and the sum of the digits in the number 10! is 3 + 6 + 2 + 8 + 8 + 0 + 0 = 27.
    /// Find the sum of the digits in the number 100!
    /// </summary>
    public class FactorialDigitSum
    {
        /// <summary>
        /// The number to calculate the factorial
        /// </summary>
        public long Number;
        /// <summary>
        /// The factorial result
        /// </summary>
        public long Result { get { return Solve(); } }
        /// <summary>
        /// Get the largest prime factor for the given number
        /// </summary>
        /// <param name="number">The number to extract it prime factor</param>
        public FactorialDigitSum(long number = 100)
        {
            this.Number = number;
        }
        /// <summary>
        /// Solve the problem
        /// </summary>
        /// <returns>The sum result</returns>
        private long Solve()
        {
            BigNumber pG = BigOperation.Factorial(this.Number);
            int sum=0;
            foreach (char d in pG.ToString().ToCharArray())
                sum += int.Parse(d.ToString());
            return sum;
        }

        /// <summary>
        /// Print the result
        /// </summary>
        /// <returns>The result</returns>
        public override string ToString()
        {
            return String.Format("The sum of of the digits in the number {0}! is {1}", this.Number, this.Result);
        }
    }
}
