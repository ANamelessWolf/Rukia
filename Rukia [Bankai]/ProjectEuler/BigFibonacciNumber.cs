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
    /// The Fibonacci sequence is defined by the recurrence relation:
    /// Fn = Fn−1 + Fn−2, where F1 = 1 and F2 = 1.
    /// Hence the first 12 terms will be:
    /// F1 = 1
    /// F2 = 1
    /// F3 = 2
    /// F4 = 3
    /// F5 = 5
    /// F6 = 8
    /// F7 = 13
    /// F8 = 21
    /// F9 = 34
    /// F10 = 55
    /// F11 = 89
    /// F12 = 144
    /// The 12th term, F12, is the first term to contain three digits.
    /// What is the first term in the Fibonacci sequence to contain 1000 digits?
    /// </summary>
    public class BigFibonacciNumber
    {
        /// <summary>
        /// The number digit size Limit
        /// </summary>
        public int DigitLimitSize;
        /// <summary>
        /// Big Number
        /// </summary>
        public long Term;
        /// <summary>
        /// The multple sum result
        /// </summary>
        public long Result { get { return Solve(); } }
        /// <summary>
        /// Generate the fibonnaci sequence until the term size is equal to limit
        /// of the digit size
        /// </summary>
        /// <param name="SuperiorLimit">The terms had to be below this limit</param>
        public BigFibonacciNumber(int digitLimit = 1000)
        {
            this.DigitLimitSize = digitLimit;
        }
        /// <summary>
        /// Solve the problem
        /// </summary>
        /// <returns>The sum result</returns>
        private long Solve()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            BigNumber currentTerm = new BigNumber(10),
                      nextTerm = new BigNumber(10);
            String tmp;
            currentTerm.Digits.Add(1);
            nextTerm.Digits.Add(1);
            Term = 1;
            while (currentTerm.ToString().Length < this.DigitLimitSize)
            {
                tmp = nextTerm.ToString();
                nextTerm = nextTerm + currentTerm;
                currentTerm = BigNumber.Parse(tmp);
                Term++;
            }
            sw.Stop();
            Console.WriteLine("Elapsed: {0}s, {1}ms", sw.Elapsed.Seconds, sw.Elapsed.Milliseconds);
            return Term;
        }
        /// <summary>
        /// Print the result
        /// </summary>
        /// <returns>The result</returns>
        public override string ToString()
        {
            return String.Format("the first term in the Fibonacci sequence to contain {0} digits is {1}", this.DigitLimitSize, this.Result);
        }

    }
}
