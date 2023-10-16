using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler.Utility
{
    /// <summary>
    /// Christian Goldbach propose that every odd composite number can be written as the sum of a prime and twice a square.
    /// This is false
    /// </summary>
    public class GoldbachConjecture
    {
        /// <summary>
        /// The collection of primes smaller the odd number
        /// </summary>
        long[] Numbers;
        /// <summary>
        /// The collection of primes smaller the odd number
        /// </summary>
        long[] Primes;
        /// <summary>
        /// True if the conjecture is valid
        /// </summary>
        public Boolean IsValid;
        /// <summary>
        /// The OddNumber
        /// </summary>
        public long OddNumber;
        /// <summary>
        /// The prime sumand
        /// </summary>
        public long PrimeSum;
        /// <summary>
        /// The Square double
        /// </summary>
        public long SquareDouble;
        /// <summary>
        /// Creates a Goldbach conjecture
        /// </summary>
        /// <param name="number">The odd number to be tested</param>
        /// <param name="nums">The list of primes to test the number</param>
        public GoldbachConjecture(long number, long[] primes)
        {
            this.OddNumber = number;
            this.Numbers = Enumerable.Range(1, (int)number / 2).Select<int, long>(x => (long)x).ToArray();
            this.Primes = primes;
            this.Solve();
        }
        /// <summary>
        /// Solve the conjecture
        /// </summary>
        public void Solve()
        {
            for (int i = 0; i < Numbers.Length; i++)
            {
                SquareDouble = 2 * this.Numbers[i] * this.Numbers[i];
                PrimeSum = this.OddNumber - SquareDouble;
                if (this.Primes.Contains(PrimeSum))
                {
                    SquareDouble = this.Numbers[i];
                    this.IsValid = true;
                    break;
                }
            }
        }
        /// <summary>
        /// Prints the goldbach conjecture
        /// </summary>
        /// <returns>The Goldbach string coneture</returns>
        public override string ToString()
        {
            if (IsValid)
                return String.Format("{0} = {1} + 2x{2}²", this.OddNumber, this.PrimeSum, this.SquareDouble);
            else
                return String.Format("Goldbach Conjecture Error: {0}", this.OddNumber);
        }
    }
}
