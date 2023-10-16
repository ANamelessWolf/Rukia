using Nameless.Libraries.Rukia.ProjectEuler.Utility;
using Nameless.Libraries.Yggdrasil.Frau.NET;
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
    /// By replacing the 1st digit of the 2-digit number *3, it turns out that six of the nine possible values: 13, 23, 43, 53, 73, and 83, are all prime.
    /// By replacing the 3rd and 4th digits of 56**3 with the same digit, this 5-digit number is the first example having seven primes among the ten generated numbers, 
    /// yielding the family: 56003, 56113, 56333, 56443, 56663, 56773, and 56993. Consequently 56003, being the first member of this family, is the smallest prime with this property.
    /// Find the smallest prime which, by replacing part of the number (not necessarily adjacent digits) with the same digit, is part of an eight prime value family.
    /// </summary>
    public class PrimeDigitReplacement : ISolution<long>
    {
        const String PRIME_PATH = @"..\..\Assets\Primes\";
        const String PRIME_FILE = "50000000.txt";
        PrimeFileReader pReader;
        IEnumerable<String> FamilyPermutations;
        long[] Primes;
        long Limit;
        /// <summary>
        /// Creates a new problem
        /// </summary>
        public PrimeDigitReplacement(long familySize = 8)
        {
            this.Limit = familySize;
            pReader = new PrimeFileReader(new FileInfo(Path.Combine(PRIME_PATH, PRIME_FILE)), new long[] { 100000, 1000000 });
            Permutation p = new Permutation("YYYXXX"); //La combinación de permutaciones
            FamilyPermutations = p.Permutations.Distinct().OrderBy<String, String>(x => x);
            Primes = pReader.SmallerThan(1000000).Where(x => x > 100000).ToArray();
        }
        public long Result
        {
            get { return Solve(); }
        }

        public long Solve()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            //El indice del primo a probar
            int pIndex = 0,
                famCount = 0;
            //Los indices de los digitos a reemplazar
            int[] digitIndex;
            long prime;
            long[] primeDigRepl = new long[0];
            do
            {
                prime = Primes[pIndex];
                //Console.Clear();
                //Console.WriteLine(prime);
                foreach (String p in FamilyPermutations)
                {
                    digitIndex = IndexOf(p, 'X');
                    primeDigRepl = PrimeDigitals(prime, digitIndex);
                    if (primeDigRepl.Length < this.Limit)
                        continue;
                    else
                    {
                        famCount = primeDigRepl.Length;
                        break;
                    }
                }
                pIndex++;
                //Omite un loop infinito
                if (pIndex == Primes.Length)
                    break;
            } while (famCount != this.Limit);
            sw.Stop();
            Console.WriteLine("Elapsed: {0}s, {1}ms", sw.Elapsed.Seconds, sw.Elapsed.Milliseconds);
            return primeDigRepl.OrderBy<long, long>(x => x).First();
        }

        private int[] IndexOf(String s, char c)
        {
            List<int> indexes = new List<int>();
            int index = 0;
            foreach (Char ch in s)
            {
                if (ch == c)
                    indexes.Add(index);
                index++;
            }
            return indexes.ToArray();
        }

        Char[] Digits = new Char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        private long[] PrimeDigitals(long testPrime, int[] digitIndex)
        {
            Char[] testPrimeStr = testPrime.ToString().ToCharArray();
            int size = testPrimeStr.Length;
            long[] primes = new long[Digits.Length];

            for (int i = 0; i < Digits.Length; i++)
            {
                for (int j = 0; j < digitIndex.Length; j++)
                    testPrimeStr[digitIndex[j]] = Digits[i];
                primes[i] = long.Parse(new String(testPrimeStr));
            }
            return primes.Where(x => x.ToString().Length == size && pReader.IsPrime(x)).ToArray();
        }

        public override string ToString()
        {
            return String.Format("The smallest prime which, by replacing part of the number (not necessarily adjacent digits) with the same digit, is part of an eight prime value family is {0}.", this.Solve());
        }
    }
}
