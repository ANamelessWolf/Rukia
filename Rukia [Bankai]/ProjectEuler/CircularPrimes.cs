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
    /// The number, 197, is called a circular prime because all rotations of the digits: 197, 971, and 719, are themselves prime.
    /// There are thirteen such primes below 100: 2, 3, 5, 7, 11, 13, 17, 31, 37, 71, 73, 79, and 97.
    /// How many circular primes are there below one million?
    /// </summary>
    public class CircularPrimes : ISolution<int>
    {
        const int BLOCK_SIZE = 100;
        const int LIMIT = 1000000;
        Dictionary<long, List<long>> Primes;
        List<long> CPrimes;
        List<long> PrimeList;
        public CircularPrimes()
        {
            Primes = new Dictionary<long, List<long>>();
            long primeCount;
            PrimeGenerator pg = new PrimeGenerator(LIMIT, out primeCount);
            PrimeList = pg.Primes;
            Primes = pg.CreateBlocks(LIMIT,BLOCK_SIZE);
        }

        public int Result
        {
            get { return Solve(); }
        }

        public int Solve()
        {
            List<long> ignore = new List<long>();
            List<long> permResult = new List<long>();
            long Vector = LIMIT / BLOCK_SIZE, block = 1, num, key, subKey;
            Boolean IsCircular = false;
            CPrimes = new List<long>();
            String[] rotatePrimes;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < PrimeList.Count; i++)
            {
                if (PrimeList[i] > block * Vector)
                    block++;
                key = block * Vector;

                if (ignore.Contains((long)PrimeList[i]))
                    continue;
                else if (Primes[key].Contains(PrimeList[i]))
                {
                    if (PrimeList[i].ToString().Length == 1)
                        this.CPrimes.Add(PrimeList[i]);
                    else
                    {
                        rotatePrimes = PrimeList[i].ToString().ToCircleNumber();
                        IsCircular = true;
                        permResult.Clear();
                        foreach (string n in rotatePrimes)
                        {
                            num = long.Parse(n);
                            subKey = ((long)(num / Vector) + 1) * Vector;
                            if (num.ToString().Length == PrimeList[i].ToString().Length)
                            {
                                if (num % 2 == 0)
                                    IsCircular = false;
                                if (Primes[subKey].Contains(num))
                                {
                                    if (num > PrimeList[i] && !ignore.Contains(num))
                                        ignore.Add(num);
                                    if (!permResult.Contains(num))
                                        permResult.Add(num);
                                }
                                else
                                    IsCircular = false;
                            }
                            else
                                IsCircular = false;
                        }
                        if (IsCircular)
                            foreach (long cPrime in permResult)
                            {
                             //   Console.WriteLine(cPrime);
                                CPrimes.Add(cPrime);
                            }
                    }
                }
            }
            sw.Stop();
            Console.WriteLine("Elapsed: {0}s, {1}ms", sw.Elapsed.Seconds, sw.Elapsed.Milliseconds);
            return CPrimes.Count;
        }



        /// <summary>
        /// Print the result
        /// </summary>
        /// <returns>The result</returns>
        public override string ToString()
        {
            return String.Format("There are {0} circular primes below one million", this.Result);
        }



    }
}
