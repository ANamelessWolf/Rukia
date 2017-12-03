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
    /// The first two consecutive numbers to have two distinct prime factors are:
    /// 14 = 2 × 7
    /// 15 = 3 × 5
    /// The first three consecutive numbers to have three distinct prime factors are:
    /// 644 = 2² × 7 × 23
    /// 645 = 3 × 5 × 43
    /// 646 = 2 × 17 × 19.
    /// Find the first four consecutive integers to have four distinct prime factors. What is the first of these numbers?
    /// </summary>
    public class DistinctPrimesFactors : ISolution<long>
    {
        public KeyValuePair<long, int>[] ConsecNumbers;
        PrimeFileReader pReader;
        public int Size;
        const String PRIME_PATH = @"..\..\Assets\Primes\";
        const String PRIME_FILE = "50000000.txt";
        public Boolean HasSameConsecutives
        {
            get
            {
                Boolean flag = true;
                foreach (Boolean countFlag in ConsecNumbers.Select<KeyValuePair<long, int>, Boolean>(X => X.Value == this.Size))
                    flag = flag && countFlag;
                return flag;
            }
        }
        /// <summary>
        /// Creates a new problem
        /// </summary>
        /// <param name="consecSize">The size of consec numbers</param>
        public DistinctPrimesFactors(int consecSize = 4)
        {
            ConsecNumbers = new KeyValuePair<long, int>[consecSize];
            this.Size = consecSize;
            FactorFinder f;
            pReader = new PrimeFileReader(new FileInfo(Path.Combine(PRIME_PATH, PRIME_FILE)), new long[] { 0, 10000000 });
            for (int i = 0; i < consecSize; i++)
            {

                f = new FactorFinder(i + 1);
                f.FindPrimes(pReader.SmallerThan(i + 2));
                ConsecNumbers[i] = new KeyValuePair<long, int>(i + 1, f.Primes.Keys.Count);

            }
        }

        /// <summary>
        /// return the problem result
        /// </summary>
        public long Result
        {
            get { return Solve(); }
        }
        /// <summary>
        /// Solves the problem
        /// </summary>
        /// <returns></returns>
        public long Solve()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            long num = ConsecNumbers[this.Size - 1].Key;
            FactorFinder f;
            while (!HasSameConsecutives)
            {
                try
                {
                    num++;
                  //  Console.WriteLine(num);
                    f = new FactorFinder(num);
                    f.FindPrimes(pReader.SmallerThan(num+1));
                    MoveArray(num, f.Primes.Keys.Count);
                }
                catch (Exception)
                {


                }
            }
            sw.Stop();
            Console.WriteLine("Elapsed: {0}s, {1}ms", sw.Elapsed.Seconds, sw.Elapsed.Milliseconds);
            return ConsecNumbers[0].Key;
        }
        /// <summary>
        /// Move the consecutive array
        /// </summary>
        /// <param name="num">The number to move</param>
        /// <param name="size">The size of the array</param>
        private void MoveArray(long num, int size)
        {
            for (int i = 0; i < ConsecNumbers.Length - 1; i++)
                ConsecNumbers[i] = ConsecNumbers[i + 1];
            ConsecNumbers[this.Size - 1] = new KeyValuePair<long, int>(num, size);
        }

        /// <summary>
        /// Print the result
        /// </summary>
        /// <returns>The result</returns>
        public override string ToString()
        {
            StringBuilder digits = new StringBuilder();
            long res = this.Result;
            for (int i = 0; i < ConsecNumbers.Length; i++)
                digits.Append(ConsecNumbers[i].Key + ", ");
            return String.Format("This are the numbers of the consecutive integers ({1}) to have {0} distinct prime factors, The first one is {2}", this.Size, digits.ToString().Substring(0, digits.ToString().Length - 2), res);
        }
    }
}
