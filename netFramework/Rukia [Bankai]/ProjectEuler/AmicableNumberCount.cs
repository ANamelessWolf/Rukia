using Nameless.Libraries.Rukia.ProjectEuler.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler
{
    /// <summary>
    /// Let d(n) be defined as the sum of proper divisors of n (numbers less than n which divide evenly into n).
    /// If d(a) = b and d(b) = a, where a ≠ b, then a and b are an amicable pair and each of a and b are called amicable numbers.
    /// For example, the proper divisors of 220 are 1, 2, 4, 5, 10, 11, 20, 22, 44, 55 and 110; therefore d(220) = 284. The proper divisors of 284 are 1, 2, 4, 71 and 142; so d(284) = 220.
    /// Evaluate the sum of all the amicable numbers under 10000.
    /// </summary>
    public class AmicableNumberCount
    {
        public List<long> Amicables, NotAmicables;
        /// <summary>
        /// The number Limit
        /// </summary>
        public long Limit;
        /// <summary>
        /// The factorial result
        /// </summary>
        public long Result { get { return Solve(); } }
        /// <summary>
        /// Get the largest prime factor for the given number
        /// </summary>
        /// <param name="number">The number to extract it prime factor</param>
        public AmicableNumberCount(long limit = 10000)
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
            this.Amicables = new List<long>();
            this.NotAmicables = new List<long>();
            AmicableNumber num;
            for (int i = 2; i <= this.Limit; i++)
            {
                if (!this.Amicables.Contains(i) && !this.NotAmicables.Contains(i))
                {
                    num = new AmicableNumber(i);
                    if (num.IsAmicable)
                    {
                            this.Amicables.Add(num.Number);
                            this.Amicables.Add(num.Amicable);
                    }
                    else
                    {
                        if (!this.NotAmicables.Contains(num.Number))
                            this.NotAmicables.Add(num.Number);
                        if (!this.NotAmicables.Contains(num.Amicable))
                            this.NotAmicables.Add(num.Amicable);
                    }
                }
                sum = this.Amicables.Sum<long>(x => x);
            }
            return sum;
        }

        /// <summary>
        /// Print the result
        /// </summary>
        /// <returns>The result</returns>
        public override string ToString()
        {
            return String.Format("the sum of all the amicable numbers under {0} is {1}", this.Limit, this.Result);
        }
    }
}
