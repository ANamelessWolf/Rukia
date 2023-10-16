using Nameless.Libraries.Rukia.ProjectEuler.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler
{
    /// <summary>
    /// Power digit sum
    /// 215 = 32768 and the sum of its digits is 3 + 2 + 7 + 6 + 8 = 26.
    /// What is the sum of the digits of the number 2^1000?
    /// </summary>
    public class PowerDigitSum
    {
        /// <summary>
        /// The number to elevate
        /// </summary>
        public long Number;
        /// <summary>
        /// The base power
        /// </summary>
        public long BaseNumber;
        /// <summary>
        /// The result
        /// </summary>
        public long Result { get { return Solve(); } }
        /// <summary>
        /// Elevates a number to a given power
        /// </summary>
        /// <param name="number">The number to calculate te facotrial</param>
        public PowerDigitSum(long number = 2, long baseNumer = 1000)
        {
            this.Number = number;
            this.BaseNumber = baseNumer;
        }
        /// <summary>
        /// Solve the problem
        /// </summary>
        /// <returns>The sum result</returns>
        private long Solve()
        {
            BigNumber num = BigOperation.Pow(this.Number, this.BaseNumber);
            long sum = 0;
            foreach (Char ch in num.ToString())
                sum += long.Parse(ch.ToString());
            return sum;
        }
        /// <summary>
        /// Print the result
        /// </summary>
        /// <returns>The result</returns>
        public override string ToString()
        {
            return String.Format("The sum of the digits of the number {0}^{1} is {2}", this.Number, this.BaseNumber, this.Result);
        }
    }

}
