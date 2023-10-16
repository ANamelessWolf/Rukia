using Nameless.Libraries.Rukia.ProjectEuler.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler
{
    /// <summary>
    /// The prime 41, can be written as the sum of six consecutive primes:
    /// 41 = 2 + 3 + 5 + 7 + 11 + 13
    /// This is the longest sum of consecutive primes that adds to a prime below one-hundred.
    /// The longest sum of consecutive primes below one-thousand that adds to a prime, contains 21 terms, and is equal to 953.
    /// Which prime, below one-million, can be written as the sum of the most consecutive primes?
    /// </summary>
    public class ConsecutivePrimes : ISolution<long>
    {
        const String PRIME_PATH = @"..\..\Assets\Primes\";
        const String PRIME_FILE = "50000000.txt";
        PrimeFileReader pReader;
        long[] Primes;
        public long Limit;
        public ConsecutivePrimes(long limit = 1000000)
        {
            this.Limit = limit;
            pReader = new PrimeFileReader(new FileInfo(Path.Combine(PRIME_PATH, PRIME_FILE)), new long[] { 0, limit });
        }

        public long Result
        {
            get { return this.Solve(); }
        }

        public long Solve()
        {
            long sum = 0;
            long maxPrime = 0;
            Primes = pReader.SmallerThan(this.Limit);
            int index = 3, lastCount, count=0;

            for (int i = 0; i < 5; i++)
            {
                index = i;
                count = 0;
                sum = 0;
                while (sum < this.Limit)
                {
                    count++;
                    sum += Primes[index];
                    if (sum < this.Limit && pReader.IsPrime(sum) && sum > maxPrime)
                    {
                        maxPrime = sum;
                        lastCount = count;
                    }
                    index++;
     
                }
            }
            return maxPrime;
        }
        public override string ToString()
        {
            return String.Format("The prime, below one-million that can be written as the sum of the most consecutive primes is {0}", this.Solve());
        }
    }
}
