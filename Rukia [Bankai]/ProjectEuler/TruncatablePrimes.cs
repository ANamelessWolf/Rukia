using Nameless.Libraries.Rukia.ProjectEuler.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler
{
    /// <summary>
    /// The number 3797 has an interesting property. Being prime itself, it is possible to continuously remove digits from left to right, 
    /// and remain prime at each stage: 3797, 797, 97, and 7. 
    /// Similarly we can work from right to left: 3797, 379, 37, and 3.
    /// Find the sum of the only eleven primes that are both truncatable from left to right and right to left.
    /// NOTE: 2, 3, 5, and 7 are not considered to be truncatable primes.
    /// </summary>
    public class TruncatablePrimes : ISolution<long>
    {
        const int BLOCK_SIZE = 1000;
        const int LIMIT = 1000000;

        List<long> TruncablePrimes;
        PrimeGenerator pg;
        /// <summary>
        /// Return the truncable solution
        /// </summary>
        public long Result
        {
            get { return Solve(); }
        }
        /// <summary>
        /// Solve the Prime solution
        /// </summary>
        /// <returns></returns>
        public long Solve()
        {
            long count, num, total = 0;
            int index = 0;
            pg = new PrimeGenerator(LIMIT, out count);
            TruncablePrimes = new List<long>();
            Dictionary<long, List<long>> primes = pg.CreateBlocks(LIMIT, BLOCK_SIZE);
            num = pg.Primes[index];
            while (total != 11)
            {
                if (num > 10)
                {
                    if (TruncRight(num, primes) && TruncLeft(num, primes))
                    {
                        total++;
                        this.TruncablePrimes.Add(num);
                        Console.WriteLine(String.Format("Index: {0}, Num{1}", total, num));
                    }
                }
                index++;
                num = pg.Primes[index];
            }
            return this.TruncablePrimes.Sum();
        }

        private bool TruncRight(long num, Dictionary<long, List<long>> primes)
        {
            Boolean flag = true;
            List<long> nums = new List<long>();
            String nStr = num.ToString();
            for (int i = 1; i < nStr.Length; i++)
                nums.Add(int.Parse(nStr.Substring(i)));
            long subKey;
            foreach (long number in nums)
            {
                subKey = pg.GetKey(number, LIMIT, BLOCK_SIZE);
                if (!primes[subKey].Contains(number))
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }

        private bool TruncLeft(long num, Dictionary<long, List<long>> primes)
        {
            Boolean flag = true;
            List<long> nums = new List<long>();
            String nStr = num.ToString();
            for (int i = 1; i < nStr.Length; i++)
                nums.Add(int.Parse(nStr.Substring(0, i)));
            long subKey;
            foreach (long number in nums)
            {
                subKey = pg.GetKey(number, LIMIT, BLOCK_SIZE);
                if (!primes[subKey].Contains(number))
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }
        /// <summary>
        /// Print the result
        /// </summary>
        /// <returns>The result</returns>
        public override string ToString()
        {
            return String.Format("The sum of the only eleven primes that are both truncatable from left to right and right to left is {0}", this.Result);
        }
    }
}
