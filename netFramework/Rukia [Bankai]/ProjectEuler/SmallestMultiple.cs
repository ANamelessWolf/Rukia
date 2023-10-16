using Nameless.Libraries.Rukia.ProjectEuler.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler
{
    /// <summary>
    ///2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
    ///What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?
    /// </summary>
    public class SmallestMultiple
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
        public SmallestMultiple(long number = 20)
        {
            this.Number = number;
        }
        /// <summary>
        /// Solve the problem
        /// </summary>
        /// <returns>The sum result</returns>
        private long Solve()
        {
            PrimeFactorNode n;
            long res = 1;
            int count;
            List<long> factors;
            Dictionary<long, int> factorCount = new Dictionary<long, int>();
            for (long i = this.Number; i >= 2; i--)
            {
                factors = new List<long>();
                n = new PrimeFactorNode(i, 2);
                n.GetFactors(ref factors);
                foreach (long f in factors)
                {
                    count = factors.Count(x => x == f);
                    if (factorCount.ContainsKey(f) && factorCount[f] < count)
                        factorCount[f] = count;
                    else if (!factorCount.ContainsKey(f))
                        factorCount.Add(f, count);
                }
            }
            foreach (long prime in factorCount.Keys)
                res *= (long)Math.Pow(prime, factorCount[prime]);
            return res;


        }
        /// <summary>
        /// Print the result
        /// </summary>
        /// <returns>The result</returns>
        public override string ToString()
        {
            return String.Format("The smallest positive number that is evenly divisible by all of the numbers from 1 to {0} is {1}", this.Number, this.Result);
        }
    }
}
