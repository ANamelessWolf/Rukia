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
    /// It was proposed by Christian Goldbach that every odd composite number can be written as the sum of a prime and twice a square.
    /// 9 = 7 + 2×12
    /// 15 = 7 + 2×22
    /// 21 = 3 + 2×32
    /// 25 = 7 + 2×32
    /// 27 = 19 + 2×22
    /// 33 = 31 + 2×12
    /// It turns out that the conjecture was false.
    /// What is the smallest odd composite that cannot be written as the sum of a prime and twice a square?
    /// </summary>
    public class GoldbachError : ISolution<long>
    {
        PrimeFileReader pReader;
        const String PRIME_PATH = @"..\..\Assets\Primes\";
        const String PRIME_FILE = "50000000.txt";
        /// <summary>
        /// Find the Goldbach error
        /// </summary>
        public GoldbachError()
        {
            pReader = new PrimeFileReader(new FileInfo(Path.Combine(PRIME_PATH, PRIME_FILE)), new long[] { 0, 10000000 });
        }
        /// <summary>
        /// Return the gold bach result
        /// </summary>
        public long Result
        {
            get { return Solve(); }
        }
        /// <summary>
        /// Solves the problem
        /// </summary>
        /// <returns>The solution result</returns>
        public long Solve()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            long num = 9;
            GoldbachConjecture gC = new GoldbachConjecture(num,pReader.SmallerThan(num));
            while (gC.IsValid)
            {
                num += 2;
                if (!pReader.IsPrime(num))
                    gC = new GoldbachConjecture(num, pReader.SmallerThan(num));
            }
            sw.Stop();
            Console.WriteLine("Elapsed: {0}s, {1}ms", sw.Elapsed.Seconds, sw.Elapsed.Milliseconds);
            return gC.OddNumber;
        }

        /// <summary>
        /// Print the result
        /// </summary>
        /// <returns>The result</returns>
        public override string ToString()
        {
            return String.Format("The smallest odd composite that cannot be written as the sum of a prime and twice a square is {0}", this.Result);
        }

    }
}
