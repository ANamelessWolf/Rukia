using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler.Utility
{
    /// <summary>
    /// Starting with 1 and spiralling anticlockwise in the following way, a square spiral with side length 7 is formed.
    /// 37 36 35 34 33 32 31
    /// 38 17 16 15 14 13 30
    /// 39 18  5  4  3 12 29
    /// 40 19  6  1  2 11 28
    /// 41 20  7  8  9 10 27
    /// 42 21 22 23 24 25 26
    /// 43 44 45 46 47 48 49
    /// It is interesting to note that the odd squares lie along the bottom right diagonal, but what is more interesting is that 8 out of the 13 numbers lying along both diagonals are prime; that is, a ratio of 8/13 ≈ 62%.
    /// If one complete new layer is wrapped around the spiral above, a square spiral with side length 9 will be formed. 
    /// If this process is continued, what is the side length of the square spiral for which the ratio of primes along both diagonals first falls below 10%?
    /// </summary>
    public class SpiralPrimeMatrix : SpiralMatrix
    {
        /// <summary>
        /// The diagonal members of the Spiral Matrix
        /// </summary>
        public List<long> DiagonalMember;
        /// <summary>
        /// The prime diagonal members of the Spiral Matrix
        /// </summary>
        public List<long> PrimeDiagonalMember;
        /// <summary>
        /// Gets the Spiral prime current ratio
        /// </summary>
        public Double PrimeRatio { get { return (double)PrimeDiagonalMember.Count / (double)DiagonalMember.Count; } }
        /// <summary>
        /// Gets the Spiral prime current ratio
        /// </summary>
        public String PrimeRatioPercent { get { return String.Format("{0:P2}", this.PrimeRatio); } }
        const String PRIME_PATH = @"..\..\Assets\Primes\";
        const String PRIME_FILE = "50000000.txt";
        Double Ratio;
        const long SizePrimeDictionary = 50000000;
        long CurrentPrimeDictionary = 50000000;
        public SpiralPrimeMatrix()
        {
            
        }

        PrimeFileReader pReader;
        /// <summary>
        /// Calculates the prime Ratio
        /// </summary>
        public override void MatrixAction()
        {
            this.Ratio = 0.1d;
            pReader = new PrimeFileReader(new FileInfo(Path.Combine(PRIME_PATH, PRIME_FILE)), new long[] { 0, 50000000 });
            DiagonalMember = new List<long>();
            PrimeDiagonalMember = new List<long>();
            long[] dCMembers = new long[4];
            long current = 1;
            do
            {
                this.Level++;
                for (int n = 1; n <= 4; n++)
                {
                    dCMembers[n - 1] = 2 * n * this.Level + current;
                    DiagonalMember.Add(dCMembers[n - 1]);
                }

                foreach (long prime in dCMembers.Where(x => IsPrime(x)))
                    PrimeDiagonalMember.Add(prime);
                current = dCMembers[dCMembers.Length - 1];
                //Console.Clear();
                //Console.WriteLine("Current Ratio: " + this.PrimeRatioPercent);
            } while (PrimeRatio > this.Ratio);
            this.Order = this.Level * 2 + 1;
        }

        private bool IsPrime(long number)
        {
            if (number > CurrentPrimeDictionary)
            {
                String dName = (CurrentPrimeDictionary + SizePrimeDictionary) + ".txt";
                Console.WriteLine(String.Format("Cargando diccionario de primos, \"{0}\"...", dName));
                pReader = new PrimeFileReader(new FileInfo(Path.Combine(PRIME_PATH, dName)), new long[] { CurrentPrimeDictionary, (CurrentPrimeDictionary + SizePrimeDictionary) });
                CurrentPrimeDictionary = CurrentPrimeDictionary + SizePrimeDictionary;
            }
            return pReader.IsPrime(number);
        }


    }
}
