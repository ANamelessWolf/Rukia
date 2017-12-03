using Nameless.Libraries.Rukia.ProjectEuler.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler
{
    /// <summary>
    /// Largest prime factor
    /// The prime factors of 13195 are 5, 7, 13 and 29.
    /// What is the largest prime factor of the number 600851475143 ?
    /// </summary>
    public class LargestPrimeFactor
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
        public LargestPrimeFactor(long number = 600851475143)
        {
            this.Number = number;
        }
        /// <summary>
        /// Solve the problem
        /// </summary>
        /// <returns>The sum result</returns>
        private long Solve()
        {
            PrimeFactorNode fN = new PrimeFactorNode(this.Number);
            return fN.MaxPrime;
        }
        /// <summary>
        /// Print the result
        /// </summary>
        /// <returns>The result</returns>
        public override string ToString()
        {
            return String.Format("The largest prime factor of the number {0} is {1}", this.Number, this.Result);
        }
    }
}
