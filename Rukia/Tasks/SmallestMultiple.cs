using Nameless.Libraries.Rukia.ProjectEuler.Helper;
using Nameless.Libraries.Rukia.ProjectEuler.Helper.Interface;
using Nameless.Libraries.Rukia.ProjectEuler.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler.Tasks
{
    /// <summary>
    ///2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
    ///What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?
    /// </summary>
    public class SmallestMultiple : ISolution
    {
        /// <summary>
        /// Smallest number
        /// </summary>
        public int Result;
        /// <summary>
        /// Last number range
        /// </summary>
        public int Last;

        public SmallestMultiple(int last)
        {
            Last = last;
            this.Result = Solve();
        }

        public string PrintResult()
        {
            return String.Format("The smallest positive number that is evenly divisible by all of the numbers from 1 to {0} is {1}", this.Last, this.Result);
        }

        public int Solve()
        {
            MathHelper math = new MathHelper();
            Dictionary<int, int> primeFactorFreq = GetPrimeFactors(Last);
            int result = 1;
            foreach (int prime in primeFactorFreq.Keys)
                result *= math.Power(prime, primeFactorFreq[prime]);
            return result;
        }

        /// <summary>
        /// Calculates the prime factors with the ocurrence
        /// frequency
        /// </summary>
        /// <param name="number">The table to calculate</param>
        private Dictionary<int, int> GetPrimeFactors(int number)
        {
            //1: Create prime frequency table
            Dictionary<int, int> primes = new Dictionary<int, int>();
            PrimeTester tester = new PrimeTester();
            //2: Get the prime factors
            for (int i = 2; i <= number; i++)
            {
                if (tester.IsPrime(i))
                    primes.Add(i, 1);
                else
                    //3: Update prime frequency
                    UpdatePrimeFrequency(ref primes, i);
            }
            return primes;
        }


        private void UpdatePrimeFrequency(ref Dictionary<int, int> primes, int number)
        {
            Dictionary<int, int> factors = new Dictionary<int, int>();
            int[] primeKeys = primes.Keys.ToArray();
            for (int j = 0; j < primeKeys.Length && number > 1; j++)
            {
                int prime = primeKeys[j];
                while (number % prime == 0)
                {
                    if (factors.ContainsKey(prime))
                        factors[prime]++;
                    else
                        factors.Add(prime, 1);
                    number /= prime;
                    if (primes[prime] < factors[prime])
                        primes[prime] = factors[prime];
                }
            }
        }

    }
}
