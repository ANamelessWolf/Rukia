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
    /// Surprisingly there are only three numbers that can be written as the sum of fourth powers of their digits:
    /// 1634 = 14 + 64 + 34 + 44
    /// 8208 = 84 + 24 + 04 + 84
    /// 9474 = 94 + 44 + 74 + 44
    /// As 1 = 14 is not a sum it is not included.
    /// The sum of these numbers is 1634 + 8208 + 9474 = 19316.
    /// Find the sum of all the numbers that can be written as the sum of fifth powers of their digits.
    /// </summary>
    public class DigitPowers
    {
        /// <summary>
        /// The digitable power number
        /// </summary>
        public List<long> DigitablePowers;
        /// <summary>
        /// The number Limit
        /// </summary>
        public int Limit;
        /// <summary>
        /// The number Limit
        /// </summary>
        public int Power;
        /// <summary>
        /// The result
        /// </summary>
        public long Result { get { return Solve(); } }
        /// <summary>
        /// Get the sum of all spiral members
        /// </summary>
        /// <param name="limit">The matrix spiral order</param>
        public DigitPowers(int power = 5, int limit = 295245)
        {
            this.Limit = limit;
            this.Power = power;
        }
        /// <summary>
        /// Solve the problem
        /// </summary>
        /// <returns>The sum result</returns>
        private long Solve()
        {
            this.DigitablePowers = new List<long>();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            DigitPower dPow;
            for (int i = 2; i <= this.Limit; i++)
            {
                dPow = new DigitPower(i, this.Power);
                if (dPow.IsDigitablePower)
                {
                    this.DigitablePowers.Add(dPow.Number);
                    Console.WriteLine(dPow);
                }
            }
            sw.Stop();
            Console.WriteLine("Elapsed: {0}s, {1}ms", sw.Elapsed.Seconds, sw.Elapsed.Milliseconds);
            return this.DigitablePowers.Sum();
        }
        /// <summary>
        /// Print the result
        /// </summary>
        /// <returns>The result</returns>
        public override string ToString()
        {
            return  String.Format("The sum of all the numbers that can be written as the sum of {0} powers of their digits is {1}", this.Power, this.Result);
        }
    }
}
