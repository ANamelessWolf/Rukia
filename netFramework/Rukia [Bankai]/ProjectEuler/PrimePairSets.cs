using Nameless.Libraries.Rukia.ProjectEuler.Utility;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler
{
    /// <summary>
    /// The primes 3, 7, 109, and 673, are quite remarkable. 
    /// By taking any two primes and concatenating them in any order the result will always be prime. 
    /// For example, taking 7 and 109, both 7109 and 1097 are prime. 
    /// The sum of these four primes, 792, represents the lowest sum for a set of four primes with this property.
    /// Find the lowest sum for a set of five primes for which any two primes concatenate to produce another prime.
    /// </summary>
    public class PrimePairSets : ISolution<long>
    {
        const String PRIME_PATH = @"..\..\Assets\Primes\";
        const String PRIME_FILE = "50000000.txt";
        const String PRIME_FILE_2 = "100000000.txt";
        long MAX_PRIME = 50000000;
        const long LIMIT = 8500;

        PrimeFileReader pReader1, pReader2;
        public long[] Primes;
        public long[] PrimeSet;

        public long Result
        {
            get { return this.Solve(); }
        }

        public PrimePairSets()
        {
            pReader1 = new PrimeFileReader(new FileInfo(Path.Combine(PRIME_PATH, PRIME_FILE)), new long[] { 0, MAX_PRIME });
            pReader2 = new PrimeFileReader(new FileInfo(Path.Combine(PRIME_PATH, PRIME_FILE_2)), new long[] { MAX_PRIME, MAX_PRIME * 2 });
            Primes = pReader1.SmallerThan(LIMIT);
        }

        private bool ArePairSetsPrimes(long[] FivePrimes)
        {
            List<long> testSet = new List<long>();
            for (int i = 0; i < FivePrimes.Length; i++)
                for (int j = 0; j < FivePrimes.Length; j++)
                {
                    if (i != j)
                        testSet.Add(long.Parse(FivePrimes[i].ToString() + FivePrimes[j].ToString()));
                }
            int cCount = testSet.Count, pCount = testSet.Where(x => pReader1.IsPrime(x)).Count();
            return cCount == pCount;
        }




        public long Solve()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            long[] testPrimes = new long[4];
            for (int a = 0; a < Primes.Length; a++)
                for (int b = a + 1; b < Primes.Length; b++)
                {
                    testPrimes = new long[] { Primes[a], Primes[b] };
                    if (!IsValid(testPrimes))
                        continue;
                    for (int c = b + 1; c < Primes.Length; c++)
                    {
                        testPrimes = new long[] { Primes[a], Primes[b], Primes[c] };
                        if (!IsValid(testPrimes))
                            continue;
                        for (int d = c + 1; d < Primes.Length; d++)
                        {
                            testPrimes = new long[] { Primes[a], Primes[b], Primes[c], Primes[d] };
                            if (!IsValid(testPrimes))
                                continue;
                            for (int e = d + 1; e < Primes.Length; e++)
                            {
                                //GoodIndexes
                                //a = 5; b = 691; c = 750; d = 867; e = 1050;
                                testPrimes = GetFivePrimes(a, b, c, d, e);
                                Console.WriteLine(String.Format("A: {0} B: {1} C: {2} D: {3} E: {4}", testPrimes[0], testPrimes[1], testPrimes[2], testPrimes[3], testPrimes[4]));
                                if (IsValid(testPrimes))
                                {
                                    Console.Clear();
                                    Console.WriteLine(String.Format("A: {0} B: {1} C: {2} D: {3} E: {4}", testPrimes[0], testPrimes[1], testPrimes[2], testPrimes[3], testPrimes[4]));
                                    sw.Stop();
                                    Console.WriteLine("Elapsed: {0}s, {1}ms", sw.Elapsed.Seconds, sw.Elapsed.Milliseconds);
                                    return testPrimes.Sum();
                                }
                            }

                        }
                    }
                }
            sw.Stop();
            Console.WriteLine("Elapsed: {2}min {0}s, {1}ms", sw.Elapsed.Seconds, sw.Elapsed.Milliseconds, sw.Elapsed.Minutes);
            return 0;
        }

        private bool IsValid(long[] testPrimes)
        {
            Boolean flag = true;
            long prime;
            for (int a = 0; a < testPrimes.Length; a++)
                for (int b = 0; b < testPrimes.Length; b++)
                {
                    if (a == b)
                        continue;
                    prime = long.Parse(String.Format("{0}{1}", testPrimes[a], testPrimes[b]));
                    if (prime > MAX_PRIME)
                        flag = flag && this.pReader2.IsPrime(prime);
                    else
                        flag = flag && this.pReader1.IsPrime(prime);

                    if (!flag)
                        return false;
                }
            return flag;
        }

        private long[] GetFivePrimes(int a, int b, int c, int d, int e)
        {
            return new long[] { Primes[a], Primes[b], Primes[c], Primes[d], Primes[e] };
        }

        private long[] TestFourPrimes(ref int a, ref  int b, ref  int c, ref  int d)
        {

            d++;
            if (d == Primes.Length)
            {
                c++;
                d = c + 1;
            }
            if (c == Primes.Length)
            {
                b++;
                c = b + 1;
                d = c + 1;
            }
            if (b == Primes.Length)
            {
                a++;
                b = a + 1;
                c = b + 1;
                d = c + 1;
            }
            return new long[] { Primes[a], Primes[b], Primes[c], Primes[d] };
        }


        public override string ToString()
        {
            return String.Format("The lowest sum for a set of five primes for which any two primes concatenate to produce another prime is {0}.", this.Solve());
        }
    }
}
